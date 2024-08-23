using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoRastreamentoCad : RibbonForm
    {
        public GrupoRastreamentoDAL dal;
        GrupoRastreamento gr = new GrupoRastreamento();

        public frmGrupoRastreamentoCad(GrupoRastreamento pGR)
        {
            gr = pGR;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmGrupoRastreamentoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (gr.IdGrupoRastreamento == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmGrupoRastreamentoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = gr.IdGrupoRastreamento.ToString();
            txtNome.Text = gr.Nome;
            txtDescricao.Text = gr.Descricao;
            chkObrigatorio.Checked = gr.Obrigatorio;

            chkNumeroLoteAtivo.Checked = gr.NumeroLoteAtivo;
            chkNumeroLoteSaida.Checked = gr.NumeroLoteSaida;
            chkNumeroLoteEntrada.Checked = gr.NumeroLoteEntrada;

            chkNumeroSerieAtivo.Checked = gr.NumeroSerieEntrada;
            chkNumeroSerieSaida.Checked = gr.NumeroSerieSaida;
            chkNumeroSerieEntrada.Checked = gr.NumeroSerieEntrada;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            gr = new GrupoRastreamento();
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

                    gr.Nome = txtNome.Text;
                    gr.Descricao = txtDescricao.Text;

                    gr.Obrigatorio = chkObrigatorio.Checked;

                    gr.NumeroLoteAtivo = chkNumeroLoteAtivo.Checked;
                    gr.NumeroLoteSaida = chkNumeroLoteSaida.Checked;
                    gr.NumeroLoteEntrada = chkNumeroLoteEntrada.Checked;

                    gr.NumeroSerieAtivo = chkNumeroSerieAtivo.Checked;
                    gr.NumeroSerieSaida = chkNumeroSerieSaida.Checked;
                    gr.NumeroSerieEntrada = chkNumeroSerieEntrada.Checked;

                    if (gr.IdGrupoRastreamento == 0)
                    {
                        dal.Insert(gr);
                    }
                    else
                    {
                        dal.Update(gr);
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
                    int id = gr.IdGrupoRastreamento;
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