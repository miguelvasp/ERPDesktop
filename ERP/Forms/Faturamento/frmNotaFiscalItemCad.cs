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
using ERP.DAL.Fiscal;

namespace ERP.Auxiliares
{
    public partial class frmNotaFiscalItemCad : RibbonForm
    {
        public NotaFiscalItemDAL dal = new NotaFiscalItemDAL();
        NotaFiscalItem ni = new NotaFiscalItem();

        public frmNotaFiscalItemCad(NotaFiscalItem pci)
        {
            ni = pci;
            InitializeComponent();
        }

        public frmNotaFiscalItemCad()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmConfGrupoImpostoRetidoCad_Load(object sender, EventArgs e)
        {
            CarregaCombo();
            CarregaDados();
        }

        private void CarregaDados()
        {
            cboNCM.SelectedValue = ni.IdNCM == null ? 0 : ni.IdNCM;
            cboUnidade.SelectedValue = ni.IdUnidade == null ? 0 : ni.IdUnidade;
            cboCFOP.SelectedValue = ni.IdCFOP == null ? 0 : Convert.ToInt32(ni.IdCFOP);
            cboCest.SelectedValue = ni.IdCest == null ? 0 : Convert.ToInt32(ni.IdCest);
            txtAliqICMS.Text = ni.AliquotaICMS == null ? "" : ni.AliquotaICMS.ToString();
            txtAliqIPI.Text = ni.AliquotaIPI == null ? "" : ni.AliquotaIPI.ToString();
            txtBaseICMS.Text = ni.BaseICMS == null ? "" : ni.BaseICMS.ToString();
            txtCodigo.Text = ni.Codigo == null ? "" : ni.Codigo.ToString();
            txtCodigoCliente.Text = ni.CodigoCliente == null ? "" : ni.CodigoCliente.ToString();
            txtCodigoFornecedor.Text = ni.CodigoFornecedor == null ? "" : ni.CodigoFornecedor.ToString();
            txtCST.Text = ni.SituacaoTribICMS == null ? "" : ni.SituacaoTribICMS.ToString();
            txtDesconto.Text = ni.Desconto == null ? "" : ni.Desconto.ToString();
            txtDescricao.Text = ni.Descricao == null ? "" : ni.Descricao.ToString();
            txtDespesasAcessorias.Text = ni.DespesasAcessorias == null ? "" : ni.DespesasAcessorias.ToString();
            txtEnquadramentoIPI.Text = ni.EnquadramentoIPI == null ? "" : ni.EnquadramentoIPI.ToString();
            txtFrete.Text = ni.Frete == null ? "" : ni.Frete.ToString();
            txtObservacao.Text = ni.Observacao == null ? "" : ni.Observacao.ToString();
            txtPesoBruto.Text = ni.PesoBruto == null ? "" : ni.PesoBruto.ToString();
            txtPesoLiquido.Text = ni.PesoLiquido == null ? "" : ni.PesoLiquido.ToString();
            txtQuantidade.Text = ni.Quantidade == null ? "" : ni.Quantidade.ToString();
            txtSeguro.Text = ni.Seguro == null ? "" : ni.Seguro.ToString();
            txtValorICMS.Text = ni.ValorICMS == null ? "" : ni.ValorICMS.ToString();
            txtValorIPI.Text = ni.ValorIPI == null ? "" : ni.ValorIPI.ToString();
            txtValorTotal.Text = ni.ValorTotal == null ? "" : ni.ValorTotal.ToString();
            txtValorUnitario.Text = ni.ValorUnitario == null ? "" : ni.ValorUnitario.ToString();
            txtVolumes.Text = ni.Volumes == null ? "" : ni.Volumes.ToString();
        }

        private void CarregaCombo()
        {
            var NCM = new ClassificacaoFiscalDAL().GetCombo();
            cboNCM.DataSource = NCM;
            cboNCM.DisplayMember = "Text";
            cboNCM.ValueMember = "iValue";
            cboNCM.SelectedIndex = -1;

            var CFOP = new CFOPDAL().GetCombo();
            cboCFOP.DataSource = CFOP;
            cboCFOP.DisplayMember = "Text";
            cboCFOP.ValueMember = "iValue";
            cboCFOP.SelectedIndex = -1;

            var unidade = new UnidadeDAL().GetCombo();
            cboUnidade.DataSource = unidade;
            cboUnidade.DisplayMember = "Text";
            cboUnidade.ValueMember = "iValue";
            cboUnidade.SelectedIndex = -1;

            cboCest.DataSource = new CESTDAL().GetCombo();
            cboCest.ValueMember = "iValue";
            cboCest.DisplayMember = "Text";
            cboCest.SelectedIndex = -1;
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            if(Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    ni.AliquotaICMS = null;
                    ni.AliquotaIPI = null;
                    ni.BaseICMS = null;
                    ni.Codigo = null;
                    ni.CodigoCliente = null;
                    ni.CodigoFornecedor = null;
                    ni.SituacaoTribICMS = null;
                    ni.Desconto = null;
                    ni.Descricao = null;
                    ni.DespesasAcessorias = null;
                    ni.EnquadramentoIPI = null;
                    ni.Frete = null;
                    ni.IdNCM = null;
                    ni.IdUnidade = null;
                    ni.Observacao = null;
                    ni.PesoBruto = null;
                    ni.PesoLiquido = null;
                    ni.Quantidade = null;
                    ni.Seguro = null;
                    ni.ValorICMS = null;
                    ni.ValorIPI = null;
                    ni.ValorTotal = null;
                    ni.ValorUnitario = null;
                    ni.Volumes = null;
                    ni.IdCest = null;

                    if (!String.IsNullOrEmpty(cboCFOP.Text)) ni.IdCFOP = Convert.ToInt32(cboCFOP.SelectedValue);
                    if (!String.IsNullOrEmpty(cboNCM.Text)) ni.IdNCM = Convert.ToInt32(cboNCM.SelectedValue);
                    if (!String.IsNullOrEmpty(cboUnidade.Text)) ni.IdUnidade = Convert.ToInt32(cboUnidade.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCest.Text)) ni.IdCest = Convert.ToInt32(cboCest.SelectedValue);
                    if (!String.IsNullOrEmpty(txtAliqICMS.Text)) ni.AliquotaICMS = Convert.ToDecimal(txtAliqICMS.Text);
                    if (!String.IsNullOrEmpty(txtAliqIPI.Text)) ni.AliquotaIPI = Convert.ToDecimal(txtAliqIPI.Text);
                    if (!String.IsNullOrEmpty(txtBaseICMS.Text)) ni.BaseICMS = Convert.ToDecimal(txtBaseICMS.Text);
                    if (!String.IsNullOrEmpty(txtCodigo.Text)) ni.Codigo = txtCodigo.Text;
                    if (!String.IsNullOrEmpty(txtCodigoCliente.Text)) ni.CodigoCliente = txtCodigoCliente.Text;
                    if (!String.IsNullOrEmpty(txtCodigoFornecedor.Text)) ni.CodigoFornecedor = txtCodigoFornecedor.Text;
                    if (!String.IsNullOrEmpty(txtCST.Text)) ni.SituacaoTribICMS = txtCST.Text;
                    if (!String.IsNullOrEmpty(txtDesconto.Text)) ni.Desconto = Convert.ToDecimal(txtDesconto.Text);
                    if (!String.IsNullOrEmpty(txtDescricao.Text)) ni.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(txtDespesasAcessorias.Text)) ni.DespesasAcessorias = Convert.ToDecimal(txtDespesasAcessorias.Text);
                    if (!String.IsNullOrEmpty(txtEnquadramentoIPI.Text)) ni.EnquadramentoIPI = Convert.ToInt32(txtEnquadramentoIPI.Text);
                    if (!String.IsNullOrEmpty(txtFrete.Text)) ni.Frete = Convert.ToDecimal(txtFrete.Text);
                    if (!String.IsNullOrEmpty(txtObservacao.Text)) ni.Observacao = txtObservacao.Text;
                    if (!String.IsNullOrEmpty(txtPesoBruto.Text)) ni.PesoBruto = Convert.ToDecimal(txtPesoBruto.Text);
                    if (!String.IsNullOrEmpty(txtPesoLiquido.Text)) ni.PesoLiquido = Convert.ToDecimal(txtPesoLiquido.Text);
                    if (!String.IsNullOrEmpty(txtQuantidade.Text)) ni.Quantidade = Convert.ToDecimal(txtQuantidade.Text);
                    if (!String.IsNullOrEmpty(txtSeguro.Text)) ni.Seguro = Convert.ToDecimal(txtSeguro.Text);
                    if (!String.IsNullOrEmpty(txtValorICMS.Text)) ni.ValorICMS = Convert.ToDecimal(txtValorICMS.Text);
                    if (!String.IsNullOrEmpty(txtValorIPI.Text)) ni.ValorIPI = Convert.ToDecimal(txtValorIPI.Text);
                    if (!String.IsNullOrEmpty(txtValorTotal.Text)) ni.ValorTotal = Convert.ToDecimal(txtValorTotal.Text);
                    if (!String.IsNullOrEmpty(txtValorUnitario.Text)) ni.ValorUnitario = Convert.ToDecimal(txtValorUnitario.Text);
                    if (!String.IsNullOrEmpty(txtVolumes.Text)) ni.Volumes = Convert.ToDecimal(txtVolumes.Text);




                    if (ni.IdNotaFiscalItem == 0)
                    {
                        dal.Insert(ni);
                    }
                    else
                    {
                        dal.Update(ni);
                    }
                    dal.Save();
                    this.Close();
                }
                catch(Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Verifique os dados informados");
                }
            } 
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja remover a configuração?") == System.Windows.Forms.DialogResult.Yes)
            {
                dal.Delete(ni.IdNotaFiscalItem);
                dal.Save();
                this.Close();
            }
        }

        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            frmListaImpostosNotaFiscal frmImpostos = new frmListaImpostosNotaFiscal(ni.IdNotaFiscalItem);
            frmImpostos.ShowDialog();
        }
    }
}
