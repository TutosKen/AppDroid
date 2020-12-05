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
    public class Usuario
    {
        public int Idusuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Idtipo { get; set; }

        public object idtipoNavigation { get; set; }


        public Usuario()
        {

        }

        public Usuario(int idusuario, string nombre, string email, string password, int idtipo)
        {
            Idusuario = idusuario;
            Nombre = nombre;
            Email = email;
            Password = password;
            Idtipo = idtipo;
        }

        //Registrar usuario
        public async Task<bool> AgregarUsuario()
        {
            string Ruta = ObjetosGlobales.RutaAPIStag + "Usuarios";

            var Cliente = new RestClient(Ruta);

            var Request = new RestRequest(Method.POST);

            Request.AddHeader(ObjetosGlobales.KeyName, ObjetosGlobales.KeyValue);
            Request.AddHeader("Content-Type", "application/json");

            string Datos = JsonConvert.SerializeObject(this);

            Request.AddParameter("application/json", Datos, ParameterType.RequestBody);

            IRestResponse Respuesta = await Cliente.ExecuteAsync(Request);

            HttpStatusCode CodigoRet = Respuesta.StatusCode;

            bool R = false;

            if (CodigoRet == HttpStatusCode.Created)
            {
                R = true;
            }

            return R;
        }

        //Modificar datos de usuario
        public async Task<bool> ModificarUsuario()
        {
            string Ruta = ObjetosGlobales.RutaAPIStag + "Usuarios/"+ObjetosGlobales.IDsesion;

            var Cliente = new RestClient(Ruta);

            var Request = new RestRequest(Method.PUT);

            Request.AddHeader(ObjetosGlobales.KeyName, ObjetosGlobales.KeyValue);
            Request.AddHeader("Content-Type", "application/json");

            string Datos = JsonConvert.SerializeObject(this);

            Request.AddParameter("application/json", Datos, ParameterType.RequestBody);

            IRestResponse Respuesta = await Cliente.ExecuteAsync(Request);

            HttpStatusCode CodigoRet = Respuesta.StatusCode;

            bool R = false;

            if (CodigoRet == HttpStatusCode.NoContent)
            {
                ObjetosGlobales.NombreSesion = this.Nombre;
                ObjetosGlobales.UsuarioSesion = this.Email;
                ObjetosGlobales.PasswordSesion = this.Password;
                R = true;
            }

            return R;
        }

        //Verificar email unico
        public async Task<bool> VerificarEmail()
        {
            string direccion = String.Format("Usuarios/{0}/{1}/{2}", 'x', 'x',this.Email);

            string Ruta = ObjetosGlobales.RutaAPIStag + direccion;

            var Cliente = new RestClient(Ruta);

            var Request = new RestRequest(Method.GET);

            Request.AddHeader(ObjetosGlobales.KeyName, ObjetosGlobales.KeyValue);
            Request.AddHeader("Content-Type", "application/json");

            IRestResponse Respuesta = await Cliente.ExecuteAsync(Request);

            HttpStatusCode CodigoRet = Respuesta.StatusCode;

            bool R = false;

            if (CodigoRet == HttpStatusCode.OK)
            {
                Usuario usr = new Usuario();
                usr = JsonConvert.DeserializeObject<Usuario>(Respuesta.Content);

                if (usr.Email == ObjetosGlobales.UsuarioSesion)
                {
                    R = false;
                }
                else
                {
                    R = true;
                }
            }

            return R;
        }

        //Eliminar usuario
        public async Task<bool> EliminarUsuario()
        {
            string direccion = String.Format("Usuarios/{0}", ObjetosGlobales.IDsesion);

            string Ruta = ObjetosGlobales.RutaAPIStag + direccion;

            var Cliente = new RestClient(Ruta);

            var Request = new RestRequest(Method.DELETE);

            Request.AddHeader(ObjetosGlobales.KeyName, ObjetosGlobales.KeyValue);
            Request.AddHeader("Content-Type", "application/json");

            IRestResponse Respuesta = await Cliente.ExecuteAsync(Request);

            HttpStatusCode CodigoRet = Respuesta.StatusCode;

            bool R = false;

            if (CodigoRet == HttpStatusCode.OK)
            {
                R = true;
            }

            return R;
        }



        public async Task<bool> IniciarSesion()
        {
            string direccion = String.Format("Usuarios/{0}/{1}", this.Email, this.Password);

            string Ruta = ObjetosGlobales.RutaAPIStag + direccion;

            var Cliente = new RestClient(Ruta);

            var Request = new RestRequest(Method.GET);

            Request.AddHeader(ObjetosGlobales.KeyName, ObjetosGlobales.KeyValue);
            Request.AddHeader("Content-Type", "application/json");

            IRestResponse Respuesta = await Cliente.ExecuteAsync(Request);

            HttpStatusCode CodigoRet = Respuesta.StatusCode;

            bool R = false;

            if (CodigoRet == HttpStatusCode.OK)
            {
                Usuario usr = new Usuario();
                usr = JsonConvert.DeserializeObject<Usuario>(Respuesta.Content);
                ObjetosGlobales.NombreSesion = usr.Nombre;
                ObjetosGlobales.UsuarioSesion = this.Email;
                ObjetosGlobales.PasswordSesion = this.Password;
                ObjetosGlobales.IDsesion = usr.Idusuario;
                R = true;
            }

            return R;
        }
    }
}
