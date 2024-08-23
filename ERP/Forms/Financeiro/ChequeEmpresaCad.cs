using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class ChequeEmpresaCad : RibbonForm
    {
        public ChequeDAL dal = new ChequeDAL();
        int IdCheque = 0; 

        public ChequeEmpresaCad(int pIdCheque)
        {
            IdCheque = pIdCheque;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {
            var Cheque = dal.GetChequeById(IdCheque);
            txtCheque.Text = Cheque.NumeroCheque.ToString();
            txtData.Text = Convert.ToDateTime(Cheque.Data).ToShortDateString();
            txtConta.Text = Cheque.ContaBancaria;
            txtValor.Text = Cheque.Valor.ToString();
            txtStatus.Text = Cheque.Status;

            //GetItens
            var Lista = dal.GetChequeItens(IdCheque);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = Lista;


        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Confirma o cancelamento do cheque?") == DialogResult.Yes)
            {
                Cheque ch = dal.GetByID(IdCheque);
                ch.Status = 5;
                dal.Update(ch);
                dal.Save();
                this.Close();
            }
        }
    }
}

