using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DocenteApp
{
    public class Validaciones
    {
        public bool VerificarCorreo(Entry usuario)
        {
            if (String.IsNullOrEmpty(usuario.Text))
            {
                return true;
            }
            if (!usuario.Text.Contains("."))
            {
                return true;
            }

            if (!usuario.Text.Contains("@"))
            {
                return true;
            }
            //FIN
            else
                return false;
        }

        public bool ValidarCajasTexto2(Entry password)
        {
            if (String.IsNullOrEmpty(password.Text))
            {
                return true;
            }

            else
                return false;

        }
        //Creamos metodo para validar el tamaño de la contraseña 8>caracter y que retorne un booleano

        public bool ValidarPassword(Entry password)
        {
            //8
            if (String.IsNullOrEmpty(password.Text))
            {
                return true;
            }
            if (password.Text.Length >= 8)
                return true;
            else
                return false;
        }

        public bool ValidarDocumento(Entry Documento_Nu)
        {
            //8
            if (String.IsNullOrEmpty(Documento_Nu.Text))
            {
                return true;
            }
            if (Documento_Nu.Text.Length == 10)
                return true;

            else
                return false;
        }

        public bool ValidarDocumento_Nu(Entry Documento_Nu)
        {
            if (String.IsNullOrEmpty(Documento_Nu.Text))
            {
                return true;
            }
            if (!Documento_Nu.Text.ToCharArray().All(Char.IsDigit))
            {
                return true;
            }
            else
                return false;
        }
    }
}
