using DocenteApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace DocenteApp
{
   public static class Storage
    {
        public static Sesion getSession()
        {
            bool exist = DependencyService.Get<IFileManager>().exist(Core.nombre_archivo_sesion);
            if (exist)
            {
                var sessionJson = DependencyService.Get<IFileManager>().LoadText(Core.nombre_archivo_sesion);

                try
                {
                    return JsonConvert.DeserializeObject<Sesion>(sessionJson);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error parsing Session from disk:" + e.Message);
                    //deleteSession();  
                    return null;
                };
            }
            else
            {
                Console.WriteLine("No Sesion Stored");
                return null;
            }   
        }

        public static void saveSession(Sesion session)
        {

            var sessionJson = JsonConvert.SerializeObject(session);
            DependencyService.Get<IFileManager>().SaveText(Core.nombre_archivo_sesion, sessionJson);
            Console.WriteLine("Session Saved: id" + session.Codigo_Estudiante);

        }
        public static void deleteSession() 
        {
            var deleted = DependencyService.Get<IFileManager>().delete(Core.nombre_archivo_sesion);
            Console.WriteLine("Session, stored Deleted:" + deleted);

        }
    }
}
