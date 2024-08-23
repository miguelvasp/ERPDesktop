namespace ERP.Faturamento
{
    partial class frmSelecionaDanfe
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.rbImprimir = new System.Windows.Forms.RadioButton();
            this.rbVizualizar = new System.Windows.Forms.RadioButton();
            this.rbPDF = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImage = global::ERP.Properties.Resources.fundo;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(371, 46);
            this.toolStrip1.TabIndex = 28;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(120, 43);
            this.toolStripLabel1.Text = " Danfe - Opções";
            // 
            // rbImprimir
            // 
            this.rbImprimir.AutoSize = true;
            this.rbImprimir.Checked = true;
            this.rbImprimir.Location = new System.Drawing.Point(13, 60);
            this.rbImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.rbImprimir.Name = "rbImprimir";
            this.rbImprimir.Size = new System.Drawing.Size(86, 21);
            this.rbImprimir.TabIndex = 29;
            this.rbImprimir.TabStop = true;
            this.rbImprimir.Text = "IMPRIMIR";
            this.rbImprimir.UseVisualStyleBackColor = true;
            // 
            // rbVizualizar
            // 
            this.rbVizualizar.AutoSize = true;
            this.rbVizualizar.Location = new System.Drawing.Point(13, 89);
            this.rbVizualizar.Margin = new System.Windows.Forms.Padding(4);
            this.rbVizualizar.Name = "rbVizualizar";
            this.rbVizualizar.Size = new System.Drawing.Size(189, 21);
            this.rbVizualizar.TabIndex = 30;
            this.rbVizualizar.Text = "VISUALIZAR IMPRESSÃO";
            this.rbVizualizar.UseVisualStyleBackColor = true;
            // 
            // rbPDF
            // 
            this.rbPDF.AutoSize = true;
            this.rbPDF.Location = new System.Drawing.Point(13, 118);
            this.rbPDF.Margin = new System.Windows.Forms.Padding(4);
            this.rbPDF.Name = "rbPDF";
            this.rbPDF.Size = new System.Drawing.Size(111, 21);
            this.rbPDF.TabIndex = 31;
            this.rbPDF.Text = "SALVAR PDF";
            this.rbPDF.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 33);
            this.button1.TabIndex = 32;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSelecionaDanfe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(371, 195);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbPDF);
            this.Controls.Add(this.rbVizualizar);
            this.Controls.Add(this.rbImprimir);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelecionaDanfe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSelecionaDanfe_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.RadioButton rbImprimir;
        private System.Windows.Forms.RadioButton rbVizualizar;
        private System.Windows.Forms.RadioButton rbPDF;
        private System.Windows.Forms.Button button1;
    }
}