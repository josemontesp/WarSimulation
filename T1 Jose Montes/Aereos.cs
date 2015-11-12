using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public abstract class Aereos : Mecanicos
    {
        public override bool moverse(Mapa mapa, int[] pos2)
        {
            if (pos2[0] < 1 || pos2[1] < 1 || mapa.matrizAerea[pos2[0] - 1, pos2[1] - 1] is Unidad)
            {
                
                Console.SetCursorPosition(0, 27);
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
                        this.combustible = this.capacidadEstanque*1;
                        return true;
                    }
                    else
                    {
                        this.tiempoRestante -= 1;
                    }
                }
                this.combustible -= this.CombustiblePorUnidad;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                var a = mapa.eliminarAereo(this.posicion);
                mapa.agregarAereo(pos2, a);
                
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(this.posicion[0],this.posicion[1]);
                if (mapa.entregarElemento(this.posicion[0], this.posicion[1], Tipo.terrestre) is Unidad)
                {
                    if (mapa.entregarElemento(this.posicion[0], this.posicion[1], Tipo.terrestre).bandera == bandos.azul)
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
    }
}
