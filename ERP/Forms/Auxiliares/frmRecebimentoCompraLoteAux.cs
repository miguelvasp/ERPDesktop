using ERP.DAL;
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
    public partial class frmRecebimentoCompraLoteAux : RibbonForm
    {
        RecebimentoItemLoteDAL rilDal = new RecebimentoItemLoteDAL();

        public frmRecebimentoCompraLoteAux()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }


    }
}
