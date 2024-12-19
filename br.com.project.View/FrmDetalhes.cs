using ControleDeVendasApp.br.com.project.Dao;
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
    public partial class FrmDetalhes : Form
    {
        int venda_id;
        public FrmDetalhes(int idvenda)
        {
            // Pegando o id do produto para passar como parametro da venda
            venda_id = idvenda; 
            InitializeComponent();
        }

        private void FrmDetalhes_Load(object sender, EventArgs e)
        {
            ItemVendaDao ivdao = new ItemVendaDao();
            dgvDetalhes.DataSource = ivdao.ListarItensDaVenda(venda_id);
        }
    }
}
