using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Auxiliares
{
    public partial class frmVariantesGrupoItemAux : RibbonForm
    {
        public VariantesGrupoItemDAL dal = new VariantesGrupoItemDAL();
        VariantesGrupoItem vi = new VariantesGrupoItem();


        public frmVariantesGrupoItemAux(VariantesGrupoItem v)
        {
            vi = v;
            InitializeComponent(); 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmDiasPagamentoCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            if (vi.IdVariantesGrupoItem == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaCombos()
        {
            cboVariantesConfig.DataSource = new VariantesConfigDAL().Get();
            cboVariantesConfig.ValueMember = "IdVariantesConfig";
            cboVariantesConfig.DisplayMember = "Descricao";
            cboVariantesConfig.SelectedIndex = -1;

            cboVariantesTamanho.DataSource = new VariantesTamanhoDAL().Get();
            cboVariantesTamanho.ValueMember = "IdVariantesTamanho";
            cboVariantesTamanho.DisplayMember = "Descricao";
            cboVariantesTamanho.SelectedIndex = -1;

            cboVariantesCor.DataSource = new VariantesCorDAL().Get();
            cboVariantesCor.ValueMember = "IdVariantesCor";
            cboVariantesCor.DisplayMember = "Descricao";
            cboVariantesCor.SelectedIndex = -1;

            cboVariantesEstilo.DataSource = new VariantesEstiloDAL().Get();
            cboVariantesEstilo.ValueMember = "IdVariantesEstilo";
            cboVariantesEstilo.DisplayMember = "Descricao";
            cboVariantesEstilo.SelectedIndex = -1;
        }

        private void frmDiasPagamentoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            if (vi.IdConfiguracao != null) cboVariantesConfig.SelectedValue = Convert.ToInt32(vi.IdConfiguracao);
            if (vi.IdCor != null) cboVariantesCor.SelectedValue = Convert.ToInt32(vi.IdCor);
            if (vi.IdEstilo != null) cboVariantesEstilo.SelectedValue = Convert.ToInt32(vi.IdEstilo);
            if (vi.IdTamanho != null) cboVariantesTamanho.SelectedValue = Convert.ToInt32(vi.IdTamanho);

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            vi = new VariantesGrupoItem(); 
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
                    vi.IdConfiguracao = null;
                    vi.IdCor = null;
                    vi.IdEstilo = null;
                    vi.IdTamanho = null;

                    if (!String.IsNullOrEmpty(cboVariantesConfig.Text)) vi.IdConfiguracao = Convert.ToInt32(cboVariantesConfig.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVariantesCor.Text)) vi.IdCor = Convert.ToInt32(cboVariantesCor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVariantesEstilo.Text)) vi.IdEstilo = Convert.ToInt32(cboVariantesEstilo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVariantesTamanho.Text)) vi.IdTamanho = Convert.ToInt32(cboVariantesTamanho.SelectedValue);
                    //verifica se o conjunto já existe no banco de dados
                    if (dal.VerificaDuplicidade(vi.IdVariantesGrupo, vi.IdConfiguracao, vi.IdCor, vi.IdEstilo, vi.IdTamanho))
                    {
                        Util.Aplicacao.ShowMessage("A configuração informada já existe no banco de dados.");
                        return;
                    }

                    if (vi.IdVariantesGrupoItem == 0)
                    {
                        //
                        dal.Insert(vi);
                    }
                    else
                    {
                        dal.Update(vi);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close(); 
                } 
                catch(Exception ex)
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
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    int id = vi.IdVariantesGrupoItem;

                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
        }

         
    }
}
