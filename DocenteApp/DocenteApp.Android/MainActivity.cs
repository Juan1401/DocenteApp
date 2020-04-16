using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace DocenteApp.Droid
{
    [Activity(Label = "Docentes App", RoundIcon = "@mipmap/launcher_foreground", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());




            var metricas = Resources.DisplayMetrics;

            Core.ScreenWidh = ConvertPixelsToDpi(metricas.WidthPixels);
            Core.Screenheigh = ConvertPixelsToDpi(metricas.HeightPixels);


            Console.WriteLine("Ancho de mi pantalla " + Core.ScreenWidh);
            Console.WriteLine("Alto de mi pantalla " + Core.Screenheigh);

        }
        int ConvertPixelsToDpi(float pixelsValue)
        {
            var dp = (int)(pixelsValue / Resources.DisplayMetrics.Density);
            return dp;
        }
    }
}