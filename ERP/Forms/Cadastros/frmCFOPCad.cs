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

namespace ERP.Cadastros
{
    public partial class frmCFOPCad : RibbonForm
    {
        public CFOPDAL dal;
        CFOP cfop = new CFOP();

        public frmCFOPCad(CFOP pCFOP)
        {
            cfop = pCFOP;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCFOPCad_Load(object sender, EventArgs e)
        {
            CarregarLocalizacao();
            CarregaTextoPadrao();
            CarregarDirecao();
            CarregarFinalidade();

            if (cfop.IdCFOP == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void frmCFOPCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void CarregaDados()
        {
            lbCodigo.Text = cfop.IdCFOP.ToString();
            txtCodigoCFOP.Text = cfop.CFOPCOD;
            txtDescricao.Text = cfop.Descricao;
            if (cfop.Localizacao != null)
                cboLocalizacao.SelectedValue = cfop.Localizacao.ToString();

            if (cfop.Direcao != null)
                cboDirecao.SelectedValue = cfop.Direcao.ToString();

            if (cfop.Finalidade != null)
                cboFinalidade.SelectedValue = cfop.Finalidade.ToString();

            if (cfop.IdTextoPadrao != null)
                cboTextoPadrao.SelectedValue = cfop.IdTextoPadrao;

            if (cfop.ConsiderarCIAP != null)
                chkConsiderarCIAP.Checked = cfop.ConsiderarCIAP.Value;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void CarregarLocalizacao()
        {
            List<DropList> lista = Util.EnumERP.CarregarLocalizacao();

            cboLocalizacao.DisplayMember = "Text";
            cboLocalizacao.ValueMember = "Value";
            cboLocalizacao.DataSource = lista;
            cboLocalizacao.SelectedIndex = -1;
        }

        private void CarregarDirecao()
        {
            List<DropList> lista = Util.EnumERP.CarregarDirecao();

            cboDirecao.DisplayMember = "Text";
            cboDirecao.ValueMember = "Value";
            cboDirecao.DataSource = lista;
            cboDirecao.SelectedIndex = -1;
        }

        private void CarregarFinalidade()
        {
            List<DropList> lista = Util.EnumERP.CarregarFinalidade();

            cboFinalidade.DisplayMember = "Text";
            cboFinalidade.ValueMember = "Value";
            cboFinalidade.DataSource = lista;
            cboFinalidade.SelectedIndex = -1;
        }

        protected void CarregaTextoPadrao()
        {
            cboTextoPadrao.DataSource = new TextoPadraoDAL().GetCombo();
            cboTextoPadrao.DisplayMember = "Text";
            cboTextoPadrao.ValueMember = "iValue";
            cboTextoPadrao.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cfop = new CFOP();
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
                    cfop.CFOPCOD = txtCodigoCFOP.Text;
                    cfop.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboLocalizacao.Text))
                        cfop.Localizacao = Convert.ToInt32(cboLocalizacao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboDirecao.Text))
                        cfop.Direcao = Convert.ToInt32(cboDirecao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboFinalidade.Text))
                        cfop.Finalidade = Convert.ToInt32(cboFinalidade.SelectedValue);

                    if (!String.IsNullOrEmpty(cboTextoPadrao.Text))
                        cfop.IdTextoPadrao = Convert.ToInt32(cboTextoPadrao.SelectedValue);

                    cfop.ConsiderarCIAP = chkConsiderarCIAP.Checked;

                    if (cfop.IdCFOP == 0)
                    {
                        dal.Insert(cfop);
                    }
                    else
                    {
                        dal.Update(cfop);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
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
                int id = cfop.IdCFOP;
                dal.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }
    }
}
