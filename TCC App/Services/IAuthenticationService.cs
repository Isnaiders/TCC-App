namespace TCC_App.Services
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticationMobile(string mobile);
        Task<bool> ValidateOTP(string code);
    }
}