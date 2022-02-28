using System;
using System.Data;
using System.Data.SqlClient;

namespace GestionOC.Dal
{
    public class ItemDal
    {
        public static DataTable ListaItem(int ordenCompraNumero, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                DataTable dataItem = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("sp_lista_item", conexion);
                    comando.Parameters.AddWithValue("@ordenCompraNumero", ordenCompraNumero);
                    comando.Parameters.Add("@codigo", SqlDbType.Int);
                    comando.Parameters.Add("@mensaje", SqlDbType.VarChar, 250);
                    comando.Parameters["@codigo"].Direction = ParameterDirection.Output;
                    comando.Parameters["@mensaje"].Direction = ParameterDirection.Output;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    adp.Fill(dataItem);
                    adp.Dispose();
                    codigo = Convert.ToInt32(comando.Parameters["@codigo"].Value.ToString());
                    mensaje = comando.Parameters["@mensaje"].Value.ToString();
                    return dataItem;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataItem;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }
    }
}
