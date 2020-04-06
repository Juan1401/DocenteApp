using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocenteApp
{
    public class PaginaPrincipal : ContentView
    {
        List<string> MiListaEstudiantil;
        ObservableCollection<string> MiListaEstudiantilDos;
        SearchBar miControlDeBusqueda;

        Image Image_Plus;
        BoxView Barra_Busqueda;
        ListView ListView1;
        Cargando loading;

        RelativeLayout ContenedorPrincipal;

        StackLayout VistaGeneral;

        //gesto
        TapGestureRecognizer ImageTap; //declaramos gesto 



        public PaginaPrincipal()
        {
            BackgroundColor = Color.White;
            NavigationPage.SetHasNavigationBar(this, false);  //Barra De Navegación
            CrearVistas();
            AgregarEventos();
            AgregaeVistas();
        }

        void CrearVistas()
        {

            loading = new Cargando();

            MiListaEstudiantil = new List<string>();
            MiListaEstudiantilDos = new ObservableCollection<string>();

            MiListaEstudiantilDos.Add("Juan");
            MiListaEstudiantilDos.Add("Carlos");
            MiListaEstudiantilDos.Add("David");

            //SearchBar miControlDeBusqueda;

            //MiListaEstudiantil.Add(
            //    new Estudiantes
            //        {
            //            Nombre_Completo = "Juan Quitiaquez",
            //            Documento = 1193236231,
            //            Carrera = "Informatica"
            //        });
            //MiListaEstudiantil.Add(
            //    new Estudiantes
            //        {
            //            Nombre_Completo = "Jose Hurtado",
            //            Documento = 011720143,
            //            Carrera = "Administración"
            //         });
            ////lista OBSERVABLE COLLECTION
            //MiListaEstudiantilDos.Add(
            //   new Estudiantes
            //   {
            //       Nombre_Completo = "Miguel Quitiaquez",
            //       Documento = 1193236231,
            //       Carrera = "Contaduria"
            //   });
            //MiListaEstudiantilDos.Add(
            //    new Estudiantes
            //    {
            //        Nombre_Completo = "Eduardo Hurtado",
            //        Documento = 011720143,
            //        Carrera = "Comunicación"
            //    });

            miControlDeBusqueda = new SearchBar
            {
                Placeholder = "Buscar por Nombre"
                //MaxLength = 10  
            };

            Barra_Busqueda = new BoxView
            {
                BackgroundColor = Colores.Color_Navegation

            };

            Image_Plus = new Image
            {

                Source = Imagenes.plus
            };

            VistaGeneral = new StackLayout
            {

            };
            ContenedorPrincipal = new RelativeLayout
            {

            };

            ListView1 = new ListView
            {

                BackgroundColor = Color.Blue,
                ItemsSource = MiListaEstudiantilDos


            };

            ImageTap = new TapGestureRecognizer();
            Image_Plus.GestureRecognizers.Add(ImageTap);


        }
        private void MiControlDeBusqueda_TextChanged(object sender, TextChangedEventArgs e)  //El sender es el SearchBar
        {
            //AQUI VA LA BUSQUEDA
            if (e.NewTextValue == null) return;
            string nuevovalor = miControlDeBusqueda.Text;
            if (nuevovalor.Length >= 11)
                miControlDeBusqueda.Text = nuevovalor.Remove(nuevovalor.Length - 1);
        }
        void AgregaeVistas()
        {
            ContenedorPrincipal.Children.Add(miControlDeBusqueda,
            Constraint.RelativeToParent((p) => { return p.Width * 0; }),  //X    
            Constraint.RelativeToParent((p) => { return p.Height * 0.10; })); //Y   

            ContenedorPrincipal.Children.Add(ListView1,
            Constraint.RelativeToParent((p) => { return p.Width * 0.025; }),  //X    
            Constraint.RelativeToParent((p) => { return p.Height * 0.18; }), //Y   
            Constraint.RelativeToParent((p) => { return p.Width * 0.95; }),  //W
            Constraint.RelativeToParent((p) => { return p.Height * 0.78; })); //H   

            ContenedorPrincipal.Children.Add(Image_Plus,
            Constraint.RelativeToParent((p) => { return p.Width * 0.80; }),  //X    
            Constraint.RelativeToParent((p) => { return p.Height * 0.85; })); //Y   

            ContenedorPrincipal.Children.Add(Barra_Busqueda,
            Constraint.RelativeToParent((p) => { return p.Width * 0; }),  //X
            Constraint.RelativeToParent((p) => { return p.Height * 0; }), //Y     //La barra esta en el comienzo de la aplicación
            Constraint.RelativeToParent((p) => { return p.Width * 1; }),  //W     //Ancho de toda la barra de navegación 375 en FIGMA
            Constraint.RelativeToParent((p) => { return p.Height * 0.098; })); //H

            ContenedorPrincipal.Children.Add(loading,
            Constraint.RelativeToParent((p) => { return 0; }),  //X
            Constraint.RelativeToParent((p) => { return 0; }), //Y     
            Constraint.RelativeToParent((p) => { return p.Width; }),  //W   
            Constraint.RelativeToParent((p) => { return p.Height; })); //H

            Content = ContenedorPrincipal;
        }

        void AgregarEventos()
        {
            miControlDeBusqueda.TextChanged += MiControlDeBusqueda_TextChanged;
            ImageTap.Tapped += ImageTap_Tapped; //presionamos tap tap y enter
            ListView1.ItemSelected += ListView1_ItemSelected;
        }

        private void ListView1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private void ListView1_ItemTapped(object sender, ItemTappedEventArgs e)
        {


        }
        private async void ImageTap_Tapped(object sender, EventArgs e)
        {
            AnimacionSaltoBoton((View)sender);
        }

        async void AnimacionSaltoBoton(View control)
        {
            uint tiempo = 200;
            await control.ScaleTo(0.85, tiempo); //cuando el boton es cuando el boton esta en el cero porciento "presionado"
            await control.ScaleTo(1, tiempo); //Aqui va tomar el valor completo del boton 
            if (string.IsNullOrEmpty(miControlDeBusqueda.Text))
            {
                await App.Current.MainPage.DisplayAlert("Notificación ", "Debes escribir un estudiante", "Aceptar");
                return;
            }
            loading.IsVisible = true;
            await Task.Delay(1000);
            loading.IsVisible = false;
            MiListaEstudiantilDos.Add(miControlDeBusqueda.Text);
            miControlDeBusqueda.Text = string.Empty;
        }
    }
}