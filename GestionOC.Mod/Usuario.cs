using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionOC.Mod
{
    public class Usuario
    {
        private int numero;
        private string codigoSistema;
        private string usu;
        private string clave;
        private string nombre;
        private List<int> codigoAccesoSistema;
        private List<string> formularios;

        public Usuario()
        {
        }

        public Usuario(int numero, string codigoSistema, string usu, string clave, string nombre, List<int> codigoAccesoSistema, List<string> formularios)
        {
            this.numero = numero;
            this.codigoSistema = codigoSistema;
            this.usu = usu;
            this.clave = clave;
            this.nombre = nombre;
            this.codigoAccesoSistema = codigoAccesoSistema;
            this.formularios = formularios;
        }

        public int Numero { get => numero; set => numero = value; }
        public string CodigoSistema { get => codigoSistema; set => codigoSistema = value; }
        public string Usu { get => usu; set => usu = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<int> CodigoAccesoSistema { get => codigoAccesoSistema; set => codigoAccesoSistema = value; }
        public List<string> Formularios { get => formularios; set => formularios = value; }
    }
}
