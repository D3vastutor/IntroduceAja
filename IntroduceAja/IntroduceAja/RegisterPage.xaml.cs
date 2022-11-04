using IntroduceAja.Models.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntroduceAja
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void SubmitButton(object sender, EventArgs args)
        {
            EnrollMemberRequest request = new EnrollMemberRequest();
            request.CodeName = UsernameMember.Text;
            request.Skill = SkillMember.Text;
            request.SkillLevel = int.Parse(LevelSkillMember.Text);

            bool isSuccess = await EnrollMember(request);
            if (isSuccess)
                await ClosePage();
            else
                await DisplayAlert("Error nih", "Saatnya lo debug ;p", "Okay!");
        }

        async Task<bool> EnrollMember(EnrollMemberRequest param)
        {
            string json = JsonConvert.SerializeObject(param);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            string url = "http://172.16.28.51:221/Members/enroll";
            httpClient.BaseAddress = new Uri(url);
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        async Task ClosePage()
        {
            await Navigation.PopModalAsync();
        }
    }
}