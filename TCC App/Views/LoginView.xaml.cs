using static TCC_App.ViewModels.LoginViewModel;

namespace TCC_App.Views;

public partial class LoginView : ContentPage
{
    public LoginView()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        MessagingCenter.Subscribe<LoginException>(this, "LoginFailed",
        async (exc) =>
        {
            await DisplayAlert("Login", exc.Message, "Ok");
        });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        MessagingCenter.Unsubscribe<LoginException>(this, "LoginFailed");
    }
}