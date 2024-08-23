namespace ERP.Relatorios
{
    partial class frmRepPedidoVendasViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepPedidoVendasViewer));
            this.rpt = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpt
            // 
            this.rpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpt.LocalReport.ReportEmbeddedResource = "ERP.Relatorios.RepPedidoVendas.rdlc";
            this.rpt.Location = new System.Drawing.Point(0, 0);
            this.rpt.Name = "rpt";
            this.rpt.Size = new System.Drawing.Size(799, 453);
            this.rpt.TabIndex = 1;
            // 
            // frmRepPedidoVendasViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 453);
            this.Controls.Add(this.rpt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRepPedidoVendasViewer";
            this.Tag = "frmRepPedidoVendasViewer";
            this.Text = "Pedido de Vendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRepPedidoVendasViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpt;
    }
}