using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    class Desmoralizador : Soporte
    {
        public Desmoralizador(bandos bando, int[] pos)
        {
            //Atributos de Unidad
            this.icono = "♀";
            this.posicion = pos;
            this.tipo = Tipo.terrestre;
            this.hpInicial = 225 + randy.Next(-25, 25);
            this.hpActual = this.hpInicial;
            this.dañoMecanico = 1;
            this.dañoNoMecanico = 0;
            this.rango = 3;
            this.velocidad = 5;
            this.bandera = bando;
            //Atributos de Soporte
            this.enfriamiento = 3;
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
            int a = new Random().Next(1, 2);
            if (a==1) //Velocidad
            {
                victima.velocidad /= 2;
                this.TurnosParaUsarPoder = this.enfriamiento * 1;
                return (this.GetType().Name + " (" + this.icono + ") " + " Ha hecho mas lento por 4 turnos a " + victima.GetType().Name + " (" + victima.icono + ") ");
            }
            else // Daño
            {
                victima.dañoMecanico /= 2;
                victima.dañoNoMecanico /= 2;
                this.TurnosParaUsarPoder = this.enfriamiento * 1;
                return (this.GetType().Name + " (" + this.icono + ") " + " Ha bajado el daño a la mitad a " + victima.GetType().Name + " (" + victima.icono + ") ");
            }
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
