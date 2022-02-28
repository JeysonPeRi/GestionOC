using GestionOC.Dal;
using GestionOC.Mod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionOC.Neg
{
    public class ProveedorNeg
    {
        public static Proveedor BuscarProveedor(int proveedorCodigo, out int codigo, out string mensaje)
        {
            Proveedor proveedor = new Proveedor();

            try
            {
                DataTable dataProveedors = ProveedorDal.BuscaProveedor(proveedorCodigo, out codigo, out mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataProveedors.Rows)
                    {
                        proveedor = new Proveedor(Convert.ToInt32(fila[0]), fila[1].ToString(), fila[2].ToString(), fila[3].ToString(),
                            fila[4].ToString(), fila[5].ToString(), fila[6].ToString(), fila[7].ToString(), fila[8].ToString(), fila[9].ToString(),
                            fila[10].ToString(), Convert.ToDateTime(fila[11]), Convert.ToBoolean(fila[12]), Convert.ToInt32(fila[13]));
                    }
                }
                dataProveedors.Dispose();
                return proveedor;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return proveedor;
            }
        }

        public static List<Proveedor> ListarProveedor(string provedorRazonSocial, out int codigo, out string mensaje)
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            try
            {
                if (string.IsNullOrWhiteSpace(provedorRazonSocial))
                {
                    codigo = 0;
                    mensaje = "";
                }
                else
                {
                    DataTable dataProveedores = ProveedorDal.ListaProveedor(provedorRazonSocial, out codigo, out mensaje);
                    if (codigo >= 1)
                    {
                        foreach (DataRow fila in dataProveedores.Rows)
                        {
                            proveedores.Add(new Proveedor(Convert.ToInt32(fila[0]), fila[1].ToString(), fila[2].ToString(), fila[3].ToString(),
                                fila[4].ToString(), fila[5].ToString(), fila[6].ToString(), fila[7].ToString(), fila[8].ToString(), fila[9].ToString(),
                                fila[10].ToString(), Convert.ToDateTime(fila[11]), Convert.ToBoolean(fila[12]), Convert.ToInt32(fila[13])));
                        }
                    }
                    dataProveedores.Dispose();
                }
                return proveedores;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return proveedores;
            }
        }
    }
}
