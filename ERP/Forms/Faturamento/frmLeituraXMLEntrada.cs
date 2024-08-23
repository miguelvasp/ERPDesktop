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

namespace ERP.Forms.Faturamento
{
    public partial class frmLeituraXMLEntrada : Form
    {
        public NotaFiscalDAL dal;
        public NotaFiscalItemDAL iDal;
        public NotaFiscalVencimentosDAL vdal;
        public frmLeituraXMLEntrada()
        {
            InitializeComponent();
        }

        private void frmLeituraXMLEntrada_Load(object sender, EventArgs e)
        {
            List<ComboItem> lista = new CondicaoPagamentoDAL().GetCombo();
            cboCondicao.DataSource = lista;
            cboCondicao.DisplayMember = "Text";
            cboCondicao.ValueMember = "iValue";
            cboCondicao.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
             

            if(string.IsNullOrEmpty(cboCondicao.Text))
            {
                MessageBox.Show("Selecione a condição de pagamento");
                return;
            }

            BLL.BLNotaFiscal bl = new BLL.BLNotaFiscal();
            bl.dal = dal;
            bl.iDal = iDal;
            bl.vDal = vdal;
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "XML Files (*.xml)|*.xml";
            op.FilterIndex = 0;
            op.DefaultExt = "xml";
            op.ShowDialog();
            int IdNotaFiscal = 0;
            if (!string.IsNullOrEmpty(op.FileName))
            {
                string retorno = bl.LerXMLEntrada(op.FileName, Convert.ToInt32(cboCondicao.SelectedValue), out IdNotaFiscal);
                if (retorno != "ok")
                {
                    Util.Aplicacao.ShowMessage(retorno);
                }
                else
                {
                    if (IdNotaFiscal > 0)
                    {
                        NotaFiscal nfe = dal.GetByID(IdNotaFiscal);
                        frmNotaFiscalCad cad = new frmNotaFiscalCad(nfe, 3);
                        cad.dal = dal;
                        cad.iDal = iDal;
                        cad.vDal = vdal; 
                        cad.ShowDialog();
                        this.Close();
                    }
                }
            }

        }
    }
}
