using System;
using System.Collections.Generic;
using System.Data;

namespace GestionOC.Mod
{
    public class OrdenCompra
    {
        private int numero;
        private double tipoCambio;
        private bool aplicaImpuesto;
        private DateTime fecha;
        private string lugar;
        private double subtotal;
        private double subtotalOrigen;
        private double impuesto;
        private double impuestoOrigen;
        private double total;
        private double totalOrigen;
        private bool rechazada;

        private Proveedor proveedor;
        private Empresa empresa;
        private Moneda moneda;


        private List<Item> items;

        public OrdenCompra()
        {
        }

        public OrdenCompra(int numero, double tipoCambio, bool aplicaImpuesto, DateTime fecha, string lugar, double subtotal,
            double impuesto, double total, bool rechazada, Empresa empresa, Moneda moneda, Proveedor proveedor, List<Item> items)
        {
            this.numero = numero;
            this.tipoCambio = tipoCambio;
            this.aplicaImpuesto = aplicaImpuesto;
            this.fecha = fecha;
            this.lugar = lugar;
            this.subtotal = subtotal;
            this.subtotalOrigen = subtotal * tipoCambio;
            this.impuesto = impuesto;
            this.impuestoOrigen = aplicaImpuesto ? (subtotal + impuesto) * tipoCambio : 0;
            this.total = total;
            this.rechazada = rechazada;
            this.totalOrigen = aplicaImpuesto ? subtotalOrigen + impuestoOrigen : subtotalOrigen;
            this.proveedor = proveedor;
            this.empresa = empresa;
            this.moneda = moneda;
            this.items = items;
        }

        public OrdenCompra(int numero, double tipoCambio, bool aplicaImpuesto, DateTime fecha, string lugar, double subtotal,
            double subtotalOrigen, double impuesto, double impuestoOrigen, double total, double totalOrigen, bool rechazada, Proveedor proveedor,
            Empresa empresa, Moneda moneda, List<Item> items)
        {
            this.numero = numero;
            this.tipoCambio = tipoCambio;
            this.aplicaImpuesto = aplicaImpuesto;
            this.fecha = fecha;
            this.lugar = lugar;
            this.subtotal = subtotal;
            this.subtotalOrigen = subtotalOrigen;
            this.impuesto = impuesto;
            this.impuestoOrigen = impuestoOrigen;
            this.total = total;
            this.totalOrigen = totalOrigen;
            this.rechazada = rechazada;
            this.proveedor = proveedor;
            this.empresa = empresa;
            this.moneda = moneda;
            this.items = items;
        }

        public int Numero { get => numero; set => numero = value; }
        public double TipoCambio { get => tipoCambio; set => tipoCambio = value; }
        public bool AplicaImpuesto { get => aplicaImpuesto; set => aplicaImpuesto = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public double SubtotalOrigen { get => subtotalOrigen; set => subtotalOrigen = value; }
        public double Impuesto { get => impuesto; set => impuesto = value; }
        public double ImpuestoOrigen { get => impuestoOrigen; set => impuestoOrigen = value; }
        public double Total { get => total; set => total = value; }
        public double TotalOrigen { get => totalOrigen; set => totalOrigen = value; }
        public Proveedor Proveedor { get => proveedor; set => proveedor = value; }
        public Empresa Empresa { get => empresa; set => empresa = value; }
        public Moneda Moneda { get => moneda; set => moneda = value; }
        public bool Rechazada { get => rechazada; set => rechazada = value; }

        public List<Item> Items
        {
            get
            {
                if (items == null)
                    items = new List<Item>();
                return items;
            }
            set
            {
                RemoveAllItem();
                if (value != null)
                {
                    foreach (Item oItem in value)
                        AddItem(oItem);
                }
            }
        }

        public DataTable TableItems
        {
            get
            {
                DataTable tableItems = new DataTable();
                tableItems.Columns.Add("ITM_CODIGO", typeof(int));
                tableItems.Columns.Add("ITM_DETALLE", typeof(string));
                tableItems.Columns.Add("ITM_CATIDAD", typeof(double));
                tableItems.Columns.Add("ITM_PRECIO_UNITARIO", typeof(double));
                tableItems.Columns.Add("ITM_TOTAL", typeof(double));
                if (items == null)
                    items = new List<Item>();
                foreach (Item item in items)
                {
                    tableItems.Rows.Add(item.Codigo, item.Detalle, item.Cantidad, item.PrecioUnitario, item.Total);
                }
                return tableItems;
            }
        }

        public void AddItem(Item newItem)
        {
            if (newItem == null)
                return;
            if (this.items == null)
                this.items = new List<Item>();
            if (!this.items.Contains(newItem))
                this.items.Add(newItem);
        }

        public void RemoveItem(Item oldItem)
        {
            if (oldItem == null)
                return;
            if (this.items != null)
                if (this.items.Contains(oldItem))
                    this.items.Remove(oldItem);
        }

        public void RemoveAllItem()
        {
            if (items != null)
                items.Clear();
        }
    }
}
