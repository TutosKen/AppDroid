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
    }
}