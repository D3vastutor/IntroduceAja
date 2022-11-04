using IntroduceAja.Models;
using IntroduceAja.Models.Requests;
using IntroduceAja.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntroduceAja
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateDeletePage : ContentPage
    {
        int _idItem;
        public UpdateDeletePage(int idItem)
        {
            InitializeComponent();

            GetDataMemberById(idItem);
        }

        private async void GetDataMemberById(int idItem)
        {
            HttpClient client = new HttpClient();
            string url = $"http://172.16.28.51:221/Members/Call?param={idItem}";
            var response = await client.GetStringAsync(url);
            var member = JsonConvert.DeserializeObject<IdMemberResponse>(response);

            _idItem = idItem;
            UsernameMember.Text = member.Data.UserName;
            SkillMember.Text = member.Data.Skill;
            LevelSkillMember.Text = member.Data.SkillLevel.ToString();

        }

        async void UpdateButton(object sender, EventArgs args)
        {
            Members param = new Members();
            param.Id = _idItem;
            param.UserName = UsernameMember.Text;
            param.Skill = SkillMember.Text;
            param.SkillLevel = int.Parse(LevelSkillMember.Text);

            var httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(param);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            string url = "http://172.16.28.51:221/Members/reform";
            httpClient.BaseAddress = new Uri(url);
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
                await ClosePage();
            else
                await DisplayAlert("Yah Error", "Penyebabnya cari sendiri ya ;p", "Siap!");
        }

        async void DeleteButton(object sender, EventArgs args)
        {
            string json = JsonConvert.SerializeObject(args);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            string url = "http://172.16.28.51:221/Members/enroll";
            httpClient.BaseAddress = new Uri(url);
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

        }

        async Task ClosePage()
        {
            await Navigation.PopModalAsync();
        }
    }
}