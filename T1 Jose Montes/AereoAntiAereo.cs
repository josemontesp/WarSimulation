using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public class AereoAntiAereo : Aereos
    {
        public AereoAntiAereo(bandos bando, int[] pos)
        {
            //Atributos de Unidad
            this.icono = "ε";
            this.posicion = pos;
            this.tipo = Tipo.aereo;
            this.hpInicial = 250 + randy.Next(-10, 10);
            this.hpActual = this.hpInicial;
            this.dañoMecanico = 100 + randy.Next(-25, 25);
            this.dañoNoMecanico = 0;
            this.rango = 2;
            this.velocidad = 10;
            this.bandera = bando;
            //Atributos de Mecanicos
            this.capacidadEstanque = 60;
            this.combustible = this.capacidadEstanque;
            this.CombustiblePorUnidad = 3;
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
            for (int i = pos[0] - this.rango; i <= pos[0] + this.rango; i++)
            {
                for (int j = pos[1] - this.rango; j <= pos[1] + this.rango; j++)
                {
                    if (i >= 1 && j >= 1 && j <= 25 && i <= 79)
                    {
                        if (mapa.matrizAerea[i - 1, j - 1] is Unidad && (mapa.matrizAerea[i - 1, j - 1].bandera != this.bandera) && !(i == 0 && j == 0))
                            {
                                adyacentes.Add(mapa.matrizAerea[i - 1, j - 1]);
                            }
                    }
                    
                }
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
