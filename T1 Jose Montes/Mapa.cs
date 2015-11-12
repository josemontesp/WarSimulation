using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public class Mapa : Guerra//Coordenadas de (1,1) en la esquina superior izquierda
    {
        public Unidad[,] matrizTerrestre = new Unidad[79, 25];
        public Unidad[,] matrizAerea = new Unidad[79, 25];
        Random rand = new Random();
 
        public void mostrarMapa(){
            Console.Clear();
            Console.WindowWidth = 82;
            Console.WindowHeight = 50;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("#################################################################################\n");
            for (int j = 0; j < 25; j++)
            {
                Console.Write("#");
                for (int i = 0; i < 79; i++)
                {
                    var aire = matrizAerea[i, j];
                    var tierra = matrizTerrestre[i, j];

                    if (aire is Unidad && tierra is Unidad)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(aire.icono);
                    }
                    else if (aire is Unidad)
                    {
                        if (aire.bandera == bandos.azul)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(aire.icono);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(aire.icono);
                        }
                    }
                    else if (tierra is Unidad)
                    {
                        if (tierra.bandera == bandos.azul)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(tierra.icono);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(tierra.icono);
                        }
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("·");
                    }

                }
                Console.Write("#\n");
            }
            Console.Write("#################################################################################\n");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void cambiar(int[] pos, Unidad nuevo) 
        {
            if (nuevo.tipo == Unidad.Tipo.aereo)
            {
                this.matrizAerea[pos[0] - 1, pos[1] - 1] = nuevo;
            }
            else if (nuevo.tipo == Unidad.Tipo.terrestre)
            {
                this.matrizTerrestre[pos[0] - 1, pos[1] - 1] = nuevo;
            }
            else
            {
                Console.WriteLine("No es de tipo aereo ni terrestre");
            }
        }

        public Unidad eliminarAereo(int[] pos)
        {
            var a = matrizAerea[pos[0] - 1, pos[1] - 1];
            this.matrizAerea[pos[0] - 1, pos[1] - 1] = null;
            return a;
        }

        public void agregarAereo(int[] pos, Unidad u)
        {
            this.matrizAerea[pos[0] - 1, pos[1] - 1] = u;
        }

        public Unidad eliminarTerrestre(int[] pos)
        {
            var a = matrizTerrestre[pos[0] - 1, pos[1] - 1];
            this.matrizTerrestre[pos[0] - 1, pos[1] - 1] = null;
            return a;
        }

        public void agregarTerrestre(int[] pos, Unidad u)
        {
            this.matrizTerrestre[pos[0] - 1, pos[1] - 1] = u;
        }

        public string entregaricono(int posx, int posy)
        {
            if (this.matrizAerea[posx - 1, posy - 1] is Unidad)
            {
                return this.matrizAerea[posx - 1, posy - 1].icono;
            }
            else if (this.matrizTerrestre[posx - 1, posy - 1] is Unidad)
            {
                return this.matrizTerrestre[posx - 1, posy - 1].icono;
            }
            return "·";
        }

        public int[] espacioVacio(bandos bando)
        {
            if (bando == bandos.azul)
            {
                for (int i = 0; true; i++)
                {
                    var x = rand.Next(1, 30);
                    var y = rand.Next(1, 25);
                    if (entregaricono(x, y) == "·")
                    {
                        int[] resp = {x,y};
                        return resp;
                    }
                }
            }
            else
            {
                for (int i = 0; true; i++)
                {
                    var x = rand.Next(49, 79);
                    var y = rand.Next(1, 25);
                    if (entregaricono(x, y) == "·")
                    {
                        int[] resp = { x, y };
                        return resp;
                    }
                }
            }
            
        }

        public List<int[]> posicionesAdyacentes(int[] pos, Unidad.Tipo tipo) //Entrega las posiciones adyacentes que son caminables
        {
            List<int[]> posiciones = new List<int[]>();
            if (pos[0] == 1 && pos[1] == 1) //Manejo de casos borde
            {
                int[] a = {pos[0], pos[1]+1};
                posiciones.Add(a);
                int[] b = {pos[0]+1, pos[1]};
                posiciones.Add(b);
            }
            else if (pos[0] == 1 && pos[1] == 25)
            {
                int[] a = {pos[0], pos[1] - 1 };
                posiciones.Add(a);
                int[] b = {pos[0] + 1, pos[1] };
                posiciones.Add(b);
            }
            else if (pos[0] == 79 && pos[1] == 1)
            {
                int[] a = { pos[0], pos[1] + 1 };
                posiciones.Add(a);
                int[] b = { pos[0] - 1, pos[1] };
                posiciones.Add(b);
            }
            else if (pos[0] == 79 && pos[1] == 25)
            {
                int[] a = { pos[0], pos[1] - 1 };
                posiciones.Add(a);
                int[] b = { pos[0] - 1, pos[1] };
                posiciones.Add(b);
            }
            else if (pos[0] == 1)
            {
                int[] a = { pos[0], pos[1] - 1 };
                posiciones.Add(a);
                int[] b = { pos[0], pos[1] + 1 };
                posiciones.Add(b);
                int[] c = { pos[0] + 1, pos[1] };
                posiciones.Add(c);
            }
            else if (pos[0] == 79)
            {
                int[] a = { pos[0], pos[1] - 1 };
                posiciones.Add(a);
                int[] b = { pos[0], pos[1] + 1 };
                posiciones.Add(b);
                int[] c = { pos[0] - 1, pos[1] };
                posiciones.Add(c);
            }
            else if (pos[1] == 1)
            {
                int[] a = { pos[0] +1, pos[1]};
                posiciones.Add(a);
                int[] b = { pos[0] -1, pos[1]};
                posiciones.Add(b);
                int[] c = { pos[0], pos[1] +1};
                posiciones.Add(c);
            }
            else if (pos[1] == 25)
            {
                int[] a = { pos[0] + 1, pos[1]};
                posiciones.Add(a);
                int[] b = { pos[0] - 1, pos[1]};
                posiciones.Add(b);
                int[] c = { pos[0], pos[1] -1};
                posiciones.Add(c);
            }
            else //Termino de manejo de casos borde
            {
                int[] a = { pos[0] + 1, pos[1]};
                posiciones.Add(a);
                int[] b = { pos[0], pos[1] + 1 };
                posiciones.Add(b);
                int[] c = { pos[0] -1, pos[1]};
                posiciones.Add(c);
                int[] d = { pos[0], pos[1] - 1 };
                posiciones.Add(d);
            }
            List<int[]> posicionesf = new List<int[]>();
            if (tipo == Unidad.Tipo.terrestre)
            {
                foreach (int[] i in posiciones)
                {
                    if (!(this.matrizTerrestre[i[0] - 1, i[1] - 1] is Unidad))
                    {
                        posicionesf.Add(i);
                    }
                }
            }
            else
            {
                foreach (int[] i in posiciones)
                {
                    if (!(this.matrizAerea[i[0] - 1, i[1] - 1] is Unidad))
                    {
                        posicionesf.Add(i);
                    }
                }
            }
            
            return posicionesf;
        }

        public List<int[]> alcanzables = new List<int[]>();

        public bool inLista(List<int[]> lista, int[] parametro)
        {
            foreach (int[] i in lista)
            {
                if (i[0] == parametro[0] && i[1] == parametro[1])
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void encontrarPosAlcanzable(int[] pos, int distanciaPorAvanzar, Unidad.Tipo tipo, bool inicio) // Retorna una lista con coordenadas caminables dado un rango
        {
            if (inicio && alcanzables.Count != 0)
            {
                alcanzables.Clear();
            }

            foreach (int[] i in this.posicionesAdyacentes(pos, tipo))
            {
                if (!(inLista(alcanzables, i)))
                {
                    alcanzables.Add(i);
                    if (distanciaPorAvanzar > 0)
                    {
                        encontrarPosAlcanzable(i, distanciaPorAvanzar - 1, tipo, false);
                    }
                }
            }
        }

        public Unidad entregarElemento(int posx, int posy, Unidad.Tipo tipo)
        {
            if (tipo == Unidad.Tipo.terrestre)
            {
                 return this.matrizTerrestre[posx-1, posy-1];
            }
            else
            {
                return this.matrizAerea[posx - 1, posy - 1];
            }
        }
    }
}
