using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionOC.Mod
{
    public class Proveedor
    {
        private int rut;
        private string giroCodigo;
        private string digitoVerificador;
        private string razonSocial;
        private string telefono;
        private string fax;
        private string direccion;
        private string contacto;
        private string cuentaCorriente;
        private string habitual;
        private string estado;
        private DateTime fechaEstado;
        private bool honorario;
        private int compensacion;
        private string rutFormateado;

        public Proveedor()
        {
        }

        public Proveedor(int rut, string giroCodigo, string digitoVerificador, string razonSocial,
            string telefono, string fax, string direccion, string contacto, string cuentaCorriente,
            string habitual, string estado, DateTime fechaEstado, bool honorario, int compensacion)
        {
            this.rut = rut;
            this.giroCodigo = giroCodigo;
            this.digitoVerificador = digitoVerificador;
            this.razonSocial = razonSocial;
            this.telefono = telefono;
            this.fax = fax;
            this.direccion = direccion;
            this.contacto = contacto;
            this.cuentaCorriente = cuentaCorriente;
            this.habitual = habitual;
            this.estado = estado;
            this.fechaEstado = fechaEstado;
            this.honorario = honorario;
            this.compensacion = compensacion;
        }

        public int Rut { get => rut; set => rut = value; }
        public string GiroCodigo { get => giroCodigo; set => giroCodigo = value; }
        public string DigitoVerificador { get => digitoVerificador; set => digitoVerificador = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Contacto { get => contacto; set => contacto = value; }
        public string CuentaCorriente { get => cuentaCorriente; set => cuentaCorriente = value; }
        public string Habitual { get => habitual; set => habitual = value; }
        public string Estado { get => estado; set => estado = value; }
        public DateTime FechaEstado { get => fechaEstado; set => fechaEstado = value; }
        public bool Honorario { get => honorario; set => honorario = value; }
        public int Compensacion { get => compensacion; set => compensacion = value; }
        public string RutFormateado { get => FuncionGlobal.formatearRut(rut.ToString() + digitoVerificador); set => rutFormateado = value; }
    }
}
