using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DocenteApp
{
    public static class Core
    {
        public static int ScreenWidh { get; set; }
        public static int Screenheigh { get; set; }

        public static ImageSource LogoUtap { get; } = ImageSource.FromFile("LogoUtap.png");
        public static ImageSource IconoBack { get; } = ImageSource.FromFile("IconoBack.png");
        public static ImageSource plus { get; } = ImageSource.FromFile("plus.png");

        //API
        public static string nombre_archivo_sesion { get; } = "Sesion_Usuario";

            //LOGICA PARA VALIDAR LA SESION

        public static int isLoggeddin()
        {
            var session = Storage.getSession();
            if (session == null || string.IsNullOrEmpty(session.Codigo_Estudiante))
            {
                Console.WriteLine("Not logged in");
                return -1;
            }
            return 1;
        
        }
    }
}
