
namespace GestionOC.Mod
{
    public class Moneda
    {
        private int codigo;
        private string glosa;
        private string simbolo;

        public Moneda()
        {
        }

        public Moneda(int codigo, string glosa, string simbolo)
        {
            this.codigo = codigo;
            this.glosa = glosa;
            this.simbolo = simbolo;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Glosa { get => glosa; set => glosa = value; }
        public string Simbolo { get => simbolo; set => simbolo = value; }
    }
}
