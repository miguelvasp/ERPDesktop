using ERP.DAL;
using ERP.Models;
using ERP.Relatorios;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCorredor : Form
    {
        CorredorDAL dal = new CorredorDAL();

        public frmCorredor()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCorredorCad cad = new frmCorredorCad(new Corredor());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCorredor_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCorredorCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtCorredor.Text, txtNumeroCorredor.Text, txtNome.Text);

            var lst = (from c in lista
                       select new
                       {
                           IdCorredor = c.IdCorredor,
                           Deposito = c.Deposito.Descricao,
                           Corredor = c.CorredorLocal,
                           NumeroCorredor = c.NumeroCorredor,
                           Nome = c.Nome
                       }).OrderBy(o => o.Corredor).ToList();

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
                    Corredor c = dal.GetByID(id);
                    frmCorredorCad cad = new frmCorredorCad(c);
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
            txtCorredor.Text = "";
            txtNumeroCorredor.Text = "";
            txtNome.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtCorredor.Text, txtNumeroCorredor.Text, txtNome.Text);

            var rel = dal.GetDataReport(lst);
            DataTable dt = Util.Aplicacao.GenericReportDataTable(rel);

            if (dt.Rows.Count > 0)
            {
                frmReportTabelas frm = new frmReportTabelas(dt, "Relatório de Corredores", "Depósito", "Corredor", "Número do Corredor", "Nome");
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}
