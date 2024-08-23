namespace ERP.Relatorios
{
    partial class frmRepPedidoCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepPedidoCompras));
            this.rptPedidos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptPedidos
            // 
            this.rptPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptPedidos.LocalReport.ReportEmbeddedResource = "ERP.Relatorios.RepPedidoComprasLista.rdlc";
            this.rptPedidos.Location = new System.Drawing.Point(0, 0);
            this.rptPedidos.Name = "rptPedidos";
            this.rptPedidos.Size = new System.Drawing.Size(706, 397);
            this.rptPedidos.TabIndex = 1;
            // 
            // frmRepPedidoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 397);
            this.Controls.Add(this.rptPedidos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRepPedidoCompras";
            this.Tag = "frmRepPedidoCompras";
            this.Text = "Relatório de Pedidos de Compras";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRepPedidoCompras_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptPedidos;
    }
}