using System;
using System.Data;
using System.Data.SqlClient;

namespace GestionOC.Dal
{
    public class MonedaDal
    {
        public static DataTable ListaMoneda(out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                DataTable dataMoneda = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("sp_lista_moneda", conexion);
                    comando.Parameters.Add("@codigo", SqlDbType.Int);
                    comando.Parameters.Add("@mensaje", SqlDbType.VarChar, 250);
                    comando.Parameters["@codigo"].Direction = ParameterDirection.Output;
                    comando.Parameters["@mensaje"].Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    adp.Fill(dataMoneda);
                    adp.Dispose();
                    codigo = Convert.ToInt32(comando.Parameters["@codigo"].Value.ToString());
                    mensaje = comando.Parameters["@mensaje"].Value.ToString();
                    return dataMoneda;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataMoneda;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static DataTable BuscaMoneda(int monedaCodigo, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                DataTable dataMoneda = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("sp_busca_moneda", conexion);
                    comando.Parameters.AddWithValue("@monedaCodigo", monedaCodigo);
                    comando.Parameters.Add("@codigo", SqlDbType.Int);
                    comando.Parameters.Add("@mensaje", SqlDbType.VarChar, 250);
                    comando.Parameters["@codigo"].Direction = ParameterDirection.Output;
                    comando.Parameters["@mensaje"].Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    adp.Fill(dataMoneda);
                    adp.Dispose();
                    codigo = Convert.ToInt32(comando.Parameters["@codigo"].Value.ToString());
                    mensaje = comando.Parameters["@mensaje"].Value.ToString();
                    return dataMoneda;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataMoneda;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static void GuardaActualizaMoneda(int monedacodigo, string glosa, string simbolo, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand("sp_guarda_actualiza_moneda", conexion);
                    comando.Parameters.AddWithValue("@MON_CODIGO", monedacodigo);
                    comando.Parameters.AddWithValue("@MON_GLOSA", glosa);
                    comando.Parameters.AddWithValue("@MON_SIMBOLO", simbolo);
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

        public static void EliminaMoneda(int monedacodigo, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                try
                {
                    SqlCommand comando = new SqlCommand("sp_elimina_moneda", conexion);
                    comando.Parameters.AddWithValue("@MON_CODIGO", monedacodigo);
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
