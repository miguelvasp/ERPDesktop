using ERP.DAL;
using ERP.Models;
using ERP.Relatorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmSegmentoBancario : Form
    {
        SegmentoBancarioDAL dal = new SegmentoBancarioDAL();

        public frmSegmentoBancario()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using (frmSegmentoBancarioCad cad = new frmSegmentoBancarioCad(new SegmentoBancario()))
            {
                cad.dal = dal;
                cad.ShowDialog();
            }

            CarregaGrid();
        }

        private void frmSegmento_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmSegmentoBancarioCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "Segmento.csv");
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
                    SegmentoBancario seg = dal.GetByID(id);
                    using (frmSegmentoBancarioCad cad = new frmSegmentoBancarioCad(seg))
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
            txtNome.Text = "";
            txtDescricao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            List<SegmentoBancario> lst = dal.getByParams(txtNome.Text, txtDescricao.Text);

            var rel = dal.GetDataReport(lst);
            DataTable dt = Util.Aplicacao.GenericReportDataTable(rel);

            if (dt.Rows.Count > 0)
            {
                frmReportTabelas frm = new frmReportTabelas(dt, "Relatório do Segmento Bancário", "Nome", "Descrição", "Obrigatório", "");
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}
