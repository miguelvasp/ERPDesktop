using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMatrizCFOP : Form
    {
        MatrizCFOPDAL dal = new MatrizCFOPDAL();

        public frmMatrizCFOP()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmMatrizCFOPCad cad = new frmMatrizCFOPCad(new MatrizCFOP());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmMatrizCFOP_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmMatrizCFOPCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "MatrizCFOPDAL.csv");
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
                    MatrizCFOP mCFOP = dal.GetByID(id);
                    frmMatrizCFOPCad cad = new frmMatrizCFOPCad(mCFOP);
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

            var rel = (from tb in lst
                       select new
                       {
                           Id = tb.IdOperacao,
                           Descrição = tb.Descricao,
                           CFOP = tb.CFOP == null ? "-" : tb.CFOP.Descricao,
                           Tipo_Transação = tb.TipoTransacao == 1 ? "Compral" :
                                      tb.TipoTransacao == 2 ? "Venda" :
                                      tb.TipoTransacao == 3 ? "Devolução" :
                                      tb.TipoTransacao == 4 ? "Transferência entre Empresas" :
                                      tb.TipoTransacao == 5 ? "Remessa" : "-",
                           Operação = tb.Operacao == null ? "-" : tb.Operacao.Descricao,
                           Grupo_CFOP = tb.GrupoCFOP == null ? "-" : tb.GrupoCFOP.Descricao
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
