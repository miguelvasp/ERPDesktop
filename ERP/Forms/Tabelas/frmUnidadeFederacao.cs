using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmUnidadeFederacao : Form
    {
        UnidadeFederacaoDAL dal = new UnidadeFederacaoDAL(new DB_ERPContext());

        public frmUnidadeFederacao()
        {
            InitializeComponent();
        }

        private void frmUnidadeFederacao_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmUnidadeFederacaoCad", btnNovo);
            CarregaGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmUnidadeFederacaoCad cad = new frmUnidadeFederacaoCad(new UnidadeFederacao());
            cad.ShowDialog();
            CarregaGrid();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dataGridView);
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var Lista = dal.Get().Select(x => new { x.IdUF, x.UF, x.Nome, x.AliquotaICMS, x.AliquotaICMSSubs, x.IVA, x.IBGE }).ToList();

            dataGridView.AutoGenerateColumns = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.DataSource = Lista;

            Cursor.Current = Cursors.Default;
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                    UnidadeFederacao uf = dal.GetByID(id);
                    frmUnidadeFederacaoCad cad = new frmUnidadeFederacaoCad(uf);
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.Get().ToList();
            DataTable dt = Util.Aplicacao.LINQToDataTable(lst);
            if (dt.Rows.Count > 0)
            {
                ERP.Relatorios.frmRelatorioGenerico frm = new ERP.Relatorios.frmRelatorioGenerico(dt);
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}
