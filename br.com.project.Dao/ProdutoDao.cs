using ControleDeVendasApp.br.com.project.Connection;
using ControleDeVendasApp.br.com.project.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeVendasApp.br.com.project.Dao
{
    public class ProdutoDao
    {
        private MySqlConnection connection;

        public ProdutoDao()
        {
            this.connection = new ConnectionFactory().GetConnection();
        }
        #region Método cadastrar produto
        public void CadastrarProduto(Produto obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_produtos (descricao, preco, qtd_estoque, for_id)
                              VALUES (@descricao, @preco, @qtd, @for_id)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@descricao", obj.descricao);
                cmd.Parameters.AddWithValue("@preco", obj.preco);
                cmd.Parameters.AddWithValue("@qtd", obj.qtdestoque);
                cmd.Parameters.AddWithValue("@for_id", obj.for_id);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto Cadastrado Com sucesso!");
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
        #region Método listar produtos
        public DataTable ListarProdutos()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT p.id AS 'Código', 
                                      p.descricao AS 'Descrição', 
                                      p.preco AS 'Preço (R$)',
                                      p.qtd_estoque AS 'Qtd. Estoque', 
                                      f.nome AS 'Fornecedor' FROM tb_produtos AS p JOIN tb_fornecedores AS f ON (p.for_id = f.id)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
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
        #region Método editar produtos
        public void EditarProduto(Produto obj)
        {
            try
            {
                string sql = "UPDATE tb_produtos SET descricao=@descricao, preco=@preco, qtd_estoque=@qtd, for_id=@for_id WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", obj.id);
                cmd.Parameters.AddWithValue("@descricao", obj.descricao);
                cmd.Parameters.AddWithValue("@preco", obj.preco);
                cmd.Parameters.AddWithValue("@qtd", obj.qtdestoque);
                cmd.Parameters.AddWithValue("@for_id", obj.for_id);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados Atualizados Com Sucesso!");
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
        #region Método excluir produto
        public void ExcluirProduto(Produto obj)
        {
            try
            {
                string sql = "DELETE FROM tb_produtos WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", obj.id);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto Excluído Com Sucesso!");
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
        #region Método buscar produto por nome
        public DataTable BuscarProdutoPorNome(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT p.id AS 'Código', 
                                      p.descricao AS 'Descrição', 
                                      p.preco AS 'Preço (R$)',
                                      p.qtd_estoque AS 'Qtd. Estoque', 
                                      f.nome AS 'Fornecedor' 
                                      FROM tb_produtos AS p JOIN tb_fornecedores AS f ON (p.for_id = f.id)
                                      WHERE p.descricao=@nome";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nome", nome);
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
        #region Método listar produtos por aproximação
        public DataTable ListarProdutosPorNome(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT p.id AS 'Código', 
                                      p.descricao AS 'Descrição', 
                                      p.preco AS 'Preço (R$)',
                                      p.qtd_estoque AS 'Qtd. Estoque', 
                                      f.nome AS 'Fornecedor' 
                                      FROM tb_produtos AS p JOIN tb_fornecedores AS f ON (p.for_id = f.id)
                                      WHERE p.descricao LIKE @nome";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nome", nome);
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
        #region Método que retorna um produto pelo id
        public Produto RetornaProdutoPeloId(int id)
        {
            try
            {
                Produto produto = new Produto();
                string sql = "SELECT * FROM tb_produtos WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    produto.id = dr.GetInt32("id");
                    produto.descricao = dr.GetString("descricao");
                    produto.preco = dr.GetDecimal("preco");

                    return produto;
                }
                else
                {
                    MessageBox.Show("Nenhum produto encontrado!");
                    return null;
                }
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
        #region Método que da baixa no estoque
        public void BaixaEstoque(int idproduto, int qtdestoque)
        {
            try
            {
                string sql = "UPDATE tb_produtos SET qtd_estoque=@qtd WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@qtd", qtdestoque);
                cmd.Parameters.AddWithValue("@id", idproduto);
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
        #region Método que retorna o estoque atual de um produto 
        public int RetornaEstoqueAtual(int idproduto)
        {
            try
            {
                
                string sql = "SELECT qtd_estoque FROM tb_produtos WHERE id=@id";
                int qtdestoque = 0;
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", idproduto);
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    qtdestoque = dr.GetInt32("qtd_estoque");
                }
                return qtdestoque;
                
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
    }
}
