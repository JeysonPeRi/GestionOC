using GestionOC.Dal;
using GestionOC.Mod;
using System;
using System.Collections.Generic;
using System.Data;

namespace GestionOC.Neg
{
    public class OrdenCompraNeg
    {
        public static List<OrdenCompra> ListarOrdenCompra(DateTime desde, DateTime hasta, int ordenCompraNumero, bool ordenCompraNumeroTodos, bool rechazada,
            string proveedorRut, bool proveedorRutTodos, out int codigo, out string mensaje)
        {
            List<OrdenCompra> ordenCompras = new List<OrdenCompra>();

            try
            {
                int proveedorRutEntero = FuncionGlobal.FormaterarRutEntero(proveedorRut);
                DataTable dataOrdenCompras = OrdenCompraDal.ListaOrdenCompra(desde, hasta, ordenCompraNumero, ordenCompraNumeroTodos, rechazada,
                    proveedorRutEntero, proveedorRutTodos, out codigo, out mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataOrdenCompras.Rows)
                    {
                        ordenCompras.Add(new OrdenCompra(Convert.ToInt32(fila[0]), Convert.ToDouble(fila[4]), Convert.ToBoolean(fila[5]),
                            Convert.ToDateTime(fila[6]), Convert.ToString(fila[7]), Convert.ToDouble(fila[8]), Convert.ToDouble(fila[9]),
                            Convert.ToDouble(fila[10]), Convert.ToDouble(fila[11]), Convert.ToDouble(fila[12]), Convert.ToDouble(fila[13]), Convert.ToBoolean(fila[14]),
                            ProveedorNeg.BuscarProveedor(Convert.ToInt32(fila[1]), out _, out _), EmpresaNeg.BuscarEmpresa(Convert.ToInt32(fila[2]), out _, out _),
                            MonedaNeg.BuscarMoneda(Convert.ToInt32(fila[3]), out _, out _), ItemNeg.ListarItem(Convert.ToInt32(fila[0]), out _, out _)));
                    }
                }
                dataOrdenCompras.Dispose();
                return ordenCompras;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return ordenCompras;
            }
        }

        public static List<OrdenCompra> ListarOrdenCompra(DateTime desde, DateTime hasta, int monedaCodigo, bool monedaCodigoTodos, int rechazada,
            string proveedorRut, bool proveedorRutTodos, out int codigo, out string mensaje, out DataTable filtro)
        {
            List<OrdenCompra> ordenCompras = new List<OrdenCompra>();
            filtro = new DataTable();
            filtro.Columns.Add("desde", typeof(DateTime));
            filtro.Columns.Add("hasta", typeof(DateTime));
            filtro.Columns.Add("monedaCodigo", typeof(int));
            filtro.Columns.Add("monedaCodigoTodos", typeof(bool));
            filtro.Columns.Add("rechazada", typeof(int));
            filtro.Columns.Add("proveedorRut", typeof(string));
            filtro.Columns.Add("proveedorRutTodos", typeof(bool));
            filtro.Rows.Add(desde, hasta, monedaCodigo, monedaCodigoTodos, rechazada, proveedorRut, proveedorRutTodos);

            try
            {
                int proveedorRutEntero = FuncionGlobal.FormaterarRutEntero(proveedorRut);
                DataTable dataOrdenCompras = OrdenCompraDal.ListaOrdenCompra(desde, hasta, monedaCodigo, monedaCodigoTodos, rechazada,
                    proveedorRutEntero, proveedorRutTodos, out codigo, out mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataOrdenCompras.Rows)
                    {
                        ordenCompras.Add(new OrdenCompra(Convert.ToInt32(fila[0]), Convert.ToDouble(fila[4]), Convert.ToBoolean(fila[5]),
                            Convert.ToDateTime(fila[6]), Convert.ToString(fila[7]), Convert.ToDouble(fila[8]), Convert.ToDouble(fila[9]),
                            Convert.ToDouble(fila[10]), Convert.ToDouble(fila[11]), Convert.ToDouble(fila[12]), Convert.ToDouble(fila[13]), Convert.ToBoolean(fila[14]),
                            ProveedorNeg.BuscarProveedor(Convert.ToInt32(fila[1]), out _, out _), EmpresaNeg.BuscarEmpresa(Convert.ToInt32(fila[2]), out _, out _),
                            MonedaNeg.BuscarMoneda(Convert.ToInt32(fila[3]), out _, out _), ItemNeg.ListarItem(Convert.ToInt32(fila[0]), out _, out _)));
                    }
                }
                dataOrdenCompras.Dispose();
                return ordenCompras;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return ordenCompras;
            }
        }

        public static List<OrdenCompra> ListarOrdenCompra(DateTime desde, DateTime hasta, int monedaCodigo, bool monedaCodigoTodos, int rechazada,
           string proveedorRut, bool proveedorRutTodos)
        {
            List<OrdenCompra> ordenCompras = new List<OrdenCompra>();

            try
            {
                int proveedorRutEntero = FuncionGlobal.FormaterarRutEntero(proveedorRut);
                DataTable dataOrdenCompras = OrdenCompraDal.ListaOrdenCompra(desde, hasta, monedaCodigo, monedaCodigoTodos, rechazada,
                    proveedorRutEntero, proveedorRutTodos, out int codigo, out _);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataOrdenCompras.Rows)
                    {
                        ordenCompras.Add(new OrdenCompra(Convert.ToInt32(fila[0]), Convert.ToDouble(fila[4]), Convert.ToBoolean(fila[5]),
                            Convert.ToDateTime(fila[6]), Convert.ToString(fila[7]), Convert.ToDouble(fila[8]), Convert.ToDouble(fila[9]),
                            Convert.ToDouble(fila[10]), Convert.ToDouble(fila[11]), Convert.ToDouble(fila[12]), Convert.ToDouble(fila[13]), Convert.ToBoolean(fila[14]),
                            ProveedorNeg.BuscarProveedor(Convert.ToInt32(fila[1]), out _, out _), EmpresaNeg.BuscarEmpresa(Convert.ToInt32(fila[2]), out _, out _),
                            MonedaNeg.BuscarMoneda(Convert.ToInt32(fila[3]), out _, out _), ItemNeg.ListarItem(Convert.ToInt32(fila[0]), out _, out _)));
                    }
                }
                dataOrdenCompras.Dispose();
                return ordenCompras;
            }
            catch (Exception)
            {
                return ordenCompras;
            }
        }

        public static OrdenCompra BuscarOrdenCompra(int ordenCompraNumero)
        {
            OrdenCompra ordenCompra = new OrdenCompra();
            try
            {
                DataTable dataOrdenCompra = OrdenCompraDal.BuscaOrdenCompra(ordenCompraNumero, out int codigo, out string mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataOrdenCompra.Rows)
                    {
                        ordenCompra = new OrdenCompra(Convert.ToInt32(fila[0]), Convert.ToDouble(fila[4]), Convert.ToBoolean(fila[5]),
                            Convert.ToDateTime(fila[6]), Convert.ToString(fila[7]), Convert.ToDouble(fila[8]), Convert.ToDouble(fila[9]),
                            Convert.ToDouble(fila[10]), Convert.ToDouble(fila[11]), Convert.ToDouble(fila[12]), Convert.ToDouble(fila[13]), Convert.ToBoolean(fila[14]),
                            ProveedorNeg.BuscarProveedor(Convert.ToInt32(fila[1]), out _, out _), EmpresaNeg.BuscarEmpresa(Convert.ToInt32(fila[2]), out _, out _),
                            MonedaNeg.BuscarMoneda(Convert.ToInt32(fila[3]), out _, out _), ItemNeg.ListarItem(Convert.ToInt32(fila[0]), out _, out _));
                    }
                }
                dataOrdenCompra.Dispose();
                return ordenCompra;
            }
            catch (Exception)
            {
                return ordenCompra;
            }
        }

        public static void GuardarOrdenCompra(int numero, double tipoCambio, bool aplicaImpuesto, DateTime fecha, string lugar, double subtotal,
            double impuesto, double total, bool rechazada, int empresaCodigo, int monedaCodigo, string proveedorRut, List<Item> items, out int ordenCompraNumeroActualizado, out int codigo, out string mensaje)
        {
            try
            {
                int proveedorRutEntero = FuncionGlobal.FormaterarRutEntero(proveedorRut);
                OrdenCompra ordenCompra = new OrdenCompra(numero, tipoCambio, aplicaImpuesto, fecha, lugar, subtotal, impuesto, total, rechazada, EmpresaNeg.BuscarEmpresa(empresaCodigo, out _, out _),
                    MonedaNeg.BuscarMoneda(monedaCodigo, out _, out _), ProveedorNeg.BuscarProveedor(proveedorRutEntero, out _, out _), items);
                OrdenCompraDal.GuardaOrdenCompra(ordenCompra, out ordenCompraNumeroActualizado, out codigo, out mensaje);
            }
            catch (Exception ex)
            {
                ordenCompraNumeroActualizado = 0;
                codigo = -1;
                mensaje = ex.Message;
            }
        }

        public static void RechazarOrdenCompra(int numero, out int codigo, out string mensaje)
        {
            try
            {
                OrdenCompraDal.RechazaOrdenCompra(numero, out codigo, out mensaje);
            }
            catch (Exception ex)
            {
                codigo = -1;
                mensaje = ex.Message;
            }
        }

        public static void AsignarCarpetaAntecedentes(string ruta, out int codigo, out string mensaje)
        {
            try
            {
                OrdenCompraDal.AsignaCarpetaAntecedentes(ruta, out codigo, out mensaje);
            }
            catch (Exception ex)
            {
                codigo = -1;
                mensaje = ex.Message;
            }
        }

        public static void ConfirmarAntecedentes(string ruta, string ruta2, out int codigo, out string mensaje)
        {
            try
            {
                OrdenCompraDal.ConfirmaAntecedentes(ruta, ruta2, out codigo, out mensaje);
            }
            catch (Exception ex)
            {
                codigo = -1;
                mensaje = ex.Message;
            }
        }

        public static void LimpiarAntecedentes(string ruta, out int codigo, out string mensaje)
        {
            try
            {
                OrdenCompraDal.LimpiaAntecedentes(ruta, out codigo, out mensaje);
            }
            catch (Exception ex)
            {
                codigo = -1;
                mensaje = ex.Message;
            }
        }
    }
}
