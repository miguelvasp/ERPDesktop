using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCodigoImpostoCad : RibbonForm
    {
        public CodigoImpostoDAL dal = new CodigoImpostoDAL();
        LimiteImpostoDAL lDal = new LimiteImpostoDAL();
        ValoresImpostoDAL vDal = new ValoresImpostoDAL();
        CodigoImposto ci = new CodigoImposto();
        Empresa empresa = new EmpresaDAL().getByIdEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));

        public frmCodigoImpostoCad(CodigoImposto pCI)
        {
            ci = pCI;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCodigoImpostoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarJuridicaoImposto();
            CarregarPercentualValor();
            CarregarMoeda();
            CarregarPeriodoLiquidacaoImposto();
            CarregarGrupoLancamentoContabil();
            CarregarParametrosParaCalculo();
            CarregarBaseMarginal();
            CarregarMetodoCalculo();
            CarregarCodigoImposto();
            CarregarUnidadeOperacional();
            CarregarDataDoCalculo();
            CarregarTipoImposto();
            CarregarCodigoTributacao();
            CarregarMetodoSustituicaoTributaria();

            if (ci.IdCodigoImposto == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmCodigoImpostoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = ci.IdCodigoImposto.ToString();
            txtDescricao.Text = ci.Descricao;
            if (ci.IdJuridicaoImposto != null)
                cboJuridicao.SelectedValue = ci.IdJuridicaoImposto;

            cboMoeda.SelectedValue = ci.IdMoeda;
            if (ci.IdPeriodoLiquidacaoImposto != null)
                cboPeriodoLiquidacao.SelectedValue = ci.IdPeriodoLiquidacaoImposto;
            if (ci.IdGrupoLancamentoContabil != null)
                cboGrupoLancamentoContabil.SelectedValue = ci.IdGrupoLancamentoContabil;
            chkPorcentagemNegativaImposto.Checked = ci.PorcentagemNegativaImposto;
            if (ci.ParametrosCalculos != null)
                cboParametrosCalculo.SelectedValue = ci.ParametrosCalculos.ToString();
            if (ci.BaseMarginal != null)
                cboBaseMarginal.SelectedValue = ci.BaseMarginal.ToString();
            if (ci.MetodoCalculo != null)
                cboMetodoCalculo.SelectedValue = ci.MetodoCalculo.ToString();
            if (ci.IdCodigoImpostoImposto != null)
                cboCodigoImposto.SelectedValue = ci.IdCodigoImpostoImposto;
            if (ci.IdUnidade != null)
                cboUnidadeOperacional.SelectedValue = ci.IdUnidade;
            if (ci.DataCalculo != null)
                cboDataCalculo.SelectedValue = ci.DataCalculo.ToString();
            if (ci.TipoImposto != null)
                cboTipoImposto.SelectedValue = ci.TipoImposto;
            if (ci.IdCodigoTributacao != null)
                cboCodigoTributacao.SelectedValue = ci.IdCodigoTributacao;
            chkImpostoRetidoRecuperavel.Checked = ci.ImpostoRetidoRecuperavel;
            chkImpostoIncluso.Checked = ci.ImpostoIncluso;
            if (ci.MetodoSubstituicaoTributaria != null)
                cboMetodoSustituicaoTributaria.SelectedValue = ci.MetodoSubstituicaoTributaria.ToString();
            txtCodigoReceita.Text = ci.CodigoReceita;

            var Aliq = new CodigoImpostoDAL().ConsultaPercentualPorData(ci.IdCodigoImposto);
            if (Aliq != null)
            {
                txtPercentualValor.Text = Aliq.Aliquota.ToString();
            }

            CarregaLimites();
            CarregaValores();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarBaseMarginal()
        {
            List<DropList> lista = Util.EnumERP.CarregarBaseMarginal();

            cboBaseMarginal.DisplayMember = "Text";
            cboBaseMarginal.ValueMember = "Value";
            cboBaseMarginal.DataSource = lista;
            cboBaseMarginal.SelectedValue = 1;
        }

        private void CarregarCodigoImposto()
        {
            cboCodigoImposto.DataSource = new CodigoImpostoDAL().GetCombo();
            cboCodigoImposto.DisplayMember = "Text";
            cboCodigoImposto.ValueMember = "iValue";
            cboCodigoImposto.SelectedIndex = -1;
        }

        private void CarregarCodigoTributacao()
        {
            cboCodigoTributacao.DataSource = new CodigoTributacaoDAL().GetCombo();
            cboCodigoTributacao.DisplayMember = "Text";
            cboCodigoTributacao.ValueMember = "iValue";
            cboCodigoTributacao.SelectedIndex = -1;
        }

        private void CarregarDataDoCalculo()
        {
            List<DropList> lista = Util.EnumERP.CarregarDataDoCalculo();

            cboDataCalculo.DisplayMember = "Text";
            cboDataCalculo.ValueMember = "Value";
            cboDataCalculo.DataSource = lista;
            cboDataCalculo.SelectedValue = 1;
        }

        private void CarregarGrupoLancamentoContabil()
        {
            cboGrupoLancamentoContabil.DataSource = new GrupoLancamentoContabilDAL().GetCombo();
            cboGrupoLancamentoContabil.DisplayMember = "Text";
            cboGrupoLancamentoContabil.ValueMember = "iValue";
            cboGrupoLancamentoContabil.SelectedIndex = -1;
        }

        private void CarregarJuridicaoImposto()
        {
            cboJuridicao.DataSource = new JuridicaoImpostoDAL().GetCombo();
            cboJuridicao.DisplayMember = "Text";
            cboJuridicao.ValueMember = "iValue";
            cboJuridicao.SelectedIndex = -1;
        }

        private void CarregarMetodoCalculo()
        {
            List<DropList> lista = Util.EnumERP.CarregarMetodoCalculo();

            cboMetodoCalculo.DisplayMember = "Text";
            cboMetodoCalculo.ValueMember = "Value";
            cboMetodoCalculo.DataSource = lista;
            cboMetodoCalculo.SelectedValue = 2;
        }

        private void CarregarMetodoSustituicaoTributaria()
        {
            List<DropList> lista = Util.EnumERP.CarregarMetodoSustituicaoTributaria();

            cboMetodoSustituicaoTributaria.DisplayMember = "Text";
            cboMetodoSustituicaoTributaria.ValueMember = "Value";
            cboMetodoSustituicaoTributaria.DataSource = lista;
            cboMetodoSustituicaoTributaria.SelectedIndex = -1;
        }

        private void CarregarMoeda()
        {
            cboMoeda.DataSource = new MoedaDAL().GetCombo();
            cboMoeda.DisplayMember = "Text";
            cboMoeda.ValueMember = "iValue";
            cboMoeda.SelectedIndex = -1;

           // if(empresa.idm)
        }

        private void CarregarParametrosParaCalculo()
        {
            List<DropList> lista = Util.EnumERP.CarregarParametrosParaCalculo();

            cboParametrosCalculo.DisplayMember = "Text";
            cboParametrosCalculo.ValueMember = "Value";
            cboParametrosCalculo.DataSource = lista;
            cboParametrosCalculo.SelectedValue = 1; //Padrao 
        }

        private void CarregarPercentualValor()
        {
            //cboPercentualValor.DataSource = new JuridicaoImpostoDAL().GetCombo();
            //cboPercentualValor.DisplayMember = "Text";
            //cboPercentualValor.ValueMember = "iValue";
            //cboPercentualValor.SelectedIndex = -1;
        }

        private void CarregarPeriodoLiquidacaoImposto()
        {
            cboPeriodoLiquidacao.DataSource = new PeriodoLiquidacaoImpostoDAL().GetCombo();
            cboPeriodoLiquidacao.DisplayMember = "Text";
            cboPeriodoLiquidacao.ValueMember = "iValue";
            cboPeriodoLiquidacao.SelectedIndex = -1;
        }

        private void CarregarTipoImposto()
        {
            List<ComboItem> lista = new List<ComboItem>();
            lista.Add(new ComboItem() { iValue = 1, Text = "IPI" });
            lista.Add(new ComboItem() { iValue = 2, Text = "PIS" });
            lista.Add(new ComboItem() { iValue = 3, Text = "ICMS" });
            lista.Add(new ComboItem() { iValue = 4, Text = "COFINS" });
            lista.Add(new ComboItem() { iValue = 5, Text = "ISS" });
            lista.Add(new ComboItem() { iValue = 6, Text = "IRRF" });
            lista.Add(new ComboItem() { iValue = 7, Text = "INSS" });
            lista.Add(new ComboItem() { iValue = 8, Text = "Imposto de importação" });
            lista.Add(new ComboItem() { iValue = 9, Text = "Outros Impostos" });
            lista.Add(new ComboItem() { iValue = 10, Text = "CSLL" });
            lista.Add(new ComboItem() { iValue = 11, Text = "ICMSST" });
            lista.Add(new ComboItem() { iValue = 12, Text = "ICMSDiff" });

            cboTipoImposto.DisplayMember = "Text";
            cboTipoImposto.ValueMember = "iValue";
            cboTipoImposto.DataSource = lista;
            cboTipoImposto.SelectedIndex = -1;
        }

        private void CarregarUnidadeOperacional()
        {
            cboUnidadeOperacional.DataSource = new UnidadeDAL().GetCombo();
            cboUnidadeOperacional.DisplayMember = "Text";
            cboUnidadeOperacional.ValueMember = "iValue";
            cboUnidadeOperacional.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ci = new CodigoImposto();
            lbCodigo.Text = "0";
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            //valores padrao
            cboBaseMarginal.SelectedValue = 1;
            cboParametrosCalculo.SelectedValue = 1; //Padrao 
            cboMetodoCalculo.SelectedValue = 2;
            cboDataCalculo.SelectedValue = 1;
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
                    Cursor.Current = Cursors.WaitCursor;

                    ci.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboJuridicao.Text))
                        ci.IdJuridicaoImposto = Convert.ToInt32(cboJuridicao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboMoeda.Text))
                        ci.IdMoeda = Convert.ToInt32(cboMoeda.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPeriodoLiquidacao.Text))
                        ci.IdPeriodoLiquidacaoImposto = Convert.ToInt32(cboPeriodoLiquidacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoLancamentoContabil.Text))
                        ci.IdGrupoLancamentoContabil = Convert.ToInt32(cboGrupoLancamentoContabil.SelectedValue);
                    ci.PorcentagemNegativaImposto = chkPorcentagemNegativaImposto.Checked;
                    if (!String.IsNullOrEmpty(cboParametrosCalculo.Text))
                        ci.ParametrosCalculos = Convert.ToInt32(cboParametrosCalculo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboBaseMarginal.Text))
                        ci.BaseMarginal = Convert.ToInt32(cboBaseMarginal.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMetodoCalculo.Text))
                        ci.MetodoCalculo = Convert.ToInt32(cboMetodoCalculo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoImposto.Text))
                        ci.IdCodigoImpostoImposto = Convert.ToInt32(cboCodigoImposto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboUnidadeOperacional.Text))
                        ci.IdUnidade = Convert.ToInt32(cboUnidadeOperacional.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDataCalculo.Text))
                        ci.DataCalculo = Convert.ToInt32(cboDataCalculo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoImposto.Text))
                        ci.TipoImposto = Convert.ToInt32(cboTipoImposto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoTributacao.Text))
                        ci.IdCodigoTributacao = Convert.ToInt32(cboCodigoTributacao.SelectedValue);
                    ci.ImpostoRetidoRecuperavel = chkImpostoRetidoRecuperavel.Checked;
                    ci.ImpostoIncluso = chkImpostoIncluso.Checked;
                    if (!String.IsNullOrEmpty(cboMetodoSustituicaoTributaria.Text))
                        ci.MetodoSubstituicaoTributaria = Convert.ToInt32(cboMetodoSustituicaoTributaria.SelectedValue);

                    ci.CodigoReceita = txtCodigoReceita.Text;

                    if (ci.IdCodigoImposto == 0)
                    {
                        dal.Insert(ci);
                    }
                    else
                    {
                        dal.Update(ci);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
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
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    int id = ci.IdCodigoImposto;
                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                }
            }
        }
        
        private void txtCodigoReceita_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAddLimite_Click(object sender, EventArgs e)
        {
            if (ci.IdCodigoImposto == 0)
            {
                Util.Aplicacao.ShowMessage("É necessário salvar os dados do código de imposto antes de adicionar limites.");
                return;
            }
            LimiteImposto l = new LimiteImposto();
            l.IdCodigoImposto = ci.IdCodigoImposto;
            frmLimiteImpostoCad frm = new frmLimiteImpostoCad(l);
            frm.dal = lDal;
            frm.ShowDialog();
            CarregaLimites();
        }

        private void CarregaLimites()
        {
            var lista = lDal.GetByCodigoImposto(ci.IdCodigoImposto);
            dgLimite.DataSource = lista;
            dgLimite.AutoGenerateColumns = false;
        }

        private void dgLimite_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgLimite.Rows.Count == 0) return;
            int id = Convert.ToInt32(dgLimite.Rows[dgLimite.SelectedRows[0].Index].Cells[0].Value);
            LimiteImposto l = lDal.GetByID(id);
            frmLimiteImpostoCad frm = new frmLimiteImpostoCad(l);
            frm.dal = lDal;
            frm.ShowDialog();
            CarregaLimites();
        }

        private void btnAddValores_Click(object sender, EventArgs e)
        {
            if (ci.IdCodigoImposto == 0)
            {
                Util.Aplicacao.ShowMessage("É necessário salvar os dados do código de imposto antes de adicionar valores.");
                return;
            }

            ValoresImposto v = new ValoresImposto();
            v.IdCodigoImposto = ci.IdCodigoImposto;
            frmValoresImpostoCad frm = new frmValoresImpostoCad(v);
            frm.dal = vDal;
            frm.cboCodigoImposto.SelectedValue = ci.IdCodigoImposto;
            frm.cboCodigoImposto.Enabled = false;
            frm.ShowDialog();
            CarregaValores();
        }

        private void CarregaValores()
        {
            var lista = vDal.GetByCodigoImposto(ci.IdCodigoImposto);
            dgValores.DataSource = lista;
            dgValores.AutoGenerateColumns = false;
        }

        private void dgValores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgValores.Rows.Count == 0) return;
            int id = Convert.ToInt32(dgValores.Rows[dgValores.SelectedRows[0].Index].Cells[0].Value);
            ValoresImposto v = vDal.GetByID(id);
            v.IdCodigoImposto = ci.IdCodigoImposto;
            frmValoresImpostoCad frm = new frmValoresImpostoCad(v);
            frm.dal = vDal;
            frm.cboCodigoImposto.SelectedValue = ci.IdCodigoImposto;
            frm.cboCodigoImposto.Enabled = false;
            frm.ShowDialog();
            CarregaValores();
        }

        private void cboTipoImposto_Leave(object sender, EventArgs e)
        {
            if(cboTipoImposto.Text != "")
            {
                cboCodigoTributacao.DataSource = new CodigoTributacaoDAL().GetComboTipoImposto(Convert.ToInt32(cboTipoImposto.SelectedValue));
                cboCodigoTributacao.DisplayMember = "Text";
                cboCodigoTributacao.ValueMember = "iValue";
                cboCodigoTributacao.SelectedIndex = -1;
            }
        }
    }
}