using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMovimentacaoAtivo : Form
    {
        MovimentacaoAtivoDAL dal = new MovimentacaoAtivoDAL();
        public frmMovimentacaoAtivo()
        {
            InitializeComponent();
        }

        private void frmMovimentacaoAtivo_Load(object sender, EventArgs e)
        {
            //Util.Aplicacao.BloqueiaControles("frmMovimentacaoAtivoCad", btnNovo);
            CarregaGrid();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }
        

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "MovimentacaoAtivo.csv");
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmMovimentacaoAtivoCad cad = new frmMovimentacaoAtivoCad(new MovimentacaoAtivo());
            cad.dal = dal;
            cad.Show();
        }

        private void CarregaGrid()
        {
            var lista = dal.GetAll();

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    MovimentacaoAtivo ma = dal.GetByID(id);
                    frmMovimentacaoAtivoCad cad = new frmMovimentacaoAtivoCad(ma);
                    cad.dal = dal;
                    cad.Show();
                }
            }
            catch {

            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void txtRazao_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
