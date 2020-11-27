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
    public partial class ModificarUsuarioPage : ContentPage
    {
        public ModificarUsuarioPage()
        {
            InitializeComponent();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        private async void BtnCancelar_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void BtnEliminarCuenta_Click(object sender, EventArgs e)
        {

        }
    }
}