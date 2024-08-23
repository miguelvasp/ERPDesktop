using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPerfilFornecedorCad : RibbonForm
    {
        public PerfilFornecedorDAL dal;
        PerfilFornecedor pf = new PerfilFornecedor();

        public frmPerfilFornecedorCad(PerfilFornecedor ppf)
        {
            pf = ppf;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmPerfilFornecedorCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarFornecedor();
            CarregarGrupoFornecedor();
            CarregarRelacaoAoGrupo();
            CarregarConta();
            CarregarLiquidar();
            CarregarPagamentoAntecipado();
            CarregarContraPartida();
            CarregarJuros();
            CarregarMulta();
            CarregarTransferenciaImpostos();

            if (pf.IdPerfilFornecedor == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmPerfilFornecedorCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = pf.IdPerfilFornecedor.ToString();
            txtNome.Text = pf.Nome;
            txtDescricao.Text = pf.Descricao;
            if (pf.RelacaoGrupo != null)
                cboRelacaoGrupo.SelectedValue = pf.RelacaoGrupo.ToString();
            if (pf.IdFornecedor != null)
                cboFornecedor.SelectedValue = pf.IdFornecedor;
            if (pf.IdGrupoFornecedor != null)
                cboGrupoFornecedor.SelectedValue = pf.IdGrupoFornecedor;

            if (pf.IdContaContabil != null)
                cboConta.SelectedValue = pf.IdContaContabil;
            if (pf.IdContaContabilLiquidar != null)
                cboLiquidar.SelectedValue = pf.IdContaContabilLiquidar;
            if (pf.IdContaContabilPagamentoAntecipado != null)
                cboPagamentoAntecipado.SelectedValue = pf.IdContaContabilPagamentoAntecipado;
            if (pf.IdContaContabilContraPartida != null)
                cboContraPartida.SelectedValue = pf.IdContaContabilContraPartida;
            if (pf.IdContaContabilJuros != null)
                cboJuros.SelectedValue = pf.IdContaContabilJuros;
            if (pf.IdContaContabilMulta != null)
                cboMulta.SelectedValue = pf.IdContaContabilMulta;
            if (pf.IdContaContabilTransferenciaImposto != null)
                cboTransferenciaImpostos.SelectedValue = pf.IdContaContabilTransferenciaImposto;

            chkBaixa.Checked = pf.Baixa;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregarFornecedor()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        protected void CarregarGrupoFornecedor()
        {
            GrupoFornecedorDAL gcdal = new GrupoFornecedorDAL();

            var gc = gcdal.Get().OrderBy(o => o.Descricao).ToList();
            cboGrupoFornecedor.DataSource = gc;
            cboGrupoFornecedor.ValueMember = "IdGrupoFornecedor";
            cboGrupoFornecedor.DisplayMember = "Descricao";
            cboGrupoFornecedor.SelectedIndex = -1;
        }

        private void CarregarRelacaoAoGrupo()
        {
            List<DropList> lista = Util.EnumERP.CarregarRelacaoAoGrupo();

            cboRelacaoGrupo.DisplayMember = "Text";
            cboRelacaoGrupo.ValueMember = "Value";
            cboRelacaoGrupo.DataSource = lista;
            cboRelacaoGrupo.SelectedIndex = -1;
        }

        protected void CarregarConta()
        {
            cboConta.DataSource = new ContaContabilDAL().GetCombo();
            cboConta.DisplayMember = "Text";
            cboConta.ValueMember = "iValue";
            cboConta.SelectedIndex = -1;
        }

        protected void CarregarLiquidar()
        {
            cboLiquidar.DataSource = new ContaContabilDAL().GetCombo();
            cboLiquidar.DisplayMember = "Text";
            cboLiquidar.ValueMember = "iValue";
            cboLiquidar.SelectedIndex = -1;
        }

        protected void CarregarPagamentoAntecipado()
        {
            cboPagamentoAntecipado.DataSource = new ContaContabilDAL().GetCombo();
            cboPagamentoAntecipado.DisplayMember = "Text";
            cboPagamentoAntecipado.ValueMember = "iValue";
            cboPagamentoAntecipado.SelectedIndex = -1;
        }

        protected void CarregarContraPartida()
        {
            cboContraPartida.DataSource = new ContaContabilDAL().GetCombo();
            cboContraPartida.DisplayMember = "Text";
            cboContraPartida.ValueMember = "iValue";
            cboContraPartida.SelectedIndex = -1;
        }

        protected void CarregarJuros()
        {
            cboJuros.DataSource = new ContaContabilDAL().GetCombo();
            cboJuros.DisplayMember = "Text";
            cboJuros.ValueMember = "iValue";
            cboJuros.SelectedIndex = -1;
        }

        protected void CarregarMulta()
        {
            cboMulta.DataSource = new ContaContabilDAL().GetCombo();
            cboMulta.DisplayMember = "Text";
            cboMulta.ValueMember = "iValue";
            cboMulta.SelectedIndex = -1;
        }

        protected void CarregarTransferenciaImpostos()
        {
            cboTransferenciaImpostos.DataSource = new ContaContabilDAL().GetCombo();
            cboTransferenciaImpostos.DisplayMember = "Text";
            cboTransferenciaImpostos.ValueMember = "iValue";
            cboTransferenciaImpostos.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            pf = new PerfilFornecedor();
            lbCodigo.Text = "0";
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
                    Cursor.Current = Cursors.WaitCursor;

                    pf.Nome = txtNome.Text;
                    pf.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboRelacaoGrupo.Text))
                        pf.RelacaoGrupo = Convert.ToInt32(cboRelacaoGrupo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFornecedor.Text))
                        pf.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoFornecedor.Text))
                        pf.IdGrupoFornecedor = Convert.ToInt32(cboGrupoFornecedor.SelectedValue);

                    if (!String.IsNullOrEmpty(cboConta.Text))
                        pf.IdContaContabil = Convert.ToInt32(cboConta.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLiquidar.Text))
                        pf.IdContaContabilLiquidar = Convert.ToInt32(cboLiquidar.SelectedValue);
                    else
                        pf.IdContaContabilLiquidar = null;

                    if (!String.IsNullOrEmpty(cboPagamentoAntecipado.Text))
                        pf.IdContaContabilPagamentoAntecipado = Convert.ToInt32(cboPagamentoAntecipado.SelectedValue);
                    else
                        pf.IdContaContabilPagamentoAntecipado = null;

                    if (!String.IsNullOrEmpty(cboContraPartida.Text))
                        pf.IdContaContabilContraPartida = Convert.ToInt32(cboContraPartida.SelectedValue);
                    else
                        pf.IdContaContabilContraPartida = null;

                    if (!String.IsNullOrEmpty(cboJuros.Text))
                        pf.IdContaContabilJuros = Convert.ToInt32(cboJuros.SelectedValue);
                    else
                        pf.IdContaContabilJuros = null;

                    if (!String.IsNullOrEmpty(cboMulta.Text))
                        pf.IdContaContabilMulta = Convert.ToInt32(cboMulta.SelectedValue);
                    else
                        pf.IdContaContabilMulta = null;

                    if (!String.IsNullOrEmpty(cboTransferenciaImpostos.Text))
                        pf.IdContaContabilTransferenciaImposto = Convert.ToInt32(cboTransferenciaImpostos.SelectedValue);
                    else
                        pf.IdContaContabilTransferenciaImposto = null;

                    pf.Baixa = chkBaixa.Checked;

                    if (pf.IdPerfilFornecedor == 0)
                    {
                        dal.Insert(pf);
                    }
                    else
                    {
                        dal.Update(pf);
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
                    int id = pf.IdPerfilFornecedor;
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
    }
}