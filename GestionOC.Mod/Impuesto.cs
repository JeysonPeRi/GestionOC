using System;

namespace GestionOC.Mod
{
    public class Impuesto
    {
        private int codigo;
        private float porcentajeCompleto;
        private DateTime fecha;

        public Impuesto()
        {

        }

        public Impuesto(int codigo, float porcentajeCompleto, DateTime fecha)
        {
            this.codigo = codigo;
            this.porcentajeCompleto = porcentajeCompleto;
            this.fecha = fecha;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public float PorcentajeCompleto { get => porcentajeCompleto; set => porcentajeCompleto = value; }
        public float Porcentaje { get => porcentajeCompleto <= 0 ? 0 : porcentajeCompleto / 100; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
