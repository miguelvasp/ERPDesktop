﻿namespace ERP.Auxiliares
{
    partial class frmImpressaoBoleto
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.boletoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarImagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarImagemPorEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 24);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1018, 469);
            this.webBrowser.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boletoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1018, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // boletoToolStripMenuItem
            // 
            this.boletoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizarImagemToolStripMenuItem,
            this.enviarImagemPorEmailToolStripMenuItem});
            this.boletoToolStripMenuItem.Name = "boletoToolStripMenuItem";
            this.boletoToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.boletoToolStripMenuItem.Text = "Boleto";
            // 
            // visualizarImagemToolStripMenuItem
            // 
            this.visualizarImagemToolStripMenuItem.Name = "visualizarImagemToolStripMenuItem";
            this.visualizarImagemToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.visualizarImagemToolStripMenuItem.Text = "Visualizar Imagem";
            this.visualizarImagemToolStripMenuItem.Visible = false;
            this.visualizarImagemToolStripMenuItem.Click += new System.EventHandler(this.visualizarImagemToolStripMenuItem_Click);
            // 
            // enviarImagemPorEmailToolStripMenuItem
            // 
            this.enviarImagemPorEmailToolStripMenuItem.Name = "enviarImagemPorEmailToolStripMenuItem";
            this.enviarImagemPorEmailToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.enviarImagemPorEmailToolStripMenuItem.Text = "Enviar Imagem por Email";
            // 
            // frmImpressaoBoleto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1018, 493);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmImpressaoBoleto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmImpressaoBoleto";
            this.Text = "Impressão de Boleto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem boletoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarImagemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarImagemPorEmailToolStripMenuItem;
    }
}