using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public class Groupie : Soporte
    {
        public Groupie(bandos bando, int[] pos)
        {
            //Atributos de Unidad
            this.icono = "♣";
            this.posicion = pos;
            this.tipo = Tipo.terrestre;
            this.hpInicial = 150 + randy.Next(-25, 25);
            this.hpActual = this.hpInicial;
            this.dañoMecanico = 1;
            this.dañoNoMecanico = 0;
            this.rango = 1;
            this.velocidad = randy.Next(7, 8);
            this.bandera = bando;
            //Atributos de Soporte
            this.enfriamiento = 7;
        }
        public override int recibirDaño(int mecanico, int noMecanico)
        {
            this.hpActual -= noMecanico;
            return noMecanico;
        }

        public override string atacar(Unidad victima, Mapa mapa, Batallon bvictima, Batallon bAtacante) //Aplicar polimorfismo
        {
            if (this.TurnosParaUsarPoder > 0)
            {
                this.TurnosParaUsarPoder -= 1;
                return (this.GetType().Name + " (" + this.icono + ") " + " Debe esperar " + this.TurnosParaUsarPoder + " turnos más para usar habilidad");
            }

            //Uso de habilidad
            this.TurnosParaUsarPoder = this.enfriamiento * 1;
            int a = new Random().Next(0, 100);
            if (a < 60)
            {
                victima.bandera = this.bandera;
                return (this.GetType().Name + " (" + this.icono + ") " + " Neo-Wololeó a " + victima.GetType().Name + " (" + victima.icono + ") ");
            }
            return (this.GetType().Name + " (" + this.icono + ") " + " Trató de Neo-Wololear a " + victima.GetType().Name + " (" + victima.icono + ") " + " pero no pudo");
            
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
