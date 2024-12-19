using ControleDeVendasApp.br.com.project.Connection;
using ControleDeVendasApp.br.com.project.Model;
using ControleDeVendasApp.br.com.project.View;
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
    public class FuncionarioDao
    {
        private MySqlConnection connection;

        public FuncionarioDao()
        {
            this.connection = new ConnectionFactory().GetConnection();
        }

        #region Método cadastrar funcionário
        public void CadastrarFuncionario(Funcionario obj)
        {
            try
            {
                string sql = @"INSERT INTO tb_funcionarios (nome, rg, cpf, email, senha, cargo, nivel_acesso, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado)
                          VALUES (@nome, @rg, @cpf, @email, @senha, @cargo, @nivel_acesso, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nome", obj.nome);
                cmd.Parameters.AddWithValue("@rg", obj.rg);
                cmd.Parameters.AddWithValue("@cpf", obj.cpf);
                cmd.Parameters.AddWithValue("@email", obj.email);
                cmd.Parameters.AddWithValue("@senha", obj.senha);
                cmd.Parameters.AddWithValue("@cargo", obj.cargo);
                cmd.Parameters.AddWithValue("@nivel_acesso", obj.nivel_acesso);
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
                MessageBox.Show("Funcionário cadastrado com sucesso!");
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
        #region Método listar funcionarios
        public DataTable ListarFuncionarios()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_funcionarios";
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
        #region Método editar funcionário
        public void EditarFuncionari(Funcionario obj)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"UPDATE tb_funcionarios SET nome=@nome, rg=@rg, cpf=@cpf, email=@email, senha=@senha, cargo=@cargo, nivel_acesso=@nivel_acesso, telefone=@telefone, celular=@celular, cep=@cep, endereco=@endereco, numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado
                              WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nome", obj.nome);
                cmd.Parameters.AddWithValue("@rg", obj.rg);
                cmd.Parameters.AddWithValue("@cpf", obj.cpf);
                cmd.Parameters.AddWithValue("@email", obj.email);
                cmd.Parameters.AddWithValue("@senha", obj.senha);
                cmd.Parameters.AddWithValue("@cargo", obj.cargo);
                cmd.Parameters.AddWithValue("@nivel_acesso", obj.nivel_acesso);
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
        #region Método excluir funcionario
        public void ExcluirFuncionario(Funcionario obj)
        {
            try
            {
                string sql = "DELETE FROM tb_funcionarios WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", obj.codigo);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Funcionário excluído com sucesso!");
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
        #region Método buscar funcionario por nome
        public DataTable BuscarFuncionarioPorNome(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_funcionarios WHERE nome=@nome";
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
        #region Método listar funcionário por aproximação
        public DataTable ListarFuncionarioPorAproximacao(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM tb_funcionarios WHERE nome LIKE @nome";
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
        #region Método efetuar login
        public bool EfetuarLogin(string email, string senha)
        {
            try
            {
                string sql = "SELECT * FROM tb_funcionarios WHERE email=@email AND senha=@senha";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    // pegando o nivel para permissões de acesso
                    string nivel_acesso = dr.GetString("nivel_acesso");
                    string nome = dr.GetString("nome");
                    MessageBox.Show("Login efetuado com sucesso, seja bem vindo(a) " + nome);
                    // Tratando os nivéis de acesso
                    FrmMenu telamenu = new FrmMenu();
                    // Pegando o nome do usuário logado
                    telamenu.txtUsuario.Text = nome;
                    if (nivel_acesso.Equals("Administrador"))
                    {
                        telamenu.Show();
                    }
                    else if (nivel_acesso.Equals("Usuário"))
                    {
                        telamenu.menuConfiguracao.Enabled = false;
                        telamenu.menuFornecedores.Enabled = false;
                        telamenu.Show();
                    }

                    return true;
                }
                else
                {
                    MessageBox.Show("E-mail ou senha incorreto!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aconteceu o erro: " + ex);
                return false;
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
