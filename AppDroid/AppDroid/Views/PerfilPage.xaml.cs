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
    public partial class PerfilPage : ContentPage
    {
        public PerfilPage()
        {
            InitializeComponent();
            UserName.Text = ObjetosGlobales.UsuarioSesion;
        }

        private async void BtnModificar_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ModificarUsuarioPage());
        }

        private void BtnEliminarCuenta_Click(object sender, EventArgs e)
        {

        }
    }
}