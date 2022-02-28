using System;
using System.Data;
using System.Data.SqlClient;

namespace GestionOC.Dal
{
    public class EmpresaDal
    {
        public static DataTable BuscaEmpresa(int empresaCodigo, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                DataTable dataEmpresa = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("sp_busca_empresa", conexion);
                    comando.Parameters.AddWithValue("@empresaCodigo", empresaCodigo);
                    comando.Parameters.Add("@codigo", SqlDbType.Int);
                    comando.Parameters.Add("@mensaje", SqlDbType.VarChar, 250);
                    comando.Parameters["@codigo"].Direction = ParameterDirection.Output;
                    comando.Parameters["@mensaje"].Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    adp.Fill(dataEmpresa);
                    adp.Dispose();
                    codigo = Convert.ToInt32(comando.Parameters["@codigo"].Value.ToString());
                    mensaje = comando.Parameters["@mensaje"].Value.ToString();
                    return dataEmpresa;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataEmpresa;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }
    }
}
