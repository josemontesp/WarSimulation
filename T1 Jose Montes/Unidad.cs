using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public abstract class Unidad : Guerra
    {
        //https://www.facebook.com/notes/new-facebook-text-ascii-art-icons-/new-facebook-text-ascii-art-icons-just-copy-and-paste/142360199110636
        //iconos
        public string icono = "0";
        public int[] posicion;
        public Tipo tipo;
        public int hpInicial;
        public int hpActual;
        public int dañoMecanico;
        public int dañoNoMecanico;
        public int rango;
        public int velocidad;
        public bandos bandera;
        public enum Tipo { aereo, terrestre };

        public string info()
        {
            return this.GetType().Name +" (" + this.icono + ") "+ "HP = " + this.hpActual + "/" + this.hpInicial;
        }
        
        public virtual string atacar(Unidad victima, Mapa mapa, Batallon bvictima, Batallon bAtacante) //Aplicar polimorfismo
        {
            var dañoRecibido = victima.recibirDaño(this.dañoMecanico, this.dañoNoMecanico);
            Console.SetCursorPosition(0,27);
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
        
        public abstract int recibirDaño(int mecanico, int noMecanico);

        public virtual bool moverse(Mapa mapa, int[] pos2) //Por defecto para terrestres
        {
            if (pos2[0] < 1 || pos2[1] < 1 || mapa.matrizTerrestre[pos2[0] - 1, pos2[1] - 1] is Unidad)
            {
                Console.SetCursorPosition(0, 29);

                return false;
               //Console.WriteLine("No puede moverse a un espacio ocupado");
            }
            else
            {

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

        public abstract List<Unidad> objetivosDisparables(int[] pos, Mapa mapa);

        public abstract List<Unidad> ObjetivosProximos(Mapa mapa);

        public virtual Unidad priorizarObjetivo(List<Unidad> lista)
        {
            lista.OrderBy(u => u.hpActual - u.hpInicial);
            return lista[0];
        }

    }
}
