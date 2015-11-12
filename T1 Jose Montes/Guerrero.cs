using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Jose_Montes
{
    public class Guerrero : Infanteria
    {
        public int armadura;
        public estados estado;
        public enum estados {ofensivo, defensivo}
        public Guerrero(bandos bando, int[] pos)
        {
            //Atributos de Unidad
            this.icono = "æ";
            this.posicion = pos;
            this.tipo = Tipo.terrestre;
            this.hpInicial = 300 + randy.Next(-20, 20);
            this.hpActual = this.hpInicial;
            this.dañoMecanico = 40 + randy.Next(-5, 5);
            this.dañoNoMecanico = 50 + randy.Next(-10, 10);
            this.rango = 1;
            this.velocidad = 7;
            this.bandera = bando;
            //Atributos de guerrero
            this.armadura = 200 + randy.Next(-100, 100);
            this.estado = estados.ofensivo;
        }
        public override int recibirDaño(int mecanico, int noMecanico)
        {
            if (this.estado == estados.defensivo)
            {
                noMecanico = (noMecanico * 7)/10;
            }
            if (this.armadura >= noMecanico)
            {
                this.armadura -= noMecanico;
            }
            else if (this.armadura > 0)
            {
                this.hpActual = this.hpActual - noMecanico + this.armadura;
            }
            else
            {
                this.hpActual -= noMecanico;
            }
            return noMecanico;
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
            if (u.Count == 0)
            {
                this.estado = estados.defensivo;
            }
            else
            {
                this.estado = estados.ofensivo;
            }
            return u;
        }

        
    }
}


