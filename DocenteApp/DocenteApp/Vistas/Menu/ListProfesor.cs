using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DocenteApp
{
   public class ListProfesor : ViewCell
    {
        public ListProfesor()
        {
            StackLayout CeldaPadre = new StackLayout
            {

               Orientation = StackOrientation.Horizontal,
            
            };

            StackLayout ContenedorLabel = new StackLayout
            {


            };

            StackLayout ContenedorLabel1 = new StackLayout
            {


            };

            Label Nombre = new Label
            {
                VerticalOptions = LayoutOptions.FillAndExpand,   //SE VUELVE GRANDE A TODAS DIRECCIONES
                HorizontalOptions = LayoutOptions.FillAndExpand, //SE VUELVE GRANDE A TODAS DIRECCIONES  //como el layout toma todos las partes vacias solo fue ponerlo al final

                HorizontalTextAlignment = TextAlignment.Start,     //Al final    
                VerticalTextAlignment = TextAlignment.Start,
                BackgroundColor = Color.Transparent,
                TextColor = Color.Black,
                WidthRequest = 162,

            };
            Label Materia = new Label
            {
                VerticalOptions = LayoutOptions.FillAndExpand,   //SE VUELVE GRANDE A TODAS DIRECCIONES
                HorizontalOptions = LayoutOptions.FillAndExpand, //SE VUELVE GRANDE A TODAS DIRECCIONES  //como el layout toma todos las partes vacias solo fue ponerlo al final

                HorizontalTextAlignment = TextAlignment.Start,     //Al final    
                VerticalTextAlignment = TextAlignment.Start,
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                WidthRequest = 162,

            };

            Label Docente = new Label
            {

                VerticalOptions = LayoutOptions.FillAndExpand,   //SE VUELVE GRANDE A TODAS DIRECCIONES
                HorizontalOptions = LayoutOptions.EndAndExpand, //SE VUELVE GRANDE A TODAS DIRECCIONES  //como el layout toma todos las partes vacias solo fue ponerlo al final
                //El layout se pone al final y se expanda  

                HorizontalTextAlignment = TextAlignment.Start,     //Al final    
                VerticalTextAlignment = TextAlignment.Start,
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                WidthRequest = 180,

            };

            Label Nota = new Label
            {
                VerticalOptions = LayoutOptions.FillAndExpand,   //SE VUELVE GRANDE A TODAS DIRECCIONES
                HorizontalOptions = LayoutOptions.EndAndExpand, //SE VUELVE GRANDE A TODAS DIRECCIONES  //como el layout toma todos las partes vacias solo fue ponerlo al final
                //El layout se pone al final y se expanda  

                HorizontalTextAlignment = TextAlignment.End,     //Al final    
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Colores.Color_Nota,
                BackgroundColor = Color.Transparent,
                WidthRequest = 90,
                FontSize = 27

            };


            //Orden del padre y los Labels
            //Si quiero que la imagen sea visible   
            Nota.SetBinding(Label.IsVisibleProperty, "NotaVisible");   //QUe pudieramos poner el Nota en invisible

            Nombre.SetBinding(Label.TextProperty, "Nombre");
            Materia.SetBinding(Label.TextProperty, "Materia");
            Docente.SetBinding(Label.TextProperty, "Docente");
            Nota.SetBinding(Label.TextProperty, "Nota");


            ContenedorLabel.Children.Add(Nombre);
            ContenedorLabel.Children.Add(Materia);
            ContenedorLabel.Children.Add(Docente);

            CeldaPadre.Children.Add(ContenedorLabel);
            CeldaPadre.Children.Add(Nota);

            View = CeldaPadre;
        }
    }
}
