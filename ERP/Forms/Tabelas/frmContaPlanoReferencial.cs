using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmContaPlanoReferencial : Form
    {
        ContaPlanoReferencialDAL dal = new ContaPlanoReferencialDAL();

        public frmContaPlanoReferencial()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmContaPlanoReferencialCad cad = new frmContaPlanoReferencialCad(new ContaPlanoReferencial());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCorredor_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmContaPlanoReferencialCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtCodigo.Text, txtDescricao.Text);
            
            var lst = (from c in lista
                       select new
                       {
                           Id = c.IdContaPlanoReferencial,
                           Codigo = c.Codigo,
                           Descricao = c.Descricao 
                       }).OrderBy(o => o.Codigo).ToList();

            DataTable dt = Util.Aplicacao.LINQToDataTable(lst);

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lst;

            Cursor.Current = Cursors.Default;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "Corredor.csv");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    ContaPlanoReferencial c = dal.GetByID(id);
                    frmContaPlanoReferencialCad cad = new frmContaPlanoReferencialCad(c);
                    cad.dal = dal;
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
            txtCodigo.Text = "";
            txtDescricao.Text = ""; 
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            
        }
    }
}
