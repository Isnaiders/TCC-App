using TCC_App.Services;
using static System.Runtime.CompilerServices.RuntimeHelpers;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TCC_App;

public partial class MainPage : ContentPage
{
    private readonly IAuthenticationService _authenticationService;
    int count = 0;

    public MainPage(IAuthenticationService authenticationService)
    {
        InitializeComponent();

        _authenticationService = authenticationService;
    }

    private async void btnSubmit_Clicked(object sender, EventArgs e)
    {
        if (txtMobileNumber.Text.Lengh > 0)
        {
            var isValidMobile = await _authenticationService.AuthenticationMobile(txtMobileNumber.Text);
            if (isValidMobile)
            {
                pnlMobileInfo.IsVisible = false;
                pnlMobileVerification.IsVisible = true;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Tente novamente", "Telefone inválido", "OK");
            }
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Tente novamente", "Preencha o Telefone", "OK");
        }
    }

    private async void btnVerifyCode_Clicked(object sender, EventArgs e)
    {
        if (txtCode.Text.Lengh > 0)
        {
            var isValidCode = await _authenticationService.ValidateOTP(txtCode.Text);
            if (isValidCode)
            {
                App.Current.MainPage.Navigation.PushAsync(new Home());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Tente novamente", "Código invalidado", "OK");
            }
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Tente novamente", "Preencha o código", "OK");
        }
    }
}