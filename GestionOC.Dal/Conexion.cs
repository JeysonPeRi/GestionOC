using System.Configuration;
using System.Data.SqlClient;

namespace GestionOC.Dal
{
    class Conexion
    {
        public static SqlConnection Conectar()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["strConexion"].ConnectionString);
        }

        public static SqlConnection ConectarControlAcceso()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["strConexionAcceso"].ConnectionString);
        }

        public static SqlConnection ConectarContab()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["strConexionContab"].ConnectionString);
        }
    }
}
