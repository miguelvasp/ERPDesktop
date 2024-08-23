using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCapacidadeRecursosLinhas : RibbonForm
    {
        public CapacidadeRecursosLinhasDAL dal = new CapacidadeRecursosLinhasDAL();
        CapacidadeRecursosLinhas ci = new CapacidadeRecursosLinhas();

        public frmCapacidadeRecursosLinhas(CapacidadeRecursosLinhas pci)
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
            txtDataEfetivacao.Text = ci.DataEfetivacao == null ? "" : ci.DataEfetivacao.ToString();
            txtDataVencimento.Text = ci.DataVencimento == null ? "" : ci.DataVencimento.ToString();
            txtPrioridade.Text = ci.Prioridade == null ? "" : ci.Prioridade.ToString();
            txtNivel.Text = ci.Nivel == null ? "" : ci.Nivel.ToString();
        }

        private void CarregaCombo()
        {
            cboRecurso.DataSource = new RecursosDAL().GetCombo();
            cboRecurso.DisplayMember = "Text";
            cboRecurso.ValueMember = "iValue";
            cboRecurso.SelectedIndex = -1;
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            if(Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    ci.IdRecurso = Convert.ToInt32(cboRecurso.SelectedValue);
                    ci.DataEfetivacao = Convert.ToDateTime(txtDataEfetivacao.Text);
                    ci.DataVencimento = Convert.ToDateTime(txtDataVencimento.Text);
                    ci.Prioridade = Convert.ToInt32(txtPrioridade.Text);
                    ci.Nivel = Convert.ToInt32(txtNivel.Text);
                    if (ci.IdCapacidadeRecursosLinhas == 0)
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
                    Util.Aplicacao.ShowMessage("Verifique os dados informados.");
                }
            } 
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja remover o registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                dal.Delete(ci.IdCapacidadeRecursosLinhas);
                dal.Save();
                this.Close();
            }
        }
    }
}
