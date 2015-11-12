using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public class Kamikaze : Infanteria
    {
        public Kamikaze(bandos bando, int[] pos)
        {
            //Atributos de Unidad
            this.icono = "¤";
            this.posicion = pos;
            this.tipo = Tipo.terrestre;
            this.hpInicial = 110 + randy.Next(-10, 10);
            this.hpActual = this.hpInicial;
            this.dañoMecanico = 450 + randy.Next(-50, 50);
            this.dañoNoMecanico = 150 + randy.Next(-30, 30);
            this.rango = 1;
            this.velocidad = 9;
            this.bandera = bando;
        }
        public override int recibirDaño(int mecanico, int noMecanico)
        {
            this.hpActual -= noMecanico;
            return noMecanico;
        }

        public override string atacar(Unidad victima, Mapa mapa, Batallon bvictima, Batallon bAtacante) //Aplicar polimorfismo
        {
            var dañoRecibido = victima.recibirDaño(this.dañoMecanico, this.dañoNoMecanico);
            Console.SetCursorPosition(0, 27);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" ");
            Console.SetCursorPosition(0, 27);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            if (victima.hpActual <= 0)
            {
                bvictima.eliminarUnidad(mapa, victima);
            }
            this.hpActual = -100;
            mapa.matrizTerrestre[this.posicion[0] - 1, this.posicion[1] - 1] = null;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(this.posicion[0], this.posicion[1]);
            Console.Write("·");
            return (this.GetType().Name + " (" + this.icono + ") " + " Ha hecho " + dañoRecibido + " de daño a " + victima.GetType().Name + " (" + victima.icono + ") " + "(HP=" + victima.hpActual + "/" + victima.hpInicial + ")");
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
