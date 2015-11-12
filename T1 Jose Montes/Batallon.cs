using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public class Batallon : Guerra
    {
        public List<Unidad> batallon = new List<Unidad>();

        public Batallon(Mapa mapa, bandos bando, int terrestreAntiAereo, int antiInfanteria, int bombardero, int aereoAntiAereo, int guerrero, int kamikaze, int arquero, int ingeniero, int medico, int groupie, int desmoralizador)
        {
            for (int i = 0; i < terrestreAntiAereo; i++)
            {
                var pos = mapa.espacioVacio(bando);
                TerrestreAntiAereo a = new TerrestreAntiAereo(bando, pos); 
                this.batallon.Add(a);
                mapa.cambiar(pos, a);
                
            }

            for (int i = 0; i < antiInfanteria; i++)
            {
                var pos = mapa.espacioVacio(bando);
                var a = new AntiInfanteria(bando, pos); 
                mapa.cambiar(pos, a);
                this.batallon.Add(a);
            }

            for (int i = 0; i < bombardero; i++)
            {
                var pos = mapa.espacioVacio(bando);
                var a = new Bombardero(bando, pos); 
                mapa.cambiar(pos, a);
                this.batallon.Add(a);
            }

            for (int i = 0; i < aereoAntiAereo; i++)
            {
                var pos = mapa.espacioVacio(bando);
                var a = new AereoAntiAereo(bando, pos); 
                mapa.cambiar(pos, a);
                this.batallon.Add(a);
            }

            for (int i = 0; i < guerrero; i++)
            {
                var pos = mapa.espacioVacio(bando);
                var a = new Guerrero(bando, pos); mapa.cambiar(pos, a);
                this.batallon.Add(a);
            }

            for (int i = 0; i < kamikaze; i++)
            {
                var pos = mapa.espacioVacio(bando);
                var a = new Kamikaze(bando, pos); 
                mapa.cambiar(pos, a);
                this.batallon.Add(a);
            }

            for (int i = 0; i < arquero; i++)
            {
                var pos = mapa.espacioVacio(bando);
                var a = new Arquero(bando, pos); 
                mapa.cambiar(pos, a);
                this.batallon.Add(a);
            }

            for (int i = 0; i < ingeniero; i++)
            {
                var pos = mapa.espacioVacio(bando);
                var a = new Ingeniero(bando, pos); mapa.cambiar(pos, a);
                this.batallon.Add(a);
            }

            for (int i = 0; i < medico; i++)
            {
                var pos = mapa.espacioVacio(bando);
                var a = new Medico(bando, pos); mapa.cambiar(pos, a);
                this.batallon.Add(a);
            }

            for (int i = 0; i < groupie; i++)
            {
                var pos = mapa.espacioVacio(bando);
                var a = new Groupie(bando, pos); 
                mapa.cambiar(pos, a);
                this.batallon.Add(a);
            }
            for (int i = 0; i < desmoralizador; i++)
            {
                var pos = mapa.espacioVacio(bando);
                var a = new Desmoralizador(bando, pos);
                mapa.cambiar(pos, a);
                this.batallon.Add(a);
            }
        }

        public void eliminarUnidad(Mapa mapa, Unidad fallecido)
        {
            if (fallecido.tipo == Unidad.Tipo.aereo){
                mapa.matrizAerea[fallecido.posicion[0]-1,fallecido.posicion[1]-1] = null;
            }
            else
            {
                mapa.matrizTerrestre[fallecido.posicion[0]-1,fallecido.posicion[1]-1] = null;
            }
            this.batallon.Remove(fallecido);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(fallecido.posicion[0], fallecido.posicion[1]);
            Console.Write("·");
            // Cuidado con la muerte de bombarderos y aereos
        }
    }
}
