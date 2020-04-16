using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocenteApp
{
    public class PaginaPrincipal : ContentPage
    {
        List<string> MiListaEstudiantil;
        ObservableCollection<string> MiListaEstudiantilDos;
        SearchBar miControlDeBusqueda;
        Image Image_Plus;
        ListView ListView1;
        Cargando loading;

        RelativeLayout ContenedorPrincipal;
        StackLayout VistaGeneral;

        //gesto
        TapGestureRecognizer ImageTap; //declaramos gesto 

        public PaginaPrincipal()
        {
            Title = "       Pagina Principal";
            BackgroundColor = Color.White;
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
            ////lista OBSERVABLE COLLECTION
            //MiListaEstudiantilDos.Add(
            //    new Estudiantes
            //    {
            //        Nombre_Completo = "Eduardo Hurtado",
            //        Documento = 011720143,
            //        Carrera = "Comunicación"
            //    });

            miControlDeBusqueda = new SearchBar
            {
                Placeholder = "Agrega tu nombre"
                //MaxLength = 10  
            };

            Image_Plus = new Image
            {

                Source = Core.plus
            };

            VistaGeneral = new StackLayout
            {

            };
            ContenedorPrincipal = new RelativeLayout
            {

            };
            ListView1 = new ListView
            {
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
            VistaGeneral.Children.Add(miControlDeBusqueda);

            ContenedorPrincipal.Children.Add(VistaGeneral,
            Constraint.RelativeToParent((p) => { return p.Width * 0.10; }),  //X
            Constraint.RelativeToParent((p) => { return p.Height * 0.031484; }), //Y   21*100/667= 3.1484
            Constraint.RelativeToParent((p) => { return p.Width * 0.80; }),  //W
            Constraint.RelativeToParent((p) => { return p.Height * 0.034482; })); //H   

            ContenedorPrincipal.Children.Add(ListView1,
            Constraint.RelativeToParent((p) => { return p.Width * 0.025; }),  //X    
            Constraint.RelativeToParent((p) => { return p.Height * 0.15; }), //Y   79*100/667 = 11.84 + 3.1484
            Constraint.RelativeToParent((p) => { return p.Width * 0.95; }),  //W
            Constraint.RelativeToParent((p) => { return p.Height * 0.81; })); //H   

            ContenedorPrincipal.Children.Add(Image_Plus,
            Constraint.RelativeToParent((p) => { return p.Width * 0.80; }),  //X    
            Constraint.RelativeToParent((p) => { return p.Height * 0.85; })); //Y   
            
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
        private void ImageTap_Tapped(object sender, EventArgs e)
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