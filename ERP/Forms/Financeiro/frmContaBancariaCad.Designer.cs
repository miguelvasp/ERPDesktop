namespace ERP
{
    partial class frmContaBancariaCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContaBancariaCad));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnAtualizar = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.btnImprimir = new System.Windows.Forms.RibbonButton();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAgencia = new System.Windows.Forms.TextBox();
            this.txtDigitoAgencia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDigitoConta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInicio = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtConciliacao = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.txtNomeConta = new System.Windows.Forms.TextBox();
            this.lblNomeConta = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodigoSwift = new System.Windows.Forms.TextBox();
            this.txtIban = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboConciliacaoAutomatica = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboContaContabil = new System.Windows.Forms.ComboBox();
            this.chkEmiteBoleto = new System.Windows.Forms.CheckBox();
            this.txtBoletoCarteira = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBoletoModalidade = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBoletoConvenio = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCodigoCedente = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
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
            this.ribbon1.TabIndex = 2;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // rbOpcoes
            // 
            this.rbOpcoes.Panels.Add(this.ribbonPanel1);
            this.rbOpcoes.Panels.Add(this.ribbonPanel2);
            this.rbOpcoes.Text = "Documento";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.btnAdiciona);
            this.ribbonPanel1.Items.Add(this.btnAlterar);
            this.ribbonPanel1.Items.Add(this.btnGrava);
            this.ribbonPanel1.Items.Add(this.btnCancelar);
            this.ribbonPanel1.Items.Add(this.btnExcluir);
            this.ribbonPanel1.Items.Add(this.btnAtualizar);
            this.ribbonPanel1.Text = "Informações";
            // 
            // btnAdiciona
            // 
            this.btnAdiciona.Image = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.Image")));
            this.btnAdiciona.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.SmallImage")));
            this.btnAdiciona.Text = "Adicionar";
            this.btnAdiciona.Click += new System.EventHandler(this.btnAdiciona_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAlterar.SmallImage")));
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnGrava
            // 
            this.btnGrava.Enabled = false;
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.SmallImage")));
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.btnImprimir);
            this.ribbonPanel2.Items.Add(this.ribbonButton1);
            this.ribbonPanel2.Text = "";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.SmallImage")));
            this.btnImprimir.Text = "Imprimir";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = global::ERP.Properties.Resources.Bank_Check_icon;
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Cheques";
            this.ribbonButton1.Click += new System.EventHandler(this.ribbonButton1_Click);
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(12, 128);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 3;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // cboBanco
            // 
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Location = new System.Drawing.Point(42, 161);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(198, 21);
            this.cboBanco.TabIndex = 4;
            this.cboBanco.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Banco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Agência";
            // 
            // txtAgencia
            // 
            this.txtAgencia.Location = new System.Drawing.Point(42, 211);
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Size = new System.Drawing.Size(100, 20);
            this.txtAgencia.TabIndex = 6;
            this.txtAgencia.Tag = "1";
            // 
            // txtDigitoAgencia
            // 
            this.txtDigitoAgencia.Location = new System.Drawing.Point(148, 211);
            this.txtDigitoAgencia.Name = "txtDigitoAgencia";
            this.txtDigitoAgencia.Size = new System.Drawing.Size(50, 20);
            this.txtDigitoAgencia.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Dígito";
            // 
            // txtDigitoConta
            // 
            this.txtDigitoConta.Location = new System.Drawing.Point(317, 211);
            this.txtDigitoConta.Name = "txtDigitoConta";
            this.txtDigitoConta.Size = new System.Drawing.Size(50, 20);
            this.txtDigitoConta.TabIndex = 9;
            this.txtDigitoConta.Tag = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Dígito";
            // 
            // txtConta
            // 
            this.txtConta.Location = new System.Drawing.Point(211, 211);
            this.txtConta.Name = "txtConta";
            this.txtConta.Size = new System.Drawing.Size(100, 20);
            this.txtConta.TabIndex = 8;
            this.txtConta.Tag = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Conta Corrente";
            // 
            // txtInicio
            // 
            this.txtInicio.Location = new System.Drawing.Point(373, 211);
            this.txtInicio.Mask = "99/99/9999";
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.Size = new System.Drawing.Size(74, 20);
            this.txtInicio.TabIndex = 10;
            this.txtInicio.Tag = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Data Início";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(453, 211);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(100, 20);
            this.txtSaldo.TabIndex = 11;
            this.txtSaldo.Tag = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(450, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Saldo Inicial";
            // 
            // txtCheque
            // 
            this.txtCheque.Location = new System.Drawing.Point(559, 211);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(73, 20);
            this.txtCheque.TabIndex = 12;
            this.txtCheque.Tag = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(556, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Último Cheque";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(635, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Última Conciliação";
            // 
            // txtConciliacao
            // 
            this.txtConciliacao.Location = new System.Drawing.Point(638, 211);
            this.txtConciliacao.Mask = "99/99/9999";
            this.txtConciliacao.Name = "txtConciliacao";
            this.txtConciliacao.Size = new System.Drawing.Size(100, 20);
            this.txtConciliacao.TabIndex = 13;
            this.txtConciliacao.Tag = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(556, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "País";
            // 
            // cboPais
            // 
            this.cboPais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPais.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(559, 161);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(179, 21);
            this.cboPais.TabIndex = 14;
            this.cboPais.Tag = "1";
            // 
            // txtNomeConta
            // 
            this.txtNomeConta.Location = new System.Drawing.Point(246, 161);
            this.txtNomeConta.Name = "txtNomeConta";
            this.txtNomeConta.Size = new System.Drawing.Size(307, 20);
            this.txtNomeConta.TabIndex = 5;
            this.txtNomeConta.Tag = "1";
            // 
            // lblNomeConta
            // 
            this.lblNomeConta.AutoSize = true;
            this.lblNomeConta.Location = new System.Drawing.Point(243, 145);
            this.lblNomeConta.Name = "lblNomeConta";
            this.lblNomeConta.Size = new System.Drawing.Size(81, 13);
            this.lblNomeConta.TabIndex = 16;
            this.lblNomeConta.Text = "Nome da Conta";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Código SWIFT";
            // 
            // txtCodigoSwift
            // 
            this.txtCodigoSwift.Location = new System.Drawing.Point(42, 256);
            this.txtCodigoSwift.Name = "txtCodigoSwift";
            this.txtCodigoSwift.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoSwift.TabIndex = 15;
            // 
            // txtIban
            // 
            this.txtIban.Location = new System.Drawing.Point(148, 256);
            this.txtIban.Name = "txtIban";
            this.txtIban.Size = new System.Drawing.Size(163, 20);
            this.txtIban.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(147, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "IBAN";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(314, 240);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Conciliação Automatica";
            // 
            // cboConciliacaoAutomatica
            // 
            this.cboConciliacaoAutomatica.FormattingEnabled = true;
            this.cboConciliacaoAutomatica.Location = new System.Drawing.Point(317, 256);
            this.cboConciliacaoAutomatica.Name = "cboConciliacaoAutomatica";
            this.cboConciliacaoAutomatica.Size = new System.Drawing.Size(115, 21);
            this.cboConciliacaoAutomatica.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(439, 240);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Conta Contábil";
            // 
            // cboContaContabil
            // 
            this.cboContaContabil.FormattingEnabled = true;
            this.cboContaContabil.Location = new System.Drawing.Point(442, 256);
            this.cboContaContabil.Name = "cboContaContabil";
            this.cboContaContabil.Size = new System.Drawing.Size(293, 21);
            this.cboContaContabil.TabIndex = 18;
            // 
            // chkEmiteBoleto
            // 
            this.chkEmiteBoleto.AutoSize = true;
            this.chkEmiteBoleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmiteBoleto.Location = new System.Drawing.Point(42, 299);
            this.chkEmiteBoleto.Name = "chkEmiteBoleto";
            this.chkEmiteBoleto.Size = new System.Drawing.Size(237, 19);
            this.chkEmiteBoleto.TabIndex = 33;
            this.chkEmiteBoleto.Text = "Esta conta emite boleto bancário";
            this.chkEmiteBoleto.UseVisualStyleBackColor = true;
            // 
            // txtBoletoCarteira
            // 
            this.txtBoletoCarteira.Location = new System.Drawing.Point(42, 350);
            this.txtBoletoCarteira.Name = "txtBoletoCarteira";
            this.txtBoletoCarteira.Size = new System.Drawing.Size(209, 20);
            this.txtBoletoCarteira.TabIndex = 34;
            this.txtBoletoCarteira.Tag = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(39, 334);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Carteira";
            // 
            // txtBoletoModalidade
            // 
            this.txtBoletoModalidade.Location = new System.Drawing.Point(257, 350);
            this.txtBoletoModalidade.Name = "txtBoletoModalidade";
            this.txtBoletoModalidade.Size = new System.Drawing.Size(227, 20);
            this.txtBoletoModalidade.TabIndex = 36;
            this.txtBoletoModalidade.Tag = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(254, 334);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "Modalidade";
            // 
            // txtBoletoConvenio
            // 
            this.txtBoletoConvenio.Location = new System.Drawing.Point(490, 350);
            this.txtBoletoConvenio.Name = "txtBoletoConvenio";
            this.txtBoletoConvenio.Size = new System.Drawing.Size(245, 20);
            this.txtBoletoConvenio.TabIndex = 38;
            this.txtBoletoConvenio.Tag = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(487, 334);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 39;
            this.label17.Text = "Convenio";
            // 
            // txtCodigoCedente
            // 
            this.txtCodigoCedente.Location = new System.Drawing.Point(42, 410);
            this.txtCodigoCedente.Name = "txtCodigoCedente";
            this.txtCodigoCedente.Size = new System.Drawing.Size(209, 20);
            this.txtCodigoCedente.TabIndex = 40;
            this.txtCodigoCedente.Tag = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(39, 394);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 13);
            this.label20.TabIndex = 41;
            this.label20.Text = "Código Cedente";
            // 
            // frmContaBancariaCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.txtCodigoCedente);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtBoletoConvenio);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtBoletoModalidade);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtBoletoCarteira);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chkEmiteBoleto);
            this.Controls.Add(this.cboContaContabil);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboConciliacaoAutomatica);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtIban);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCodigoSwift);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNomeConta);
            this.Controls.Add(this.lblNomeConta);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboPais);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtConciliacao);
            this.Controls.Add(this.txtCheque);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtInicio);
            this.Controls.Add(this.txtDigitoConta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDigitoAgencia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAgencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboBanco);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.Name = "frmContaBancariaCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conta bancária";
            this.Load += new System.EventHandler(this.frmContaBancariaCad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnAtualizar;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.ComboBox cboBanco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAgencia;
        private System.Windows.Forms.TextBox txtDigitoAgencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDigitoConta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtInicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtConciliacao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.TextBox txtNomeConta;
        private System.Windows.Forms.Label lblNomeConta;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton btnImprimir;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodigoSwift;
        private System.Windows.Forms.TextBox txtIban;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboConciliacaoAutomatica;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboContaContabil;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.CheckBox chkEmiteBoleto;
        private System.Windows.Forms.TextBox txtBoletoCarteira;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtBoletoModalidade;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBoletoConvenio;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCodigoCedente;
        private System.Windows.Forms.Label label20;
    }
}