using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoPrecoDesconto : Form
    {
        GrupoPrecoDescontoDAL dal = new GrupoPrecoDescontoDAL();

        public frmGrupoPrecoDesconto()
        {
            InitializeComponent();
        }
                
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmGrupoPrecoDescontoCad cad = new frmGrupoPrecoDescontoCad(new GrupoPrecoDesconto());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmGrupoPrecoDesconto_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmGrupoPrecoDescontoCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "GrupoPrecoDesconto.csv");
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
                    GrupoPrecoDesconto gpd = dal.GetByID(id);
                    frmGrupoPrecoDescontoCad cad = new frmGrupoPrecoDescontoCad(gpd);
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

            var rel = (from p in lst
                       select new
                       {
                           Id = p.IdGrupoPrecoDesconto,
                           Nome = p.Nome,
                           Descrição = p.Descricao,
                           Tipo = p.Tipo == 1 ? "Grupo de preços" :
                                  p.Tipo == 2 ? "Grupo desconto de linha" :
                                  p.Tipo == 3 ? "Grupo desconto combinado" :
                                  p.Tipo == 4 ? "Grupo desconto total" :
                                  p.Tipo == 5 ? "Grupo desconto varejo" : "-",
                           Módulo = p.Modulo == 1 ? "Compras" :
                                  p.Modulo == 2 ? "Vendas" :
                                  p.Modulo == 3 ? "Produto" : "-"
                       }).OrderBy(o => o.Nome).ToList();

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
