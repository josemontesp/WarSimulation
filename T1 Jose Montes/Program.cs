using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace T1_Jose_Montes
{
    public class Program
    {  
        public static void Main()
        {
            Simulador simu = new Simulador();
            simu.prepararEstados();
            simu.ejecutarSimulacion();
            Console.ReadLine();
        }
    }
}
