using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPerfilDepreciacao : Form
    {
        PerfilDepreciacaoDAL dal = new PerfilDepreciacaoDAL();

        public frmPerfilDepreciacao()
        {
            InitializeComponent();
        }

        private void frmPerfilDepreciacao_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmPerfilDepreciacaoCad", btnNovo);
            CarregaGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmPerfilDepreciacaoCad cad = new frmPerfilDepreciacaoCad(new PerfilDepreciacao());
            cad.dal = dal;
            cad.ShowDialog();
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
            Util.Util.ExpotaGridToCsv(dgv, "PerfilDepreciacao.csv");
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
                    PerfilDepreciacao pd = dal.GetByID(id);
                    frmPerfilDepreciacaoCad cad = new frmPerfilDepreciacaoCad(pd);
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
                           Id = tb.IdPerfilDepreciacao,
                           Descrição = tb.Descricao,
                           Método_Cálculo = tb.MetodoCalculo == 1 ? "Vida Útil Linear" :
                                            tb.MetodoCalculo == 2 ? "Vida Útil Linear Restante" :
                                            tb.MetodoCalculo == 2 ? "Fator" : "-",
                           Frequência = tb.Frequencia == 1 ? "Anual" :
                                        tb.Frequencia == 2 ? "Mensal" :
                                        tb.Frequencia == 3 ? "Trimestral" :
                                        tb.Frequencia == 4 ? "Semestral" : "-"
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
