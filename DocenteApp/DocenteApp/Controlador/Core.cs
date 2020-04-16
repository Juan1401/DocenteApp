using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DocenteApp
{
    public static class Core
    {
        public static int ScreenWidh { get; set; }
        public static int Screenheigh { get; set; }

        public static ImageSource LogoUtap { get; } = ImageSource.FromFile("LogoUtap.png");
        public static ImageSource IconoBack { get; } = ImageSource.FromFile("IconoBack.png");
        public static ImageSource plus { get; } = ImageSource.FromFile("plus.png");

    }
}
