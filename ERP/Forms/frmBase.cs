using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmBase : RibbonForm
    {
        public frmBase()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected void BloqueiaControles()
        {
            //deixa os botoes em modo de navegação de dados.
            btnAdiciona.Enabled = true;
            btnAlterar.Enabled = true;
            btnGrava.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = true;
            

            for(int i = 0; i < this.Controls.Count; i++)
            {
                if (Controls[i] is TextBox)  { (Controls[i] as TextBox).Enabled = false;  }
                if (Controls[i] is ComboBox) { (Controls[i] as ComboBox).Enabled = false; }
                if (Controls[i] is CheckBox) { (Controls[i] as CheckBox).Enabled = false; }
                if (Controls[i] is RadioButton) { (Controls[i] as RadioButton).Enabled = false; }
                if (Controls[i] is MaskedTextBox) { (Controls[i] as MaskedTextBox).Enabled = false; }
            }
        }

        protected void DesbloqueiaControles()
        {
            //deixa os botoes em modo de navegação de dados.
            btnAdiciona.Enabled = false;
            btnAlterar.Enabled = false;
            btnGrava.Enabled = true;
            btnCancelar.Enabled = true;
            btnExcluir.Enabled = false;
            

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (Controls[i] is TextBox) { (Controls[i] as TextBox).Enabled = true; }
                if (Controls[i] is ComboBox) { (Controls[i] as ComboBox).Enabled = true; }
                if (Controls[i] is CheckBox) { (Controls[i] as CheckBox).Enabled = true; }
                if (Controls[i] is RadioButton) { (Controls[i] as RadioButton).Enabled = true; }
                if (Controls[i] is MaskedTextBox) { (Controls[i] as MaskedTextBox).Enabled = true; }
            }
        }

        protected void ValidaCampos()
        {
            bool Erro = false;
            //limpa as marcações
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is TextBox || Controls[i] is ComboBox || Controls[i] is MaskedTextBox)
                {
                    Controls[i].BackColor = Color.White;
                }
            }


            //Tag = 1 Campos Obrigatorios
            for (int i = 0; i < Controls.Count; i++)
            {
                if(Controls[i].Tag.ToString() == "1")
                {
                    if(String.IsNullOrEmpty(Controls[i].Text))
                    {
                        Erro = true;
                        Controls[i].BackColor = Color.Yellow;
                    }
                }
            }



            if(Erro)
            {
                MessageBox.Show("Por favor preencha todas as informações necessárias.");
            }
        }

        protected void LimpaControles()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (Controls[i] is TextBox) { (Controls[i] as TextBox).Text = ""; }
                if (Controls[i] is ComboBox) { (Controls[i] as ComboBox).Text = ""; }
                if (Controls[i] is CheckBox) { (Controls[i] as CheckBox).Checked = false; }
                if (Controls[i] is RadioButton) { (Controls[i] as RadioButton).Checked = false; }
                if (Controls[i] is MaskedTextBox) { (Controls[i] as MaskedTextBox).Text = ""; }
            }
        }

    }
}
