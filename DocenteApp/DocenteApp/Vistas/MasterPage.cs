using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DocenteApp
{
    public class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Page _PaginaPrincipal = new VistaMenuMaster();
            Master = _PaginaPrincipal;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(PaginaPrincipal))) //Lo que esta generando 
                                                                                                 //tiene una navegación dentro
            {
                BarBackgroundColor = Colores.Color_Navegation,
                BarTextColor = Colores.Color_Textos,
            };
        }
    }
}

