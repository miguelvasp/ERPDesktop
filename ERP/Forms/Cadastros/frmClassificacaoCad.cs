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
using ERP.DAL.Fiscal;

namespace ERP
{
    public partial class frmClassificacaoCad : RibbonForm
    {
        public ClassificacaoFiscalDAL dal;
        ClassificacaoFiscal cl = new ClassificacaoFiscal();

        public frmClassificacaoCad(ClassificacaoFiscal pcl)
        {
            cl = pcl;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmClassificacaoCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();

            if (cl.IdNCM == 0)
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
            lbCodigo.Text = cl.IdNCM.ToString();
            txtNCM.Text = cl.NCM;
            txtDescricao.Text = cl.Descricao;
            txtIPI.Text = cl.IPI.ToString();
            cboCest.SelectedValue = cl.IdCest == null ? 0 : cl.IdCest; 
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void CarregaCombos() {
            CarregaComboCest();
        }

        private void CarregaComboCest()
        {
            cboCest.DataSource = new CESTDAL().GetCombo();
            cboCest.ValueMember = "iValue";
            cboCest.DisplayMember = "Text";
            cboCest.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cl = new ClassificacaoFiscal();
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
                cl.IPI = Convert.ToDecimal(txtIPI.Text);
                cl.NCM = txtNCM.Text.Replace(",", ".").Replace(".", "");
                cl.Descricao = txtDescricao.Text;
                if(!String.IsNullOrEmpty(cboCest.Text))
                {
                    cl.IdCest = Convert.ToInt32(cboCest.SelectedValue);
                }
                else
                {
                    cl.IdCest = null;
                }
                

                if (cl.IdNCM == 0)
                {
                    dal.Insert(cl);
                }
                else
                {
                    dal.Update(cl);
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
                    int id = cl.IdNCM;
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
