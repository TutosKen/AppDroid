using AppDroid.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalPage : ContentPage
    {

        //        public List<Models.Usuario> usuarios = new List<Models.Usuario>(); //probando listview
        PrincipalViewModel vm;
        public PrincipalPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NmbUsuario.Text = ObjetosGlobales.NombreSesion;
            BindingContext = vm = new PrincipalViewModel();
            CargarApps();
        }

        private async void CargarApps()
        {
            this.testView.ItemsSource = await vm.ObtenerApps();
        }

        private async void BtnPerfil(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PerfilPage()); 
        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());

            //var stackNav = Navigation.NavigationStack.ToList();

            //for (int i = 0; i < stackNav.Count - 1; i++)
            //{
            //    Navigation.RemovePage(Navigation.NavigationStack[i]);
            //}
        }

        private void App_Click(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Models.Aplicacion;
            ObjetosGlobales.NombreApp = item.Nombre;
            ObjetosGlobales.DescripcionApp = item.Descripcion;
            ObjetosGlobales.ImagenApp = item.Imagen;
            ObjetosGlobales.TrailerApp = item.UrlVideoTrailer;
            ObjetosGlobales.ApkApp = item.ArchivoApk;

            Navigation.PushAsync(new AppPage());
        }
    }
}