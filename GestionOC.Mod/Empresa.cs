
namespace GestionOC.Mod
{
    public class Empresa
    {
        private int codigo;
        private string razonSocial;
        private string direccion;
        private int rut;
        private string dv;
        private int fono;
        private int fax;
        private string ciudad;
        private string logo;

        public Empresa()
        {
        }

        public Empresa(int codigo, string razonSocial, string direccion, int rut, string dv, int fono, int fax, string ciudad, string logo)
        {
            this.codigo = codigo;
            this.razonSocial = razonSocial;
            this.direccion = direccion;
            this.rut = rut;
            this.dv = dv;
            this.fono = fono;
            this.fax = fax;
            this.ciudad = ciudad;
            this.logo = logo;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Rut { get => rut; set => rut = value; }
        public string Dv { get => dv; set => dv = value; }
        public int Fono { get => fono; set => fono = value; }
        public int Fax { get => fax; set => fax = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Logo { get => logo; set => logo = value; }
        public string RutFormateado { get => FuncionGlobal.formatearRut(rut.ToString() + dv); }
    }
}
