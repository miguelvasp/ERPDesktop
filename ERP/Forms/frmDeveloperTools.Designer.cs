namespace ERP
{
    partial class frmDeveloperTools
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtLista = new System.Windows.Forms.TextBox();
            this.btnGerarLista = new System.Windows.Forms.Button();
            this.cboForms = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1101, 735);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtC);
            this.tabPage1.Controls.Add(this.txtLista);
            this.tabPage1.Controls.Add(this.btnGerarLista);
            this.tabPage1.Controls.Add(this.cboForms);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1093, 709);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gerador Componentes x Database";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLista
            // 
            this.txtLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLista.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLista.Location = new System.Drawing.Point(20, 72);
            this.txtLista.Multiline = true;
            this.txtLista.Name = "txtLista";
            this.txtLista.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLista.Size = new System.Drawing.Size(1049, 620);
            this.txtLista.TabIndex = 2;
            // 
            // btnGerarLista
            // 
            this.btnGerarLista.Location = new System.Drawing.Point(592, 25);
            this.btnGerarLista.Name = "btnGerarLista";
            this.btnGerarLista.Size = new System.Drawing.Size(117, 23);
            this.btnGerarLista.TabIndex = 1;
            this.btnGerarLista.Text = "Gerar lista";
            this.btnGerarLista.UseVisualStyleBackColor = true;
            this.btnGerarLista.Click += new System.EventHandler(this.btnGerarLista_Click);
            // 
            // cboForms
            // 
            this.cboForms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboForms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboForms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboForms.FormattingEnabled = true;
            this.cboForms.Location = new System.Drawing.Point(20, 25);
            this.cboForms.Name = "cboForms";
            this.cboForms.Size = new System.Drawing.Size(428, 24);
            this.cboForms.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1093, 709);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SQL Connection";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(454, 27);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(100, 20);
            this.txtC.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Formulário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(454, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Alias Classe";
            // 
            // frmDeveloperTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 735);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmDeveloperTools";
            this.Text = "frmDeveloperTools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDeveloperTools_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtLista;
        private System.Windows.Forms.Button btnGerarLista;
        private System.Windows.Forms.ComboBox cboForms;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtC;
    }
}