﻿using System;
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
    }
}