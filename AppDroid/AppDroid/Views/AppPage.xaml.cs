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
    public partial class AppPage : ContentPage
    {
        public AppPage()
        {
            InitializeComponent();
            NmbUsuario.Text = ObjetosGlobales.NombreSesion;
            Lbl_TituloApp.Text = ObjetosGlobales.NombreApp;
            ImgApp.Source = ObjetosGlobales.ImagenApp;
            Lbl_Descripcion.Text = ObjetosGlobales.DescripcionApp;

            //Carga de trailer
            //var htmlcontent = new HtmlWebViewSource();
            //htmlcontent.Html = "<iframe width='560' height='315' src='https://www.youtube.com/embed/peX9k5wMqWk' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>";
            Video.Source = ObjetosGlobales.TrailerApp;



        }

        private void BtnDescargar_Click(object sender, EventArgs e)
        {

        }

        private async void BtnPerfil(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PerfilPage());
        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());

            var stackNav = Navigation.NavigationStack.ToList();

            for (int i = 0; i < stackNav.Count - 1; i++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[i]);
            }
        }
    }
}