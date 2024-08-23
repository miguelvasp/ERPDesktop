using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoImpostos : Form
    {
        GrupoImpostoDAL dal = new GrupoImpostoDAL();
        public frmGrupoImpostos()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmGrupoImpostosCad cad = new frmGrupoImpostosCad(new GrupoImposto());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmGrupoImpostos_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmGrupoImpostosCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtCodigo.Text, txtDescricao.Text).Select(x => new { x.IdGrupoImposto, x.CodigoGrupoImposto, x.Descricao }).ToList();

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
            Util.Util.ExpotaGridToCsv(dgv, "GrupoDeImpostos.csv");
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
                    GrupoImposto gi = dal.GetByID(id);
                    frmGrupoImpostosCad cad = new frmGrupoImpostosCad(gi);
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
            txtCodigo.Text = "";
            txtDescricao.Text = "";
        }
    }
}
