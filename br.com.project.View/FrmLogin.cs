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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            FuncionarioDao fdao = new FuncionarioDao();
            if(fdao.EfetuarLogin(email, senha))
            {
              
                this.Hide();
            }
            else
            {
                txtEmail.Clear();
                txtSenha.Clear();
                txtEmail.Focus();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            dtDataHora.Value = DateTime.Now;
           
        }
    }
}
