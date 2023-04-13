using TCC_App.Services;

namespace TCC_App.Platforms.iOS.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private TaskCompletionSource<bool> _verficationCodeCompletionSource;
        private string _verificationId;

        Task<bool> IAuthenticationService.AuthenticationMobile(string mobile)
        {
            throw new NotImplementedException();
        }

        //public override void OnCodeSent(string verificationId, PhoneAuthProvider.ForceResendingToken p1)
        //{
        //    throw new NotImplementedException();
        //}

        //public override void OnVerificationCompleted(PhoneAuthCredential p0)
        //{
        //    throw new NotImplementedException();
        //}

        //public override void OnVerificationFailed(FirebaseException p0)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> ValidateOTP(string code)
        {
            throw new NotImplementedException();
        }
    }
}