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
using ERP.ModelView;

namespace ERP.Forms.Faturamento
{
    public partial class frmDevolucao : Form
    {
        NotaFiscalDAL dal = new NotaFiscalDAL();
        NotaFiscalItemDAL idal = new NotaFiscalItemDAL();
        NotaFiscal n = new NotaFiscal();
        List<NotaFiscalItemModelView> Itens = new List<NotaFiscalItemModelView>();
        public frmDevolucao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = dal.getByNumero(txtNotaFiscal.Text);
            if(n == null)
            {
                Util.Aplicacao.ShowMessage("Nota Fiscal não localizada!");
            }
            else
            {
                Itens = idal.GetByNFGrid(n.IdNotaFiscal);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = Itens;
            }
        }

        private void frmDevolucao_Load(object sender, EventArgs e)
        {
            cboCFOP.DataSource = new CFOPDAL().GetCombo();
            cboCFOP.DisplayMember = "Text";
            cboCFOP.ValueMember = "iValue";
            cboCFOP.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            if(Util.Validacao.ValidaCampos(this))
            {
                if (Util.Aplicacao.ShowQuestionMessage("Confirma a entrada da Nota de Devolução?") == DialogResult.Yes)
                {
                    BLL.BLNotaFiscal bl = new BLL.BLNotaFiscal();
                    bl.dal = dal;
                    bl.iDal = idal;
                    foreach(DataGridViewRow dr in dataGridView1.Rows)
                    {
                        int Id = Convert.ToInt32(dr.Cells[0].Value);
                        decimal qtde = Convert.ToDecimal(dr.Cells[5].Value);
                        var item = Itens.Where(x => x.Id == Id).FirstOrDefault();
                        if(item != null)
                        {
                            item.Qtde = qtde;
                        }
                    }


                    var ItensEnviar = Itens.Where(x => x.Qtde > 0).ToList();
                    if(ItensEnviar.Count == 0)
                    {
                        Util.Aplicacao.ShowMessage("Não existem itens selecionados para devolução");
                        return;
                    }
                    else
                    {
                        var nfdev = bl.GeraNotaFiscalDevolucao(Convert.ToInt32(cboCFOP.SelectedValue), txtNotaDevolucao.Text, txtSerie.Text, Convert.ToDateTime(txtEmissao.Text), n, ItensEnviar);
                        if(nfdev == null)
                        {
                            Util.Aplicacao.ShowMessage("Não foi possível data entrada na nota fiscal de devolução");
                        }
                        else
                        {
                            frmNotaFiscalCad frmc = new frmNotaFiscalCad(nfdev, 8);
                            frmc.ShowDialog();
                            this.Close();
                        }
                    } 
                }
            } 
        }
    }
}
