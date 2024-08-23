namespace ERP.Auxiliares
{
    partial class frmNotaFiscalItemCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotaFiscalItemCad));
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.cboUnidade = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSeguro = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFrete = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDespesasAcessorias = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodigoFornecedor = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCST = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAliqIPI = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtValorIPI = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEnquadramentoIPI = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBaseICMS = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAliqICMS = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtValorICMS = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPesoLiquido = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPesoBruto = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtVolumes = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cboNCM = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cboCFOP = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cboCest = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Text = "Opções";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribbonButton1);
            this.ribbonPanel1.Items.Add(this.ribbonButton2);
            this.ribbonPanel1.Text = "";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = global::ERP.Properties.Resources.save32;
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Gravar";
            this.ribbonButton1.Click += new System.EventHandler(this.ribbonButton1_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = global::ERP.Properties.Resources.Close_2_icon;
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "excluir";
            this.ribbonButton2.Click += new System.EventHandler(this.ribbonButton2_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.ribbonButton3);
            this.ribbonPanel2.Text = "";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = global::ERP.Properties.Resources.Actions_view_list_details_icon;
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "Impostos";
            this.ribbonButton3.Click += new System.EventHandler(this.ribbonButton3_Click);
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 8F);
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
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(934, 135);
            this.ribbon1.TabIndex = 5;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(20, 173);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(180, 20);
            this.txtCodigo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(204, 173);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(464, 20);
            this.txtDescricao.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(669, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(672, 173);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(84, 20);
            this.txtQuantidade.TabIndex = 11;
            // 
            // cboUnidade
            // 
            this.cboUnidade.FormattingEnabled = true;
            this.cboUnidade.Location = new System.Drawing.Point(762, 172);
            this.cboUnidade.Name = "cboUnidade";
            this.cboUnidade.Size = new System.Drawing.Size(146, 21);
            this.cboUnidade.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(759, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Unidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Valor Unit.";
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.Location = new System.Drawing.Point(20, 226);
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.Size = new System.Drawing.Size(135, 20);
            this.txtValorUnitario.TabIndex = 15;
            this.txtValorUnitario.Text = "0,0000";
            this.txtValorUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Desconto";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(161, 226);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(135, 20);
            this.txtDesconto.TabIndex = 17;
            this.txtDesconto.Text = "0,0000";
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Seguro";
            // 
            // txtSeguro
            // 
            this.txtSeguro.Location = new System.Drawing.Point(302, 226);
            this.txtSeguro.Name = "txtSeguro";
            this.txtSeguro.Size = new System.Drawing.Size(135, 20);
            this.txtSeguro.TabIndex = 19;
            this.txtSeguro.Text = "0,0000";
            this.txtSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(440, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Frete";
            // 
            // txtFrete
            // 
            this.txtFrete.Location = new System.Drawing.Point(443, 226);
            this.txtFrete.Name = "txtFrete";
            this.txtFrete.Size = new System.Drawing.Size(135, 20);
            this.txtFrete.TabIndex = 21;
            this.txtFrete.Text = "0,0000";
            this.txtFrete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(581, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Despesas Acessorias";
            // 
            // txtDespesasAcessorias
            // 
            this.txtDespesasAcessorias.Location = new System.Drawing.Point(584, 226);
            this.txtDespesasAcessorias.Name = "txtDespesasAcessorias";
            this.txtDespesasAcessorias.Size = new System.Drawing.Size(135, 20);
            this.txtDespesasAcessorias.TabIndex = 23;
            this.txtDespesasAcessorias.Text = "0,0000";
            this.txtDespesasAcessorias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 382);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Código Cliente";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(20, 398);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(135, 20);
            this.txtCodigoCliente.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(158, 382);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Código Fornecedor";
            // 
            // txtCodigoFornecedor
            // 
            this.txtCodigoFornecedor.Location = new System.Drawing.Point(161, 398);
            this.txtCodigoFornecedor.Name = "txtCodigoFornecedor";
            this.txtCodigoFornecedor.Size = new System.Drawing.Size(135, 20);
            this.txtCodigoFornecedor.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(299, 382);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "CST";
            // 
            // txtCST
            // 
            this.txtCST.Location = new System.Drawing.Point(302, 398);
            this.txtCST.Name = "txtCST";
            this.txtCST.Size = new System.Drawing.Size(135, 20);
            this.txtCST.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 268);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Aliquota IPI";
            // 
            // txtAliqIPI
            // 
            this.txtAliqIPI.Location = new System.Drawing.Point(20, 284);
            this.txtAliqIPI.Name = "txtAliqIPI";
            this.txtAliqIPI.Size = new System.Drawing.Size(135, 20);
            this.txtAliqIPI.TabIndex = 31;
            this.txtAliqIPI.Text = "0,0000";
            this.txtAliqIPI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(158, 268);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Valor IPI";
            // 
            // txtValorIPI
            // 
            this.txtValorIPI.Location = new System.Drawing.Point(161, 284);
            this.txtValorIPI.Name = "txtValorIPI";
            this.txtValorIPI.Size = new System.Drawing.Size(135, 20);
            this.txtValorIPI.TabIndex = 33;
            this.txtValorIPI.Text = "0,0000";
            this.txtValorIPI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(299, 268);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Enquadramento IPI";
            // 
            // txtEnquadramentoIPI
            // 
            this.txtEnquadramentoIPI.Location = new System.Drawing.Point(302, 284);
            this.txtEnquadramentoIPI.Name = "txtEnquadramentoIPI";
            this.txtEnquadramentoIPI.Size = new System.Drawing.Size(135, 20);
            this.txtEnquadramentoIPI.TabIndex = 35;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(440, 268);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "Base ICMS";
            // 
            // txtBaseICMS
            // 
            this.txtBaseICMS.Location = new System.Drawing.Point(443, 284);
            this.txtBaseICMS.Name = "txtBaseICMS";
            this.txtBaseICMS.Size = new System.Drawing.Size(135, 20);
            this.txtBaseICMS.TabIndex = 37;
            this.txtBaseICMS.Text = "0,0000";
            this.txtBaseICMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(581, 268);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "Aliquota ICMS";
            // 
            // txtAliqICMS
            // 
            this.txtAliqICMS.Location = new System.Drawing.Point(584, 284);
            this.txtAliqICMS.Name = "txtAliqICMS";
            this.txtAliqICMS.Size = new System.Drawing.Size(135, 20);
            this.txtAliqICMS.TabIndex = 39;
            this.txtAliqICMS.Text = "0,0000";
            this.txtAliqICMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(722, 268);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "Valor ICMS";
            // 
            // txtValorICMS
            // 
            this.txtValorICMS.Location = new System.Drawing.Point(725, 284);
            this.txtValorICMS.Name = "txtValorICMS";
            this.txtValorICMS.Size = new System.Drawing.Size(135, 20);
            this.txtValorICMS.TabIndex = 41;
            this.txtValorICMS.Text = "0,0000";
            this.txtValorICMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 329);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 44;
            this.label19.Text = "Valor Total";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(20, 345);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(135, 20);
            this.txtValorTotal.TabIndex = 43;
            this.txtValorTotal.Text = "0,0000";
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(158, 329);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 13);
            this.label20.TabIndex = 46;
            this.label20.Text = "Peso Líquido";
            // 
            // txtPesoLiquido
            // 
            this.txtPesoLiquido.Location = new System.Drawing.Point(161, 345);
            this.txtPesoLiquido.Name = "txtPesoLiquido";
            this.txtPesoLiquido.Size = new System.Drawing.Size(135, 20);
            this.txtPesoLiquido.TabIndex = 45;
            this.txtPesoLiquido.Text = "0,0000";
            this.txtPesoLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(299, 329);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 13);
            this.label21.TabIndex = 48;
            this.label21.Text = "Peso Bruto";
            // 
            // txtPesoBruto
            // 
            this.txtPesoBruto.Location = new System.Drawing.Point(302, 345);
            this.txtPesoBruto.Name = "txtPesoBruto";
            this.txtPesoBruto.Size = new System.Drawing.Size(135, 20);
            this.txtPesoBruto.TabIndex = 47;
            this.txtPesoBruto.Text = "0,0000";
            this.txtPesoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(440, 329);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 13);
            this.label22.TabIndex = 50;
            this.label22.Text = "Volumes";
            // 
            // txtVolumes
            // 
            this.txtVolumes.Location = new System.Drawing.Point(443, 345);
            this.txtVolumes.Name = "txtVolumes";
            this.txtVolumes.Size = new System.Drawing.Size(135, 20);
            this.txtVolumes.TabIndex = 49;
            this.txtVolumes.Text = "0,0000";
            this.txtVolumes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(440, 382);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(31, 13);
            this.label24.TabIndex = 54;
            this.label24.Text = "NCM";
            // 
            // cboNCM
            // 
            this.cboNCM.FormattingEnabled = true;
            this.cboNCM.Location = new System.Drawing.Point(443, 398);
            this.cboNCM.Name = "cboNCM";
            this.cboNCM.Size = new System.Drawing.Size(135, 21);
            this.cboNCM.TabIndex = 53;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(17, 462);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 56;
            this.label25.Text = "Observação";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(20, 478);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(888, 121);
            this.txtObservacao.TabIndex = 55;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(581, 382);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 58;
            this.label23.Text = "CFOP";
            // 
            // cboCFOP
            // 
            this.cboCFOP.FormattingEnabled = true;
            this.cboCFOP.Location = new System.Drawing.Point(584, 398);
            this.cboCFOP.Name = "cboCFOP";
            this.cboCFOP.Size = new System.Drawing.Size(135, 21);
            this.cboCFOP.TabIndex = 57;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(722, 381);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 13);
            this.label26.TabIndex = 60;
            this.label26.Text = "CEST";
            // 
            // cboCest
            // 
            this.cboCest.FormattingEnabled = true;
            this.cboCest.Location = new System.Drawing.Point(725, 397);
            this.cboCest.Name = "cboCest";
            this.cboCest.Size = new System.Drawing.Size(135, 21);
            this.cboCest.TabIndex = 59;
            // 
            // frmNotaFiscalItemCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 611);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.cboCest);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cboCFOP);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cboNCM);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtVolumes);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtPesoBruto);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtPesoLiquido);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtValorICMS);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtAliqICMS);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtBaseICMS);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtEnquadramentoIPI);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtValorIPI);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtAliqIPI);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCST);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodigoFornecedor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDespesasAcessorias);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFrete);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSeguro);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtValorUnitario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboUnidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.ribbon1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNotaFiscalItemCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nota Fiscal Itens";
            this.Load += new System.EventHandler(this.frmConfGrupoImpostoRetidoCad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.ComboBox cboUnidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSeguro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFrete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDespesasAcessorias;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodigoFornecedor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCST;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAliqIPI;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtValorIPI;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtEnquadramentoIPI;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBaseICMS;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtAliqICMS;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtValorICMS;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtPesoLiquido;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtPesoBruto;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtVolumes;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cboNCM;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cboCFOP;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cboCest;
    }
}