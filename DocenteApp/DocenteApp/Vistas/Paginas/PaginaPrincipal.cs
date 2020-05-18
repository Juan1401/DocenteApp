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

        ObservableCollection<Profesor> MiListaEstudiantilDos;
        ListView ListView2;

        SearchBar miControlDeBusqueda;
        Image Image_Plus;
        ListView ListView1;
        Cargando loading;

        BoxView boxView;
        Picker picker;

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


            MiListaEstudiantilDos = new ObservableCollection<Profesor>
            {
              new Profesor {Nombre ="Roney Rodriguez", Materia = "Electiva II" , Docente = "Docente: Roney Rodriguez", Nota = "4.3", NotaVisible = true },
              new Profesor {Nombre ="Roney Rodriguez", Materia = "POII" , Docente = "Docente: Roney Rodriguez", Nota = "4.5", NotaVisible = true },
              new Profesor {Nombre ="Roney Rodriguez", Materia = "Desarrollo Web" , Docente = "Docente: Roney Rodriguez", Nota = "3.7", NotaVisible = true }
            
            };

            ListView2 = new ListView   //listView
            {
                ItemsSource = MiListaEstudiantilDos,
                ItemTemplate = new DataTemplate(typeof(ListProfesor)),
                SeparatorVisibility = SeparatorVisibility.Default,
                RowHeight = 85,
            };

       

            Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
        {
            { "Aqua", Color.Aqua }, { "Black", Color.Black },
            { "Gray", Color.Gray }, { "Green", Color.Green },
            { "Lime", Color.Lime }, { "Maroon", Color.Maroon },
            { "Navy", Color.Navy }, { "Olive", Color.Olive },
            { "Purple", Color.Purple }, { "Red", Color.Red },
            { "Silver", Color.Silver }, { "Teal", Color.Teal },
            { "White", Color.White }, { "Yellow", Color.Yellow }
        };

            picker = new Picker
            {
                Title = "Color",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string colorName in nameToColor.Keys)
            {
                picker.Items.Add(colorName);
            }

            // Create BoxView for displaying picked Color
            boxView = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

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
                Placeholder = "Agrega tu nombre",
                VerticalOptions = LayoutOptions.CenterAndExpand
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
            VistaGeneral.Children.Add(picker);
            VistaGeneral.Children.Add(boxView);

            ContenedorPrincipal.Children.Add(VistaGeneral,
            Constraint.RelativeToParent((p) => { return p.Width * 0.15; }),  //X
            Constraint.RelativeToParent((p) => { return p.Height * 0.01; }), //Y   97-76=21   (21*100/667= 3.1484)
            Constraint.RelativeToParent((p) => { return p.Width * 0.70; }),  //W
            Constraint.RelativeToParent((p) => { return p.Height * 0.01402; })); //H   

            ContenedorPrincipal.Children.Add(ListView2,
            Constraint.RelativeToParent((p) => { return p.Width * 0.05; }),  //X    
            Constraint.RelativeToParent((p) => { return p.Height * 0.22; }), //Y   79*100 /667 = 11.84 + 3.1484 = 0.25;
            Constraint.RelativeToParent((p) => { return p.Width * 0.90; }),  //W
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
            ListView2.ItemSelected += ListView2_ItemSelected;
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;            
        }

        private void ListView2_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        public void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker.SelectedIndex == -1)
            {
                boxView.Color = Color.Default;
            }
            else
            {
                string colorName = picker.Items[picker.SelectedIndex];
                boxView.Color = Colores.Color_Navegation;
            }
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
            //if (string.IsNullOrEmpty(miControlDeBusqueda.Text))
            //{
            //    await App.Current.MainPage.DisplayAlert("Notificación ", "Debes escribir un estudiante", "Aceptar");
            //    return;
            //}
            //loading.IsVisible = true;
            //await Task.Delay(1000);
            //loading.IsVisible = false;
            //MiListaEstudiantilDos.Add(miControlDeBusqueda.Text);
            //miControlDeBusqueda.Text = string.Empty;
        }
    }
}