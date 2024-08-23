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
    public partial class frmGrupoRecursosLinhas : RibbonForm
    {
        public GrupoRecursoLinhaDAL dal = new GrupoRecursoLinhaDAL();
        GrupoRecursoLinha ci = new GrupoRecursoLinha();

        public frmGrupoRecursosLinhas(GrupoRecursoLinha pci)
        {
            ci = pci;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmConfGrupoImpostoRetidoCad_Load(object sender, EventArgs e)
        {
            CarregaCombo();
            CarregaDados();
        }

        private void CarregaDados()
        {
            cboRecurso.SelectedValue = ci.IdRecurso == null ? 0 : ci.IdRecurso;
            txtDescricao.Text = ci.Descricao;
            txtAte.Text = ci.Ate.ToString();
            cboCalendario.SelectedValue = ci.IdCalendario == null ? 0 : ci.IdCalendario;
            cboDeposito.SelectedValue = ci.IdDeposito == null ? 0 : ci.IdDeposito;

        }

        private void CarregaCombo()
        {
            cboRecurso.DataSource = new RecursosDAL().GetCombo();
            cboRecurso.DisplayMember = "Text";
            cboRecurso.ValueMember = "iValue";
            cboRecurso.SelectedIndex = -1;

            cboDeposito.DataSource = new DepositoDAL().GetCombo();
            cboDeposito.DisplayMember = "Text";
            cboDeposito.ValueMember = "iValue";
            cboDeposito.SelectedIndex = -1;

            cboCalendario.DataSource = new CalendarioDAL().GetCombo();
            cboCalendario.DisplayMember = "Text";
            cboCalendario.ValueMember = "iValue";
            cboCalendario.SelectedIndex = -1;
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            if(Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    ci.IdRecurso = null;
                    ci.IdCalendario = null;
                    ci.IdDeposito = null;
                    ci.Ate = null;

                    ci.Descricao = txtDescricao.Text;
                    ci.Ate = Util.Validacao.IsDateTime(txtAte.Text);
                    if (!String.IsNullOrEmpty(cboRecurso.Text)) ci.IdRecurso = Convert.ToInt32(cboRecurso.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCalendario.Text)) ci.IdCalendario = Convert.ToInt32(cboCalendario.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDeposito.Text)) ci.IdDeposito = Convert.ToInt32(cboDeposito.SelectedValue);

                    if (ci.IdGrupoRecursoLinha == 0)
                    {
                        dal.Insert(ci);
                    }
                    else
                    {
                        dal.Update(ci);
                    }
                    dal.Save();
                    this.Close();
                }
                catch
                {
                    Util.Aplicacao.ShowMessage("Verifique os dados informados");
                }
            } 
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja remover a configuração?") == System.Windows.Forms.DialogResult.Yes)
            {
                dal.Delete(ci.IdGrupoRecursoLinha);
                dal.Save();
                this.Close();
            }
        }
    }
}
