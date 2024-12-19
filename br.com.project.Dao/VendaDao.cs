using ControleDeVendasApp.br.com.project.Connection;
using ControleDeVendasApp.br.com.project.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeVendasApp.br.com.project.Dao
{
    public class VendaDao
    {
        private MySqlConnection connection;
        public VendaDao()
        {
            this.connection = new ConnectionFactory().GetConnection();
        }

        #region Método cadastrar venda
        public void CadastrarVenda(Vendas obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_vendas (cliente_id, data_venda, total_venda, observacoes) 
                              VALUES (@cliente_id, @data_venda, @total_venda, @obs)"; 
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@cliente_id", obj.client_id);
                cmd.Parameters.AddWithValue("@data_venda", obj.data_venda);
                cmd.Parameters.AddWithValue("@total_venda", obj.total_venda);
                cmd.Parameters.AddWithValue("@obs", obj.obs);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Aconteceu o erro: " + ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        #endregion
        #region Método listar vendas
        public DataTable ListarVendas()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT v.id AS 'Código', 
                                      v.data_venda AS 'Data da venda',
                                      c.nome AS 'Cliente',
                                      v.total_venda AS 'Total',
                                      v.observacoes AS 'Obs' 
                                      FROM tb_vendas AS v JOIN tb_clientes AS c ON (v.cliente_id = c.id)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex )
            {

                MessageBox.Show("Aconteceu o erro: " + ex);
                return null;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        #endregion
        #region Método retornar o id da ultima venda
        public int RetornaIdUltimaVenda()
        {
            try
            {
                int idvenda = 0;
                string sql = "SELECT max(id) id FROM tb_vendas";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idvenda = dr.GetInt32("id");
                }
                return idvenda;
            }
            catch (Exception ex)
            {


                MessageBox.Show("Aconteceu o erro: " + ex);
                return 0;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        #endregion
        #region Método que retorna o histórico de vendas
        public DataTable RetornaHistoricoVendas(DateTime datainicio, DateTime datafim)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT v.id AS 'Código', 
                                      v.data_venda AS 'Data da venda',
                                      c.nome AS 'Cliente',
                                      v.total_venda AS 'Total',
                                      v.observacoes AS 'Obs' 
                                      FROM tb_vendas AS v JOIN tb_clientes AS c ON (v.cliente_id = c.id) 
                                      WHERE v.data_venda BETWEEN @datainicio AND @datafim";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@datainicio", datainicio);
                cmd.Parameters.AddWithValue("@datafim", datafim);
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Aconteceu o erro: " + ex);
                return null;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        #endregion
    }
}
