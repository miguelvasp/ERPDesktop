using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCodigoTributacaoCad : RibbonForm
    {
        public CodigoTributacaoDAL dal = new CodigoTributacaoDAL();
        CodigoTributacao ct = new CodigoTributacao();

        public frmCodigoTributacaoCad(CodigoTributacao pCT)
        {
            ct = pCT;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCodigoTributacaoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarTipoImposto();
            CarregarValorFiscal();

            if (ct.IdCodigoTributacao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmCodigoTributacaoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = ct.IdCodigoTributacao.ToString();
            txtCodigo.Text = ct.Codigo;
            txtDescricao.Text = ct.Descricao;
         
            if (ct.ValorFiscal != null)
                cboValorFiscal.SelectedValue = ct.ValorFiscal.ToString();
            txtCodigoEntrada.Text = ct.CodigoEntrada;
            txtCodigoSped.Text = ct.CodigoSped;
            txtCodigoSaida.Text = ct.CodigoSaida;
            cboTipoImposto.SelectedValue = ct.TipoImposto == null ? 0 : ct.TipoImposto;

            if (ct.De != null && ct.De != DateTime.MinValue)
                dtpDe.Value = ct.De.Value;

            if (ct.Ate != null && ct.Ate != DateTime.MinValue)
                dtpAte.Value = ct.Ate.Value;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
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

        private void CarregarValorFiscal()
        {
            List<DropList> lista = Util.EnumERP.CarregarValorFiscal();

            cboValorFiscal.DisplayMember = "Text";
            cboValorFiscal.ValueMember = "Value";
            cboValorFiscal.DataSource = lista;
            cboValorFiscal.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ct = new CodigoTributacao();
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

                    ct.Codigo = txtCodigo.Text;
                    ct.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboTipoImposto.Text))
                        ct.TipoImposto = Convert.ToInt32(cboTipoImposto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboValorFiscal.Text))
                        ct.ValorFiscal = Convert.ToInt32(cboValorFiscal.SelectedValue);
                    ct.CodigoSped = txtCodigoSped.Text;
                    ct.CodigoEntrada = txtCodigoEntrada.Text;
                    ct.CodigoSaida = txtCodigoSaida.Text;

                    if (dtpDe.Checked)
                        ct.De = DateTime.Parse(dtpDe.Value.ToString("dd/MM/yyyy"));
                    if (dtpAte.Checked)
                        ct.Ate = DateTime.Parse(dtpAte.Value.ToString("dd/MM/yyyy"));

                    if (!String.IsNullOrEmpty(cboTipoImposto.Text)) ct.TipoImposto = Convert.ToInt32(cboTipoImposto.SelectedValue);

                    if (ct.IdCodigoTributacao == 0)
                    {
                        dal.Insert(ct);
                    }
                    else
                    {
                        dal.Update(ct);
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
                    int id = ct.IdCodigoTributacao;
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
