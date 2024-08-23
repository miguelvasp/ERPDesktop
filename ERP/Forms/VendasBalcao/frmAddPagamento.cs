using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Models;
using ERP.DAL;

namespace ERP.Forms.VendasBalcao
{
    public partial class frmAddPagamento : Form
    {
        public PedidoBalcaoPagamentoDAL dal = new PedidoBalcaoPagamentoDAL(); 
        PedidoBalcaoPagamento p = new PedidoBalcaoPagamento();
        public frmAddPagamento(PedidoBalcaoPagamento pp)
        {
            p = pp;
            InitializeComponent();
        }

        private void frmAddPagamento_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("DINHEIRO");
            comboBox1.Items.Add("CARTÃO CRÉDITO");
            comboBox1.Items.Add("CARTÃO CRÉDITO 2x");
            comboBox1.Items.Add("CARTÃO CRÉDITO 3x");
            comboBox1.Items.Add("CARTÃO CRÉDITO 4x");
            comboBox1.Items.Add("CARTÃO DÉBITO");
            comboBox1.Items.Add("CHEQUE");
            comboBox1.Items.Add("CREDIARIO LOJA 30 DIAS");
            comboBox1.Items.Add("CREDIARIO LOJA 30/60 DIAS");
            comboBox1.Items.Add("CREDIARIO LOJA 30/60/90 DIAS");
            comboBox1.SelectedIndex = -1;
            if (p.IdPedidoBalcaoPagamento > 0)
            { 
                comboBox1.Text = p.FormaPagamento;
                textBox1.Text = p.Valor.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja remover a forma de pagamento") == DialogResult.Yes)
            {
                dal.Delete(p.IdPedidoBalcaoPagamento);
                dal.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.FormaPagamento = comboBox1.Text;
            p.Valor = Convert.ToDecimal(textBox1.Text);
            if(p.IdPedidoBalcaoPagamento == 0)
            {
                dal.Insert(p);
            }
            else
            {
                dal.Update(p);
            }
            dal.Save();
            this.Close();
        }
    }
}
