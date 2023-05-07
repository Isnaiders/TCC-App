using System.Windows.Input;
using TCC_App.Models.User;

namespace TCC_App.ViewModels
{
    public class LoginViewModel
    {
        private string user;
        public string User
        {
            get { return user; }
            set
            {
                user = value;
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                await Login(user, password);
            }, () =>
            {
                return !string.IsNullOrEmpty(user)
                        && !string.IsNullOrEmpty(password);
            });
        }

        private static async Task Login(string user, string password)
        {
            using (var client = new HttpClient())
            {
                var result = new HttpResponseMessage();
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("email", user),
                        new KeyValuePair<string, string>("password", password)
                    });
                client.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                try
                {
                    result = await client.PostAsync("/login", camposFormulario);

                }
                catch (Exception)
                {
                    MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro de comunicação com o servidor.
                    Por favor verifique a sua conexão e tente novamente mais tarde."),
                    "FalhaLogin");
                }
                if (result.IsSuccessStatusCode)
                    MessagingCenter.Send<User>(new User(), "SuccessfulLogin");
                else
                    MessagingCenter.Send<LoginException>(new LoginException("Usuário ou senha incorretos"), "LoginFailed");
            }
        }

        public class LoginException : Exception
        {
            public LoginException(string message) : base(message)
            {
            }
        }
    }
}