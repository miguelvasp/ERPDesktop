using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.DAL;
using ERP.Models;
using ERP.BLL;

namespace ERP.Fiscal
{
    public partial class frmSelecionaRecebimentos : Form
    {
        public NotaFiscalDAL dal;
        public NotaFiscalItemDAL iDal;
        public NotaFiscalVencimentosDAL vDal;
        public RecebimentoDAL rDal;
        public NotaFiscal NF = null;
        

        public frmSelecionaRecebimentos()
        {
            InitializeComponent();
            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(Util.Util.GetAppSettings("IdEmpresa"));
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lista = rDal.GetRecebimentosByFornecedor(Convert.ToInt32(cboFornecedor.SelectedValue));
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //valida se os itens selecionados tem a mesma condição de pagamento
            string Condicao = "";
            foreach(DataGridViewRow dr in dgv.Rows)
            {
                if(Convert.ToBoolean(dr.Cells[1].Value))
                {
                    if(String.IsNullOrEmpty(Condicao))
                    {
                        Condicao = dr.Cells[3].Value.ToString();
                    }
                    else
                    {
                        if(Condicao != dr.Cells[3].Value.ToString())
                        {
                            Util.Aplicacao.ShowMessage("A condição de pagamento deve ser a mesma para os itens selecionados.");
                            return;
                        }
                    }
                }
            }


            //Se passa a validação cria a lista com os ids selecionados
            List<int> ItensSelecionados = new List<int>();
            foreach (DataGridViewRow dr in dgv.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[1].Value))
                {
                    int id = Convert.ToInt32(dr.Cells[0].Value);
                    ItensSelecionados.Add(id);
                }
            }

            BLNotaFiscal blNotaFiscal = new BLNotaFiscal();
            blNotaFiscal.dal = this.dal;
            blNotaFiscal.iDal = iDal;
            blNotaFiscal.vDal = vDal;
            blNotaFiscal.rDal = rDal;

            DateTime Emissao = Convert.ToDateTime(txtEmissao.Text);

            NF = blNotaFiscal.GeraNotaFiscalEntrada(ItensSelecionados, Convert.ToInt32(cboFornecedor.SelectedValue), Convert.ToInt32(txtNotaFiscal.Text), txtSerie.Text, Emissao);

            this.Close();


        }
    }
}
