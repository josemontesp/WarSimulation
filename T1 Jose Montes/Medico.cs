using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public class Medico : Soporte
    {
        public Medico(bandos bando, int[] pos)
        {
            //Atributos de Unidad
            this.icono = "+";
            this.posicion = pos;
            this.tipo = Tipo.terrestre;
            this.hpInicial = 100 + randy.Next(-20, 20);
            this.hpActual = this.hpInicial;
            this.dañoMecanico = 1;
            this.dañoNoMecanico = 0;
            this.rango = 1;
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
                return (this.GetType().Name + " (" + this.icono + ") " + " Debe esperar " + this.TurnosParaUsarPoder + " turnos más para curar");
            }
            victima.hpActual += 100;
            if (victima.hpActual > victima.hpInicial)
            {
                victima.hpActual = victima.hpInicial*1;
            }
            Console.SetCursorPosition(0, 27);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" ");
            Console.SetCursorPosition(0, 27);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            this.TurnosParaUsarPoder = this.enfriamiento * 1;
            return (this.GetType().Name + " (" + this.icono + ") " + " Ha sanado 100 HP a " + victima.GetType().Name + " (" + victima.icono + ") " + "(HP=" + victima.hpActual + "/" + victima.hpInicial + ")");
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
                        if (mapa.matrizTerrestre[i - 1, j - 1] is NoMecanico && mapa.matrizTerrestre[i - 1, j - 1].bandera == this.bandera && !(i == 0 && j == 0))
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
            u.RemoveAll(x => x.hpActual + 10 > x.hpInicial);
            return u;
        }

        public override Unidad priorizarObjetivo(List<Unidad> lista)
        {
            if (lista.Count == 0)
            {
                return this;
            }
            lista.OrderBy(u => (u.hpActual-u.hpInicial)*-1);
            var a = lista;
            return lista[0];
        }

    }
}
