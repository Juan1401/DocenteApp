using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DocenteApp
{
    public class App : Application   //"Aplicacion conecta todos los 3 proyectos"
    {

        public static MasterPage _masterPage;
        public App()
        {
            MainPage = new Login();
            
            _masterPage = new MasterPage();

            MainPage = new NavigationPage(new Login());  ///Para navegar entra páginas
        }
    }
}