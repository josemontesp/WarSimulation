using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public class Arquero : Infanteria
    {
        public Arquero(bandos bando, int[] pos)
        {
            //Atributos de Unidad
            this.icono = "↔";
            this.posicion = pos;
            this.tipo = Tipo.terrestre;
            this.hpInicial = 150 + randy.Next(-25, 25);
            this.hpActual = this.hpInicial;
            this.dañoMecanico = 100 + randy.Next(-15, 15);
            this.dañoNoMecanico = 80 + randy.Next(-20, 20);
            this.rango = 4;
            this.velocidad = 5;
            this.bandera = bando;
            
        }
        public override int recibirDaño(int mecanico, int noMecanico)
        {
            this.hpActual -= noMecanico;
            return noMecanico;
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
                        if (mapa.matrizTerrestre[i - 1, j - 1] is Unidad && mapa.matrizTerrestre[i - 1, j - 1].bandera != this.bandera && !(i == 0 && j == 0))
                        {
                            adyacentes.Add(mapa.matrizTerrestre[i - 1, j - 1]);
                        }
                        if (mapa.matrizAerea[i - 1, j - 1] is Unidad && mapa.matrizAerea[i - 1, j - 1].bandera != this.bandera && !(i == 0 && j == 0))
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
