using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmRecebimentoLoteCad : Form
    {
        RecebimentoLoteDAL dal = new RecebimentoLoteDAL();
        RecebimentoLote p;
        public frmRecebimentoLoteCad(int id)
        { 
            InitializeComponent();
            p = dal.GetByID(id);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {
            CarregaDados();
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            CarregaCombos();
            if(p != null)
            {
                txtCodigo.Text = "PL" + p.IdRecebimentoLote.ToString().PadLeft(7, '0');
                txtData.Text = p.Data.ToString();
                cboContaBancaria.SelectedValue = p.IdContaBancaria == null ? 0 : p.IdContaBancaria;
                cboMetodoPagamento.SelectedValue = p.IdMetodoPagamento;
                txtCheque.Text = p.Cheque == null ? "" : p.Cheque.ToString();
                txtValor.Text = Convert.ToDecimal(p.Valor).ToString("N2");
                cboFornecedor.SelectedValue = p.IdFornecedor == null ? 0 : p.IdFornecedor;
                cboCliente.SelectedValue = p.IdCliente == null ? 0 : p.IdCliente;
                cboContaContabil.SelectedValue = p.IdContaContabil == null ? 0 : p.IdContaContabil;
                cboStatus.SelectedValue = p.StatusRecebimento == null ? 0 : p.StatusRecebimento;
                //Carrega os titulos pagos
                var titulos = dal.GetTitulosPagos(p.IdRecebimentoLote);
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = titulos;

                //Carrega os cheques
                var cheques = dal.GetChequesTerceirosPagos(p.IdRecebimentoLote);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = cheques;

                if(p.StatusRecebimento != null && p.StatusRecebimento == 2)
                {
                    btnConfirma.Enabled = false;
                    btnCancelaPagamento.Enabled = false;
                }
                else
                {
                    btnConfirma.Enabled = true;
                    btnCancelaPagamento.Enabled = true;
                }
            }
            
        }
        

        private void CarregaCombos()
        {
            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(Util.Util.GetAppSettings("IdEmpresa"));
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
             

            cboCliente.DataSource = new ClienteDAL().GetCombo(Util.Util.GetAppSettings("IdEmpresa"));
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;

            cboContaBancaria.DataSource = new EmpresaDAL().GetContasBancarias(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            cboContaBancaria.ValueMember = "iValue";
            cboContaBancaria.DisplayMember = "Text";
            cboContaBancaria.SelectedIndex = -1;

            cboContaContabil.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboContaContabil.ValueMember = "iValue";
            cboContaContabil.DisplayMember = "Text";
            cboContaContabil.SelectedIndex = -1;

            cboMetodoPagamento.DataSource = new MetodoPagamentoDAL().GetCombo();
            cboMetodoPagamento.ValueMember = "iValue";
            cboMetodoPagamento.DisplayMember = "Text";
            cboMetodoPagamento.SelectedIndex = -1;

            List<ComboItem> statusP = new List<ComboItem>();
            statusP.Add(new ComboItem() { Text = "A Confirmar", iValue = 1 });
            statusP.Add(new ComboItem() { Text = "Confirmado", iValue = 2 });
            cboStatus.DataSource = statusP;
            cboStatus.ValueMember = "iValue";
            cboStatus.DisplayMember = "Text";
            cboStatus.SelectedIndex = -1;

        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja confirmar o Recebimento em lote? \n\rAs alterações não poderão ser desfeitas.") == DialogResult.Yes)
            {
                p.StatusRecebimento = 2;
                dal.Update(p);
                dal.Save();
                this.Close();
            }
        }

        private void btnCancelaPagamento_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja cancelar o Recebimento em lote? \n\rAs alterações não poderão ser desfeitas.") == DialogResult.Yes)
            {
                dal.CancelaRecebimentoLote(p);
                this.Close();
            }
        }
    }
}

