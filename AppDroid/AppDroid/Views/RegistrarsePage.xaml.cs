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
    public partial class RegistrarsePage : ContentPage
    {
        public RegistrarsePage()
        {
            InitializeComponent();
        }

        private void BtnRegistrarse_Click(object sender, EventArgs e)
        {

        }

        private async void BtnCancelar_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void SwVerPass_T(object sender, ToggledEventArgs e)
        {
            TxtPass.IsPassword = true;
            TxtConfirmPass.IsPassword = true;

            if (SwVerPass.IsToggled)
            {
                TxtPass.IsPassword = false;
                TxtConfirmPass.IsPassword = false;
            }
        }
    }
}