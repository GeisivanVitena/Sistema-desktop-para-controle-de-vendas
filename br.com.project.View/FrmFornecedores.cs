using ControleDeVendasApp.br.com.project.Dao;
using ControleDeVendasApp.br.com.project.Model;
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
    public partial class FrmFornecedores : Form
    {
        public FrmFornecedores()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {
            try
            {
                string cep = txtCepForn.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";
                DataSet dados = new DataSet();
                dados.ReadXml(xml);

                txtEnd.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                cbUf.Text = dados.Tables[0].Rows[0]["uf"].ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Nenhum endereço encontrado, digite manualmente!");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Fornecedor obj = new Fornecedor();
            obj.nome = txtNome.Text;
            obj.cnpj = txtCnpj.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTel.Text;
            obj.celular = txtCel.Text;
            obj.cep = txtCepForn.Text;
            obj.endereco = txtEnd.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComp.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbUf.Text;
            FornecedorDao dao = new FornecedorDao();
            dao.CadastrarFornecedor(obj);
            new Helpers().LimparTela(this);
            dgvFornecedores.DataSource = dao.ListarFornecedores();
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            FornecedorDao dao = new FornecedorDao();
            dgvFornecedores.DataSource = dao.ListarFornecedores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Fornecedor obj = new Fornecedor();
            obj.nome = txtNome.Text;
            obj.cnpj = txtCnpj.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTel.Text;
            obj.celular = txtCel.Text;
            obj.cep = txtCepForn.Text;
            obj.endereco = txtEnd.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComp.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbUf.Text;
            obj.codigo = int.Parse(txtCodigo.Text);
            FornecedorDao dao = new FornecedorDao();
            dao.EditarFornecedor(obj);
            new Helpers().LimparTela(this);
            dgvFornecedores.DataSource = dao.ListarFornecedores();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja realmente excluir este fornecedor?", "Excluir Fornecedor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Fornecedor obj = new Fornecedor();
                obj.codigo = int.Parse(txtCodigo.Text);
                FornecedorDao dao = new FornecedorDao();
                dao.ExcluirFornecedor(obj);
                new Helpers().LimparTela(this);
                dgvFornecedores.DataSource = dao.ListarFornecedores();
            }

        }

        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pegando os dados do datagridview
            txtCodigo.Text = dgvFornecedores.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgvFornecedores.CurrentRow.Cells[1].Value.ToString();
            txtCnpj.Text = dgvFornecedores.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dgvFornecedores.CurrentRow.Cells[3].Value.ToString();
            txtTel.Text = dgvFornecedores.CurrentRow.Cells[4].Value.ToString();
            txtCel.Text = dgvFornecedores.CurrentRow.Cells[5].Value.ToString();
            txtCepForn.Text = dgvFornecedores.CurrentRow.Cells[6].Value.ToString();
            txtEnd.Text = dgvFornecedores.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text = dgvFornecedores.CurrentRow.Cells[8].Value.ToString();
            txtComp.Text = dgvFornecedores.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text = dgvFornecedores.CurrentRow.Cells[10].Value.ToString();
            txtCidade.Text = dgvFornecedores.CurrentRow.Cells[11].Value.ToString();
            cbUf.Text = dgvFornecedores.CurrentRow.Cells[12].Value.ToString();
            tabFornecedores.SelectedTab = tabPage1;
        }

        private void btnPesquisarForn_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisarForn.Text;
            FornecedorDao dao = new FornecedorDao();
            dgvFornecedores.DataSource = dao.BuscarFornecedorPorNome(nome);

            if(dgvFornecedores.Rows.Count == 0 || txtPesquisarForn.Text == string.Empty)
            {
                MessageBox.Show("Nenhum fornecedor encontrado!");
                dgvFornecedores.DataSource = dao.ListarFornecedores();
            }
        }

        private void txtPesquisarForn_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisarForn.Text + "%";
            FornecedorDao dao = new FornecedorDao();
            dgvFornecedores.DataSource = dao.ListarFornecedoresPorAproximacao(nome);
        }
    }
}
