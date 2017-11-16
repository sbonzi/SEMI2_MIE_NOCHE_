namespace cuadernito.MicroServices.Authentication.Helpers
{
    public interface IAuthenticationHashHelper
    {
        string GenerateCredentialHash(string emailAddress, string password);
    }
}