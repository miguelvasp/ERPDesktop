namespace ERP
{
    partial class frmSearchForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInformePrograma = new System.Windows.Forms.TextBox();
            this.dtgPrograma = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrograma)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informe o nome do programa";
            // 
            // txtInformePrograma
            // 
            this.txtInformePrograma.Location = new System.Drawing.Point(12, 40);
            this.txtInformePrograma.Name = "txtInformePrograma";
            this.txtInformePrograma.Size = new System.Drawing.Size(469, 20);
            this.txtInformePrograma.TabIndex = 1;
            this.txtInformePrograma.TextChanged += new System.EventHandler(this.txtInformePrograma_TextChanged);
            // 
            // dtgPrograma
            // 
            this.dtgPrograma.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgPrograma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPrograma.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dtgPrograma.Location = new System.Drawing.Point(12, 88);
            this.dtgPrograma.Name = "dtgPrograma";
            this.dtgPrograma.ReadOnly = true;
            this.dtgPrograma.RowHeadersVisible = false;
            this.dtgPrograma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPrograma.Size = new System.Drawing.Size(571, 375);
            this.dtgPrograma.TabIndex = 2;
            this.dtgPrograma.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPrograma_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Formulario";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Nome";
            this.Column2.HeaderText = "Nome";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 400;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Duplo click para abrir o programa";
            // 
            // frmSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 478);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgPrograma);
            this.Controls.Add(this.txtInformePrograma);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busca de Programas";
            this.Load += new System.EventHandler(this.frmSearchForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearchForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrograma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInformePrograma;
        private System.Windows.Forms.DataGridView dtgPrograma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label2;
    }
}