using TCC_App.Models.User;
using TCC_App.Views;

namespace TCC_App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new LoginView();
	}

    protected override void OnStart()
    {
        MessagingCenter.Subscribe<User>(this, "SuccessfulLogin",
        (user) =>
        {
            MainPage = new NavigationPage(new Home());
        });
    }
}