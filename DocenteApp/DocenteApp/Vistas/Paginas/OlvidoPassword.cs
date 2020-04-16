using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocenteApp
{
    public class OlvidoPassword : ContentPage
    {
        Image ImageBack;
        Entry CorreoRecuperacion;
        BoxView BoxViewCorreo;
        BoxView BoxViewNavegation;

        Cargando loading;

        Button ButtonRecuperar;


        StackLayout VistaGeneral;
        RelativeLayout ContenedorPrincipal;

        TapGestureRecognizer tabButtonRecuperar;
        TapGestureRecognizer tabIconBack;

        public OlvidoPassword()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            CrearVistas();
            AgregarVistas();
            AgregarEventos();
        }

        void CrearVistas()
        {
            loading = new Cargando();

            CorreoRecuperacion = new Entry
            {
                Placeholder = "Correo Institucional",
                PlaceholderColor = Color.FromHex("#000000"),
                Keyboard = Keyboard.Email,
                TextColor = Colores.Color_TextosSecundario
            };

            BoxViewCorreo = new BoxView
            {

            };
            BoxViewNavegation = new BoxView
            {
                Color = Colores.Color_Navegation
            };

            ButtonRecuperar = new Button
            {
                Text = "Recuperar",
                BackgroundColor = Colores.Color_Navegation,
                TextColor = Colores.Color_Textos
            };

            VistaGeneral = new StackLayout
            {
                BackgroundColor = Color.FromHex("#FFFFFF")

            };

            ContenedorPrincipal = new RelativeLayout
            {

                BackgroundColor = Color.White

            };

            ImageBack = new Image
            {

                Source = Core.IconoBack

            };

            tabButtonRecuperar = new TapGestureRecognizer(); //Instanciamos
            ButtonRecuperar.GestureRecognizers.Add(tabButtonRecuperar);

            tabIconBack = new TapGestureRecognizer();
            ImageBack.GestureRecognizers.Add(tabIconBack);
        }

        void AgregarVistas()
        {
            //Declarlos en el orden en que quiero que aparezca 

            VistaGeneral.Children.Add(CorreoRecuperacion);
            VistaGeneral.Children.Add(ButtonRecuperar);
            Content = VistaGeneral;

            ContenedorPrincipal.Children.Add(VistaGeneral,
            Constraint.RelativeToParent((p) => { return 20; }),  //X
            Constraint.RelativeToParent((p) => { return p.Height * 0.3718; }), //Y  segun figma: 304*100/667= 45.577/100 = y  se le mermo la altura del BoxViewNavegation por que este porcentaje contava desde el eje x em 0
            Constraint.RelativeToParent((p) => { return 320; }));  //W  

            ContenedorPrincipal.Children.Add(BoxViewNavegation,
            Constraint.RelativeToParent((p) => { return p.Width * 0; }),  //X    
            Constraint.RelativeToParent((p) => { return p.Height * 0; }), //Y   
            Constraint.RelativeToParent((p) => { return p.Width * 1; }),  //W
            Constraint.RelativeToParent((p) => { return p.Height * 0.0839; })); //H  //56*100/667 = 8.39

            ContenedorPrincipal.Children.Add(ImageBack,
            Constraint.RelativeToParent((p) => { return p.Width * 0; }),  //X    
            Constraint.RelativeToParent((p) => { return p.Height * 0; }), //Y
            Constraint.RelativeToParent((p) => { return p.Width * 0.15; }),  //W
            Constraint.RelativeToParent((p) => { return p.Height * 0.0839; })); //H  //56*100/667 = 8.39

            ContenedorPrincipal.Children.Add(loading,
            Constraint.RelativeToParent((p) => { return 0; }),  //X
            Constraint.RelativeToParent((p) => { return 0; }), //Y     
            Constraint.RelativeToParent((p) => { return p.Width; }),  //W   
            Constraint.RelativeToParent((p) => { return p.Height; })); //H

            Content = ContenedorPrincipal;
            
        }

        void AgregarEventos()
        {
            ButtonRecuperar.Clicked += ButtonRecuperar_Clicked;
            tabButtonRecuperar.Tapped += TabButtonRecuperar_Tapped;
            tabIconBack.Tapped += TabIconBack_Tapped;

        }

        private async void TabIconBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        private async void TabButtonRecuperar_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        private async void ButtonRecuperar_Clicked(object sender, EventArgs e)
        {
            Validaciones val = new Validaciones();

            if (String.IsNullOrEmpty(CorreoRecuperacion.Text))
            {
                loading.IsVisible = true;
                await Task.Delay(500);
                loading.IsVisible = false;
                await DisplayAlert("Advertencia", "El campo Correo esta vacio", "Aceptar");
                return;
            }
            bool validarcorreo = val.VerificarCorreo(CorreoRecuperacion);
            if (validarcorreo)
            {
                loading.IsVisible = true;
                await Task.Delay(500);
                loading.IsVisible = false;
                await DisplayAlert("Advertencia", "El campo Correo no es una dirrección Valida", "Aceptar");
                return;
            }

            if (!CorreoRecuperacion.Text.Contains("@"))
            {
                loading.IsVisible = true;
                await Task.Delay(500);
                loading.IsVisible = false;
                await DisplayAlert("Advertencia", "El campo Correo no contiene una dirección valida", "Aceptar");
                return;
            }
            if (!CorreoRecuperacion.Text.Contains("."))
            {
                loading.IsVisible = true;
                await Task.Delay(500);
                loading.IsVisible = false;
                await DisplayAlert("Advertencia", "El campo Correo no contiene una dirección valida, falta el '.' ", "Aceptar");
                return;
            }
            else
            {
                loading.IsVisible = true;
                await Task.Delay(500);
                loading.IsVisible = false;
                await DisplayAlert("Confirmación", "Se ha enviado un correo de Recuperación", "Aceptar");
           
                return;
            }
        }
    }
}