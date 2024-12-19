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
    public partial class FrmPagamentos : Form
    {
        // Criando objetos para manipular os valores na tela de pagamentos e salvar na tabela de vendas
        Cliente cliente = new Cliente();
        DataTable carrinho = new DataTable();
        DateTime dataatual;
        public FrmPagamentos(Cliente cliente, DataTable carrinho, DateTime dataatual)
        {
            this.cliente = cliente;
            this.carrinho = carrinho;
            this.dataatual = dataatual;

            InitializeComponent();
            this.dataatual = dataatual;
        }

        private void FrmPagamentos_Load(object sender, EventArgs e)
        {
            txtDinheiro.Text = "0,00";
            txtTroco.Text = "0,00";
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                // Variaveis para dar baixa no estoque 
                int qtd_estoque, qtd_comprada, estoque_atual;
                ProdutoDao produto_dao = new ProdutoDao();

                // Fazendo calculo das compras 
                decimal v_dinheiro, troco, total_pago, total;

                v_dinheiro = decimal.Parse(txtDinheiro.Text);
                total = decimal.Parse(txtTotal.Text);
                total_pago = v_dinheiro;

                if (total_pago < total)
                {
                    MessageBox.Show("Atenção: Valor pago insuficiente!");
                }
                else
                {
                    troco = total_pago - total;

                    // Pegando os dados e salvando na tabela de vendas
                    Vendas vendas = new Vendas();
                    vendas.client_id = cliente.codigo;
                    vendas.data_venda = dataatual;
                    vendas.total_venda = total;
                    vendas.obs = txtObs.Text;

                    VendaDao vdao = new VendaDao();
                    vdao.CadastrarVenda(vendas);
                    txtTroco.Text = troco.ToString();

                    // Salvando os itens da venda
                    foreach (DataRow linha in carrinho.Rows)
                    {
                        ItensVendas item = new ItensVendas();
                        item.venda_id = vdao.RetornaIdUltimaVenda();
                        item.produto_id = int.Parse(linha["Código"].ToString());
                        item.qtd = int.Parse(linha["Qtd"].ToString());
                        item.subtotal = decimal.Parse(linha["Subtotal"].ToString());

                        // Baixa no estoque
                        qtd_estoque = produto_dao.RetornaEstoqueAtual(item.produto_id);
                        qtd_comprada = item.qtd;
                        estoque_atual = qtd_estoque - qtd_comprada;

                        produto_dao.BaixaEstoque(item.produto_id, estoque_atual);
                      

                        ItemVendaDao ivdao = new ItemVendaDao();
                        ivdao.CadastrarItensVenda(item);
                    }

                    MessageBox.Show("Venda Finalizada Com Sucesso!");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Aconteceu o erro: " + ex);
            }
            this.Dispose();
            new FrmVendas().ShowDialog();
        
        }
    }
}
