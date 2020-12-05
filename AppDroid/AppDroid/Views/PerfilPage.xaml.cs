using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppDroid.ViewModels;

namespace AppDroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilPage : ContentPage
    {
        ModificarUsuarioVIewModel vm;

        public PerfilPage()
        {
            InitializeComponent();
            BindingContext = vm = new ModificarUsuarioVIewModel();
            UserName.Text = ObjetosGlobales.UsuarioSesion;
        }

        private async void BtnModificar_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ModificarUsuarioPage());
        }

        private async void BtnEliminarCuenta_Click(object sender, EventArgs e)
        {
            bool R = await vm.EliminarUsuario();

            if (R)
            {
                await DisplayAlert("Aviso", "Usuario eliminado correctamente", "OK");
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Error", "Error al eliminar usuario", "OK");
            }
        }
    }
}