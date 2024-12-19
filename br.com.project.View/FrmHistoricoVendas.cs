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
    public partial class FrmHistoricoVendas : Form
    {
        public FrmHistoricoVendas()
        {
            InitializeComponent();
        }

        private void FrmHistoricoVendas_Load(object sender, EventArgs e)
        {
            //Carregando a lista de vendas quando inicializar o formulário
            VendaDao vdao = new VendaDao();
            dgvHistorico.DataSource = vdao.ListarVendas();
            dgvHistorico.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            // Selecionando as datas de icio e fim  e chamando o método para pesquisar o histórico de vendas
            DateTime datainicio, datafim;

            datainicio = Convert.ToDateTime(dtInicio.Value.ToString("yyyy, MM, dd"));
            datafim = Convert.ToDateTime(dtFim.Value.ToString("yyyy, MM, dd"));
            VendaDao dao = new VendaDao();
            dgvHistorico.DataSource = dao.RetornaHistoricoVendas(datainicio, datafim);
        }

        private void dgvHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // pegando o id da venda e Carregando os dados de historico de vendas para a tela de detalhas da venda
            int idvenda = int.Parse(dgvHistorico.CurrentRow.Cells[0].Value.ToString());
            FrmDetalhes tela = new FrmDetalhes(idvenda);
            tela.txtData.Text = dgvHistorico.CurrentRow.Cells[1].Value.ToString();
            tela.txtCliente.Text = dgvHistorico.CurrentRow.Cells[2].Value.ToString();
            tela.txtTotal.Text = dgvHistorico.CurrentRow.Cells[3].Value.ToString();
            tela.txtObs.Text = dgvHistorico.CurrentRow.Cells[4].Value.ToString();
            tela.ShowDialog();
            
        }
    }
}
