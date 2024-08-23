using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCondicaoFrete : Form
    {
        CondicaoFreteDAL dal = new CondicaoFreteDAL();

        public frmCondicaoFrete()
        {
            InitializeComponent();
        }
        
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCondicaoFreteCad cad = new frmCondicaoFreteCad(new CondicaoFrete());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCondicaoFrete_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCondicaoFreteCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtNome.Text, txtDescricao.Text);

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
            Util.Util.ExpotaGridToCsv(dgv, "CondicaoFrete.csv");
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
                    CondicaoFrete cf = dal.GetByID(id);
                    frmCondicaoFreteCad cad = new frmCondicaoFreteCad(cf);
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
            txtDescricao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtNome.Text, txtDescricao.Text);
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
