using System;
using System.Data;
using System.Data.SqlClient;

namespace GestionOC.Dal
{
    public class ProveedorDal
    {
        public static DataTable BuscaProveedor(int proveedorRut, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.ConectarContab())
            {
                DataTable dataProveedor = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("SELECT p.Pro_Rut, p.Gir_Codigo, p.Pro_Digito, p.Pro_RazonSocial, p.Pro_Telefono"
                    + ", p.Pro_Fax, p.Pro_Direccion, p.Pro_Contacto, p.Pro_CtaCte, p.Pro_Habitual, p.Pro_Estado, p.Pro_FechaEstado, p.Pro_Honorario"
                    + ", p.Pro_Compensacion FROM Proveedor p WHERE p.Pro_Rut = @proveedorRut", conexion);
                    comando.Parameters.AddWithValue("@proveedorRut", proveedorRut);
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    dataProveedor.AcceptChanges();
                    adp.Fill(dataProveedor);
                    adp.Dispose();
                    codigo = dataProveedor.Rows.Count > 0 ? 1 : 0;
                    mensaje = codigo == 1 ? "Proveedor encontrado" : "No se encontro nungún proveedor";
                    return dataProveedor;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataProveedor;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static DataTable ListaProveedor(string provedorRazonSocial, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.ConectarContab())
            {
                DataTable dataProveedor = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("SELECT p.Pro_Rut, p.Gir_Codigo, p.Pro_Digito, p.Pro_RazonSocial, p.Pro_Telefono"
                    + ", p.Pro_Fax, p.Pro_Direccion, p.Pro_Contacto, p.Pro_CtaCte, p.Pro_Habitual, p.Pro_Estado, p.Pro_FechaEstado, p.Pro_Honorario"
                    + ", p.Pro_Compensacion FROM Proveedor p WHERE p.Pro_RazonSocial LIKE'%" + provedorRazonSocial + "%'", conexion);
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    dataProveedor.AcceptChanges();
                    adp.Fill(dataProveedor);
                    adp.Dispose();
                    codigo = dataProveedor.Rows.Count > 0 ? 1 : 0;
                    mensaje = codigo == 1 ? "Proveedor encontrado" : "No se encontro nungún proveedor";
                    return dataProveedor;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataProveedor;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }
    }
}
