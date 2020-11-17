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
        public LoginPage()
        {
            InitializeComponent();
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

        private void BtnInicioSesion_Click(object sender, EventArgs e)
        {

        }

        private async void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarsePage());
        }
    }
}