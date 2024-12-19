using ControleDeVendasApp.br.com.project.Connection;
using ControleDeVendasApp.br.com.project.Model;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeVendasApp.br.com.project.Dao
{
    public class ClienteDao
    {
        private MySqlConnection connection;

        public ClienteDao()
        {
            this.connection = new ConnectionFactory().GetConnection();
        }

        #region Método cadastrar cliente
        public void CadastrarCliente( Cliente obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_clientes (nome, rg, cpf, email, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado)
                              VALUES (@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nome", obj.nome);
                cmd.Parameters.AddWithValue("@rg", obj.rg);
                cmd.Parameters.AddWithValue("@cpf", obj.cpf);
                cmd.Parameters.AddWithValue("@email", obj.email);
                cmd.Parameters.AddWithValue("@telefone", obj.telefone);
                cmd.Parameters.AddWithValue("@celular", obj.celular);
                cmd.Parameters.AddWithValue("@cep", obj.cep);
                cmd.Parameters.AddWithValue("@endereco", obj.endereco);
                cmd.Parameters.AddWithValue("@numero", obj.numero);
                cmd.Parameters.AddWithValue("@complemento", obj.complemento);
                cmd.Parameters.AddWithValue("@bairro", obj.bairro);
                cmd.Parameters.AddWithValue("@cidade", obj.cidade);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente cadastrado com sucesso!");
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
        #region Método listar clientes
        public DataTable ListarClientes()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_clientes";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
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
        #region Método editar cliente
        public void EditarCliente(Cliente obj)
        {
            try
            {
                string sql = @"UPDATE tb_clientes SET nome=@nome, rg=@rg, cpf=@cpf, email=@email, telefone=@telefone, celular=@celular, cep=@cep, endereco=@endereco, numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado
                              WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nome", obj.nome);
                cmd.Parameters.AddWithValue("@rg", obj.rg);
                cmd.Parameters.AddWithValue("@cpf", obj.cpf);
                cmd.Parameters.AddWithValue("@email", obj.email);
                cmd.Parameters.AddWithValue("@telefone", obj.telefone);
                cmd.Parameters.AddWithValue("@celular", obj.celular);
                cmd.Parameters.AddWithValue("@cep", obj.cep);
                cmd.Parameters.AddWithValue("@endereco", obj.endereco);
                cmd.Parameters.AddWithValue("@numero", obj.numero);
                cmd.Parameters.AddWithValue("@complemento", obj.complemento);
                cmd.Parameters.AddWithValue("@bairro", obj.bairro);
                cmd.Parameters.AddWithValue("@cidade", obj.cidade);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                cmd.Parameters.AddWithValue("@id", obj.codigo);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados atualizados com sucesso!");
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
        #region Método excluir cliente
        public void ExcluirCliente( Cliente obj)
        {
            try
            {
                string sql = "DELETE FROM tb_clientes WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", obj.codigo);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente excluído com sucesso!");
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
        #region Método buscar cliente por nome
        public DataTable BuscarClientePorNome(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_clientes WHERE nome=@nome";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nome", nome);
                connection.Open();
                cmd.ExecuteNonQuery();
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
        #region Método listar clientes por aproximação
        public DataTable ListarClientesPorAproximacao(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_clientes WHERE nome LIKE @nome";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nome", nome);
                connection.Open();
                cmd.ExecuteNonQuery();
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
        #region Método que retorna um cliente por cpf
        public Cliente RetornaClientePorCpf(string cpf)
        {
            try
            {
                Cliente obj = new Cliente();
                string sql = "SELECT * FROM tb_clientes WHERE cpf=@cpf";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj.codigo = dr.GetInt32("id");
                    obj.nome = dr.GetString("nome");
                    return obj;
                }
                else
                {
                    MessageBox.Show("Nenhum cliente encontrado!");

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
    }
}
