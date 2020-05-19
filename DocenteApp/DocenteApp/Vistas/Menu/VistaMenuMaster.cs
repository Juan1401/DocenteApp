using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DocenteApp
{
    public class VistaMenuMaster : ContentPage
    {
        StackLayout Vista;
        List<MasterMenu> Menu;
        ListView ListView;
        BoxView boxView, boxView1, boxView2,boxView3;
        public VistaMenuMaster() //Constructor
        {
            Title = "Bienvenidos";
            CrearVistas();
            AgregarVistas();
            AgregarEventos();
        }
        void CrearVistas()
        {
            boxView = new BoxView
            {
                BackgroundColor = Colores.Color_Navegation,
                Scale = 2
            };
            boxView1 = new BoxView
            {
                BackgroundColor = Colores.Color_Navegation,
                Scale = 2
            };
            boxView2 = new BoxView
            {
                BackgroundColor = Colores.Color_Navegation,
                Scale = 2
            };
            boxView3 = new BoxView
            {
                BackgroundColor = Colores.Color_Navegation,
                Scale = 1
            };

            Vista = new StackLayout
            {
                BackgroundColor = Colores.Color_Textos
            };
            Menu = new List<MasterMenu>
            {
                new MasterMenu{Texto_Menu = "Registro Notas"}, 
                new MasterMenu{Texto_Menu = "Listado Estudiantes"},
                new MasterMenu{Texto_Menu = "Cerrar Sesión"}
            };
            ListView = new ListView //Instancia 
            {
                ItemsSource = Menu,
                ItemTemplate = new DataTemplate(typeof(EstiloTemplate)),
                SeparatorVisibility = SeparatorVisibility.Default,  //Default or None "linea"
                RowHeight = 60//Altura de la celda
            };
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;//CASTEO para que obligar a un tomar cierto valor 
        }
        void AgregarVistas()
        {
            Vista.Children.Add(boxView);
            Vista.Children.Add(boxView1);
            Vista.Children.Add(boxView2);
            Vista.Children.Add(boxView3);
            Vista.Children.Add(ListView);
            Content = Vista; 
        }
        void AgregarEventos()
        {
            ListView.ItemSelected += ListView_ItemSelected;
            ListView.ItemTapped += ListView_ItemTapped;    //cuando lo toco
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)  //dentro de la "e" viene el objeto de la lista 
        {
            //Siempre que yo le haga tap 
            //
            switch (((MasterMenu)e.Item).Texto_Menu)
            {
                case "Registro Notas":
                    Console.WriteLine("Hola como estas");
                    await DisplayAlert("Advertencias", "Mi Perfil", "Aceptar");
                    break;
                case "Listado estudiantes":
                    break;
                case "Cerrar Sesión":
                    Storage.deleteSession();//Se elimina la session
                    await Navigation.PushAsync(new Login());
                    break;

                default:
                    break;
            }
        }
    }
}