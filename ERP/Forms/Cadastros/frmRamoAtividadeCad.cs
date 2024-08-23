using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Models;
using ERP.DAL;

namespace ERP
{
    public partial class frmRamoAtividadeCad : RibbonForm
    {
        RamoAtividade ra = new RamoAtividade();
        RamoAtividadeDAL dal = new RamoAtividadeDAL(new DB_ERPContext());
        public frmRamoAtividadeCad(RamoAtividade RamoAtividade)
        {
            ra = RamoAtividade;
            InitializeComponent();
        }

        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmRamoAtividadeCad_Load(object sender, EventArgs e)
        {
            if (ra.IdRamoAtividade == 0)
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
            txtNome.Text = ra.Nome;
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ra = new RamoAtividade();
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
                ra.Nome = txtNome.Text;

                if (ra.IdRamoAtividade == 0)
                {
                    dal.Insert(ra);
                }
                else
                {
                    dal.Update(ra);
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
                    int id = ra.IdRamoAtividade;
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
