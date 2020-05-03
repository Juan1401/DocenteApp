using DocenteApp.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocenteApp
{
   public interface IRestApiForgot
   {
      ResponseAPI Forgot(string CorreoForgot);
   }
}
