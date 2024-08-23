using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPerfilProducaoCad : RibbonForm
    {
        public PerfilProducaoDAL dal;
        PerfilProducao pp = new PerfilProducao();

        public frmPerfilProducaoCad(PerfilProducao pPP)
        {
            pp = pPP;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmPerfilProducaoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarListaSeparacao();
            CarregarContraPartidaListaSeparacao();
            CarregarRelatorioConclusao();
            CarregarContraPartidaRelatorioConclusao();
            CarregarSaida();
            CarregarContraPartidaSaida();
            CarregarRecebimento();
            CarregarContraPartidaRecebimento();
            CarregarSaidaWIP();
            CarregarContaWIP();

            if (pp.IdPerfilProducao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmPerfilProducaoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = pp.IdPerfilProducao.ToString();
            txtNome.Text = pp.Nome;
            if (pp.IdContabil_ListaSeparacao != null)
                cboListaSeparacao.SelectedValue = pp.IdContabil_ListaSeparacao;
            if (pp.IdContabil_ContapartidaListaSeparacao != null)
                cboContraPartidaListaSeparacao.SelectedValue = pp.IdContabil_ContapartidaListaSeparacao;
            if (pp.IdContabil_RelatorioConclusao != null)
                cboRelatorioConclusao.SelectedValue = pp.IdContabil_RelatorioConclusao;
            if (pp.IdContabil_ContraPartidaRelatorioConclusao != null)
                cboContraPartidaRelatorioConclusao.SelectedValue = pp.IdContabil_ContraPartidaRelatorioConclusao;
            if (pp.IdContabil_Saida != null)
                cboSaida.SelectedValue = pp.IdContabil_Saida;
            if (pp.IdContabil_ContrapartidaSaida != null)
                cboContraPartidaSaida.SelectedValue = pp.IdContabil_ContrapartidaSaida;
            if (pp.IdContabil_Recebimento != null)
                cboRecebimento.SelectedValue = pp.IdContabil_Recebimento;
            if (pp.IdContabil_ContrapartidaRecebimento != null)
                cboContraPartidaRecebimento.SelectedValue = pp.IdContabil_ContrapartidaRecebimento;
            if (pp.IdContabil_SaidaWIP != null)
                cboSaidaWIP.SelectedValue = pp.IdContabil_SaidaWIP;
            if (pp.IdContabil_ContaWIP != null)
                cboContaWIP.SelectedValue = pp.IdContabil_ContaWIP;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarListaSeparacao()
        {
            cboListaSeparacao.DataSource = new ContaContabilDAL().GetCombo();
            cboListaSeparacao.DisplayMember = "Text";
            cboListaSeparacao.ValueMember = "iValue";
            cboListaSeparacao.SelectedIndex = -1;
        }

        private void CarregarContraPartidaListaSeparacao()
        {
            cboContraPartidaListaSeparacao.DataSource = new ContaContabilDAL().GetCombo();
            cboContraPartidaListaSeparacao.DisplayMember = "Text";
            cboContraPartidaListaSeparacao.ValueMember = "iValue";
            cboContraPartidaListaSeparacao.SelectedIndex = -1;
        }

        private void CarregarRelatorioConclusao()
        {
            cboRelatorioConclusao.DataSource = new ContaContabilDAL().GetCombo();
            cboRelatorioConclusao.DisplayMember = "Text";
            cboRelatorioConclusao.ValueMember = "iValue";
            cboRelatorioConclusao.SelectedIndex = -1;
        }

        private void CarregarContraPartidaRelatorioConclusao()
        {
            cboContraPartidaRelatorioConclusao.DataSource = new ContaContabilDAL().GetCombo();
            cboContraPartidaRelatorioConclusao.DisplayMember = "Text";
            cboContraPartidaRelatorioConclusao.ValueMember = "iValue";
            cboContraPartidaRelatorioConclusao.SelectedIndex = -1;
        }

        private void CarregarSaida()
        {
            cboSaida.DataSource = new ContaContabilDAL().GetCombo();
            cboSaida.DisplayMember = "Text";
            cboSaida.ValueMember = "iValue";
            cboSaida.SelectedIndex = -1;
        }

        private void CarregarContraPartidaSaida()
        {
            cboContraPartidaSaida.DataSource = new ContaContabilDAL().GetCombo();
            cboContraPartidaSaida.DisplayMember = "Text";
            cboContraPartidaSaida.ValueMember = "iValue";
            cboContraPartidaSaida.SelectedIndex = -1;
        }

        private void CarregarRecebimento()
        {
            cboRecebimento.DataSource = new ContaContabilDAL().GetCombo();
            cboRecebimento.DisplayMember = "Text";
            cboRecebimento.ValueMember = "iValue";
            cboRecebimento.SelectedIndex = -1;
        }

        private void CarregarContraPartidaRecebimento()
        {
            cboContraPartidaRecebimento.DataSource = new ContaContabilDAL().GetCombo();
            cboContraPartidaRecebimento.DisplayMember = "Text";
            cboContraPartidaRecebimento.ValueMember = "iValue";
            cboContraPartidaRecebimento.SelectedIndex = -1;
        }

        private void CarregarSaidaWIP()
        {
            cboSaidaWIP.DataSource = new ContaContabilDAL().GetCombo();
            cboSaidaWIP.DisplayMember = "Text";
            cboSaidaWIP.ValueMember = "iValue";
            cboSaidaWIP.SelectedIndex = -1;
        }

        private void CarregarContaWIP()
        {
            cboContaWIP.DataSource = new ContaContabilDAL().GetCombo();
            cboContaWIP.DisplayMember = "Text";
            cboContaWIP.ValueMember = "iValue";
            cboContaWIP.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            pp = new PerfilProducao();
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

                    pp.Nome = txtNome.Text;
                    if (!String.IsNullOrEmpty(cboListaSeparacao.Text))
                        pp.IdContabil_ListaSeparacao = Convert.ToInt32(cboListaSeparacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContraPartidaListaSeparacao.Text))
                        pp.IdContabil_ContapartidaListaSeparacao = Convert.ToInt32(cboContraPartidaListaSeparacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboRelatorioConclusao.Text))
                        pp.IdContabil_RelatorioConclusao = Convert.ToInt32(cboRelatorioConclusao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContraPartidaRelatorioConclusao.Text))
                        pp.IdContabil_ContraPartidaRelatorioConclusao = Convert.ToInt32(cboContraPartidaRelatorioConclusao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboSaida.Text))
                        pp.IdContabil_Saida = Convert.ToInt32(cboSaida.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContraPartidaSaida.Text))
                        pp.IdContabil_ContrapartidaSaida = Convert.ToInt32(cboContraPartidaSaida.SelectedValue);
                    if (!String.IsNullOrEmpty(cboRecebimento.Text))
                        pp.IdContabil_Recebimento = Convert.ToInt32(cboRecebimento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContraPartidaRecebimento.Text))
                        pp.IdContabil_ContrapartidaRecebimento = Convert.ToInt32(cboContraPartidaRecebimento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboSaidaWIP.Text))
                        pp.IdContabil_SaidaWIP = Convert.ToInt32(cboSaidaWIP.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaWIP.Text))
                        pp.IdContabil_ContaWIP = Convert.ToInt32(cboContaWIP.SelectedValue);

                    if (pp.IdPerfilProducao == 0)
                    {
                        dal.Insert(pp);
                    }
                    else
                    {
                        dal.Update(pp);
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
                    int id = pp.IdPerfilProducao;
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
