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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            txtData.Text = DateTime.Now.ToShortDateString();
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void menuSairSistema_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja realmente sair do sistema?", "Sair do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuCadastroCliente_Click(object sender, EventArgs e)
        {
            FrmClientes telaclientes = new FrmClientes();
            telaclientes.ShowDialog();
        }

        private void menuConsultarCliente_Click(object sender, EventArgs e)
        {
            FrmClientes tela = new FrmClientes();
            tela.tabClientes.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void menuCadastroDeFuncionario_Click(object sender, EventArgs e)
        {
            FrmFuncionarios tela = new FrmFuncionarios();
            tela.ShowDialog();
        }

        private void menuConsultarFuncionario_Click(object sender, EventArgs e)
        {
            FrmFuncionarios tela = new FrmFuncionarios();
            tela.tabFuncionarios.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void menuCadastroFornecedores_Click(object sender, EventArgs e)
        {
            FrmFornecedores tela = new FrmFornecedores();
            tela.ShowDialog();
        }

        private void menuConsultarFornecedores_Click(object sender, EventArgs e)
        {
            FrmFornecedores tela = new FrmFornecedores();
            tela.tabFornecedores.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void menuCadastroProdutos_Click(object sender, EventArgs e)
        {
            FrmProdutos tela = new FrmProdutos();
            tela.ShowDialog();
        }

        private void menuConsultarProdutos_Click(object sender, EventArgs e)
        {
            FrmProdutos tela = new FrmProdutos();
            tela.tabProdutos.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void menuNovaVenda_Click(object sender, EventArgs e)
        {
            FrmVendas tela = new FrmVendas();
            tela.ShowDialog();
        }

        private void menuHistoricoVendas_Click(object sender, EventArgs e)
        {
            FrmHistoricoVendas tela = new FrmHistoricoVendas();
            tela.ShowDialog();
        }

        private void menuTrocarUsuario_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Você será redirecionado para a tela de login, deseja continuar?", "Trocar Usuário", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Close();
                FrmLogin tela = new FrmLogin();
                tela.ShowDialog();
            }
           
        }

     
    }
}
