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

namespace ERP.Auxiliares
{
    public partial class frmCalendarioDataLinhas : RibbonForm
    {
        public CalendarioDataLinhasDAL dal = new CalendarioDataLinhasDAL();
        CalendarioDataLinhas ci = new CalendarioDataLinhas();

        public frmCalendarioDataLinhas(CalendarioDataLinhas pci)
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
            cboTempoTrabalho.SelectedValue = ci.IdTempoTrabalho == null ? 0 : ci.IdTempoTrabalho;
            txtDescricao.Text = ci.Descricao;
            txtDe.Text = ci.De.ToString();
            txtAte.Text = ci.Ate.ToString();
            txtPorcentagemEficiencia.Text = ci.PorcentagemEficiencia.ToString();
        }

        private void CarregaCombo()
        {
            cboTempoTrabalho.DataSource = new TempoTrabalhoDAL().GetCombo();
            cboTempoTrabalho.DisplayMember = "Text";
            cboTempoTrabalho.ValueMember = "iValue";
            cboTempoTrabalho.SelectedIndex = -1;
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            if(Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    ci.IdTempoTrabalho = null;
                    ci.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboTempoTrabalho.Text)) ci.IdTempoTrabalho = Convert.ToInt32(cboTempoTrabalho.SelectedValue);
                    var ta1 = txtDe.Text.Split(':');
                    TimeSpan t1 = new TimeSpan(Convert.ToInt32(ta1[0]), Convert.ToInt32(ta1[1]), 0);
                    ci.De = t1;
                    var ta2 = txtAte.Text.Split(':');
                    TimeSpan t2 = new TimeSpan(Convert.ToInt32(ta2[0]), Convert.ToInt32(ta2[1]), 0);
                    ci.Ate = t2;
                    ci.PorcentagemEficiencia = Convert.ToDecimal(txtPorcentagemEficiencia.Text);
                    if (ci.IdCalendarioDataLinhas == 0)
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
                dal.Delete(ci.IdCalendarioDataLinhas);
                dal.Save();
                this.Close();
            }
        }
    }
}
