namespace ERP
{
    partial class frmPedidoCompraApuracaoImposto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidoCompraApuracaoImposto));
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtDataLancamento = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataDocumento = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataVencimentoImposto = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataRegistroIVA = new System.Windows.Forms.MaskedTextBox();
            this.cboCodigoImposto = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCodigoTributacao = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCodigoTributacaoAjustado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAliquota = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtValorFiscalAjustado = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtValorFiscal = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPercentualReducaoImposto = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEncargoImposto = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtValorIsencaoImposto = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtValorBaseIsencao = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOutroValorImposto = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtOutroValorBase = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtBaseValorAjustado = new System.Windows.Forms.MaskedTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtBaseValor = new System.Windows.Forms.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtValorAjustado = new System.Windows.Forms.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtValorImposto = new System.Windows.Forms.MaskedTextBox();
            this.chkManterValores = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrava
            // 
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.btnGrava);
            this.ribbonPanel1.Items.Add(this.btnCancelar);
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
            this.ribbon1.Size = new System.Drawing.Size(884, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDataLancamento
            // 
            this.txtDataLancamento.Enabled = false;
            this.txtDataLancamento.Location = new System.Drawing.Point(12, 173);
            this.txtDataLancamento.Name = "txtDataLancamento";
            this.txtDataLancamento.Size = new System.Drawing.Size(133, 20);
            this.txtDataLancamento.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Data lançamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Data do documento";
            // 
            // txtDataDocumento
            // 
            this.txtDataDocumento.Enabled = false;
            this.txtDataDocumento.Location = new System.Drawing.Point(151, 173);
            this.txtDataDocumento.Name = "txtDataDocumento";
            this.txtDataDocumento.Size = new System.Drawing.Size(133, 20);
            this.txtDataDocumento.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Data do Vencimento imposto";
            // 
            // txtDataVencimentoImposto
            // 
            this.txtDataVencimentoImposto.Enabled = false;
            this.txtDataVencimentoImposto.Location = new System.Drawing.Point(290, 173);
            this.txtDataVencimentoImposto.Name = "txtDataVencimentoImposto";
            this.txtDataVencimentoImposto.Size = new System.Drawing.Size(151, 20);
            this.txtDataVencimentoImposto.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(444, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Data do registro de IVA";
            // 
            // txtDataRegistroIVA
            // 
            this.txtDataRegistroIVA.Enabled = false;
            this.txtDataRegistroIVA.Location = new System.Drawing.Point(447, 173);
            this.txtDataRegistroIVA.Name = "txtDataRegistroIVA";
            this.txtDataRegistroIVA.Size = new System.Drawing.Size(133, 20);
            this.txtDataRegistroIVA.TabIndex = 19;
            // 
            // cboCodigoImposto
            // 
            this.cboCodigoImposto.Enabled = false;
            this.cboCodigoImposto.FormattingEnabled = true;
            this.cboCodigoImposto.Location = new System.Drawing.Point(12, 237);
            this.cboCodigoImposto.Name = "cboCodigoImposto";
            this.cboCodigoImposto.Size = new System.Drawing.Size(272, 21);
            this.cboCodigoImposto.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Código do Imposto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Código de tributação";
            // 
            // cboCodigoTributacao
            // 
            this.cboCodigoTributacao.Enabled = false;
            this.cboCodigoTributacao.FormattingEnabled = true;
            this.cboCodigoTributacao.Location = new System.Drawing.Point(290, 237);
            this.cboCodigoTributacao.Name = "cboCodigoTributacao";
            this.cboCodigoTributacao.Size = new System.Drawing.Size(290, 21);
            this.cboCodigoTributacao.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(583, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Código de tributação Ajustado";
            // 
            // cboCodigoTributacaoAjustado
            // 
            this.cboCodigoTributacaoAjustado.FormattingEnabled = true;
            this.cboCodigoTributacaoAjustado.Location = new System.Drawing.Point(586, 237);
            this.cboCodigoTributacaoAjustado.Name = "cboCodigoTributacaoAjustado";
            this.cboCodigoTributacaoAjustado.Size = new System.Drawing.Size(286, 21);
            this.cboCodigoTributacaoAjustado.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(433, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Enabled = false;
            this.txtQuantidade.Location = new System.Drawing.Point(436, 307);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(133, 20);
            this.txtQuantidade.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Aliquota";
            // 
            // txtAliquota
            // 
            this.txtAliquota.Enabled = false;
            this.txtAliquota.Location = new System.Drawing.Point(290, 307);
            this.txtAliquota.Name = "txtAliquota";
            this.txtAliquota.Size = new System.Drawing.Size(140, 20);
            this.txtAliquota.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Valor Fiscal Ajustado";
            // 
            // txtValorFiscalAjustado
            // 
            this.txtValorFiscalAjustado.Location = new System.Drawing.Point(151, 307);
            this.txtValorFiscalAjustado.Name = "txtValorFiscalAjustado";
            this.txtValorFiscalAjustado.Size = new System.Drawing.Size(133, 20);
            this.txtValorFiscalAjustado.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 291);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Valor Fiscal";
            // 
            // txtValorFiscal
            // 
            this.txtValorFiscal.Enabled = false;
            this.txtValorFiscal.Location = new System.Drawing.Point(12, 307);
            this.txtValorFiscal.Name = "txtValorFiscal";
            this.txtValorFiscal.Size = new System.Drawing.Size(133, 20);
            this.txtValorFiscal.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(572, 291);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "% de Redução de Imposto";
            // 
            // txtPercentualReducaoImposto
            // 
            this.txtPercentualReducaoImposto.Enabled = false;
            this.txtPercentualReducaoImposto.Location = new System.Drawing.Point(575, 307);
            this.txtPercentualReducaoImposto.Name = "txtPercentualReducaoImposto";
            this.txtPercentualReducaoImposto.Size = new System.Drawing.Size(133, 20);
            this.txtPercentualReducaoImposto.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(711, 291);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Encargo de Imposto";
            // 
            // txtEncargoImposto
            // 
            this.txtEncargoImposto.Enabled = false;
            this.txtEncargoImposto.Location = new System.Drawing.Point(714, 307);
            this.txtEncargoImposto.Name = "txtEncargoImposto";
            this.txtEncargoImposto.Size = new System.Drawing.Size(158, 20);
            this.txtEncargoImposto.TabIndex = 37;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(711, 364);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(140, 13);
            this.label14.TabIndex = 50;
            this.label14.Text = "Valor de isenção de imposto";
            // 
            // txtValorIsencaoImposto
            // 
            this.txtValorIsencaoImposto.Enabled = false;
            this.txtValorIsencaoImposto.Location = new System.Drawing.Point(714, 380);
            this.txtValorIsencaoImposto.Name = "txtValorIsencaoImposto";
            this.txtValorIsencaoImposto.Size = new System.Drawing.Size(158, 20);
            this.txtValorIsencaoImposto.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(572, 364);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 13);
            this.label15.TabIndex = 48;
            this.label15.Text = "Valor base de isenção";
            // 
            // txtValorBaseIsencao
            // 
            this.txtValorBaseIsencao.Enabled = false;
            this.txtValorBaseIsencao.Location = new System.Drawing.Point(575, 380);
            this.txtValorBaseIsencao.Name = "txtValorBaseIsencao";
            this.txtValorBaseIsencao.Size = new System.Drawing.Size(133, 20);
            this.txtValorBaseIsencao.TabIndex = 47;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(433, 364);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 13);
            this.label16.TabIndex = 46;
            this.label16.Text = "Outro Valor de imposto";
            // 
            // txtOutroValorImposto
            // 
            this.txtOutroValorImposto.Enabled = false;
            this.txtOutroValorImposto.Location = new System.Drawing.Point(436, 380);
            this.txtOutroValorImposto.Name = "txtOutroValorImposto";
            this.txtOutroValorImposto.Size = new System.Drawing.Size(133, 20);
            this.txtOutroValorImposto.TabIndex = 45;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(287, 364);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 13);
            this.label17.TabIndex = 44;
            this.label17.Text = "Outro valor base";
            // 
            // txtOutroValorBase
            // 
            this.txtOutroValorBase.Enabled = false;
            this.txtOutroValorBase.Location = new System.Drawing.Point(290, 380);
            this.txtOutroValorBase.Name = "txtOutroValorBase";
            this.txtOutroValorBase.Size = new System.Drawing.Size(140, 20);
            this.txtOutroValorBase.TabIndex = 43;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(148, 364);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "Base Valor Ajustado";
            // 
            // txtBaseValorAjustado
            // 
            this.txtBaseValorAjustado.Location = new System.Drawing.Point(151, 380);
            this.txtBaseValorAjustado.Name = "txtBaseValorAjustado";
            this.txtBaseValorAjustado.Size = new System.Drawing.Size(133, 20);
            this.txtBaseValorAjustado.TabIndex = 41;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 364);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 40;
            this.label19.Text = "Base Valor";
            // 
            // txtBaseValor
            // 
            this.txtBaseValor.Enabled = false;
            this.txtBaseValor.Location = new System.Drawing.Point(12, 380);
            this.txtBaseValor.Name = "txtBaseValor";
            this.txtBaseValor.Size = new System.Drawing.Size(133, 20);
            this.txtBaseValor.TabIndex = 39;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(148, 438);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 13);
            this.label20.TabIndex = 54;
            this.label20.Text = "Valor Ajustado";
            // 
            // txtValorAjustado
            // 
            this.txtValorAjustado.Location = new System.Drawing.Point(151, 454);
            this.txtValorAjustado.Name = "txtValorAjustado";
            this.txtValorAjustado.Size = new System.Drawing.Size(133, 20);
            this.txtValorAjustado.TabIndex = 53;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 438);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 13);
            this.label21.TabIndex = 52;
            this.label21.Text = "Valor do imposto";
            // 
            // txtValorImposto
            // 
            this.txtValorImposto.Enabled = false;
            this.txtValorImposto.Location = new System.Drawing.Point(12, 454);
            this.txtValorImposto.Name = "txtValorImposto";
            this.txtValorImposto.Size = new System.Drawing.Size(133, 20);
            this.txtValorImposto.TabIndex = 51;
            // 
            // chkManterValores
            // 
            this.chkManterValores.AutoSize = true;
            this.chkManterValores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManterValores.Location = new System.Drawing.Point(12, 531);
            this.chkManterValores.Name = "chkManterValores";
            this.chkManterValores.Size = new System.Drawing.Size(163, 17);
            this.chkManterValores.TabIndex = 55;
            this.chkManterValores.Text = "Mater Valores Ajustados";
            this.chkManterValores.UseVisualStyleBackColor = true;
            // 
            // frmPedidoCompraApuracaoImposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.chkManterValores);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtValorAjustado);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtValorImposto);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtValorIsencaoImposto);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtValorBaseIsencao);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtOutroValorImposto);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtOutroValorBase);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtBaseValorAjustado);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtBaseValor);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtEncargoImposto);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPercentualReducaoImposto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAliquota);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtValorFiscalAjustado);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtValorFiscal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboCodigoTributacaoAjustado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCodigoTributacao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboCodigoImposto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDataRegistroIVA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDataVencimentoImposto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDataDocumento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDataLancamento);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 505);
            this.Name = "frmPedidoCompraApuracaoImposto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmPedidoVendaApuracaoImposto";
            this.Text = "Apuração de Impostos";
            this.Load += new System.EventHandler(this.frmAutoridadeCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAutoridadeCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.MaskedTextBox txtDataLancamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtDataDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtDataVencimentoImposto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtDataRegistroIVA;
        private System.Windows.Forms.ComboBox cboCodigoImposto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCodigoTributacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCodigoTributacaoAjustado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtQuantidade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtAliquota;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtValorFiscalAjustado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtValorFiscal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtPercentualReducaoImposto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txtEncargoImposto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox txtValorIsencaoImposto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox txtValorBaseIsencao;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MaskedTextBox txtOutroValorImposto;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.MaskedTextBox txtOutroValorBase;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox txtBaseValorAjustado;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.MaskedTextBox txtBaseValor;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox txtValorAjustado;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.MaskedTextBox txtValorImposto;
        private System.Windows.Forms.CheckBox chkManterValores;
    }
}