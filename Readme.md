
dotnet-ef migrations add --context SakuraDbContext --startup-project ../Sakura.Api/ CreateCustomer

dotnet-ef database update --context SakuraDbContext --startup-project ../Sakura.Api/ 