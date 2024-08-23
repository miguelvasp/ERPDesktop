using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmTipoDocumento : Form
    {
        TipoDocumentoDAL dal = new TipoDocumentoDAL(new DB_ERPContext());
        public frmTipoDocumento()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmTipoDocumentoCad cad = new frmTipoDocumentoCad(new TipoDocumento());
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmTipoDocumento_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmTipoDocumentoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.Get().OrderBy(x => x.Nome).ToList();

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dataGridView2);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                    TipoDocumento tp = dal.GetByID(id);
                    frmTipoDocumentoCad cad = new frmTipoDocumentoCad(tp);
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.Get().OrderBy(x => x.Nome).ToList();
            DataTable dt = Util.Aplicacao.LINQToDataTable(lst);

            if (dt.Rows.Count > 0)
            {
                ERP.Relatorios.frmRelatorioGenerico frm = new ERP.Relatorios.frmRelatorioGenerico(dt);
                frm.Text = "Relatório de Tipo de Documentos";
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}
