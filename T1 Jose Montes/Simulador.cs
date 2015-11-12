using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace T1_Jose_Montes
{
    public class Simulador
    {
        
        public Batallon bat1; // Azul
        public Batallon bat2; // Rojo
        public Mapa mapa;
        public Base b1; //Azul
        public Base b2; // Roja
        public Random randy = new Random();

        public void prepararEstados()
        {
            Console.Title = "Zod-To vs Dr. Fadic";
            this.mapa = new Mapa();
            
            int[] posBase1 = { 3, 3 };
            int[] posBase2 = { 75, 20 };
            this.b1 = new Base(Guerra.bandos.azul, posBase1);
            mapa.cambiar(posBase1, b1);
            posBase1[0] += 1;
            mapa.cambiar(posBase1, b1);
            posBase1[1] += 1;
            mapa.cambiar(posBase1, b1);
            posBase1[0] -= 1;
            mapa.cambiar(posBase1, b1);

            this.b2 = new Base(Guerra.bandos.rojo, posBase2);
            mapa.cambiar(posBase2, b2);
            posBase2[0] += 1;
            mapa.cambiar(posBase2, b2);
            posBase2[1] += 1;
            mapa.cambiar(posBase2, b2);
            posBase2[0] -= 1;
            mapa.cambiar(posBase2, b2);
            

            Console.WriteLine("Bienvenido!\n (1) Para simular con un ejercito por defecto\n (2) Para crear un ejercito a tu gusto");
            var a = Console.ReadKey().KeyChar.ToString();
            Console.Clear();
            if (a == "1")
            {
                Console.WriteLine("Elija el tamaño de cada ejercito. 1-9");
                var b = Int32.Parse(Console.ReadKey().KeyChar.ToString());
                this.bat1 = new Batallon(mapa, Guerra.bandos.azul, b, b, b, b, b, b, b, b, b, b, b);
                this.bat2 = new Batallon(mapa, Guerra.bandos.rojo, b, b, b, b, b, b, b, b, b, b, b);
            }
            else
            {
                bool cont = true;
                int a1 = 0;
                int a2 = 0;
                int a3 = 0;
                int a4 = 0;
                int a5 = 0;
                int a6 = 0;
                int a7 = 0;
                int a8 = 0;
                int a9 = 0;
                int a10 = 0;
                int a11 = 0;

                while (cont)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("Elija la cantidad de cada tipo de tropa para el ejército azul.\n Presione cualquier otra tecla para continuar\n\n");
                    Console.WriteLine("(1) Terrestre Anti-aereo : " + a1);
                    Console.WriteLine("(2) Anti-infanteria : " + a2);
                    Console.WriteLine("(3) Bombardero : " + a3);
                    Console.WriteLine("(4) Aereo Anti-Aereo : " + a4);
                    Console.WriteLine("(5) Guerrero : " + a5);
                    Console.WriteLine("(6) Kamikaze : " + a6);
                    Console.WriteLine("(7) Arquero : " + a7);
                    Console.WriteLine("(8) Ingeniero : " + a8);
                    Console.WriteLine("(9) Medico : " + a9);
                    Console.WriteLine("(0) Groupie : " + a10);
                    Console.WriteLine("(-)Desmoralizador : " + a11);
                    var b = Console.ReadKey().KeyChar.ToString();
                    if (b == "1")
                    {
                        a1+=1;
                    }
                    else if (b == "2")
                    {
                        a2++;
                    }
                    else if (b == "3")
                    {
                        a3++;
                    }
                    else if (b == "4")
                    {
                        a4++;
                    }
                    else if (b == "5")
                    {
                        a5++;
                    }
                    else if (b == "6")
                    {
                        a6++;
                    }
                    else if (b == "7")
                    {
                        a7++;
                    }
                    else if (b == "8")
                    {
                        a8++;
                    }
                    else if (b == "9")
                    {
                        a9++;
                    }
                    else if (b == "0")
                    {
                        a10++;
                    }
                    else if (b == "-")
                    {
                        a11++;
                    }
                    else
                    {
                        cont = false;
                        this.bat1 = new Batallon(mapa, Guerra.bandos.azul, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11);
                    }
                }
                cont = true;
                a1 = 0;
                a2 = 0;
                a3 = 0;
                a4 = 0;
                a5 = 0;
                a6 = 0;
                a7 = 0;
                a8 = 0;
                a9 = 0;
                a10 = 0;
                a11 = 0;
                while (cont)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("Elija la cantidad de cada tipo de tropa para el ejército rojo.\n Presione cualquier otra tecla para continuar\n\n");
                    Console.WriteLine("(1) Terrestre Anti-aereo : " + a1);
                    Console.WriteLine("(2) Anti-infanteria : " + a2);
                    Console.WriteLine("(3) Bombardero : " + a3);
                    Console.WriteLine("(4) Aereo Anti-Aereo : " + a4);
                    Console.WriteLine("(5) Guerrero : " + a5);
                    Console.WriteLine("(6) Kamikaze : " + a6);
                    Console.WriteLine("(7) Arquero : " + a7);
                    Console.WriteLine("(8) Ingeniero : " + a8);
                    Console.WriteLine("(9) Medico : " + a9);
                    Console.WriteLine("(0) Groupie : " + a10);
                    Console.WriteLine("(-)Desmoralizador : " + a11);
                    var b = Console.ReadKey().KeyChar.ToString();
                    if (b == "1")
                    {
                        a1 += 1;
                    }
                    else if (b == "2")
                    {
                        a2++;
                    }
                    else if (b == "3")
                    {
                        a3++;
                    }
                    else if (b == "4")
                    {
                        a4++;
                    }
                    else if (b == "5")
                    {
                        a5++;
                    }
                    else if (b == "6")
                    {
                        a6++;
                    }
                    else if (b == "7")
                    {
                        a7++;
                    }
                    else if (b == "8")
                    {
                        a8++;
                    }
                    else if (b == "9")
                    {
                        a9++;
                    }
                    else if (b == "0")
                    {
                        a10++;
                    }
                    else if (b == "-")
                    {
                        a11++;
                    }
                    else
                    {
                        cont = false;
                        this.bat2 = new Batallon(mapa, Guerra.bandos.rojo, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11);
                    }
                }


            }

            mapa.mostrarMapa();

            
            
            

            
        }

        public bool seMovio = false;

        public void ejecutarSimulacion()
        {
            while (continuarSimulacion())
            {
                Console.Beep(); // Bip!
                int sleep = 0;
                string mensaje1 = "";
                seMovio = false;
                foreach (Unidad u in bat1.batallon)
                {
                    for (int d=0; d <= u.velocidad; d++)
                    {
                        System.Threading.Thread.Sleep(sleep);
                        List<Unidad> proximos = u.ObjetivosProximos(mapa);
                        if (proximos.Count() > 0)
                        {
                            Unidad victima = u.priorizarObjetivo(proximos);
                            if (victima.posicion[0] > u.posicion[0])
                            {
                                int[] pos2 = { u.posicion[0] + 1, u.posicion[1] };
                                seMovio = u.moverse(mapa, pos2);
                                var i = 0;
                                while (!seMovio)
                                {
                                    i++;
                                    int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                    seMovio = u.moverse(mapa, pos3);
                                    if (i > 100)
                                    {
                                        seMovio = true;
                                    }
                                }
                            }
                            else if (victima.posicion[0] < u.posicion[0])
                            {
                                int[] pos2 = { u.posicion[0] - 1, u.posicion[1] };
                                seMovio = u.moverse(mapa, pos2);
                                var i = 0;
                                while (!seMovio)
                                {
                                    i++;
                                    int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                    seMovio = u.moverse(mapa, pos3);
                                    if (i > 100)
                                    {
                                        seMovio = true;
                                    }
                                }
                            }
                            else if (victima.posicion[1] < u.posicion[1])
                            {
                                int[] pos2 = { u.posicion[0], u.posicion[1] - 1 };
                                seMovio = u.moverse(mapa, pos2);
                                var i = 0;
                                while (!seMovio)
                                {
                                    i++;
                                    int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                    seMovio = u.moverse(mapa, pos3);
                                    if (i > 100)
                                    {
                                        seMovio = true;
                                    }
                                }
                            }
                            else if (victima.posicion[1] > u.posicion[1])
                            {
                                int[] pos2 = { u.posicion[0], u.posicion[1] + 1 };
                                seMovio = u.moverse(mapa, pos2);
                                var i = 0;
                                while (!seMovio)
                                {
                                    i++;
                                    int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                    seMovio = u.moverse(mapa, pos3);
                                    if (i > 100)
                                    {
                                        seMovio = true;
                                    }
                                }
                            }
                            if (Math.Pow((victima.posicion[0] - u.posicion[0]), 2) + Math.Pow((victima.posicion[1] - u.posicion[1]), 2) <= Math.Pow(u.rango, 2))
                            {
                                mensaje1 += u.atacar(victima, mapa, bat2, bat1) + "\n";
                                d = u.velocidad + 10;
                            }
                            
                        }
                        else // Cuando no tiene enemigos cerca y quiere acercarse a la base enemiga
                        {
                            
                                if (b2.posicion[0] > u.posicion[0])
                                {
                                    int[] pos2 = { u.posicion[0] + 1, u.posicion[1] };
                                    seMovio = u.moverse(mapa, pos2);
                                    var i = 0;
                                    while (!seMovio)
                                    {
                                        i++;
                                        int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                        seMovio = u.moverse(mapa, pos3);
                                        if (i > 100)
                                        {
                                            seMovio = true;
                                        }
                                    }
                                }
                                else if (b2.posicion[0] < u.posicion[0])
                                {
                                    int[] pos2 = { u.posicion[0] - 1, u.posicion[1] };
                                    seMovio = u.moverse(mapa, pos2);
                                    var i = 0;
                                    while (!seMovio)
                                    {
                                        i++;
                                        int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                        seMovio = u.moverse(mapa, pos3);
                                        if (i > 100)
                                        {
                                            seMovio = true;
                                        }
                                    }
                                }
                                else if (b2.posicion[1] < u.posicion[1])
                                {
                                    int[] pos2 = { u.posicion[0], u.posicion[1] - 1 };
                                    seMovio = u.moverse(mapa, pos2);
                                    var i = 0;
                                    while (!seMovio)
                                    {
                                        i++;
                                        int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                        seMovio = u.moverse(mapa, pos3);
                                        if (i > 100)
                                        {
                                            seMovio = true;
                                        }
                                    }
                                }
                                else if (b2.posicion[1] > u.posicion[1])
                                {
                                    int[] pos2 = { u.posicion[0], u.posicion[1] + 1 };
                                    seMovio = u.moverse(mapa, pos2);
                                    var i = 0;
                                    while (!seMovio)
                                    {
                                        i++;
                                        int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                        seMovio = u.moverse(mapa, pos3);
                                        if (i > 100)
                                        {
                                            seMovio = true;
                                        }
                                    }
                                }
                                if (Math.Pow((b2.posicion[0] - u.posicion[0]), 2) + Math.Pow((b2.posicion[1] - u.posicion[1]), 2) <= Math.Pow(u.rango, 2))
                                {
                                    mensaje1 += u.atacar(b2, mapa, bat2, bat1) + "\n";
                                    d = u.velocidad + 10;
                                }
                                
                        }
                        
                    }

                }
                
                foreach (Unidad i in bat2.batallon)
                {
                    if (i.bandera == Guerra.bandos.azul)
                    {
                        bat1.batallon.Add(i);
                    }
                }
                bat1.batallon.RemoveAll(u => u.hpActual <= 0 || u.bandera == Guerra.bandos.rojo);
                seMovio = false;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 27);
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < 60; i++)
                {
                    Console.WriteLine("                                                                                 ");
                }
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 27);
                Console.Write(mensaje1);
                Console.SetCursorPosition(0, 0);
                Console.ReadKey();
                string mensaje2 = "";
                Console.Beep(); // Bip!
                foreach (Unidad u in bat2.batallon)
                {
                    for (int d = 0; d <= u.velocidad; d++)
                    {
                        System.Threading.Thread.Sleep(sleep);
                        List<Unidad> proximos = u.ObjetivosProximos(mapa);
                        if (proximos.Count() > 0)
                        {
                            Unidad victima = u.priorizarObjetivo(proximos);
                            if (victima.posicion[0] > u.posicion[0])
                            {
                                int[] pos2 = { u.posicion[0] + 1, u.posicion[1] };
                                seMovio = u.moverse(mapa, pos2);
                                var i = 0;
                                while (!seMovio)
                                {
                                    i++;
                                    int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                    seMovio = u.moverse(mapa, pos3);
                                    if (i > 100)
                                    {
                                        seMovio = true;
                                    }
                                }
                            }
                            else if (victima.posicion[0] < u.posicion[0])
                            {
                                int[] pos2 = { u.posicion[0] - 1, u.posicion[1] };
                                seMovio = u.moverse(mapa, pos2);
                                var i = 0;
                                while (!seMovio)
                                {
                                    i++;
                                    int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                    seMovio = u.moverse(mapa, pos3);
                                    if (i > 100)
                                    {
                                        seMovio = true;
                                    }
                                }
                            }
                            else if (victima.posicion[1] < u.posicion[1])
                            {
                                int[] pos2 = { u.posicion[0], u.posicion[1] - 1 };
                                seMovio = u.moverse(mapa, pos2);
                                var i = 0;
                                while (!seMovio)
                                {
                                    i++;
                                    int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                    seMovio = u.moverse(mapa, pos3);
                                    if (i > 100)
                                    {
                                        seMovio = true;
                                    }
                                }
                            }
                            else if (victima.posicion[1] > u.posicion[1])
                            {
                                int[] pos2 = { u.posicion[0], u.posicion[1] + 1 };
                                seMovio = u.moverse(mapa, pos2);
                                var i = 0;
                                while (!seMovio)
                                {
                                    i++;
                                    int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                    seMovio = u.moverse(mapa, pos3);
                                    if (i > 100)
                                    {
                                        seMovio = true;
                                    }
                                }
                            }
                            if (Math.Pow((victima.posicion[0] - u.posicion[0]), 2) + Math.Pow((victima.posicion[1] - u.posicion[1]), 2) <= Math.Pow(u.rango , 2))
                            {
                                mensaje2 += u.atacar(victima, mapa, bat1, bat2) + "\n";
                                d = u.velocidad + 10;
                            }
                        }
                        else // Cuando no tiene enemigos cerca y quiere acercarse a la base enemiga
                        {
                            
                                if (b1.posicion[0] > u.posicion[0])
                                {
                                    int[] pos2 = { u.posicion[0] + 1, u.posicion[1] };
                                    seMovio = u.moverse(mapa, pos2);
                                    var i = 0;
                                    while (!seMovio)
                                    {
                                        i++;
                                        int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                        seMovio = u.moverse(mapa, pos3);
                                        if (i > 100)
                                        {
                                            seMovio = true;
                                        }
                                    }
                                }
                                else if (b1.posicion[0] < u.posicion[0])
                                {
                                    int[] pos2 = { u.posicion[0] - 1, u.posicion[1] };
                                    seMovio = u.moverse(mapa, pos2);
                                    var i = 0;
                                    while (!seMovio)
                                    {
                                        i++;
                                        int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                        seMovio = u.moverse(mapa, pos3);
                                        if (i > 100)
                                        {
                                            seMovio = true;
                                        }
                                    }
                                }
                                else if (b1.posicion[1] < u.posicion[1])
                                {
                                    int[] pos2 = { u.posicion[0], u.posicion[1] - 1 };
                                    seMovio = u.moverse(mapa, pos2);
                                    var i = 0;
                                    while (!seMovio)
                                    {
                                        i++;
                                        int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                        seMovio = u.moverse(mapa, pos3);
                                        if (i > 100)
                                        {
                                            seMovio = true;
                                        }
                                    }
                                }
                                else if (b1.posicion[1] > u.posicion[1])
                                {
                                    int[] pos2 = { u.posicion[0], u.posicion[1] + 1 };
                                    seMovio = u.moverse(mapa, pos2);
                                    var i = 0;
                                    while (!seMovio)
                                    {
                                        i++;
                                        int[] pos3 = { u.posicion[0] + randy.Next(-1, 1), u.posicion[1] + randy.Next(-1, 1) };
                                        seMovio = u.moverse(mapa, pos3);
                                        if (i > 100)
                                        {
                                            seMovio = true;
                                        }
                                    }
                                }
                                if (Math.Pow((b1.posicion[0] - u.posicion[0]), 2) + Math.Pow((b1.posicion[1] - u.posicion[1]), 2) <= Math.Pow(u.rango, 2))
                                {
                                    var A = ((b1.posicion[0] - u.posicion[0]) ^ 2);
                                    mensaje2 += u.atacar(b1, mapa, bat1, bat2) + "\n";
                                    d = u.velocidad + 10;
                                }
                        }
                    }
                }
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 27);
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < 60; i++)
                {
                    Console.WriteLine("                                                                                 ");
                }
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 27);
                Console.Write(mensaje2);
                Console.SetCursorPosition(0, 0);
                Console.ReadKey();
                foreach (Unidad i in bat1.batallon)
                {
                    if (i.bandera == Guerra.bandos.rojo)
                    {
                        bat2.batallon.Add(i);
                    }
                }
                bat2.batallon.RemoveAll(u => u.hpActual <= 0 || u.bandera == Guerra.bandos.azul);
                
            }


        }

        public bool continuarSimulacion()
        {
            
           
            if (b1.hpActual <= 0)
            {
                Console.SetCursorPosition(0, 27);
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < 60; i++)
                {
                    Console.WriteLine("                                                                                 ");
                }
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 27);
                Console.WriteLine("El ejercito rojo ha ganado!");
                foreach (Unidad u in bat2.batallon)
                {
                    Console.WriteLine(u.info());
                }
                Console.SetCursorPosition(0, 0);
                Console.ReadKey();
                
                return false;
            }
            if (b2.hpActual <= 0)
            {
                Console.SetCursorPosition(0, 27);
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < 60; i++)
                {
                    Console.WriteLine("                                                                                 ");
                }
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 27);
                Console.WriteLine("El ejercito azul ha ganado!");
                foreach (Unidad u in bat1.batallon)
                {
                    Console.WriteLine(u.info());
                }
                Console.SetCursorPosition(0, 0);
                Console.ReadKey();
                
                return false;
            }
            if (bat1.batallon.Count() == 0 && bat2.batallon.Count() == 0)
            {
                Console.WriteLine("No quedan tropas para seguir la simulación. Es un empate!");
                return false;
            }
            return true;
        }

    }
}
