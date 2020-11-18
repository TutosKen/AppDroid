using AppDroid.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDroid.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Models.Usuario MiUsuario { get; set; }

        public LoginViewModel()
        {
            MiUsuario = new Models.Usuario();
        }

        public async Task<bool> IniciarSesion(string email, string password)
        {
            //TODO
        }
    }
}
