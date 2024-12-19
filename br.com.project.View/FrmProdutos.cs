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
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            // Carregando os dados do fornecedor no combobox
            FornecedorDao f_dao = new FornecedorDao();
            cbFornecedor.DataSource = f_dao.ListarFornecedores();
            cbFornecedor.DisplayMember = "nome";
            cbFornecedor.ValueMember = "id";

            ProdutoDao dao = new ProdutoDao();
            dgvProdutos.DataSource = dao.ListarProdutos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto obj = new Produto();
            obj.descricao = txtDescricao.Text;
            obj.preco = decimal.Parse(txtPreco.Text);
            obj.qtdestoque = int.Parse(txtQtd.Text);
            obj.for_id = int.Parse(cbFornecedor.SelectedValue.ToString());
            ProdutoDao dao = new ProdutoDao();
            dao.CadastrarProduto(obj);
            new Helpers().LimparTela(this);
            dgvProdutos.DataSource = dao.ListarProdutos();
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            txtCodigo.Text = dgvProdutos.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = dgvProdutos.CurrentRow.Cells[1].Value.ToString();
            txtPreco.Text = dgvProdutos.CurrentRow.Cells[2].Value.ToString();
            txtQtd.Text = dgvProdutos.CurrentRow.Cells[3].Value.ToString();
            cbFornecedor.Text = dgvProdutos.CurrentRow.Cells[4].Value.ToString();
            tabProdutos.SelectedTab = tabPage1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Produto obj = new Produto();
            obj.id = int.Parse(txtCodigo.Text);
            obj.descricao = txtDescricao.Text;
            obj.preco = decimal.Parse(txtPreco.Text);
            obj.qtdestoque = int.Parse(txtQtd.Text);
            obj.for_id = int.Parse(cbFornecedor.SelectedValue.ToString());
            ProdutoDao dao = new ProdutoDao();
            dao.EditarProduto(obj);
            new Helpers().LimparTela(this); 
            dgvProdutos.DataSource = dao.ListarProdutos();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja realmente excluir este produto?", "Excluir Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Produto obj = new Produto();
                obj.id = int.Parse(txtCodigo.Text);
                ProdutoDao dao = new ProdutoDao();
                dao.ExcluirProduto(obj);
                new Helpers().LimparTela(this);
                dgvProdutos.DataSource = dao.ListarProdutos();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisarPro.Text;
            ProdutoDao dao = new ProdutoDao();
            dgvProdutos.DataSource = dao.BuscarProdutoPorNome(nome);
            if (dgvProdutos.Rows.Count == 0 || txtPesquisarPro.Text == string.Empty)
            {
                MessageBox.Show("Nenhum produto encontrado!");
                dgvProdutos.DataSource = dao.ListarProdutos();
            }
        }

        private void txtPesquisarPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisarPro.Text + "%";
            ProdutoDao dao = new ProdutoDao();
            dgvProdutos.DataSource = dao.ListarProdutosPorNome(nome);
        }
    }
}
