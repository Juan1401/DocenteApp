using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DocenteApp
{
    public class Cargando: RelativeLayout
    {
        ActivityIndicator Loading;

        public Cargando()
        {
            IsVisible = false;
            BackgroundColor = Colores.Color_Navegation.MultiplyAlpha(0.6);

            Loading = new ActivityIndicator
            {
                IsRunning = true,
                Color = Colores.Color_Textos,
            };
          
            Children.Add(Loading,
            Constraint.RelativeToParent((p) => { return p.Width * 0.45; }),  //X    //90% /2 = 45%
            Constraint.RelativeToParent((p) => { return p.Height * 0.45; }), //Y    //90% /2 = 45%
            Constraint.RelativeToParent((p) => { return p.Width * 0.1; }),  //W     //10%
            Constraint.RelativeToParent((p) => { return p.Height * 0.1; })); //H    //10%

            //BowView para el el fondo del cargando
        }
    }
}