using MediatR;
using Sakura.Core.Communication;
using Sakura.Core.Data;
using Sakura.Core.Messages;
using Sakura.Core.Messages.CommonMessages.Notifications;
using Sakura.Domain.DomainServices;
using Sakura.Domain.Entities;


namespace Sakura.Application.Customers
{
    public class CustomerHandler : IRequestHandler<CreateCustomerCommand, bool>,
                                   IRequestHandler<UpdateCustomerCommand, bool>,
                                   IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly CustomerRepository _customerRepository;
        private readonly CommunicationHandler _communicationHandler;
        public CustomerHandler(UnitOfWork unitOfWork,
        CustomerRepository customerRepository,
        CommunicationHandler communicationHandler)
        {
            _unitOfWork = unitOfWork ?? throw new NullReferenceException(nameof(unitOfWork));
            _customerRepository = customerRepository ?? throw new NullReferenceException(nameof(customerRepository));
            _communicationHandler = communicationHandler ?? throw new NullReferenceException(nameof(communicationHandler));
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _customerRepository.Get(request.CustomerId);

            if (customer == null)
            {
                await _communicationHandler.PublishNotificationAsync(new DomainNotification(request.MessageType, "Customer is not found."));
                return false;
            }

            customer.SetEmail(request.Email);

            _customerRepository.Update(customer);

            return await _unitOfWork.Commit();
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _customerRepository.Get(request.CustomerId);

            if (customer == null)
            {
                await _communicationHandler.PublishNotificationAsync(new DomainNotification(request.MessageType, "Customer is not found."));
                return false;
            }

            _customerRepository.Remove(customer);

            return await _unitOfWork.Commit();
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!IsValid(request)) return false;

            var customer = Customer.Create(email: request.Email);

            _customerRepository.Add(customer);

            return await _unitOfWork.Commit();
        }

        private bool IsValid(Command request)
        {
            if (request.IsValid()) return true;

            foreach (var error in request.ValidationResult.Errors)
            {
                _communicationHandler.PublishNotificationAsync(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}