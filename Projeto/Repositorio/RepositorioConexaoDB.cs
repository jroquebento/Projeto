using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Projeto.Repositorio
{
    public class RepositorioConexaoDB
    { 
        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjetoConn"].ConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
    }
}
