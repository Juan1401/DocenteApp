using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocenteApp
{

    public class Login : ContentPage
    {
        Image LogoUTAP,IconoBack,ImageBackOlvidoContraseña;

        Label labeLBienvenido;

        Entry entryCodigoEstudiante, entryIdentificacion, entryContraseña;

        BoxView BoxviewDiseño;

        Button buttonIniciar;

        Label labelOlvidoContraseña;

        Cargando loading;

        StackLayout VistaGeneral;
         
        //TAREA PUESTA 24-02-2020
        RelativeLayout ContenedorPrincipal;

        BoxView Circulo;

        //30/03/2020
        PaginaPrincipal paginaPrincipal; //30/03/2020
     
        TapGestureRecognizer ImageBack; //declaramos gesto 
        TapGestureRecognizer NavegarOlvidoContra; //declaramos gesto 


        //Añadir Modelo para los colores y tamaño de texto.
        //No posicionar con Stacklayout o Relative Por Ahora.

        public Login()
        {
            NavigationPage.SetHasNavigationBar(this, false);  //Barra De Navegación
            CrearVistas();
            AgregarVistas();
            AgregarEventos();
        }
        void CrearVistas()
        {
            loading = new Cargando();

            IconoBack = new Image
            {
                Source = Imagenes.IconoBack,
                IsVisible = false
            };

            ImageBackOlvidoContraseña = new Image
            {
                Source = Imagenes.IconoBack,
                IsVisible = false
            };

            paginaPrincipal = new PaginaPrincipal
            {
                TranslationX = 420
            };

            LogoUTAP = new Image
            {
                Source = Imagenes.LogoUtap
            };

            BoxviewDiseño = new BoxView
            {
                Color = Colores.Color_Navegation
            };

            labeLBienvenido = new Label
            {
                Text = " Bienvenidos ",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Colores.Color_Titulos, /*Color.FromHex("#FFFFFF")*/
                FontSize = TamanosLetras.Texto_Titulos
            };

            labelOlvidoContraseña = new Label
            {
                Text = " ¿Olvido Su Contraseña? ",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Colores.Color_Titulos,
                FontSize = TamanosLetras.Texto_Controles
            };

            entryIdentificacion = new Entry
            {
                Placeholder = "No. Documento",
                PlaceholderColor = Color.FromHex("#FFFFFF"),
                Keyboard = Keyboard.Numeric,
                TextColor = Color.FromHex("#FFFFFF")
            };

            entryCodigoEstudiante = new Entry
            {
                Placeholder = "Código estudiante ",
                PlaceholderColor = Color.FromHex("#FFFFFF"),
                Keyboard = Keyboard.Numeric,
                TextColor = Colores.Color_Textos
            };

            entryContraseña = new Entry
            {
                Placeholder = "Contraseña",
                PlaceholderColor = Color.FromHex("#FFFFFF"),
                Keyboard = Keyboard.Text,
                TextColor = Colores.Color_Textos,
                IsPassword = true
            };

            buttonIniciar = new Button
            {
                Text = "Acceder a la App",
                BackgroundColor = Color.FromHex("FFFFF"),
                TextColor = Colores.Color_TextosSecundario,
                //Scale = 6  "El boton se pone 6 veces mas grande que el original" 
            };

            VistaGeneral = new StackLayout
            {
                BackgroundColor = Colores.Color_Navegation
            };

            ContenedorPrincipal = new RelativeLayout
            {
                BackgroundColor = Colores.Color_Navegation
            };
            Circulo = new BoxView
            {
                Color = Color.Black,
                CornerRadius = 40, //Para que el boxview se ponga rendondo 
                Scale = 20
            };

            buttonIniciar.Clicked += ButtonIniciar_Clicked; //evento para animación  24-02-2020
            
            ImageBack = new TapGestureRecognizer();
            IconoBack.GestureRecognizers.Add(ImageBack);

            NavegarOlvidoContra = new TapGestureRecognizer();
            labelOlvidoContraseña.GestureRecognizers.Add(NavegarOlvidoContra);

        }
        void AgregarVistas()
        {
            VistaGeneral.Children.Add(LogoUTAP);
            VistaGeneral.Children.Add(labeLBienvenido);
            VistaGeneral.Children.Add(entryIdentificacion);
            VistaGeneral.Children.Add(entryCodigoEstudiante);
            VistaGeneral.Children.Add(entryContraseña);
            VistaGeneral.Children.Add(BoxviewDiseño);
            VistaGeneral.Children.Add(buttonIniciar);
            VistaGeneral.Children.Add(labelOlvidoContraseña);
            Content = VistaGeneral;

            ContenedorPrincipal.Children.Add(VistaGeneral,
            Constraint.RelativeToParent((p) => { return 20; }),  //X
            Constraint.RelativeToParent((p) => { return p.Height * 0.1; }), //Y
            Constraint.RelativeToParent((p) => { return 320; }));  //W  

            //Declarlos en el orden en que quiero que aparezca 
            ContenedorPrincipal.Children.Add(Circulo,
            Constraint.RelativeToParent((p) => { return p.Width * 0.45; }),  //X    
            Constraint.RelativeToParent((p) => { return p.Height * 0.45; })); //H   

            ContenedorPrincipal.Children.Add(paginaPrincipal,
            Constraint.RelativeToParent((p) => { return 0; }),  //X
            Constraint.RelativeToParent((p) => { return 0; }), //Y
            Constraint.RelativeToParent((p) => { return p.Width; }),  //W  
            Constraint.RelativeToParent((p) => { return p.Height; }));  //H  

            ContenedorPrincipal.Children.Add(IconoBack,
            Constraint.RelativeToParent((p) => { return p.Width * 0; }),  //X    
            Constraint.RelativeToParent((p) => { return p.Height * 0; })); //Y   

            ContenedorPrincipal.Children.Add(loading,
            Constraint.RelativeToParent((p) => { return 0; }),  //X
            Constraint.RelativeToParent((p) => { return 0; }), //Y     
            Constraint.RelativeToParent((p) => { return p.Width; }),  //W   
            Constraint.RelativeToParent((p) => { return p.Height; })); //H


            Content = ContenedorPrincipal;
        }

        void AgregarEventos()
        {
            ImageBack.Tapped += ImageBack_Tapped;  //Back para pagina principal
            NavegarOlvidoContra.Tapped += NavegarOlvidoContra_Tapped;
        }

        private async void NavegarOlvidoContra_Tapped(object sender, EventArgs e)
        {

            loading.IsVisible = true;
            await Task.Delay(500);
            loading.IsVisible = false;
            await Navigation.PushAsync(new OlvidoPassword());
        }

        private async void ImageBack_Tapped(object sender, EventArgs e)
        {
            loading.IsVisible = true;
            await Task.Delay(500);
            loading.IsVisible = false;
            await paginaPrincipal.TranslateTo(420, 0, 200);
            IconoBack.IsVisible = false;
        }

        private async void ButtonIniciar_Clicked(object sender, EventArgs e) //animación del boton 24-02-2020
        {
            //UInt16 Tiempo = 125;
            ////ESTO TMABIEN PUEDE IR ACA ARRIBA
            //await buttonIniciar.ScaleTo(0.95, Tiempo); //cuando el boton es cuando el boton esta en el cero porciento "presionado"
            //await buttonIniciar.ScaleTo(1, Tiempo); //Aqui va tomar el valor completo del boton 

            Validaciones val = new Validaciones();
         
            if (String.IsNullOrEmpty(entryIdentificacion.Text))
            {
                loading.IsVisible = true;
                await Task.Delay(450);
                loading.IsVisible = false;
                await DisplayAlert("Advertencia", "El campo No.Documento esta vacio", "Aceptar");
            }

            bool ValidarDocumento = val.ValidarDocumento(entryIdentificacion);
            if (!ValidarDocumento)
            {
                loading.IsVisible = true;
                await Task.Delay(450);
                loading.IsVisible = false;
                await DisplayAlert("Advertencia", "El campo No. Documento debe tener maximo 10 digitos", "Aceptar");
            }
            
            if (String.IsNullOrEmpty(entryCodigoEstudiante.Text))
            {
                loading.IsVisible = true;
                await Task.Delay(450);
                loading.IsVisible = false;
                await DisplayAlert("Advertencia", "El campo Código estudiante esta vacio", "Aceptar");
                return;
            }

            bool ValidarDocumento_Nu = val.ValidarDocumento_Nu(entryCodigoEstudiante);
            if (ValidarDocumento_Nu) 
            {
                loading.IsVisible = true;
                await Task.Delay(450);
                loading.IsVisible = false;
                await DisplayAlert("Advertencia", "El campo Código estudiante solo recibe 'Numeros'.", "Aceptar");
                return;
            }

            if (String.IsNullOrEmpty(entryContraseña.Text))
            {
                loading.IsVisible = true;
                await Task.Delay(450);
                loading.IsVisible = false;
                await DisplayAlert("Advertencia", "El campo Contraseña esta vacio", "Aceptar");
                return;
            }
            bool ValidarPassword = val.ValidarPassword(entryContraseña);
            if (!ValidarPassword)
            {
                loading.IsVisible = true;
                await Task.Delay(450);
                loading.IsVisible = false;
                await DisplayAlert("Advertencia", "El campo Contraseña debe tener al menos 8 caracteres", "Aceptar");
                return;
            }
            else {
                loading.IsVisible = true;
                await Task.Delay(500);
                loading.IsVisible = false;
                Rectangle dimensiones = paginaPrincipal.Bounds;
                await paginaPrincipal.TranslateTo(0, 0, 200);
                IconoBack.IsVisible = true;
            }
            //ESTO LO PUEDO UTILIZAR CUANDO HAYA UN ERROR EN LOS DATOS EL BOTON SALTE

            //await buttonIniciar.TranslateTo(20, 0, Tiempo); //mueve x a la izquierda //queda en la posicion original del boton
            //await buttonIniciar.TranslateTo(0, 0, Tiempo);  //vuelve a la poscion original
            //await buttonIniciar.TranslateTo(-20, 0, Tiempo); //mueve x a la izquierda //queda en la posicion original del boton
            //await buttonIniciar.TranslateTo(0, 0, Tiempo);
        }
        //ANIMACIÓN

        async Task AnimationInicial()  //Para dar un tiempo de espera
        {
            UInt16 Tiempo = 500;

            await Task.Delay(250);

            await Circulo.ScaleTo(0, Tiempo);

            Circulo.Color = Color.Red;

            await Circulo.ScaleTo(20, Tiempo);

            await Circulo.FadeTo(0, Tiempo); //se desaparece pero sigue ahi

            Circulo.IsVisible = false; //se desaparece del todo
        }
        protected override async void OnAppearing() //esto funciona al momento en que inicia la aplicacion "antes de que se genere todo el stacklayout"
        {
            base.OnAppearing();

            await AnimationInicial(); //Se ejecuta antes de todo por la propiedad del OnAppearing //La animación de los circulos.
        }
        protected override void OnDisappearing() //Este metodo funciona solo cuando se cierra la vista
        {
            base.OnAppearing();
        }
    }
}
