using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMovimentacaoAtivoCad : RibbonForm
    {
        MovimentacaoAtivo objMovAt = new MovimentacaoAtivo();
        public MovimentacaoAtivoDAL dal = new MovimentacaoAtivoDAL();
        
        public frmMovimentacaoAtivoCad()
        {
            InitializeComponent();
        }

        public frmMovimentacaoAtivoCad(MovimentacaoAtivo _MovimentacaoAtivo)
        {
            objMovAt = _MovimentacaoAtivo;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmMovimentacaoAtivoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaCombos();

            if (objMovAt.IdMovimentacaoAtivo == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void CarregaCombos()
        {
            CarregaMovimentacaoAtivo();
            CarregaConvencao();
            CarregaDepreciacao();
            CarregaValorNegativo();
            CarregaStatusAtivo();
            CarregaLancamento();
            CarregaCliente();
            CarregaFornecedor();
            CarregaGrupoAtivo();
        }

        private void CarregaMovimentacaoAtivo()
        {
            List<ComboItem> Ativo = new List<ComboItem>();
            Ativo.Add(new ComboItem() { iValue = 1, Text = "Ainda não adquirido" });
            Ativo.Add(new ComboItem() { iValue = 2, Text = "Em aberto" });
            Ativo.Add(new ComboItem() { iValue = 3, Text = "Suspenso" });
            Ativo.Add(new ComboItem() { iValue = 4, Text = "Fechada" });
            Ativo.Add(new ComboItem() { iValue = 5, Text = "Vendido" });
            Ativo.Add(new ComboItem() { iValue = 6, Text = "Sucateado" });
            Ativo.Add(new ComboItem() { iValue = 7, Text = "Transferido para o grupo de valor baixo" });
            Ativo.Add(new ComboItem() { iValue = 8, Text = "Adquirido" });
            cboMovimentacaoAtivo.DataSource = Ativo;
            cboMovimentacaoAtivo.ValueMember = "iValue";
            cboMovimentacaoAtivo.DisplayMember = "Text";
            cboMovimentacaoAtivo.SelectedIndex = -1;
        }

        private void CarregaConvencao()
        {
            List<ComboItem> Convencao = new List<ComboItem>();
            Convencao.Add(new ComboItem() { iValue = 1, Text = "Semestre" });
            Convencao.Add(new ComboItem() { iValue = 2, Text = "Meio do Mês(Primeiro dia)" });
            Convencao.Add(new ComboItem() { iValue = 3, Text = "Meio do Mês(Decimo quinto dia)" });
            Convencao.Add(new ComboItem() { iValue = 4, Text = "Mês inteiro" });
            Convencao.Add(new ComboItem() { iValue = 5, Text = "Meio do trimeste" });
            Convencao.Add(new ComboItem() { iValue = 6, Text = "Semestre(inicio)" });
            Convencao.Add(new ComboItem() { iValue = 7, Text = "Semestre(proximo ano)" });
            cboConvencao.DataSource = Convencao;
            cboConvencao.ValueMember = "iValue";
            cboConvencao.DisplayMember = "Text";
            cboConvencao.SelectedIndex = -1;
        }

        private void CarregaDepreciacao()
        {
            List<ComboItem> Depreciacao = new List<ComboItem>();
            Depreciacao.Add(new ComboItem() { iValue = 1, Text = "Não" });
            Depreciacao.Add(new ComboItem() { iValue = 2, Text = "Sim" });
            cboDepreciacao.DataSource = Depreciacao;
            cboDepreciacao.ValueMember = "iValue";
            cboDepreciacao.DisplayMember = "Text";
            cboDepreciacao.SelectedIndex = -1;
        }

        private void CarregaValorNegativo()
        {
            List<ComboItem> ValorNeg = new List<ComboItem>();
            ValorNeg.Add(new ComboItem() { iValue = 1, Text = "Não" });
            ValorNeg.Add(new ComboItem() { iValue = 2, Text = "Sim" });
            cboPermitirValorNegativo.DataSource = ValorNeg;
            cboPermitirValorNegativo.ValueMember = "iValue";
            cboPermitirValorNegativo.DisplayMember = "Text";
            cboPermitirValorNegativo.SelectedIndex = -1;
        }

        private void CarregaStatusAtivo()
        {
            List<ComboItem> stAtivo = new List<ComboItem>();
            stAtivo.Add(new ComboItem() { iValue = 1, Text = "Ainda não adquirido" });
            stAtivo.Add(new ComboItem() { iValue = 2, Text = "Adquirido" });
            stAtivo.Add(new ComboItem() { iValue = 3, Text = "Em aberto" });
            stAtivo.Add(new ComboItem() { iValue = 4, Text = "Suspenso" });
            stAtivo.Add(new ComboItem() { iValue = 5, Text = "Fechada" });
            stAtivo.Add(new ComboItem() { iValue = 6, Text = "Vendido" });
            stAtivo.Add(new ComboItem() { iValue = 7, Text = "Sucateado" });
            stAtivo.Add(new ComboItem() { iValue = 8, Text = "Transferido para o grupo de valor baixo" });
            cboStatusAtivo.DataSource = stAtivo;
            cboStatusAtivo.ValueMember = "iValue";
            cboStatusAtivo.DisplayMember = "Text";
            cboStatusAtivo.SelectedIndex = -1;
        }

        private void CarregaLancamento()
        {
            List<ComboItem> Lancamento = new List<ComboItem>();
            Lancamento.Add(new ComboItem() { iValue = 1, Text = "Atual" });
            Lancamento.Add(new ComboItem() { iValue = 2, Text = "Operação" });
            Lancamento.Add(new ComboItem() { iValue = 3, Text = "Impostos" });
            cboNivelLancamento.DataSource = Lancamento;
            cboNivelLancamento.ValueMember = "iValue";
            cboNivelLancamento.DisplayMember = "Text";
            cboNivelLancamento.SelectedIndex = -1;
        }

        private void CarregaCliente()
        {
            cboCliente.DataSource = new ClienteDAL().GetCombo();
            cboCliente.ValueMember = "iValue";
            cboCliente.DisplayMember = "Text";
            cboCliente.SelectedIndex = -1;
        }

        private void CarregaFornecedor()
        {
            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(Util.Util.GetAppSettings("IdEmpresa"));
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.SelectedIndex = -1;
        }

        private void CarregaGrupoAtivo()
        {
            cboGrupoAtivo.DataSource = new GrupoAtivoDAL().GetCombo();
            cboGrupoAtivo.ValueMember = "iValue";
            cboGrupoAtivo.DisplayMember = "Text";
            cboGrupoAtivo.SelectedIndex = -1;
        }
        
        private void CarregaDados()
        {
            cboAtivo.SelectedValue = objMovAt.IDAtivo == null ? 0 : objMovAt.IDAtivo;
            cboCliente.SelectedValue = objMovAt.IDCliente == null ? 0 : objMovAt.IDCliente;
            cboConvencao.SelectedValue = objMovAt.Convencao == null ? 0 : objMovAt.Convencao;
            cboFornecedor.SelectedValue = objMovAt.IDFornecedor == null ? 0 : objMovAt.IDFornecedor;
            cboGrupoAtivo.SelectedValue = objMovAt.IDGrupoAtivo == null ? 0 : objMovAt.IDGrupoAtivo;
            cboMovimentacaoAtivo.SelectedValue = objMovAt.IdMovimentacaoAtivoStatus == null ? 0 : objMovAt.IdMovimentacaoAtivoStatus;
            cboNivelLancamento.SelectedValue = objMovAt.NivelLancamento == null ? 0 : objMovAt.NivelLancamento;
            cboPerfilLancamento.SelectedValue = objMovAt.IDPerfilLanamento == null ? 0 : objMovAt.IDPerfilLanamento;
            cboPeriodoDepreciacaoRestante.SelectedValue = objMovAt.PeriodoDepreciacaoRestante == null ? 0 : objMovAt.PeriodoDepreciacaoRestante;
            cboPermitirValorNegativo.SelectedValue = objMovAt.PermitirValorNegativo == null ? 0 : objMovAt.PermitirValorNegativo;
            cboStatusAtivo.SelectedValue = objMovAt.StatusAtivo == null ? 0 : objMovAt.StatusAtivo;
            cboTransacaoAtivo.SelectedValue = objMovAt.IDTransacaoAtivo == null ? 0 : objMovAt.IDTransacaoAtivo;
            txtDataDocumento.Text = objMovAt.DataDocumento == null ? "" : objMovAt.DataDocumento.ToString();
            txtDataExecucaoDepreciacao.Text = objMovAt.DataExecucaoDepreciacao == null ? "" : objMovAt.DataExecucaoDepreciacao.ToString();
            txtDataTrasação.Text = objMovAt.DataTrasacao == null ? "" : objMovAt.DataTrasacao.ToString();
            txtDataUltimaDepre.Text = objMovAt.DataUltimaDepreciacao == null ? "" : objMovAt.DataUltimaDepreciacao.ToString();
            txtNotaFiscal.Text = objMovAt.NotaFiscal == null ? "" : objMovAt.NotaFiscal.ToString();
            txtPeriodo.Text = objMovAt.Periodo == null ? "" : objMovAt.Periodo.ToString();
            txtRevisaoAquisicao.Text = objMovAt.RevisaoAquisicao == null ? "" : objMovAt.RevisaoAquisicao.ToString();
            txtValorAquisicao.Text = objMovAt.ValorAquisicao == null ? "" : objMovAt.ValorAquisicao.ToString();
            txtValorICMS.Text = objMovAt.ValorICMS == null ? "" : objMovAt.ValorICMS.ToString();
            txtValorSucata.Text = objMovAt.ValorSucata == null ? "" : objMovAt.ValorSucata.ToString();
            txtValorVenda.Text = objMovAt.ValorVenda == null ? "" : objMovAt.ValorVenda.ToString();
            txtVidaUtil.Text = objMovAt.VidaUtil == null ? "" : objMovAt.VidaUtil.ToString();
            cboDepreciacao.SelectedValue = objMovAt.Depreciacao == null ? 0 : objMovAt.Depreciacao;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            objMovAt = new MovimentacaoAtivo();
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    objMovAt.DataDocumento = null;
                    objMovAt.DataExecucaoDepreciacao = null;
                    objMovAt.DataTrasacao = null;
                    objMovAt.DataExecucaoDepreciacao = null;
                    objMovAt.IDAtivo = null;
                    objMovAt.IDCliente = null;
                    objMovAt.Convencao = null;
                    objMovAt.IDFornecedor = null;
                    objMovAt.IDGrupoAtivo = null;
                    objMovAt.NivelLancamento = null;
                    objMovAt.IDPerfilLanamento = null;
                    objMovAt.PeriodoDepreciacaoRestante = null;
                    objMovAt.PermitirValorNegativo = null;
                    objMovAt.StatusAtivo = null;
                    objMovAt.IDTransacaoAtivo = null;
                    objMovAt.NotaFiscal = null;
                    objMovAt.Periodo = null;
                    objMovAt.RevisaoAquisicao = null;
                    objMovAt.ValorAquisicao = null;
                    objMovAt.ValorICMS = null;
                    objMovAt.ValorSucata = null;
                    objMovAt.ValorVenda = null;
                    objMovAt.VidaUtil = null;
                    objMovAt.Depreciacao = null;
                    objMovAt.IdMovimentacaoAtivoStatus = null;
                    
                    if (!String.IsNullOrEmpty(cboAtivo.Text)) objMovAt.IDAtivo = Convert.ToInt32(cboAtivo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCliente.Text)) objMovAt.IDCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    if (!String.IsNullOrEmpty(cboConvencao.Text)) objMovAt.Convencao = Convert.ToInt32(cboConvencao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFornecedor.Text)) objMovAt.IDFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoAtivo.Text)) objMovAt.IDGrupoAtivo = Convert.ToInt32(cboGrupoAtivo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMovimentacaoAtivo.Text)) objMovAt.IdMovimentacaoAtivoStatus = Convert.ToInt32(cboMovimentacaoAtivo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboNivelLancamento.Text)) objMovAt.NivelLancamento = Convert.ToInt32(cboNivelLancamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPerfilLancamento.Text)) objMovAt.IDPerfilLanamento = Convert.ToInt32(cboPerfilLancamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPeriodoDepreciacaoRestante.Text)) objMovAt.PeriodoDepreciacaoRestante = Convert.ToInt32(cboPeriodoDepreciacaoRestante.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPermitirValorNegativo.Text)) objMovAt.PermitirValorNegativo = Convert.ToInt32(cboPermitirValorNegativo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboStatusAtivo.Text)) objMovAt.StatusAtivo = Convert.ToInt32(cboStatusAtivo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTransacaoAtivo.Text)) objMovAt.IDTransacaoAtivo = Convert.ToInt32(cboTransacaoAtivo.SelectedValue);
                    if (!String.IsNullOrEmpty(txtDataDocumento.Text)) objMovAt.DataDocumento = Convert.ToDateTime(txtDataDocumento.Text);
                    if (!String.IsNullOrEmpty(txtDataExecucaoDepreciacao.Text)) objMovAt.DataExecucaoDepreciacao = Convert.ToDateTime(txtDataExecucaoDepreciacao.Text);
                    if (!String.IsNullOrEmpty(txtDataTrasação.Text)) objMovAt.DataTrasacao = Convert.ToDateTime(txtDataTrasação.Text);
                    if (!String.IsNullOrEmpty(txtDataUltimaDepre.Text)) objMovAt.DataUltimaDepreciacao = Convert.ToDateTime(txtDataUltimaDepre.Text);
                    if (!String.IsNullOrEmpty(txtNotaFiscal.Text)) objMovAt.NotaFiscal = txtNotaFiscal.Text;
                    if (!String.IsNullOrEmpty(txtPeriodo.Text)) objMovAt.Periodo = Convert.ToInt32(txtPeriodo.Text);
                    if (!String.IsNullOrEmpty(txtRevisaoAquisicao.Text)) objMovAt.RevisaoAquisicao = Convert.ToDecimal(txtRevisaoAquisicao.Text);
                    if (!String.IsNullOrEmpty(txtValorAquisicao.Text)) objMovAt.ValorAquisicao = Convert.ToDecimal(txtValorAquisicao.Text);
                    if (!String.IsNullOrEmpty(txtValorICMS.Text)) objMovAt.ValorICMS = Convert.ToDecimal(txtValorICMS.Text);
                    if (!String.IsNullOrEmpty(txtValorSucata.Text)) objMovAt.ValorSucata = Convert.ToDecimal(txtValorSucata.Text);
                    if (!String.IsNullOrEmpty(txtValorVenda.Text)) objMovAt.ValorVenda = Convert.ToDecimal(txtValorVenda.Text);
                    if (!String.IsNullOrEmpty(txtVidaUtil.Text)) objMovAt.VidaUtil = Convert.ToDecimal(txtVidaUtil.Text);
                    if (!String.IsNullOrEmpty(cboDepreciacao.Text)) objMovAt.Depreciacao = Convert.ToInt32(cboDepreciacao.SelectedValue);

                    if (objMovAt.IdMovimentacaoAtivo == 0)
                    {

                        dal.Insert(objMovAt);
                    }
                    else
                    {
                        dal.Update(objMovAt);
                    }

                    dal.Save();
                    CarregaDados();
                   
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {

                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }

            else
            {
                Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
            }           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == System.Windows.Forms.DialogResult.Yes)
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = objMovAt.IdMovimentacaoAtivo;
                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
            }
        }
    }
}
