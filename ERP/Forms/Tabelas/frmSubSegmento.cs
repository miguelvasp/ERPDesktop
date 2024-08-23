using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmSubSegmento : Form
    {
        SubSegmentoDAL dal = new SubSegmentoDAL();

        public frmSubSegmento()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmSubSegmentoCad cad = new frmSubSegmentoCad(new SubSegmento());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmSubSegmento_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmSubSegmentoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtSegmento.Text, txtNome.Text).Select(x => new { x.IdSubSegmento, Segmento = x.Segmento == null ? "Segmento" : x.Segmento.Nome, x.Nome, x.Descricao }).ToList();

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "SubSegmento.csv");
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
                    SubSegmento ss = dal.GetByID(id);
                    frmSubSegmentoCad cad = new frmSubSegmentoCad(ss);
                    cad.dal = dal;
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
            txtSegmento.Text = "";
            txtNome.Text = "";
        }
    }
}
