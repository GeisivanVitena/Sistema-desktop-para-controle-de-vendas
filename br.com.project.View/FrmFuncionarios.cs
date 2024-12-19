using ControleDeVendasApp.br.com.project.Dao;
using ControleDeVendasApp.br.com.project.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeVendasApp.br.com.project.View
{
    public partial class FrmFuncionarios : Form
    {
        public FrmFuncionarios()
        {
            InitializeComponent();
        }

        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {

            try
            {
                string cep = txtCep.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";
                DataSet ds = new DataSet();
                ds.ReadXml(xml);

                txtEnd.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = ds.Tables[0].Rows[0]["localidade"].ToString();
                cbUf.Text = ds.Tables[0].Rows[0]["uf"].ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Nenhum endereço encontrado com o cep informado!");
            }
          
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Funcionario obj = new Funcionario();
            obj.nome = txtNome.Text;
            obj.rg = txtRg.Text;
            obj.cpf = txtCpf.Text;
            obj.email = txtEmail.Text;
            obj.senha = txtSenha.Text;
            obj.cargo = cbCargo.Text;
            obj.nivel_acesso = cbNivel.Text;
            obj.telefone = txtTel.Text;
            obj.celular = txtCel.Text;
            obj.cep = txtCep.Text;
            obj.endereco = txtEnd.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComp.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbUf.Text;
            FuncionarioDao dao = new FuncionarioDao();
            dao.CadastrarFuncionario(obj);
            new Helpers().LimparTela(this);
            dgvFuncionarios.DataSource = dao.ListarFuncionarios();
      
        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            FuncionarioDao dao = new FuncionarioDao();
            dgvFuncionarios.DataSource = dao.ListarFuncionarios();
        }

        private void dgvFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pegando os dados do datagridview
            txtCodigo.Text = dgvFuncionarios.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgvFuncionarios.CurrentRow.Cells[1].Value.ToString();
            txtRg.Text = dgvFuncionarios.CurrentRow.Cells[2].Value.ToString();
            txtCpf.Text = dgvFuncionarios.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgvFuncionarios.CurrentRow.Cells[4].Value.ToString();
            txtSenha.Text = dgvFuncionarios.CurrentRow.Cells[5].Value.ToString();
            cbCargo.Text = dgvFuncionarios.CurrentRow.Cells[6].Value.ToString();
            cbNivel.Text = dgvFuncionarios.CurrentRow.Cells[7].Value.ToString();
            txtTel.Text = dgvFuncionarios.CurrentRow.Cells[8].Value.ToString();
            txtCel.Text = dgvFuncionarios.CurrentRow.Cells[9].Value.ToString();
            txtCep.Text = dgvFuncionarios.CurrentRow.Cells[10].Value.ToString();
            txtEnd.Text = dgvFuncionarios.CurrentRow.Cells[11].Value.ToString();
            txtNumero.Text = dgvFuncionarios.CurrentRow.Cells[12].Value.ToString();
            txtComp.Text = dgvFuncionarios.CurrentRow.Cells[13].Value.ToString();
            txtBairro.Text = dgvFuncionarios.CurrentRow.Cells[14].Value.ToString();
            txtCidade.Text = dgvFuncionarios.CurrentRow.Cells[15].Value.ToString();
            cbUf.Text = dgvFuncionarios.CurrentRow.Cells[16].Value.ToString();

            tabFuncionarios.SelectedTab = tabPage1;
        

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Funcionario obj = new Funcionario();
            obj.nome = txtNome.Text;
            obj.rg = txtRg.Text;
            obj.cpf = txtCpf.Text;
            obj.email = txtEmail.Text;
            obj.senha = txtSenha.Text;
            obj.cargo = cbCargo.Text;
            obj.nivel_acesso = cbNivel.Text;
            obj.telefone = txtTel.Text;
            obj.celular = txtCel.Text;
            obj.cep = txtCep.Text;
            obj.endereco = txtEnd.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComp.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbUf.Text;
            obj.codigo = int.Parse(txtCodigo.Text);
            FuncionarioDao dao = new FuncionarioDao();
            dao.EditarFuncionari(obj);
            new Helpers().LimparTela(this);
            dgvFuncionarios.DataSource = dao.ListarFuncionarios();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja realmente excluir este funcionário?", "Excluir Funcionário", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Funcionario obj = new Funcionario();
                obj.codigo = int.Parse(txtCodigo.Text);
                FuncionarioDao dao = new FuncionarioDao();
                dao.ExcluirFuncionario(obj);
                new Helpers().LimparTela(this);
                dgvFuncionarios.DataSource = dao.ListarFuncionarios();

            }

        }

        private void btnPesquisarFunc_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisarFunc.Text;
            FuncionarioDao dao = new FuncionarioDao();
            dgvFuncionarios.DataSource = dao.BuscarFuncionarioPorNome(nome);
            if (dgvFuncionarios.Rows.Count == 0 || txtPesquisarFunc.Text == string.Empty)
            {
                MessageBox.Show("Nenhum funcionário encontrado!");
                txtPesquisarFunc.Clear();
                txtPesquisarFunc.Focus();
                dgvFuncionarios.DataSource = dao.ListarFuncionarios();
            }
  

            
        }

        private void txtPesquisarFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisarFunc.Text + "%";
            FuncionarioDao dao = new FuncionarioDao();
            dgvFuncionarios.DataSource = dao.ListarFuncionarioPorAproximacao(nome);
        }
    }
}
