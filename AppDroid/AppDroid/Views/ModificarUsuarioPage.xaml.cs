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
    public partial class ModificarUsuarioPage : ContentPage
    {

        ModificarUsuarioVIewModel vm;
        public ModificarUsuarioPage()
        {
            InitializeComponent();
            BindingContext = vm = new ModificarUsuarioVIewModel();
            TxtNombre.Text = ObjetosGlobales.NombreSesion;
            Txtemail.Text = ObjetosGlobales.UsuarioSesion;
            TxtPass.Text = ObjetosGlobales.PasswordSesion;
            TxtConfirmPass.Text = ObjetosGlobales.PasswordSesion;
        }

        private bool verificarContrasenna()
        {
            if (TxtPass.Text.Trim() == TxtConfirmPass.Text.Trim())
            {
                return true;
            }
            return false;
        }
        private async void BtnModificar_Click(object sender, EventArgs e)
        {
            if (verificarContrasenna())
            {
                if (await vm.VerificarEmail(Txtemail.Text.Trim()))
                {
                    await DisplayAlert("Error", "El correo ya se encuentra en uso", "OK");
                }
                else
                {
                    bool R = await vm.ModificarUsuario(TxtNombre.Text.Trim(), Txtemail.Text.Trim(), TxtPass.Text.Trim(), 1);
                    if (R)
                    {
                        await DisplayAlert("Aviso", "Usuario modificado correctamente", "OK");
                        await Navigation.PushAsync(new PrincipalPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Error al modificar el usuario", "OK");
                    }
                }

            }
            else
            {
                await DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
            }
        }

        private async void BtnCancelar_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnEliminarCuenta_Click(object sender, EventArgs e)
        {

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