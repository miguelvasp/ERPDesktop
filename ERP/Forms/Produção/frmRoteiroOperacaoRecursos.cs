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
    public partial class frmRoteiroOperacaoRecursos : RibbonForm
    {
        public RoteiroOperacaoRecursosDAL dal = new RoteiroOperacaoRecursosDAL();
        RoteiroOperacaoRecursos ci = new RoteiroOperacaoRecursos();

        public frmRoteiroOperacaoRecursos(RoteiroOperacaoRecursos pci)
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
            cboTipo.SelectedValue = ci.Tipo == null ? 0 : ci.Tipo;
            cboRecurso.SelectedValue = ci.IdRecurso == null ? 0 : ci.IdRecurso;
            cboCapacidadeRecurso.SelectedValue = ci.IdCapacidadeRecurso == null ? 0 : ci.IdCapacidadeRecurso;
            cboGrupoRecurso.SelectedValue = ci.IdGrupoRecurso == null ? 0 : ci.IdGrupoRecurso;
            cboRecursoAvaliacao.SelectedValue = ci.IdRecursoAvaliacaoCusto == null ? 0 : ci.IdRecursoAvaliacaoCusto;
            chkPlanejamentoOperacao.Checked = ci.PlanejamentoOperacao;
            chkPlanejamentoTrabalho.Checked = ci.PlanejamentoTrabalho;
        }

        private void CarregaCombo()
        {
            cboRecurso.DataSource = new RecursosDAL().GetCombo();
            cboRecurso.DisplayMember = "Text";
            cboRecurso.ValueMember = "iValue";
            cboRecurso.SelectedIndex = -1;

            cboCapacidadeRecurso.DataSource = new CapacidadeRecursosDAL().GetCombo();
            cboCapacidadeRecurso.DisplayMember = "Text";
            cboCapacidadeRecurso.ValueMember = "iValue";
            cboCapacidadeRecurso.SelectedIndex = -1;

            cboGrupoRecurso.DataSource = new GrupoRecursosDAL().GetCombo();
            cboGrupoRecurso.DisplayMember = "Text";
            cboGrupoRecurso.ValueMember = "iValue";
            cboGrupoRecurso.SelectedIndex = -1;

            cboRecursoAvaliacao.DataSource = new RecursosDAL().GetCombo();
            cboRecursoAvaliacao.DisplayMember = "Text";
            cboRecursoAvaliacao.ValueMember = "iValue";
            cboRecursoAvaliacao.SelectedIndex = -1;

            List<ComboItem> tipos = new List<ComboItem>();
            tipos.Add(new ComboItem() { iValue = 1, Text = "Recurso" });
            tipos.Add(new ComboItem() { iValue = 2, Text = "Capacidade" });
            tipos.Add(new ComboItem() { iValue = 3, Text = "Grupo deRecurso" });
            tipos.Add(new ComboItem() { iValue = 4, Text = "Recurso" });
            cboTipo.DataSource = tipos;
            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "iValue";
            cboTipo.SelectedIndex = -1;
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {

            if(Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    ci.Tipo = null;
                    ci.IdRecurso = null;
                    ci.IdCapacidadeRecurso = null;
                    ci.IdGrupoRecurso = null;
                    ci.IdRecursoAvaliacaoCusto = null;

                    if (!String.IsNullOrEmpty(cboTipo.Text)) ci.Tipo = Convert.ToInt32(cboTipo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboRecurso.Text)) ci.IdRecurso = Convert.ToInt32(cboRecurso.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCapacidadeRecurso.Text)) ci.IdCapacidadeRecurso = Convert.ToInt32(cboCapacidadeRecurso.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoRecurso.Text)) ci.IdGrupoRecurso = Convert.ToInt32(cboGrupoRecurso.SelectedValue);
                    if (!String.IsNullOrEmpty(cboRecursoAvaliacao.Text)) ci.IdRecursoAvaliacaoCusto = Convert.ToInt32(cboRecursoAvaliacao.SelectedValue);
                    ci.PlanejamentoOperacao = chkPlanejamentoOperacao.Checked;
                    ci.PlanejamentoTrabalho = chkPlanejamentoTrabalho.Checked;

                    if (ci.IdRoteiroOperacaoRecurso == 0)
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
                dal.Delete(ci.IdRoteiroOperacaoRecurso);
                dal.Save();
                this.Close();
            }
        }
    }
}
