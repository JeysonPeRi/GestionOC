using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionOC.Dal
{
    public class ImpuestoDal
    {
        public static DataTable ListaImpuesto(out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                DataTable dataImpuesto = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("sp_lista_impuesto", conexion);
                    comando.Parameters.Add("@codigo", SqlDbType.Int);
                    comando.Parameters.Add("@mensaje", SqlDbType.VarChar, 250);
                    comando.Parameters["@codigo"].Direction = ParameterDirection.Output;
                    comando.Parameters["@mensaje"].Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    adp.Fill(dataImpuesto);
                    adp.Dispose();
                    codigo = Convert.ToInt32(comando.Parameters["@codigo"].Value.ToString());
                    mensaje = comando.Parameters["@mensaje"].Value.ToString();
                    return dataImpuesto;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataImpuesto;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static DataTable BuscaImpuesto(DateTime impuestoFecha, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                DataTable dataImpuesto = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("sp_busca_impuesto", conexion);
                    comando.Parameters.AddWithValue("@IMP_FECHA", impuestoFecha);
                    comando.Parameters.Add("@codigo", SqlDbType.Int);
                    comando.Parameters.Add("@mensaje", SqlDbType.VarChar, 250);
                    comando.Parameters["@codigo"].Direction = ParameterDirection.Output;
                    comando.Parameters["@mensaje"].Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    adp.Fill(dataImpuesto);
                    adp.Dispose();
                    codigo = Convert.ToInt32(comando.Parameters["@codigo"].Value.ToString());
                    mensaje = comando.Parameters["@mensaje"].Value.ToString();
                    return dataImpuesto;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataImpuesto;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static void GuardaImpuesto(int impuestoCodigo, float porcentajeCompleto, DateTime fecha, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand("sp_guarda_impuesto", conexion);
                    comando.Parameters.AddWithValue("@IMP_CODIGO", impuestoCodigo);
                    comando.Parameters.AddWithValue("@IMP_PORCENTAJE", porcentajeCompleto);
                    comando.Parameters.AddWithValue("@IMP_FECHA", fecha);
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

        public static void EliminaImpuesto(int impuestoCodigo, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand("sp_elimina_impuesto", conexion);
                    comando.Parameters.AddWithValue("@IMP_CODIGO", impuestoCodigo);
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
    }
}
