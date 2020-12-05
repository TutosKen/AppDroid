using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppDroid.Models
{
    class Aplicacion
    {
        public int Idaplicacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string UrlVideoTrailer { get; set; }
        public string ArchivoApk { get; set; }

        public virtual ICollection<CategoriaAplicacion> CategoriaAplicacions { get; set; }

        public async Task<List<Aplicacion>> ObtenerAplicaciones()
        {
            string direccion = String.Format("Aplicaciones");

            string Ruta = ObjetosGlobales.RutaAPIStag + direccion;

            var Cliente = new RestClient(Ruta);

            var Request = new RestRequest(Method.GET);

            Request.AddHeader(ObjetosGlobales.KeyName, ObjetosGlobales.KeyValue);
            Request.AddHeader("Content-Type", "application/json");

            IRestResponse Respuesta = await Cliente.ExecuteAsync(Request);

            HttpStatusCode CodigoRet = Respuesta.StatusCode;

            if (CodigoRet == HttpStatusCode.OK)
            {
                var listaApps = (JsonConvert.DeserializeObject<List<Models.Aplicacion>>(Respuesta.Content));
                foreach (var app in listaApps)
                {
                    Debug.WriteLine(app.Nombre);
                }
                return listaApps;
            }

            return null;
        }
    }
}
