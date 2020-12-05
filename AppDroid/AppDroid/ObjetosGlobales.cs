using System;
using System.Collections.Generic;
using System.Text;

namespace AppDroid
{
    public static class ObjetosGlobales
    {

        //Aplicacion actual
        public static string NombreApp;
        public static string DescripcionApp;
        public static string ImagenApp;
        public static string TrailerApp;
        public static string ApkApp;


        //Variables de sesion
        public static string NombreSesion;
        public static string UsuarioSesion;
        public static string PasswordSesion;
        public static int IDsesion;

        public static string RutaAPIStag = "http://192.168.100.27:45455/api/";
        public static string RutaAPITest = "http://192.168.100.27:45455/api/";

        public static string KeyName = "ServiceApiKey";
        public static string KeyValue = "s3cr3t";

    }
}
