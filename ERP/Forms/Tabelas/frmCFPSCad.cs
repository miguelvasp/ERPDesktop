using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCFPSCad : RibbonForm
    {
        public CFPSDAL dal;
        CFPS cfps = new CFPS();

        public frmCFPSCad(CFPS pCFPS)
        {
            cfps = pCFPS;
            InitializeComponent();
            CarregarSemanaMes();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }


        private void frmCFPSCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (cfps.IdCFPS == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = cfps.IdCFPS.ToString();
            txtCFPS.Text = cfps.CFPSCod;
            txtDescricao.Text = cfps.Descricao;
            cboTipoTransacao.SelectedValue = cfps.TipoTransacao.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarSemanaMes()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipodeTransacao();

            cboTipoTransacao.DisplayMember = "Text";
            cboTipoTransacao.ValueMember = "Value";
            cboTipoTransacao.DataSource = lista;
            cboTipoTransacao.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cfps = new CFPS();
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

                    cfps.CFPSCod = txtCFPS.Text;
                    cfps.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboTipoTransacao.Text))
                        cfps.TipoTransacao = Convert.ToInt32(cboTipoTransacao.SelectedValue);

                    if (cfps.IdCFPS == 0)
                    {
                        dal.Insert(cfps);
                    }
                    else
                    {
                        dal.Update(cfps);
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
                    int id = cfps.IdCFPS;
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
