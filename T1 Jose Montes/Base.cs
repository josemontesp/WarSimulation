using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public class Base : Unidad
    {
        public Base(bandos bando, int[] pos)
        {
            this.icono = "█";
            this.hpInicial = 8000;
            this.posicion = pos;
            this.hpActual = hpInicial;
            this.bandera = bando;
            this.tipo = Tipo.terrestre;
        }
        public override int recibirDaño(int mecanico, int noMecanico)
        {
            this.hpActual -= mecanico;
            return mecanico;
        }
        public override List<Unidad> objetivosDisparables(int[] pos, Mapa mapa)
        {
            throw new NotImplementedException();
        }
        public override List<Unidad> ObjetivosProximos(Mapa mapa)
        {
            throw new NotImplementedException();
        }

    }
}
