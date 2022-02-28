using System;
using System.Data;
using System.Data.SqlClient;

namespace GestionOC.Dal
{
    public class UsuarioDal
    {
        public static DataTable BuscaUsuario(int usuarioNumero, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.ConectarControlAcceso())
            {
                DataTable dataUsuario = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("SELECT * FROM USUARIO WHERE USU_NUMERO = @pNumUsuario", conexion);
                    comando.Parameters.AddWithValue("@pNumUsuario", usuarioNumero);
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    dataUsuario.AcceptChanges();
                    adp.Fill(dataUsuario);
                    adp.Dispose();
                    codigo = dataUsuario.Rows.Count > 0 ? 1 : 0;
                    mensaje = codigo == 1 ? "Usuario encontrado" : "No se encontró ningún usuario";
                    return dataUsuario;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataUsuario;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static DataTable BuscaUsuarioAcceso(int usuarioNumero, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.ConectarControlAcceso())
            {
                DataTable dataUsuarioAcceso = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("SELECT * FROM ACCESO WHERE USU_NUM_USU = @pNumUsuario", conexion);
                    comando.Parameters.AddWithValue("@pNumUsuario", usuarioNumero);
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    dataUsuarioAcceso.AcceptChanges();
                    adp.Fill(dataUsuarioAcceso);
                    adp.Dispose();
                    codigo = dataUsuarioAcceso.Rows.Count > 0 ? 1 : 0;
                    mensaje = codigo == 1 ? "Acceso encontrado" : "No se encontró ningún acceso";
                    return dataUsuarioAcceso;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataUsuarioAcceso;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static DataTable BuscaUsuarioFormularios(int usuarioNumero, out int codigo, out string mensaje)
        {
            using (SqlConnection conexion = Conexion.ConectarControlAcceso())
            {
                DataTable dataUsuarioFormulario = new DataTable();
                try
                {
                    SqlCommand comando = new SqlCommand("SELECT o.Opc_Formulario FROM OPCION o WHERE o.Opc_Correlativo IN(SELECT p.Pop_Opc_Numero  FROM PERFIL p WHERE p.Usu_Numero = @Usu_Numero) AND o.Sis_CodSistema = @Sis_CodSistema", conexion);
                    comando.Parameters.AddWithValue("@Usu_Numero", usuarioNumero);
                    comando.Parameters.AddWithValue("@Sis_CodSistema", "ODC");
                    SqlDataAdapter adp = new SqlDataAdapter(comando);
                    dataUsuarioFormulario.AcceptChanges();
                    adp.Fill(dataUsuarioFormulario);
                    adp.Dispose();
                    codigo = dataUsuarioFormulario.Rows.Count > 0 ? 1 : 0;
                    mensaje = codigo == 1 ? "formularios encontrados" : "No se encontró ningún formulario";
                    return dataUsuarioFormulario;
                }
                catch (Exception ex)
                {
                    codigo = -1;
                    mensaje = ex.Message;
                    return dataUsuarioFormulario;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }
    }
}
