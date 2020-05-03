using DocenteApp.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocenteApp
{
    public interface IRestApi
    {
        ResponseAPI LoginApp(string Identificación, string CodigoPro, string Contraseña);
    }
}
