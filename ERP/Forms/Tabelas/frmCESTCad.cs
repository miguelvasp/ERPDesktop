using System;
using System.Windows.Forms;
using ERP.Models;
using ERP.DAL.Fiscal;

namespace ERP
{
    public partial class frmCESTCad : RibbonForm
    {
        public CESTDAL dal;
        CEST objCest = new CEST();

        public frmCESTCad(CEST pcl)
        {
            objCest = pcl;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCESTCad_Load(object sender, EventArgs e)
        {
            if (objCest.IdCest == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaDados()
        {
            lbCodigo.Text = objCest.IdCest.ToString();
            txtCEST.Text = objCest.Cest;
            txtDescricao.Text = objCest.Descricao;
            txtNCM.Text = objCest.NCM;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }
        
        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            objCest = new CEST();
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

                objCest.Cest = txtCEST.Text;
                objCest.Descricao = txtDescricao.Text;
                objCest.NCM = txtNCM.Text;

                if (objCest.IdCest == 0)
                {
                    dal.Insert(objCest);
                }
                else
                {
                    dal.Update(objCest);
                }

                dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
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
                    int id = objCest.IdCest;
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
