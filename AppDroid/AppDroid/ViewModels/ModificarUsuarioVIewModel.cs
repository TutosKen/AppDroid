using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDroid.ViewModels
{
    class ModificarUsuarioVIewModel : BaseViewModel
    {
        public Models.Usuario MiUsuario { get; set; }

        public ModificarUsuarioVIewModel()
        {
            MiUsuario = new Models.Usuario();
        }

        public async Task<bool> ModificarUsuario(string nombre, string email, string password, int idtipo)
        {
            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MiUsuario.Idusuario = ObjetosGlobales.IDsesion;
                MiUsuario.Nombre = nombre;
                MiUsuario.Email = email;
                MiUsuario.Password = password;
                MiUsuario.Idtipo = idtipo;

                bool R = await MiUsuario.ModificarUsuario();

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

        public async Task<bool> EliminarUsuario()
        {
            if (IsBusy) return false;

            IsBusy = true;

            try
            {

                bool R = await MiUsuario.EliminarUsuario();

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
