using AppDroid.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel vm;

        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            BindingContext = vm = new LoginViewModel();
        }

        void LoginProcedure(object sender, EventArgs e)
        {
            

        }

        private void SwVerPassword_Activado(object sender, ToggledEventArgs e)
        {
            Entry_Password.IsPassword = true;

            if (SwVerPassword.IsToggled)
            {
                Entry_Password.IsPassword = false;
            }
        }

        private async void BtnInicioSesion_Click(object sender, EventArgs e)
        {
            bool R = await vm.IniciarSesion(Entry_Email.Text.Trim(), Entry_Password.Text.Trim());

            if (R)
            {
                await Navigation.PushAsync(new PrincipalPage());
            }
            else
            {
                await DisplayAlert("Error", "Datos incorrectos", "OK");
            }
        }

        private async void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarsePage());
        }
    }
}