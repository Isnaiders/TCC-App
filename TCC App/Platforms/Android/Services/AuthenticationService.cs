using Firebase;
using Firebase.Auth;
using TCC_App.Services;

namespace TCC_App.Platforms.Android.Services
{
    public class AuthenticationService : PhoneAuthProvider.OnVerificationStateChangedCallbacks, IAuthenticationService
    {
        private TaskCompletionSource<bool> _verficationCodeCompletionSource;
        private string _verificationId;

        Task<bool> IAuthenticationService.AuthenticationMobile(string mobile)
        {
            _verficationCodeCompletionSource = new TaskCompletionSource<bool>();
            var authOption = PhoneAuthOptions.NewBuilder()
                .SetPhoneNumber(mobile)
                .SetTimeout((Java.Lang.Long)60L, Java.Util.Concurrent.TimeUnit.Seconds)
                .SetActivity(Platform.CurrentActivity)
                .SetCallbacks(this).Build();
            PhoneAuthProvider.VerifyPhoneNumber(authOption);
            return _verficationCodeCompletionSource.Task;
        }

        public override void OnCodeSent(string verificationId, PhoneAuthProvider.ForceResendingToken p1)
        {
            base.OnCodeSent(verificationId, p1);
            _verficationCodeCompletionSource.SetResult(true);
            _verificationId = verificationId;
        }

        public override void OnVerificationCompleted(PhoneAuthCredential p0)
        {
            System.Diagnostics.Debug.WriteLine("Verification completed");
        }

        public override void OnVerificationFailed(FirebaseException p0)
        {
            _verficationCodeCompletionSource.SetResult(false);
        }

        public async Task<bool> ValidateOTP(string code)
        {
            bool returnValue = false;
            if (!string.IsNullOrWhiteSpace(_verificationId))
            {
                var credential = PhoneAuthProvider.GetCredential(_verificationId, code);

                await FirebaseAuth.Instance.SignInWithCredentialAsync(credential).ContinueWith((authTask) =>
                {
                    if (authTask.IsFaulted || authTask.IsCanceled)
                    {
                        returnValue = false;
                        return;
                    }
                    returnValue = true;
                });
            }

            return returnValue;
        }
    }
}