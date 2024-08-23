using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.DAL;


namespace ERP.Financeiro
{
    public partial class frmGeraCheque : Form
    {
        int IdContaBancaria;
        public int UltimoCheque = 0;
        public frmGeraCheque(int pIdContaBancaria, int Cheque, string Conta)
        {
            IdContaBancaria = pIdContaBancaria;
            
            InitializeComponent();
            txtDe.Text = Cheque.ToString();
            txtConta.Text = Conta;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChequeDAL dal = new ChequeDAL();
            if(dal.ConsultaDisponibilidade(IdContaBancaria, Convert.ToInt32(txtDe.Text), Convert.ToInt32(txtQuantidade.Text)))
            {
                if (Util.Aplicacao.ShowQuestionMessage("Confirma a geração da numeração dos cheques?") == DialogResult.Yes)
                {
                    dal.GeraNumeracaoCheques(IdContaBancaria, Convert.ToInt32(txtDe.Text), Convert.ToInt32(txtQuantidade.Text));
                    Util.Aplicacao.ShowMessage("Numeração de cheques gerada com sucesso");
                    UltimoCheque = Convert.ToInt32(txtDe.Text) + Convert.ToInt32(txtQuantidade.Text);
                    this.Close();
                }
            }
            else
            {
                Util.Aplicacao.ShowMessage("Numeração de cheques não pode ser gerada.");
            }
            
        }
    }
}
