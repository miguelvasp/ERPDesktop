using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoCliente : Form
    {
        GrupoClienteDAL dal = new GrupoClienteDAL();
        public frmGrupoCliente()
        {
            InitializeComponent();
        }
        
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmGrupoClienteCad cad = new frmGrupoClienteCad(new GrupoCliente());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmGrupoCliente_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmGrupoClienteCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lst = dal.getByParams(txtDescricao.Text);
            
            var lista = (from c in lst
                       select new
                       {
                           IdGrupoCliente = c.IdGrupoCliente,
                           Descricao = c.Descricao,
                           CondicaoPagamento = c.CondicaoPagamento == null ? "" : c.CondicaoPagamento.Descricao,
                           GrupoImposto = c.GrupoImposto == null ? "" : c.GrupoImposto.Descricao,
                           Periodo = c.PeriodoLiquidacaoImposto == null ? "" : c.PeriodoLiquidacaoImposto.Descricao
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
            Util.Util.ExpotaGridToCsv(dgv, "GrupoCliente.csv");
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
                    GrupoCliente gc = dal.GetByID(id);
                    frmGrupoClienteCad cad = new frmGrupoClienteCad(gc);
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

            var rel = (from c in lst
                         select new
                         {
                             Id = c.IdGrupoCliente,
                             Descrição = c.Descricao,
                             Condição_Pagto = c.CondicaoPagamento.Descricao,
                             Grupo_Imposto = c.GrupoImposto.Descricao,
                             Período = c.PeriodoLiquidacaoImposto.Descricao
                         }).OrderBy(o => o.Descrição).ToList();

            DataTable dt = Util.Aplicacao.LINQToDataTable(rel);

            if (dt.Rows.Count > 0)
            {
                ERP.Relatorios.frmRelatorioGenerico frm = new ERP.Relatorios.frmRelatorioGenerico(dt);
                frm.Text = "Relatório de Grupo de Clientes";
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}