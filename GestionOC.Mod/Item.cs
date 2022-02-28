
namespace GestionOC.Mod
{
    public class Item
    {
        private int codigo;
        private string detalle;
        private double cantidad;
        private double precioUnitario;
        private double total;

        public Item()
        {
        }

        public Item(int codigo, string detalle, double cantidad, double precioUnitario, double total)
        {
            this.codigo = codigo;
            this.detalle = detalle;
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
            this.total = total;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Detalle { get => detalle; set => detalle = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public double Total { get => total; set => total = value; }
    }
}
