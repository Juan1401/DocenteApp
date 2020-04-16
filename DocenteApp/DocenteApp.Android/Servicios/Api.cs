using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestSharp;

namespace DocenteApp.Droid.Servicios
{
    public class Api : IRestApi
    {
        public bool CreateClients()
        {
            try  //try y catch creado para mitigar los errores.
            {
                RestClient _Client = new RestClient("http://192.168.43.111/ProjectMVC.MobileP/api/Parcial/Prueba");  //viene de la libreria RestSharp
                RestRequest _request = new RestRequest("", Method.POST)
                { RequestFormat = DataFormat.Json };

                //_request.AddBody();

                var respuesta = _Client.Execute(_request);
                Console.WriteLine("The Server return:" + respuesta.Content);

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}