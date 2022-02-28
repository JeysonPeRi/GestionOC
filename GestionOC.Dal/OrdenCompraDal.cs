using GestionOC.Mod;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace GestionOC.Dal
{
    public class OrdenCompraDal
    {
        public static DataTable ListaOrdenCompra(DateTime desde, DateTime hasta, int ordenCompraNumero, bool ordenCompraNumeroTodos, bool rechazada,
            int proveedorRut, bool proveedorRutTodos, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                DataTable dataOrdenCompra = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("sp_lista_orden_compra", conexion);
                    comando.Parameters.AddWithValue("@desde", desde);
                    comando.Parameters.AddWithValue("@hasta", hasta);
                    comando.Parameters.AddWithValue("@ordenCompraNumero", ordenCompraNumero);
                    comando.Parameters.AddWithValue("@ordenCompraNumeroTodos", ordenCompraNumeroTodos);
                    comando.Parameters.AddWithValue("@rechazada", rechazada);
                    comando.Parameters.AddWithValue("@proveedorRut", proveedorRut);
                    comando.Parameters.AddWithValue("@proveedorRutTodos", proveedorRutTodos);
                    comando.Parameters.Add("@codigo", SqlDbType.Int);
                    comando.Parameters.Add("@mensaje", SqlDbType.VarChar, 250);
                    comando.Parameters["@codigo"].Direction = ParameterDirection.Output;
                    comando.Parameters["@mensaje"].Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    adp.Fill(dataOrdenCompra);
                    adp.Dispose();
                    codigo = Convert.ToInt32(comando.Parameters["@codigo"].Value.ToString());
                    mensaje = comando.Parameters["@mensaje"].Value.ToString();
                    return dataOrdenCompra;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataOrdenCompra;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static DataTable ListaOrdenCompra(DateTime desde, DateTime hasta, int monedaCodigo, bool monedaCodigoTodos, int rechazada,
            int proveedorRut, bool proveedorRutTodos, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                DataTable dataOrdenCompra = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("sp_lista_orden_compra_informe", conexion);
                    comando.Parameters.AddWithValue("@desde", desde);
                    comando.Parameters.AddWithValue("@hasta", hasta);
                    comando.Parameters.AddWithValue("@monedaCodigo", monedaCodigo);
                    comando.Parameters.AddWithValue("@monedaCodigoTodos", monedaCodigoTodos);
                    comando.Parameters.AddWithValue("@rechazada", rechazada);
                    comando.Parameters.AddWithValue("@proveedorRut", proveedorRut);
                    comando.Parameters.AddWithValue("@proveedorRutTodos", proveedorRutTodos);
                    comando.Parameters.Add("@codigo", SqlDbType.Int);
                    comando.Parameters.Add("@mensaje", SqlDbType.VarChar, 250);
                    comando.Parameters["@codigo"].Direction = ParameterDirection.Output;
                    comando.Parameters["@mensaje"].Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    adp.Fill(dataOrdenCompra);
                    adp.Dispose();
                    codigo = Convert.ToInt32(comando.Parameters["@codigo"].Value.ToString());
                    mensaje = comando.Parameters["@mensaje"].Value.ToString();
                    return dataOrdenCompra;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataOrdenCompra;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static DataTable BuscaOrdenCompra(int ordenCompraNumero, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                DataTable dataOrdenCompra = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("sp_busca_orden_compra", conexion);
                    comando.Parameters.AddWithValue("@ordenCompraNumero", ordenCompraNumero);
                    comando.Parameters.Add("@codigo", SqlDbType.Int);
                    comando.Parameters.Add("@mensaje", SqlDbType.VarChar, 250);
                    comando.Parameters["@codigo"].Direction = ParameterDirection.Output;
                    comando.Parameters["@mensaje"].Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    adp.Fill(dataOrdenCompra);
                    adp.Dispose();
                    codigo = Convert.ToInt32(comando.Parameters["@codigo"].Value.ToString());
                    mensaje = comando.Parameters["@mensaje"].Value.ToString();
                    return dataOrdenCompra;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataOrdenCompra;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static void GuardaOrdenCompra(OrdenCompra ordenCompra, out int ordenCompraNumeroActualizado, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand("sp_guarda_orden_compra", conexion);
                    comando.Parameters.AddWithValue("@OC_NUMERO", ordenCompra.Numero);
                    comando.Parameters.AddWithValue("@PRO_RUT", ordenCompra.Proveedor.Rut);
                    comando.Parameters.AddWithValue("@EMP_CODIGO", ordenCompra.Empresa.Codigo);
                    comando.Parameters.AddWithValue("@MON_CODIGO", ordenCompra.Moneda.Codigo);
                    comando.Parameters.AddWithValue("@OC_TIPO_CAMBIO", ordenCompra.TipoCambio);
                    comando.Parameters.AddWithValue("@OC_APLICA_IMPUESTO", ordenCompra.AplicaImpuesto);
                    comando.Parameters.AddWithValue("@OC_FECHA", ordenCompra.Fecha);
                    comando.Parameters.AddWithValue("@OC_LUGAR", ordenCompra.Lugar);
                    comando.Parameters.AddWithValue("@OC_SUBTOTAL", ordenCompra.Subtotal);
                    comando.Parameters.AddWithValue("@OC_IMPUESTO", ordenCompra.Impuesto);
                    comando.Parameters.AddWithValue("@OC_RECHAZADA", ordenCompra.Rechazada);
                    comando.Parameters.Add("@ITEMS", SqlDbType.Structured).Value = ordenCompra.TableItems;
                    comando.Parameters.Add("@OC_NUMERO_ACTUALIZADO", SqlDbType.Int);
                    comando.Parameters.Add("@codigo", SqlDbType.Int);
                    comando.Parameters.Add("@mensaje", SqlDbType.VarChar, 250);
                    comando.Parameters["@OC_NUMERO_ACTUALIZADO"].Direction = ParameterDirection.Output;
                    comando.Parameters["@codigo"].Direction = ParameterDirection.Output;
                    comando.Parameters["@mensaje"].Direction = ParameterDirection.Output;
                    conexion.Open();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.ExecuteNonQuery();
                    ordenCompraNumeroActualizado = Convert.ToInt32(comando.Parameters["@OC_NUMERO_ACTUALIZADO"].Value.ToString());
                    codigo = Convert.ToInt32(comando.Parameters["@codigo"].Value.ToString());
                    mensaje = comando.Parameters["@mensaje"].Value.ToString();
                }
                catch (Exception e)
                {
                    ordenCompraNumeroActualizado = 0;
                    codigo = -1;
                    mensaje = e.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static void RechazaOrdenCompra(int ordenCompraNumero, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand("sp_rechaza_orden_compra", conexion);
                    comando.Parameters.AddWithValue("@OC_NUMERO", ordenCompraNumero);
                    comando.Parameters.Add("@codigo", SqlDbType.Int);
                    comando.Parameters.Add("@mensaje", SqlDbType.VarChar, 250);
                    comando.Parameters["@codigo"].Direction = ParameterDirection.Output;
                    comando.Parameters["@mensaje"].Direction = ParameterDirection.Output;
                    conexion.Open();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.ExecuteNonQuery();
                    codigo = Convert.ToInt32(comando.Parameters["@codigo"].Value.ToString());
                    mensaje = comando.Parameters["@mensaje"].Value.ToString();
                }
                catch (Exception e)
                {
                    codigo = -1;
                    mensaje = e.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static void AsignaCarpetaAntecedentes(string ruta, out int codigo, out string mensaje)
        {
            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                    codigo = 1;
                    mensaje = "Carpeta creada y asignada.";
                }
                else
                {
                    codigo = 1;
                    mensaje = "Carpeta asignada.";
                }
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
            }
        }

        public static void ConfirmaAntecedentes(string ruta, string ruta2, out int codigo, out string mensaje)
        {
            try
            {
                if (Directory.Exists(ruta))
                {
                    Directory.Move(ruta, ruta2);
                    codigo = 1;
                    mensaje = "Antecedentes confirmados.";
                }
                else
                {
                    codigo = 0;
                    mensaje = "Carpeta no encontrada.";
                }
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
            }
        }

        public static void LimpiaAntecedentes(string ruta, out int codigo, out string mensaje)
        {
            try
            {
                if (Directory.Exists(ruta))
                {
                    foreach (string archivo in Directory.GetFiles(ruta))
                    {
                        File.Delete(archivo);
                    }
                    Directory.Delete(ruta);
                    codigo = 1;
                    mensaje = "Antecedentes limpiados.";
                }
                else
                {
                    codigo = 1;
                    mensaje = "Carpeta no encontrada.";
                }
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
            }
        }
    }
}
