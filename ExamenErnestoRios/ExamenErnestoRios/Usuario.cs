using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenErnestoRios
{
    [Serializable]
    class Usuario
    {
        string nombre;
        int puntaje;

        public Usuario(string usuario1)
        {
            nombre = usuario1;
            puntaje = 0;
        }

        public string GetNombre()
        {
            return nombre;
        }
        public int GetPuntaje()
        {
            return puntaje;
        }
        public void GuardarPuntaje(int p)
        {
            if(p>puntaje)
            {
                puntaje = p;
            }
        }
    }
}
