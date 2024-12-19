using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVendasApp.br.com.project.Connection
{
    public class ConnectionFactory
    {
        // Método que conecta com o banco de dados

        public MySqlConnection GetConnection()
        {
            string connection = ConfigurationManager.ConnectionStrings["bdvendas"].ConnectionString;
            return new MySqlConnection(connection);
        }
    }
}
