using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoFornecedor : Form
    {
        GrupoFornecedorDAL dal = new GrupoFornecedorDAL();

        public frmGrupoFornecedor()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmGrupoFornecedorCad cad = new frmGrupoFornecedorCad(new GrupoFornecedor());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmGrupoFornecedor_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmGrupoFornecedorCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lst = dal.getByParams(txtDescricao.Text);

            var lista = (from f in lst
                         select new
                         {
                             IdGrupoFornecedor = f.IdGrupoFornecedor,
                             Descricao = f.Descricao,
                             CondicaoPagamento = f.CondicaoPagamento == null ? "" : f.CondicaoPagamento.Descricao,
                             GrupoImposto = f.GrupoImposto == null ? "" : f.GrupoImposto.Descricao,
                             Periodo = f.PeriodoLiquidacaoImposto == null ? "" : f.PeriodoLiquidacaoImposto.Descricao,
                         }).OrderBy(o => o.Descricao).ToList();

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
            Util.Util.ExpotaGridToCsv(dgv, "GrupoFornecedor.csv");
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
                    GrupoFornecedor gf = dal.GetByID(id);
                    frmGrupoFornecedorCad cad = new frmGrupoFornecedorCad(gf);
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
            txtDescricao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtDescricao.Text);

            var rel = (from f in lst
                       select new
                       {
                           Id = f.IdGrupoFornecedor,
                           Descrição = f.Descricao,
                           Condição_Pagto = f.CondicaoPagamento.Descricao,
                           Grupo_Imposto = f.GrupoImposto.Descricao,
                           Período = f.PeriodoLiquidacaoImposto.Descricao
                       }).OrderBy(o => o.Descrição).ToList();

            DataTable dt = Util.Aplicacao.LINQToDataTable(rel);

            if (dt.Rows.Count > 0)
            {
                ERP.Relatorios.frmRelatorioGenerico frm = new ERP.Relatorios.frmRelatorioGenerico(dt);
                frm.Text = "Relatório de Grupo de Fornecedores";
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}