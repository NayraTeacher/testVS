using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensayo
{
    abstract class Actividad
    {
        string nombre;
        int dificultad;
        string localizacion;
        DateTime fecha;
        public Actividad (string nombre,int dificultad,string localizacion,DateTime fecha)
        {
            this.nombre = nombre;
            this.dificultad = dificultad;
            this.localizacion = localizacion;
            this.fecha = fecha;
        }
        abstract void CrearNueva
        {

        }
        
        




    }
}
