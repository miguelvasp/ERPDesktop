namespace ERP.Auxiliares
{
    partial class frmVisualizarImagem
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
            this.pctBoleto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoleto)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBoleto
            // 
            this.pctBoleto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctBoleto.Location = new System.Drawing.Point(0, 0);
            this.pctBoleto.Name = "pctBoleto";
            this.pctBoleto.Size = new System.Drawing.Size(984, 436);
            this.pctBoleto.TabIndex = 1;
            this.pctBoleto.TabStop = false;
            // 
            // frmVisualizarImagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 436);
            this.Controls.Add(this.pctBoleto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmVisualizarImagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmVisualizarImagem";
            this.Text = "Visualizar Boleto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pctBoleto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBoleto;
    }
}