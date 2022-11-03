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

        void LoginClicked(object sender, EventArgs args)
        {
            //lblJudul.RelRotateTo(360, 1000);
            logo.RelRotateTo(360, 1000);
        }

        async void TapRegister(object sender, EventArgs args)
        {
            //string value1 = isiEmail.Text;
            //await   DisplayAlert("VAlue", isiEmail.Text, "Ok");
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}