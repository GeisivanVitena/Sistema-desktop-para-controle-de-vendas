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
    public partial class FrmVendas : Form
    {
        // Objeto para retornar o nome do cliente por cpf
        Cliente cliente = new Cliente();
        ClienteDao cdao = new ClienteDao();

        // Objetos para retornar um produto pelo id
        Produto produto = new Produto();
        ProdutoDao pdao = new ProdutoDao();

        // variaveis para armazenar a quantidade digitada pelo usuario e fazer o calculo dos produtos
        int qtd;
        decimal preco, subtotal, total;

        // Criando objeto carrinho para adicionar os produtos
        DataTable carrinho = new DataTable();
        public FrmVendas()
        {
            InitializeComponent();
            
            // Criando as colunas do carrinho no datagridview
            carrinho.Columns.Add("Código", typeof(int));
            carrinho.Columns.Add("Descrição", typeof(string));
            carrinho.Columns.Add("Preço", typeof(decimal));
            carrinho.Columns.Add("Qtd", typeof(int));
            carrinho.Columns.Add("Subtotal", typeof (decimal));
            dgvVendas.DataSource = carrinho;
        }

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            txtData.Text = DateTime.Now.ToShortDateString();
            txtCpf.Focus();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Fazendo calculo
                qtd = int.Parse(txtQtd.Text);
                preco = decimal.Parse(txtPreco.Text);
                subtotal = qtd * preco;
                total += subtotal;

                // Adicionando valores no carrinho
                carrinho.Rows.Add(int.Parse(txtCodigo.Text), txtDescricao.Text, preco, qtd, subtotal);
                txtTotal.Text = total.ToString();


                txtCodigo.Clear();
                txtDescricao.Clear();
                txtPreco.Clear();
                txtQtd.Clear();
                txtCodigo.Focus();
            }
            catch (Exception)
            {

                MessageBox.Show("Digite o código do produto!");
            }
            

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            // Pegando o valor do subtotal para subtrair a compra
            decimal subproduto = decimal.Parse(dgvVendas.CurrentRow.Cells[4].Value.ToString());

            int indice = dgvVendas.CurrentRow.Index;
            DataRow linha = carrinho.Rows[indice];
            carrinho.Rows.Remove(linha);
            carrinho.AcceptChanges();

            total -= subproduto;
            txtTotal.Text = total.ToString();
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            // Objeto com os parametros para pegar as informações do cliente, do carrinho e a data atual que serão salvas no banco de dados
            DateTime dataatual = DateTime.Parse(txtData.Text);  
            FrmPagamentos tela = new FrmPagamentos(cliente, carrinho, dataatual);
            tela.txtTotal.Text = total.ToString();
            tela.ShowDialog();
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        // Chamando a função que retorna um cliente pelo cpf
        {
         
                if (e.KeyChar == 13)
                {
                    cliente = cdao.RetornaClientePorCpf(txtCpf.Text);
                    if (cliente != null)
                    {
                        txtNome.Text = cliente.nome;
                    }
                    else
                    {
                        txtCpf.Clear();
                        txtCpf.Focus();
                    }
                   
                }
          
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chamando a função que retorna um produto pelo id
            if (e.KeyChar == 13)
            {
                produto = pdao.RetornaProdutoPeloId(int.Parse(txtCodigo.Text));

                if (produto != null)
                {
                    txtDescricao.Text = produto.descricao;
                    txtPreco.Text = produto.preco.ToString();
                }
                else
                {
                    txtCodigo.Clear();
                    txtDescricao.Clear();
                    txtPreco.Clear();
                    txtCodigo.Focus();
                }
               

            }
            



        }
    }
}
