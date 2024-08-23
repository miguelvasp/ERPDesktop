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
    public partial class frmCodigoIsencaoAux : RibbonForm
    {
        public frmCodigoIsencaoAux()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            if(Util.Validacao.ValidaCampos(this))
            {
                CodigoIsencao c = new CodigoIsencao();
                c.Codigo = txtCodigo.Text;
                c.Descricao = txtDescricao.Text;
                CodigoIsencaoDAL dal = new CodigoIsencaoDAL();
                dal.Insert(c);
                dal.Save();
                this.Close();
            }
            
        }


    }
}
