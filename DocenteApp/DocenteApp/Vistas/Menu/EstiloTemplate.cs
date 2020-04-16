using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DocenteApp
{
    public class EstiloTemplate : ViewCell
    {
        public EstiloTemplate()
        {

            StackLayout CeldaPadre = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Padding = 10 //Padding = new hickness(10,10,10,10)

            };

            StackLayout Contenedor = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Label label = new Label
            {

                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Colores.Color_Primario
            };


            //ES COMO LA ENVOLTURA

            //se adapta al tamaño de la imagen 

            label.SetBinding(Label.TextProperty, "Texto_Menu");

            Contenedor.Children.Add(label);
            CeldaPadre.Children.Add(Contenedor);
            View = CeldaPadre;
        }
    }
}
