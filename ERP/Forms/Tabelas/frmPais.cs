using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPais : Form
    {
        PaisDAL dal = new PaisDAL();

        public frmPais()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using (frmPaisCad cad = new frmPaisCad(new Pais()))
            {
                cad.dal = dal;
                cad.ShowDialog();
            }

            CarregaGrid();
        }

        private void frmPais_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmPaisCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtPais.Text, txtCodigo.Text, txtCodigoIBGE.Text);

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
            Util.Util.ExpotaGridToCsv(dgv, "Pais.csv");
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
                    Pais pais = dal.GetByID(id);
                    using (frmPaisCad cad = new frmPaisCad(pais))
                    {
                        cad.dal = dal;
                        cad.ShowDialog();
                    }

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
            txtPais.Text = "";
            txtCodigo.Text = "";
            txtCodigoIBGE.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtPais.Text, txtCodigo.Text, txtCodigoIBGE.Text);
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
