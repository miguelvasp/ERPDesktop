using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoPrecoDescontoCad : RibbonForm
    {
        public GrupoPrecoDescontoDAL dal;
        GrupoPrecoDesconto gpd = new GrupoPrecoDesconto();

        public frmGrupoPrecoDescontoCad(GrupoPrecoDesconto pGPD)
        {
            gpd = pGPD;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmGrupoPrecoDescontoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarTipoGrupoPrecoDesconto();
            CarregarModuloGrupoPrecoDesconto();

            if (gpd.IdGrupoPrecoDesconto == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmGrupoPrecoDescontoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = gpd.IdGrupoPrecoDesconto.ToString();
            txtNome.Text = gpd.Nome;
            txtDescricao.Text = gpd.Descricao;
            if (gpd.Tipo != null)
                cboTipo.SelectedValue = gpd.Tipo.ToString();

            if (gpd.Modulo != null)
                cboModulo.SelectedValue = gpd.Modulo.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarTipoGrupoPrecoDesconto()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipoGrupoPrecoDesconto();

            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "Value";
            cboTipo.DataSource = lista;
            cboTipo.SelectedIndex = -1;
        }

        private void CarregarModuloGrupoPrecoDesconto()
        {
            List<DropList> lista = Util.EnumERP.CarregarModuloGrupoPrecoDesconto();

            cboModulo.DisplayMember = "Text";
            cboModulo.ValueMember = "Value";
            cboModulo.DataSource = lista;
            cboModulo.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            gpd = new GrupoPrecoDesconto();
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

                    gpd.Nome = txtNome.Text;
                    gpd.Descricao = txtDescricao.Text;

                    if (!String.IsNullOrEmpty(cboTipo.Text))
                        gpd.Tipo = Convert.ToInt32(cboTipo.SelectedValue);

                    if (!String.IsNullOrEmpty(cboModulo.Text))
                        gpd.Modulo = Convert.ToInt32(cboModulo.SelectedValue);

                    if (gpd.IdGrupoPrecoDesconto == 0)
                    {
                        dal.Insert(gpd);
                    }
                    else
                    {
                        dal.Update(gpd);
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
                    int id = gpd.IdGrupoPrecoDesconto;
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