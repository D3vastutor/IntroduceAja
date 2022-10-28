using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntroduceAja
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void LoginClicked(object sender, EventArgs args)
        {
            await lblJudul.RelRotateTo(360, 1000);
        }

        async void TapRegister(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}