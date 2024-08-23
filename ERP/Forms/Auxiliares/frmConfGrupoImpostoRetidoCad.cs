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
    public partial class frmCalendarioDataLinha : RibbonForm
    {
        public ConfGrupoImpostoRetidoDAL dal = new ConfGrupoImpostoRetidoDAL();
        CodigoImpostoRetidoDAL ciDal = new CodigoImpostoRetidoDAL();
        ConfGrupoImpostoRetido ci = new ConfGrupoImpostoRetido();

        public frmCalendarioDataLinha(ConfGrupoImpostoRetido pci)
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
            //carrega o combo
            CarregaCombo();


            if (ci.IdCodigoImpostoRetido != 0) cboCodigoImposto.SelectedValue = ci.IdCodigoImpostoRetido;
        }

        private void CarregaCombo()
        {
            cboCodigoImposto.DataSource = ciDal.GetCombo();
            cboCodigoImposto.DisplayMember = "Text";
            cboCodigoImposto.ValueMember = "iValue";
            cboCodigoImposto.SelectedIndex = -1;
        }

        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            CodigoImpostoRetido c = new CodigoImpostoRetido();
            frmCodigoImpostoRetidoCad f = new frmCodigoImpostoRetidoCad(c);
            f.dal = ciDal;
            f.ShowDialog();
            CarregaCombo();
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            if(cboCodigoImposto.Text == "")
            {
                Util.Aplicacao.ShowMessage("Selecione o codigo de imposto retido.");
                return;
            }
            ci.IdCodigoImpostoRetido = Convert.ToInt32(cboCodigoImposto.SelectedValue);

            if(ci.IdConfGrupoImpostoRetido == 0)
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

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja remover a configuração?") == System.Windows.Forms.DialogResult.Yes)
            {
                dal.Delete(ci.IdConfGrupoImpostoRetido);
                dal.Save();
                this.Close();
            }
        }

        private void ribbon1_Click(object sender, EventArgs e)
        {

        }
    }
}
