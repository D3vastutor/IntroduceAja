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

        async void BtnLoginCommand(object sender, System.EventArgs e)
        {
            await DisplayAlert("Hallo", "Okay", "No");
        }
    }
}