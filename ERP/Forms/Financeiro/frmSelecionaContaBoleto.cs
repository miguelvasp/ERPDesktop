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
using ERP.Models;

namespace ERP.Financeiro
{
    public partial class frmSelecionaContaBoleto : Form
    {
        public int IdBanco = 0;
        public bool Continuar = false;
        public frmSelecionaContaBoleto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(cboBanco.Text))
            {
                Util.Aplicacao.ShowMessage("Selecione o banco!");
                return;
            }

            IdBanco = Convert.ToInt32(cboBanco.SelectedValue);
            Continuar = checkBox1.Checked;
            this.Close();
        }

        private void frmSelecionaContaBoleto_Load(object sender, EventArgs e)
        {
            List<ComboItem> cb = new List<ComboItem>();
            var lista = new ContaBancariaDAL().Get().Where(x => x.IdEmpresa == Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"))).ToList();
            foreach(var c in lista.Where(x => x.EmiteBoleto == true).ToList())
            {
                string Conta = c.Banco.NomeBanco + " - Ag: " + c.Agencia + " - Conta: " + c.Conta + "-" + c.DigitoConta; 
                cb.Add(new ComboItem() { iValue = c.IdContaBancaria, Text = Conta });
            }

            cboBanco.DataSource = cb;
            cboBanco.DisplayMember = "Text";
            cboBanco.ValueMember = "iValue";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IdBanco = 0;
            Continuar = false;
            this.Close();
        }
    }
}
