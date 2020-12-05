using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDroid.ViewModels
{
    class PrincipalViewModel : BaseViewModel
    {
        public Models.Aplicacion MiApp { get; set; }

        public PrincipalViewModel()
        {
            MiApp = new Models.Aplicacion();
        }

        public async Task<List<Models.Aplicacion>> ObtenerApps()
        {
            List<Models.Aplicacion> lista = new List<Models.Aplicacion>();

            if (!IsBusy)
            {
                IsBusy = true;

                try
                {
                    lista = await MiApp.ObtenerAplicaciones();
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    IsBusy = false;
                }
            }
            return lista;
        }
    }
}
