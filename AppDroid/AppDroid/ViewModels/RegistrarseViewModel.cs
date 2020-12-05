using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDroid.ViewModels
{
    class RegistrarseViewModel : BaseViewModel
    {

        //public Command CmdAgregarUsuario { get; set; } Proximamente....

        public Models.Usuario MiUsuario { get; set; }

        public RegistrarseViewModel()
        {
            MiUsuario = new Models.Usuario();
        }

        public async Task<bool> AgregarUsuario(string nombre, string email, string password, int idtipo)
        {
            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MiUsuario.Nombre = nombre;
                MiUsuario.Email = email;
                MiUsuario.Password = password;
                MiUsuario.Idtipo = idtipo;

                bool R = await MiUsuario.AgregarUsuario();

                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> VerificarEmail(string email)
        {
            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MiUsuario.Email = email;

                bool R = await MiUsuario.VerificarEmail();

                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
