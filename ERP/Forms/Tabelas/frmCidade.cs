using ERP.DAL;
using ERP.Models;
using ERP.Relatorios;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCidade : Form
    {
        //List<Cidade> Lista = new List<Cidade>();
        CidadeDAL dal = new CidadeDAL();
        public frmCidade()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCidadeCad cad = new frmCidadeCad(new Cidade());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCidade_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCidadeCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtUF.Text, txtNome.Text).Select(x => new { x.IdCidade, x.UnidadeFederacao.UF, x.Nome, x.IBGE }).OrderBy(o => o.UF).ThenBy(t => t.Nome).ToList();

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
            Util.Util.ExpotaGridToCsv(dgv, "Cidade.csv");
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
                    Cidade cid = dal.GetByID(id);
                    frmCidadeCad cad = new frmCidadeCad(cid);
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
            txtUF.Text = "";
            txtNome.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtUF.Text, txtNome.Text).ToList();

            var rel = dal.GetDataReport(lst);
            DataTable dt = Util.Aplicacao.GenericReportDataTable(rel);

            if (dt.Rows.Count > 0)
            {
                frmReportTabelas frm = new frmReportTabelas(dt, "Relatório de Cidades", "Cidade", "UF", "País", "IBGE");
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}
