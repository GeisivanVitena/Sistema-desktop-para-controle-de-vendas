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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            obj.nome = txtNome.Text;
            obj.rg = txtRg.Text;
            obj.cpf = txtCpf.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTel.Text;
            obj.celular = txtCel.Text;
            obj.cep = txtCep.Text;
            obj.endereco = txtEnd.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComp.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbUf.Text;
            ClienteDao dao = new ClienteDao();
            dao.CadastrarCliente(obj);
            new Helpers().LimparTela(this);
            dgvClientes.DataSource = dao.ListarClientes();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ClienteDao dao = new ClienteDao();
            dgvClientes.DataSource = dao.ListarClientes();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pegando os dados do datagrid view
            txtCodigo.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            txtRg.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
            txtCpf.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
            txtTel.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
            txtCel.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
            txtCep.Text = dgvClientes.CurrentRow.Cells[7].Value.ToString();
            txtEnd.Text = dgvClientes.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text = dgvClientes.CurrentRow.Cells[9].Value.ToString();
            txtComp.Text = dgvClientes.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = dgvClientes.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = dgvClientes.CurrentRow.Cells[12].Value.ToString();
            cbUf.Text = dgvClientes.CurrentRow.Cells[13].Value.ToString();
            tabClientes.SelectedTab = tabPage1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            Cliente obj = new Cliente();
            obj.nome = txtNome.Text;
            obj.rg = txtRg.Text;
            obj.cpf = txtCpf.Text;
            obj.email = txtEmail.Text;
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
            ClienteDao dao = new ClienteDao();
            dao.EditarCliente(obj);
            new Helpers().LimparTela(this);
            dgvClientes.DataSource = dao.ListarClientes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja realmente excluir este cliente?", "Excluir Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Cliente obj = new Cliente();
                obj.codigo = int.Parse(txtCodigo.Text);
                ClienteDao dao = new ClienteDao();
                dao.ExcluirCliente(obj);
                new Helpers().LimparTela(this);
                dgvClientes.DataSource = dao.ListarClientes();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisarCli.Text;
            ClienteDao dao = new ClienteDao();
            dgvClientes.DataSource = dao.BuscarClientePorNome(nome);
            if (dgvClientes.Rows.Count == 0 || txtPesquisarCli.Text == string.Empty)
            {
                MessageBox.Show("Nenhum cliente encontrado!");
                txtPesquisarCli.Clear();
                txtPesquisarCli.Focus();
                dgvClientes.DataSource = dao.ListarClientes();
            }
        }

        private void txtPesquisarCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisarCli.Text + "%";
            ClienteDao dao = new ClienteDao();
            dgvClientes.DataSource = dao.ListarClientesPorAproximacao(nome);
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
                txtCep.Clear();
                txtCep.Focus();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }
    }
}
