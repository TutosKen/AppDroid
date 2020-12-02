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
        public PrincipalPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NmbUsuario.Text = ObjetosGlobales.NombreSesion;
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

        private void App_Click(object sender, EventArgs e)
        {

            //Debug.WriteLine("tapFrame");
            Frame f = (Frame)sender;
            var hijos = f.Children;

            foreach (var hijo in hijos)
            {
                if (hijo.GetType() == typeof(Grid))
                {
                    Grid celdas = (Grid)hijo;
                    var hijosGrid = celdas.Children;

                    foreach (var hijoG in hijosGrid)
                    {
                        if (hijoG.GetType() == typeof(Label))
                        {
                            Label lbl = (Label)hijoG;
                            Debug.WriteLine(lbl.Text);
                            break;
                        }
                    }
                }
            }

        }
    }
}