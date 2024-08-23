using ERP.DAL;
using ERP.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmAjusteEstoque : Form
    {
        AjusteEstoqueDAL dal = new AjusteEstoqueDAL();
        vwAjusteEstoqueDAL vwDal = new vwAjusteEstoqueDAL();

        public frmAjusteEstoque()
        {
            InitializeComponent();
        }

        private void frmContratoComercial_Load(object sender, EventArgs e)
        {
            txtDataFim.Text = DateTime.Now.ToShortDateString();
            txtDataInicio.Text = DateTime.Now.ToShortDateString();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            try
            {
                DateTime di = Convert.ToDateTime(txtDataInicio.Text);
                DateTime df = Convert.ToDateTime(txtDataFim.Text);
                var lista = vwDal.getByParams(di, df);

                dgv.AutoGenerateColumns = false;
                dgv.RowHeadersVisible = false;
                dgv.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
            
        }
        


        private void txtDataFim_TextChanged(object sender, EventArgs e)
        {
            //this.AcceptButton = btnPesquisa;
        }

        private void txtDataInicio_TextChanged(object sender, EventArgs e)
        {
            //this.AcceptButton = btnPesquisa;
        }
        
        private void btnAjustePreco_Click(object sender, EventArgs e)
        {
         
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmAjusteEstoqueCad cad = new frmAjusteEstoqueCad( new AjusteEstoque());
            cad.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    AjusteEstoque cc = dal.GetByID(id);
                    frmAjusteEstoqueCad cad = new frmAjusteEstoqueCad(cc);
                    cad.Show();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }
    }
}
