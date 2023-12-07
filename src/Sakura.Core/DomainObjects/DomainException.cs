namespace Sakura.Core;

public class DomainException : Exception
{
    private List<string> _errorMessages;
    public IReadOnlyCollection<string> ErrorMessages => _errorMessages;
    private DomainException(string message) : base(message) { }
    private DomainException(List<string> messages) : base()
    {
        _errorMessages = messages;
    }
    public static void When(bool isError, string message)
    {
        if (isError) throw new DomainException(message);
    }
    public static void When(bool isError, List<string> messages)
    {
        if (isError) throw new DomainException(messages);
    }
}
