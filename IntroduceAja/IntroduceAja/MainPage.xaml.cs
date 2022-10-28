using IntroduceAja.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IntroduceAja
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Members> ParaMembers { get; set; } = new ObservableCollection<Members>();

        public MainPage()
        {
            InitializeComponent();
        }

        async void ClosePage(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SummonMembers();

        }

        private async void SummonMembers()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://172.16.28.51:221/Members/Summon");
            var members = JsonConvert.DeserializeObject<List<Members>>(response);
            MemberCollection.ItemsSource = members;
        }
    }
}
