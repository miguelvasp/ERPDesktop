using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmDescontoaVista : Form
    {
        DescontoaVistaDAL dal = new DescontoaVistaDAL();

        public frmDescontoaVista()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmDescontoaVistaCad cad = new frmDescontoaVistaCad(new DescontoaVista());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmDescontoaVista_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmDescontoaVistaCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtDescricao.Text);

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
            Util.Util.ExpotaGridToCsv(dgv, "DescontoaVista.csv");
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
                    DescontoaVista dv = dal.GetByID(id);
                    frmDescontoaVistaCad cad = new frmDescontoaVistaCad(dv);
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
            txtDescricao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtDescricao.Text);

            var rel = (from d in lst
                       select new
                       {
                           Id = d.IdDescontoaVista,
                           Descrição = d.Descricao,
                           Cálculo = d.Calculo == 1 ? "Líquido" :
                                     d.Calculo == 2 ? "Mês Atual" :
                                     d.Calculo == 3 ? "Trimestre Atua" :
                                     d.Calculo == 4 ? "Ano Atual" :
                                     d.Calculo == 5 ? "Semana Atual" : "-",
                            Meses = d.Meses,
                            Dias = d.Dias
                       }).OrderBy(o => o.Descrição).ToList();

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
