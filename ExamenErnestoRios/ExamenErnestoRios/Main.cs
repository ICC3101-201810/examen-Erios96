using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenErnestoRios
{
    [Serializable]
    class Main
    {
        List<Usuario> usuarios = new List<Usuario>();

        public Main()
        {

        }
        public bool GuardarUsuario(string nombre)
        {
            bool x = true;
            foreach(Usuario u in usuarios)
            {
                if(u.GetNombre() == nombre)
                {
                    x = false;
                }
            }
            if(x)
            {
                Usuario u1 = new Usuario(nombre);
            }
            return x;
        }

    }
}
