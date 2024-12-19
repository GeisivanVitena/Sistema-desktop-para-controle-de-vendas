namespace ControleDeVendasApp.br.com.project.View
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultarCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroDeFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultarFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultarFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultarProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNovaVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistoricoVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfiguracao = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTrocarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSairSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtData = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCliente,
            this.menuFuncionario,
            this.menuFornecedores,
            this.menuProdutos,
            this.menuVendas,
            this.menuConfiguracao,
            this.menuSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1308, 72);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuCliente
            // 
            this.menuCliente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroCliente,
            this.menuConsultarCliente});
            this.menuCliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuCliente.Image = global::ControleDeVendasApp.Properties.Resources.client;
            this.menuCliente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCliente.Name = "menuCliente";
            this.menuCliente.Size = new System.Drawing.Size(165, 68);
            this.menuCliente.Text = "Clientes";
            // 
            // menuCadastroCliente
            // 
            this.menuCadastroCliente.Name = "menuCadastroCliente";
            this.menuCadastroCliente.Size = new System.Drawing.Size(299, 28);
            this.menuCadastroCliente.Text = "Cadastro de clientes";
            this.menuCadastroCliente.Click += new System.EventHandler(this.menuCadastroCliente_Click);
            // 
            // menuConsultarCliente
            // 
            this.menuConsultarCliente.Name = "menuConsultarCliente";
            this.menuConsultarCliente.Size = new System.Drawing.Size(299, 28);
            this.menuConsultarCliente.Text = "Consultar clientes";
            this.menuConsultarCliente.Click += new System.EventHandler(this.menuConsultarCliente_Click);
            // 
            // menuFuncionario
            // 
            this.menuFuncionario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroDeFuncionario,
            this.menuConsultarFuncionario});
            this.menuFuncionario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuFuncionario.Image = global::ControleDeVendasApp.Properties.Resources.funcionario1;
            this.menuFuncionario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuFuncionario.Name = "menuFuncionario";
            this.menuFuncionario.Size = new System.Drawing.Size(207, 68);
            this.menuFuncionario.Text = "Funcionários";
            // 
            // menuCadastroDeFuncionario
            // 
            this.menuCadastroDeFuncionario.Name = "menuCadastroDeFuncionario";
            this.menuCadastroDeFuncionario.Size = new System.Drawing.Size(340, 28);
            this.menuCadastroDeFuncionario.Text = "Cadastro de funcionários";
            this.menuCadastroDeFuncionario.Click += new System.EventHandler(this.menuCadastroDeFuncionario_Click);
            // 
            // menuConsultarFuncionario
            // 
            this.menuConsultarFuncionario.Name = "menuConsultarFuncionario";
            this.menuConsultarFuncionario.Size = new System.Drawing.Size(340, 28);
            this.menuConsultarFuncionario.Text = "consultar funcionários";
            this.menuConsultarFuncionario.Click += new System.EventHandler(this.menuConsultarFuncionario_Click);
            // 
            // menuFornecedores
            // 
            this.menuFornecedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroFornecedores,
            this.menuConsultarFornecedores});
            this.menuFornecedores.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuFornecedores.Image = global::ControleDeVendasApp.Properties.Resources.fornecedores;
            this.menuFornecedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuFornecedores.Name = "menuFornecedores";
            this.menuFornecedores.Size = new System.Drawing.Size(222, 68);
            this.menuFornecedores.Text = "Fornecedores";
            // 
            // menuCadastroFornecedores
            // 
            this.menuCadastroFornecedores.Name = "menuCadastroFornecedores";
            this.menuCadastroFornecedores.Size = new System.Drawing.Size(355, 28);
            this.menuCadastroFornecedores.Text = "Cadastro de fornecedores";
            this.menuCadastroFornecedores.Click += new System.EventHandler(this.menuCadastroFornecedores_Click);
            // 
            // menuConsultarFornecedores
            // 
            this.menuConsultarFornecedores.Name = "menuConsultarFornecedores";
            this.menuConsultarFornecedores.Size = new System.Drawing.Size(355, 28);
            this.menuConsultarFornecedores.Text = "Consultar fornecedores";
            this.menuConsultarFornecedores.Click += new System.EventHandler(this.menuConsultarFornecedores_Click);
            // 
            // menuProdutos
            // 
            this.menuProdutos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroProdutos,
            this.menuConsultarProdutos});
            this.menuProdutos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuProdutos.Image = global::ControleDeVendasApp.Properties.Resources.produtos;
            this.menuProdutos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProdutos.Name = "menuProdutos";
            this.menuProdutos.Size = new System.Drawing.Size(173, 68);
            this.menuProdutos.Text = "Produtos";
            // 
            // menuCadastroProdutos
            // 
            this.menuCadastroProdutos.Name = "menuCadastroProdutos";
            this.menuCadastroProdutos.Size = new System.Drawing.Size(312, 28);
            this.menuCadastroProdutos.Text = "Cadastro de produtos";
            this.menuCadastroProdutos.Click += new System.EventHandler(this.menuCadastroProdutos_Click);
            // 
            // menuConsultarProdutos
            // 
            this.menuConsultarProdutos.Name = "menuConsultarProdutos";
            this.menuConsultarProdutos.Size = new System.Drawing.Size(312, 28);
            this.menuConsultarProdutos.Text = "Consultar produtos";
            this.menuConsultarProdutos.Click += new System.EventHandler(this.menuConsultarProdutos_Click);
            // 
            // menuVendas
            // 
            this.menuVendas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNovaVenda,
            this.menuHistoricoVendas});
            this.menuVendas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuVendas.Image = global::ControleDeVendasApp.Properties.Resources.vendas;
            this.menuVendas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVendas.Name = "menuVendas";
            this.menuVendas.Size = new System.Drawing.Size(164, 68);
            this.menuVendas.Text = "Vendas";
            // 
            // menuNovaVenda
            // 
            this.menuNovaVenda.Name = "menuNovaVenda";
            this.menuNovaVenda.Size = new System.Drawing.Size(287, 28);
            this.menuNovaVenda.Text = "Nova venda";
            this.menuNovaVenda.Click += new System.EventHandler(this.menuNovaVenda_Click);
            // 
            // menuHistoricoVendas
            // 
            this.menuHistoricoVendas.Name = "menuHistoricoVendas";
            this.menuHistoricoVendas.Size = new System.Drawing.Size(287, 28);
            this.menuHistoricoVendas.Text = "Histórico de vendas";
            this.menuHistoricoVendas.Click += new System.EventHandler(this.menuHistoricoVendas_Click);
            // 
            // menuConfiguracao
            // 
            this.menuConfiguracao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTrocarUsuario});
            this.menuConfiguracao.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuConfiguracao.Image = global::ControleDeVendasApp.Properties.Resources.configuration;
            this.menuConfiguracao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuConfiguracao.Name = "menuConfiguracao";
            this.menuConfiguracao.Size = new System.Drawing.Size(230, 68);
            this.menuConfiguracao.Text = "Configurações";
            // 
            // menuTrocarUsuario
            // 
            this.menuTrocarUsuario.Name = "menuTrocarUsuario";
            this.menuTrocarUsuario.Size = new System.Drawing.Size(228, 28);
            this.menuTrocarUsuario.Text = "Trocar usuário";
            this.menuTrocarUsuario.Click += new System.EventHandler(this.menuTrocarUsuario_Click);
            // 
            // menuSair
            // 
            this.menuSair.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSairSistema});
            this.menuSair.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuSair.Image = global::ControleDeVendasApp.Properties.Resources.sair;
            this.menuSair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(119, 68);
            this.menuSair.Text = "sair";
            // 
            // menuSairSistema
            // 
            this.menuSairSistema.Name = "menuSairSistema";
            this.menuSairSistema.Size = new System.Drawing.Size(238, 28);
            this.menuSairSistema.Text = "Sair do sistema";
            this.menuSairSistema.Click += new System.EventHandler(this.menuSairSistema_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txtData,
            this.toolStripStatusLabel3,
            this.txtHora,
            this.toolStripStatusLabel5,
            this.txtUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 796);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1308, 29);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(130, 23);
            this.toolStripStatusLabel1.Text = "Data Atual: ";
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(116, 23);
            this.txtData.Text = "19/12/2024";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(122, 23);
            this.toolStripStatusLabel3.Text = "          Hora:";
            // 
            // txtHora
            // 
            this.txtHora.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(60, 23);
            this.txtHora.Text = "17:47";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel5.ForeColor = System.Drawing.Color.Green;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(227, 23);
            this.toolStripStatusLabel5.Text = "          Usuário Logado:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.Green;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(28, 23);
            this.txtUsuario.Text = "...";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::ControleDeVendasApp.Properties.Resources.fundo3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1308, 825);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GSVtech - Sistemas";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCliente;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroCliente;
        private System.Windows.Forms.ToolStripMenuItem menuFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroDeFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuConsultarFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroFornecedores;
        private System.Windows.Forms.ToolStripMenuItem menuConsultarFornecedores;
        private System.Windows.Forms.ToolStripMenuItem menuProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuConsultarProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuVendas;
        private System.Windows.Forms.ToolStripMenuItem menuNovaVenda;
        private System.Windows.Forms.ToolStripMenuItem menuHistoricoVendas;
        private System.Windows.Forms.ToolStripMenuItem menuTrocarUsuario;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.ToolStripMenuItem menuSairSistema;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ToolStripMenuItem menuFornecedores;
        public System.Windows.Forms.ToolStripMenuItem menuConfiguracao;
        public System.Windows.Forms.ToolStripMenuItem menuConsultarCliente;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        public System.Windows.Forms.ToolStripStatusLabel txtData;
        public System.Windows.Forms.ToolStripStatusLabel txtHora;
        public System.Windows.Forms.ToolStripStatusLabel txtUsuario;
    }
}