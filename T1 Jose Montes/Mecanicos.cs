using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public abstract class Mecanicos : Unidad
    {
        public int capacidadEstanque;
        public int combustible = 0;
        public int tiempoDeReposicion;
        public int tiempoRestante = 0;
        public int CombustiblePorUnidad;
    }
}
