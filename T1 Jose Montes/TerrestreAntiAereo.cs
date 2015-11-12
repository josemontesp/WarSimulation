using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public class TerrestreAntiAereo : Terrestres
    {
        public TerrestreAntiAereo(bandos bando, int[] pos)
        {
            //Atributos de Unidad
            this.icono = "♂";
            this.posicion = pos;
            this.tipo = Tipo.terrestre;
            this.hpInicial = 300 + randy.Next(-20, 20);
            this.hpActual = this.hpInicial*1;
            this.dañoMecanico = 200 + randy.Next(-50, 50);
            this.dañoNoMecanico = 0;
            this.rango = 6;
            this.velocidad = randy.Next(4, 5);
            this.bandera = bando;
            //Atributos de Mecanicos
            this.capacidadEstanque = 50;
            this.combustible = this.capacidadEstanque;
            this.CombustiblePorUnidad = 4;
            this.tiempoDeReposicion = 3; 
        }
        public override string atacar(Unidad victima, Mapa mapa, Batallon bvictima, Batallon bAtacante) //Aplicar polimorfismo
        {
            if (victima is Base)
            {
                return null;
            }
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
            return (this.GetType().Name + " (" + this.icono + ") " + " Ha hecho " + dañoRecibido + " de daño a " + victima.GetType().Name + " (" + victima.icono + ") " + "(HP=" + victima.hpActual + "/" + victima.hpInicial + ")");
        }

        public override int recibirDaño(int mecanico, int noMecanico)
        {
            this.hpActual -= mecanico;
            return mecanico;
        }

        public override bool moverse(Mapa mapa, int[] pos2) //Por defecto para terrestres
        {
            if (pos2[0] < 1 || pos2[1] < 1 || mapa.matrizTerrestre[pos2[0] - 1, pos2[1] - 1] is Unidad)
            {
                Console.SetCursorPosition(0, 29);

                return false;
                //Console.WriteLine("No puede moverse a un espacio ocupado");
            }
            else
            {
                if (this.combustible < this.CombustiblePorUnidad)
                {
                    if (this.tiempoRestante == 1)
                    {
                        this.tiempoRestante = 0;
                        this.combustible = this.capacidadEstanque * 1;
                        return true;
                    }
                    else
                    {
                        this.tiempoRestante -= 1;
                    }
                }

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                var a = mapa.eliminarTerrestre(this.posicion);
                mapa.agregarTerrestre(pos2, a);

                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(this.posicion[0], this.posicion[1]);
                if (mapa.entregarElemento(this.posicion[0], this.posicion[1], Tipo.aereo) is Unidad)
                {
                    if (mapa.entregarElemento(this.posicion[0], this.posicion[1], Tipo.aereo).bandera == bandos.azul)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
                Console.Write(mapa.entregaricono(this.posicion[0], this.posicion[1]));

                if (bandera == bandos.azul)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.SetCursorPosition(pos2[0], pos2[1]);

                Console.Write(this.icono);
                this.posicion = pos2;
                return true;
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
                        if (mapa.matrizAerea[i - 1, j - 1] is Mecanicos && mapa.matrizAerea[i - 1, j - 1].bandera != this.bandera && !(i == this.posicion[0] && j == this.posicion[1]))
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
