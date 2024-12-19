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
    public class ItemVendaDao
    {
        private MySqlConnection connection;

        public ItemVendaDao()
        {
            this.connection = new ConnectionFactory().GetConnection();
        }

        #region Método cadastrar itens da venda
        public void CadastrarItensVenda(ItensVendas obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_itensvendas (venda_id, produto_id, qtd, subtotal) 
                              VALUES (@venda_id, @produto_id, @qtd, @subtotal)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@venda_id", obj.venda_id);
                cmd.Parameters.AddWithValue("@produto_id", obj.produto_id);
                cmd.Parameters.AddWithValue("@qtd", obj.qtd);
                cmd.Parameters.AddWithValue("@subtotal", obj.subtotal);
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
        #region Método que lista os itens da venda nos detalhes da venda
        public DataTable ListarItensDaVenda(int venda_id)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT i.id AS 'Código',
                                      p.descricao AS 'Descrição',
                                      i.qtd AS 'Quantidade',
                                      p.preco AS 'Preço',
                                      i.subtotal AS 'Subtotal' 
                                      FROM tb_itensvendas AS i JOIN tb_produtos AS p 
                                      ON (i.produto_id = p.id) WHERE venda_id=@venda_id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@venda_id", venda_id);
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
