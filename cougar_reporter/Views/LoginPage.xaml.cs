using cougar_reporter.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_Login.ViewModels;

namespace cougar_reporter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
    

        public LoginPage()
        {

            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }

       async private void Button_Clicked(object sender, EventArgs e)
        {
          await  Navigation.PushModalAsync(new HomePage());
        }
    }
}