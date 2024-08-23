using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmDiasPagamento : Form
    {
        DiasPagamentoDAL dal = new DiasPagamentoDAL();

        public frmDiasPagamento()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmDiasPagamentoCad cad = new frmDiasPagamentoCad(new DiasPagamento());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmDiasPagamento_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmDiasPagamentoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lst = dal.getByParams(txtNome.Text);

            var lista = (from l in lst
                         select new
                         {
                             IdDiasPagamento = l.IdDiasPagamento,
                             Nome = l.Nome
                         }).ToList();

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
            Util.Util.ExpotaGridToCsv(dgv, "DiasPagamento.csv");
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
                    DiasPagamento dp = dal.GetByID(id);
                    frmDiasPagamentoCad cad = new frmDiasPagamentoCad(dp);
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
            txtNome.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtNome.Text);

            var rel = (from l in lst
                         select new
                         {
                             Id = l.IdDiasPagamento,
                             Nome = l.Nome
                         }).ToList();

            DataTable dt = Util.Aplicacao.LINQToDataTable(rel);

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