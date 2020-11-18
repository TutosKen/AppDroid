using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDroid.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarsePage : ContentPage
    {
        RegistrarseViewModel vm;

        public RegistrarsePage()
        {
            InitializeComponent();
            BindingContext = vm = new RegistrarseViewModel();
        }

        private async void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            bool R = await vm.AgregarUsuario(TxtNombre.Text, Txtemail.Text,TxtPass.Text,1);

            if (R)
            {
                await DisplayAlert("Aviso", "Usuario registrado correctamente", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Error al agregar usuario", "OK");
            }
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