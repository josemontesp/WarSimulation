using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public class Bombardero : Aereos
    {
        public Bombardero(bandos bando, int[] pos)
        {
            //Atributos de Unidad
            this.icono = "!";
            this.posicion = pos;
            this.tipo = Tipo.aereo;
            this.hpInicial = 40 + randy.Next(-5, 5);
            this.hpActual = this.hpInicial;
            this.dañoMecanico = 250 + randy.Next(-50, 50);
            this.dañoNoMecanico = 300 + randy.Next(-50, 50);
            this.rango = 0;
            this.velocidad = 10;
            this.bandera = bando;
            //Atributos de Mecanicos
            this.capacidadEstanque = 120;
            this.combustible = this.capacidadEstanque;
            this.CombustiblePorUnidad = 4;
            this.tiempoDeReposicion = 6; 
        }
        public override int recibirDaño(int mecanico, int noMecanico)
        {
            this.hpActual -= mecanico;
            return mecanico;
        }

        public override List<Unidad> objetivosDisparables(int[] pos, Mapa mapa)
        {
            List<Unidad> adyacentes = new List<Unidad>();
            if (mapa.matrizTerrestre[pos[0] - 1, pos[1] - 1] is Unidad && mapa.matrizTerrestre[pos[0] - 1, pos[1] - 1].bandera != this.bandera)
            {
                adyacentes.Add(mapa.matrizTerrestre[pos[0] - 1, pos[1] - 1]);
            }
            return adyacentes;
        }

        public override List<Unidad> ObjetivosProximos(Mapa mapa)
        {
            List<Unidad> u = new List<Unidad>();
            mapa.encontrarPosAlcanzable(this.posicion, this.velocidad, this.tipo, true);
            foreach (int[] i in mapa.alcanzables)
            {
                var adyacentes = objetivosDisparables(i, mapa);
                if (adyacentes.Count != 0)
                {
                    foreach (Unidad a in adyacentes)
                    {
                        if (!(u.Contains(a)))
                        {
                            u.Add(a);
                        }
                    }
                }
            }
            return u;
        }



    }
}
