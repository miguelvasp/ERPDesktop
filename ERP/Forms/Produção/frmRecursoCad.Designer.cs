namespace ERP
{
    partial class frmRecursoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecursoCad));
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboUnidadeCapacidade = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCapacidade = new System.Windows.Forms.TextBox();
            this.txtCapacidadeLote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPorcentagemPlanoOperacao = new System.Windows.Forms.TextBox();
            this.txtPorcentagemEficiencia = new System.Windows.Forms.TextBox();
            this.chkCapacidadeFinita = new System.Windows.Forms.CheckBox();
            this.chkPropriedadeFinita = new System.Windows.Forms.CheckBox();
            this.chkExclusivo = new System.Windows.Forms.CheckBox();
            this.cboGrupoRoteiro = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPorcentagemSucata = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTempoEsperaAnterior = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTempoEsperaPosterior = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTempoExecusao = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTempoPreparacao = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTempoTransito = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboFuncionario = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtHorasTempo = new System.Windows.Forms.TextBox();
            this.cboLocalProducao = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cboContaContabilCusto = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboContaContabilContraCusto = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboContaContabilWIP = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cboContaContabilContaPartidaWIP = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrava
            // 
            this.btnGrava.Enabled = false;
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAlterar.SmallImage")));
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnAdiciona
            // 
            this.btnAdiciona.Image = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.Image")));
            this.btnAdiciona.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.SmallImage")));
            this.btnAdiciona.Text = "Adicionar";
            this.btnAdiciona.Click += new System.EventHandler(this.btnAdiciona_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.btnAdiciona);
            this.ribbonPanel1.Items.Add(this.btnAlterar);
            this.ribbonPanel1.Items.Add(this.btnGrava);
            this.ribbonPanel1.Items.Add(this.btnCancelar);
            this.ribbonPanel1.Items.Add(this.btnExcluir);
            this.ribbonPanel1.Text = "Informações";
            // 
            // rbOpcoes
            // 
            this.rbOpcoes.Panels.Add(this.ribbonPanel1);
            this.rbOpcoes.Text = "Documento";
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbDropDown.Visible = false;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(784, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(21, 171);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(290, 20);
            this.txtDescricao.TabIndex = 13;
            this.txtDescricao.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Descrição";
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(317, 170);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(233, 21);
            this.cboTipo.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tipo";
            // 
            // cboUnidadeCapacidade
            // 
            this.cboUnidadeCapacidade.FormattingEnabled = true;
            this.cboUnidadeCapacidade.Location = new System.Drawing.Point(556, 170);
            this.cboUnidadeCapacidade.Name = "cboUnidadeCapacidade";
            this.cboUnidadeCapacidade.Size = new System.Drawing.Size(211, 21);
            this.cboUnidadeCapacidade.TabIndex = 17;
            this.cboUnidadeCapacidade.Tag = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Unidade de Capacidade";
            // 
            // txtCapacidade
            // 
            this.txtCapacidade.Location = new System.Drawing.Point(21, 229);
            this.txtCapacidade.Name = "txtCapacidade";
            this.txtCapacidade.Size = new System.Drawing.Size(144, 20);
            this.txtCapacidade.TabIndex = 19;
            this.txtCapacidade.Tag = "3";
            // 
            // txtCapacidadeLote
            // 
            this.txtCapacidadeLote.Location = new System.Drawing.Point(171, 229);
            this.txtCapacidadeLote.Name = "txtCapacidadeLote";
            this.txtCapacidadeLote.Size = new System.Drawing.Size(140, 20);
            this.txtCapacidadeLote.TabIndex = 20;
            this.txtCapacidadeLote.Tag = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Capacidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Capacidade Lote";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Porcentagem Plano Operação";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(314, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Porcentagem Eficiência";
            // 
            // txtPorcentagemPlanoOperacao
            // 
            this.txtPorcentagemPlanoOperacao.Location = new System.Drawing.Point(467, 229);
            this.txtPorcentagemPlanoOperacao.Name = "txtPorcentagemPlanoOperacao";
            this.txtPorcentagemPlanoOperacao.Size = new System.Drawing.Size(150, 20);
            this.txtPorcentagemPlanoOperacao.TabIndex = 24;
            this.txtPorcentagemPlanoOperacao.Tag = "3";
            // 
            // txtPorcentagemEficiencia
            // 
            this.txtPorcentagemEficiencia.Location = new System.Drawing.Point(317, 229);
            this.txtPorcentagemEficiencia.Name = "txtPorcentagemEficiencia";
            this.txtPorcentagemEficiencia.Size = new System.Drawing.Size(144, 20);
            this.txtPorcentagemEficiencia.TabIndex = 23;
            this.txtPorcentagemEficiencia.Tag = "3";
            // 
            // chkCapacidadeFinita
            // 
            this.chkCapacidadeFinita.AutoSize = true;
            this.chkCapacidadeFinita.Location = new System.Drawing.Point(623, 197);
            this.chkCapacidadeFinita.Name = "chkCapacidadeFinita";
            this.chkCapacidadeFinita.Size = new System.Drawing.Size(111, 17);
            this.chkCapacidadeFinita.TabIndex = 27;
            this.chkCapacidadeFinita.Text = "Capacidade Finita";
            this.chkCapacidadeFinita.UseVisualStyleBackColor = true;
            // 
            // chkPropriedadeFinita
            // 
            this.chkPropriedadeFinita.AutoSize = true;
            this.chkPropriedadeFinita.Location = new System.Drawing.Point(623, 215);
            this.chkPropriedadeFinita.Name = "chkPropriedadeFinita";
            this.chkPropriedadeFinita.Size = new System.Drawing.Size(111, 17);
            this.chkPropriedadeFinita.TabIndex = 28;
            this.chkPropriedadeFinita.Text = "Propriedade Finita";
            this.chkPropriedadeFinita.UseVisualStyleBackColor = true;
            // 
            // chkExclusivo
            // 
            this.chkExclusivo.AutoSize = true;
            this.chkExclusivo.Location = new System.Drawing.Point(623, 234);
            this.chkExclusivo.Name = "chkExclusivo";
            this.chkExclusivo.Size = new System.Drawing.Size(71, 17);
            this.chkExclusivo.TabIndex = 29;
            this.chkExclusivo.Text = "Exclusivo";
            this.chkExclusivo.UseVisualStyleBackColor = true;
            // 
            // cboGrupoRoteiro
            // 
            this.cboGrupoRoteiro.FormattingEnabled = true;
            this.cboGrupoRoteiro.Location = new System.Drawing.Point(21, 286);
            this.cboGrupoRoteiro.Name = "cboGrupoRoteiro";
            this.cboGrupoRoteiro.Size = new System.Drawing.Size(290, 21);
            this.cboGrupoRoteiro.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Grupo de Roteiro";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(314, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Porcentagem Sucata";
            // 
            // txtPorcentagemSucata
            // 
            this.txtPorcentagemSucata.Location = new System.Drawing.Point(317, 287);
            this.txtPorcentagemSucata.Name = "txtPorcentagemSucata";
            this.txtPorcentagemSucata.Size = new System.Drawing.Size(144, 20);
            this.txtPorcentagemSucata.TabIndex = 32;
            this.txtPorcentagemSucata.Tag = "3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 330);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Tempo Espera Anterior";
            // 
            // txtTempoEsperaAnterior
            // 
            this.txtTempoEsperaAnterior.Location = new System.Drawing.Point(21, 346);
            this.txtTempoEsperaAnterior.Name = "txtTempoEsperaAnterior";
            this.txtTempoEsperaAnterior.Size = new System.Drawing.Size(144, 20);
            this.txtTempoEsperaAnterior.TabIndex = 34;
            this.txtTempoEsperaAnterior.Tag = "3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(168, 330);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Tempo Espera Posterior";
            // 
            // txtTempoEsperaPosterior
            // 
            this.txtTempoEsperaPosterior.Location = new System.Drawing.Point(171, 346);
            this.txtTempoEsperaPosterior.Name = "txtTempoEsperaPosterior";
            this.txtTempoEsperaPosterior.Size = new System.Drawing.Size(144, 20);
            this.txtTempoEsperaPosterior.TabIndex = 36;
            this.txtTempoEsperaPosterior.Tag = "3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(317, 330);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Tempo Execusão";
            // 
            // txtTempoExecusao
            // 
            this.txtTempoExecusao.Location = new System.Drawing.Point(320, 346);
            this.txtTempoExecusao.Name = "txtTempoExecusao";
            this.txtTempoExecusao.Size = new System.Drawing.Size(144, 20);
            this.txtTempoExecusao.TabIndex = 38;
            this.txtTempoExecusao.Tag = "3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(465, 330);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "Tempo Preparacão";
            // 
            // txtTempoPreparacao
            // 
            this.txtTempoPreparacao.Location = new System.Drawing.Point(468, 346);
            this.txtTempoPreparacao.Name = "txtTempoPreparacao";
            this.txtTempoPreparacao.Size = new System.Drawing.Size(144, 20);
            this.txtTempoPreparacao.TabIndex = 40;
            this.txtTempoPreparacao.Tag = "3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(615, 330);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "Tempo Transito";
            // 
            // txtTempoTransito
            // 
            this.txtTempoTransito.Location = new System.Drawing.Point(618, 346);
            this.txtTempoTransito.Name = "txtTempoTransito";
            this.txtTempoTransito.Size = new System.Drawing.Size(149, 20);
            this.txtTempoTransito.TabIndex = 42;
            this.txtTempoTransito.Tag = "3";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 393);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "Funcionário";
            // 
            // cboFuncionario
            // 
            this.cboFuncionario.FormattingEnabled = true;
            this.cboFuncionario.Location = new System.Drawing.Point(21, 409);
            this.cboFuncionario.Name = "cboFuncionario";
            this.cboFuncionario.Size = new System.Drawing.Size(222, 21);
            this.cboFuncionario.TabIndex = 44;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(246, 394);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 47;
            this.label16.Text = "Horas";
            // 
            // txtHorasTempo
            // 
            this.txtHorasTempo.Location = new System.Drawing.Point(249, 410);
            this.txtHorasTempo.Name = "txtHorasTempo";
            this.txtHorasTempo.Size = new System.Drawing.Size(93, 20);
            this.txtHorasTempo.TabIndex = 46;
            this.txtHorasTempo.Tag = "3";
            // 
            // cboLocalProducao
            // 
            this.cboLocalProducao.FormattingEnabled = true;
            this.cboLocalProducao.Location = new System.Drawing.Point(348, 409);
            this.cboLocalProducao.Name = "cboLocalProducao";
            this.cboLocalProducao.Size = new System.Drawing.Size(187, 21);
            this.cboLocalProducao.TabIndex = 48;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(345, 393);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 13);
            this.label17.TabIndex = 49;
            this.label17.Text = "Local de produção";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(538, 393);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 13);
            this.label18.TabIndex = 51;
            this.label18.Text = "Conta Contábil Custo";
            // 
            // cboContaContabilCusto
            // 
            this.cboContaContabilCusto.FormattingEnabled = true;
            this.cboContaContabilCusto.Location = new System.Drawing.Point(541, 409);
            this.cboContaContabilCusto.Name = "cboContaContabilCusto";
            this.cboContaContabilCusto.Size = new System.Drawing.Size(226, 21);
            this.cboContaContabilCusto.TabIndex = 50;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 464);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(140, 13);
            this.label19.TabIndex = 53;
            this.label19.Text = "Conta Contábil Contra Custo";
            // 
            // cboContaContabilContraCusto
            // 
            this.cboContaContabilContraCusto.FormattingEnabled = true;
            this.cboContaContabilContraCusto.Location = new System.Drawing.Point(21, 480);
            this.cboContaContabilContraCusto.Name = "cboContaContabilContraCusto";
            this.cboContaContabilContraCusto.Size = new System.Drawing.Size(222, 21);
            this.cboContaContabilContraCusto.TabIndex = 52;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(246, 464);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 13);
            this.label20.TabIndex = 55;
            this.label20.Text = "Conta Contábil WIP";
            // 
            // cboContaContabilWIP
            // 
            this.cboContaContabilWIP.FormattingEnabled = true;
            this.cboContaContabilWIP.Location = new System.Drawing.Point(249, 480);
            this.cboContaContabilWIP.Name = "cboContaContabilWIP";
            this.cboContaContabilWIP.Size = new System.Drawing.Size(244, 21);
            this.cboContaContabilWIP.TabIndex = 54;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(496, 464);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(167, 13);
            this.label21.TabIndex = 57;
            this.label21.Text = "Conta Contábil Conta Partida WIP";
            // 
            // cboContaContabilContaPartidaWIP
            // 
            this.cboContaContabilContaPartidaWIP.FormattingEnabled = true;
            this.cboContaContabilContaPartidaWIP.Location = new System.Drawing.Point(499, 480);
            this.cboContaContabilContaPartidaWIP.Name = "cboContaContabilContaPartidaWIP";
            this.cboContaContabilContaPartidaWIP.Size = new System.Drawing.Size(268, 21);
            this.cboContaContabilContaPartidaWIP.TabIndex = 56;
            // 
            // frmRecursoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cboContaContabilContaPartidaWIP);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cboContaContabilWIP);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cboContaContabilContraCusto);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cboContaContabilCusto);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cboLocalProducao);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtHorasTempo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboFuncionario);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTempoTransito);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTempoPreparacao);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTempoExecusao);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTempoEsperaPosterior);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTempoEsperaAnterior);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPorcentagemSucata);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboGrupoRoteiro);
            this.Controls.Add(this.chkExclusivo);
            this.Controls.Add(this.chkPropriedadeFinita);
            this.Controls.Add(this.chkCapacidadeFinita);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPorcentagemPlanoOperacao);
            this.Controls.Add(this.txtPorcentagemEficiencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCapacidadeLote);
            this.Controls.Add(this.txtCapacidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboUnidadeCapacidade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 505);
            this.Name = "frmRecursoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmRecursoCad";
            this.Text = "Cadastro de Recursos";
            this.Load += new System.EventHandler(this.frmAutoridadeCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAutoridadeCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboUnidadeCapacidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCapacidade;
        private System.Windows.Forms.TextBox txtCapacidadeLote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPorcentagemPlanoOperacao;
        private System.Windows.Forms.TextBox txtPorcentagemEficiencia;
        private System.Windows.Forms.CheckBox chkCapacidadeFinita;
        private System.Windows.Forms.CheckBox chkPropriedadeFinita;
        private System.Windows.Forms.CheckBox chkExclusivo;
        private System.Windows.Forms.ComboBox cboGrupoRoteiro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPorcentagemSucata;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTempoEsperaAnterior;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTempoEsperaPosterior;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTempoExecusao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTempoPreparacao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTempoTransito;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboFuncionario;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtHorasTempo;
        private System.Windows.Forms.ComboBox cboLocalProducao;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboContaContabilCusto;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboContaContabilContraCusto;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboContaContabilWIP;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboContaContabilContaPartidaWIP;
    }
}