using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPeriodoLiquidacaoImpostoVencCad : RibbonForm
    {
        public PeriodoLiquidacaoImpostoVencDAL dal;
        PeriodoLiquidacaoImpostoVenc pli = new PeriodoLiquidacaoImpostoVenc();

        public frmPeriodoLiquidacaoImpostoVencCad(PeriodoLiquidacaoImpostoVenc pPLI)
        {
            pli = pPLI;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmPeriodoLiquidacaoImpostoVencCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarPeriodoLiquidacaoImposto();

            if (pli.IdPeriodoLiquidacaoImposto > 0)
            {
                cboPeriodoLiquidacaoImposto.SelectedValue = pli.IdPeriodoLiquidacaoImposto;
            }

            if (pli.IdPeriodoLiquidacaoImpostoVenc == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmPeriodoLiquidacaoImpostoVencCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = pli.IdPeriodoLiquidacaoImpostoVenc.ToString();
            if (pli.IdPeriodoLiquidacaoImposto != null)
                cboPeriodoLiquidacaoImposto.SelectedValue = pli.IdPeriodoLiquidacaoImposto;

            if (pli.De != null && pli.De != DateTime.MinValue)
                dtpDe.Value = pli.De.Value;

            if (pli.Ate != null && pli.Ate != DateTime.MinValue)
                dtpAte.Value = pli.Ate.Value;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarPeriodoLiquidacaoImposto()
        {
            cboPeriodoLiquidacaoImposto.DataSource = new PeriodoLiquidacaoImpostoDAL().GetCombo();
            cboPeriodoLiquidacaoImposto.DisplayMember = "Text";
            cboPeriodoLiquidacaoImposto.ValueMember = "iValue";
            cboPeriodoLiquidacaoImposto.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            pli = new PeriodoLiquidacaoImpostoVenc();
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

                    if (!String.IsNullOrEmpty(cboPeriodoLiquidacaoImposto.Text))
                        pli.IdPeriodoLiquidacaoImposto = Convert.ToInt32(cboPeriodoLiquidacaoImposto.SelectedValue);

                    pli.De = DateTime.Parse(dtpDe.Value.ToString("dd/MM/yyyy"));
                    pli.Ate = DateTime.Parse(dtpAte.Value.ToString("dd/MM/yyyy"));

                    if (pli.IdPeriodoLiquidacaoImpostoVenc == 0)
                    {
                        dal.Insert(pli);
                    }
                    else
                    {
                        dal.Update(pli);
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
                    int id = pli.IdPeriodoLiquidacaoImpostoVenc;
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
