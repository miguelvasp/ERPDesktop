namespace ERP
{
    partial class frmTotalDimensoes
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
            this.cboDimensaoDe = new System.Windows.Forms.ComboBox();
            this.lblDimensaoDe = new System.Windows.Forms.Label();
            this.cboDimensaoAte = new System.Windows.Forms.ComboBox();
            this.lblDimensaoAte = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboDimensaoDe
            // 
            this.cboDimensaoDe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDimensaoDe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDimensaoDe.FormattingEnabled = true;
            this.cboDimensaoDe.Location = new System.Drawing.Point(15, 45);
            this.cboDimensaoDe.Name = "cboDimensaoDe";
            this.cboDimensaoDe.Size = new System.Drawing.Size(166, 21);
            this.cboDimensaoDe.TabIndex = 21;
            this.cboDimensaoDe.Tag = "1";
            // 
            // lblDimensaoDe
            // 
            this.lblDimensaoDe.AutoSize = true;
            this.lblDimensaoDe.Location = new System.Drawing.Point(12, 29);
            this.lblDimensaoDe.Name = "lblDimensaoDe";
            this.lblDimensaoDe.Size = new System.Drawing.Size(77, 13);
            this.lblDimensaoDe.TabIndex = 20;
            this.lblDimensaoDe.Text = "Dimensão (De)";
            // 
            // cboDimensaoAte
            // 
            this.cboDimensaoAte.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDimensaoAte.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDimensaoAte.FormattingEnabled = true;
            this.cboDimensaoAte.Location = new System.Drawing.Point(194, 45);
            this.cboDimensaoAte.Name = "cboDimensaoAte";
            this.cboDimensaoAte.Size = new System.Drawing.Size(166, 21);
            this.cboDimensaoAte.TabIndex = 23;
            this.cboDimensaoAte.Tag = "1";
            // 
            // lblDimensaoAte
            // 
            this.lblDimensaoAte.AutoSize = true;
            this.lblDimensaoAte.Location = new System.Drawing.Point(191, 29);
            this.lblDimensaoAte.Name = "lblDimensaoAte";
            this.lblDimensaoAte.Size = new System.Drawing.Size(79, 13);
            this.lblDimensaoAte.TabIndex = 22;
            this.lblDimensaoAte.Text = "Dimensão (Até)";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(282, 100);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 26;
            this.btnExcluir.Text = "E&xcluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(201, 100);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(75, 23);
            this.btnIncluir.TabIndex = 25;
            this.btnIncluir.Text = "&Novo";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(120, 100);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 24;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // frmTotalDimensoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(379, 148);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.cboDimensaoAte);
            this.Controls.Add(this.lblDimensaoAte);
            this.Controls.Add(this.cboDimensaoDe);
            this.Controls.Add(this.lblDimensaoDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTotalDimensoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmTotalDimensoes";
            this.Text = "Total de Dimensões";
            this.Load += new System.EventHandler(this.frmTotalDimensoes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTotalDimensoes_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDimensaoDe;
        private System.Windows.Forms.Label lblDimensaoDe;
        private System.Windows.Forms.ComboBox cboDimensaoAte;
        private System.Windows.Forms.Label lblDimensaoAte;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnSalvar;
    }
}