using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoArmazenamentoCad : RibbonForm
    {
        public GrupoArmazenamentoDAL dal;
        GrupoArmazenamento ga = new GrupoArmazenamento();

        public frmGrupoArmazenamentoCad(GrupoArmazenamento pGA)
        {
            ga = pGA;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmGrupoArmazenamentoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (ga.IdGrupoArmazenamento == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmGrupoArmazenamentoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = ga.IdGrupoArmazenamento.ToString();
            txtNome.Text = ga.Nome;
            txtDescricao.Text = ga.Descricao;
            chkObrigatorio.Checked = ga.Obrigatorio;

            chkSiteAtivo.Checked = ga.SiteAtivo;
            chkSiteSaida.Checked = ga.SiteSaida;
            chkSiteEntrada.Checked = ga.SiteEntrada;

            chkDepositoAtivo.Checked = ga.DepositoAtivo;
            chkDepositoSaida.Checked = ga.DepositoSaida;
            chkDepositoEntrada.Checked = ga.DepositoEntrada;

            chkLocalizacaoAtivo.Checked = ga.LocalizacaoAtivo;
            chkLocalizacaoSaida.Checked = ga.LocalizacaoSaida;
            chkLocalizacaoEntrada.Checked = ga.LocalizacaoEntrada;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ga = new GrupoArmazenamento();
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

                    ga.Nome = txtNome.Text;
                    ga.Descricao = txtDescricao.Text;

                    ga.Obrigatorio = chkObrigatorio.Checked;

                    ga.SiteAtivo = chkSiteAtivo.Checked;
                    ga.SiteSaida = chkSiteSaida.Checked;
                    ga.SiteEntrada = chkSiteEntrada.Checked;

                    ga.DepositoAtivo = chkDepositoAtivo.Checked;
                    ga.DepositoSaida = chkDepositoSaida.Checked;
                    ga.DepositoEntrada = chkDepositoEntrada.Checked;

                    ga.LocalizacaoAtivo = chkLocalizacaoAtivo.Checked;
                    ga.LocalizacaoSaida = chkLocalizacaoSaida.Checked;
                    ga.LocalizacaoEntrada = chkLocalizacaoEntrada.Checked;

                    if (ga.IdGrupoArmazenamento == 0)
                    {
                        dal.Insert(ga);
                    }
                    else
                    {
                        dal.Update(ga);
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
                    int id = ga.IdGrupoArmazenamento;
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