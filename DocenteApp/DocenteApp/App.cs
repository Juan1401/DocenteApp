using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DocenteApp
{
    public class App : Application   //"Aplicacion conecta todos los 3 proyectos"
    {
        public static Sesion usuario;
        public static MasterPage _masterPage;

        public App()
        {
            _masterPage = new MasterPage();

            if (Core.isLoggeddin() == 1)
            {
                usuario = Storage.getSession();
                MainPage = new NavigationPage(new PaginaPrincipal());
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }

        }

    }
}
