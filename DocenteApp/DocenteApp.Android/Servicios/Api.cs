using DocenteApp.Droid;
using DocenteApp.Interfaces;
using DocenteApp.Modelo;
using Newtonsoft.Json;
using RestSharp;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(Api))]

[assembly: Dependency(typeof(ApiForgot))]

namespace DocenteApp.Droid
{
    public class Api : IRestApi
    {
        public ResponseAPI LoginApp(string Identificación, string CodigoPro, string Contraseña)
        {
            try  //try y catch creado para mitigar los errores.
            {
                RestClient _Client = new RestClient("http://todoapijjq.azurewebsites.net/api/login/authenticate");  //viene de la libreria RestSharp
                RestRequest _request = new RestRequest("", Method.POST)
                { RequestFormat = DataFormat.Json };

                //_request.AddBody();

               _request.AddParameter("Identificación", Identificación);
               _request.AddParameter("CodigoPro", CodigoPro); //Codigo que pongamos en el API    
               _request.AddParameter("Contraseña", Contraseña);


                var respuesta = _Client.Execute(_request);
                Console.WriteLine("The Server return:" + respuesta.Content);

                var responseAPI = JsonConvert.DeserializeObject<ResponseAPI>(respuesta.Content);
                
                return responseAPI;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
    public class ApiForgot : IRestApiForgot
    {
        public ResponseAPI Forgot(string CorreoForgot)
        {
            try 
            {
                RestClient _Client = new RestClient("http://todoapijjq.azurewebsites.net/api/login/Forgot");
                RestRequest _request = new RestRequest("", Method.POST)
                { RequestFormat = DataFormat.Json };

                _request.AddParameter("CorreoForgot", CorreoForgot);


                var respuesta = _Client.Execute(_request);
                Console.WriteLine("The Server return:" + respuesta.Content);

                var responseAPI = JsonConvert.DeserializeObject<ResponseAPI>(respuesta.Content);

                return responseAPI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}