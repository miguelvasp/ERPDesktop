using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPeriodoLiquidacaoImposto : Form
    {
        PeriodoLiquidacaoImpostoDAL dal = new PeriodoLiquidacaoImpostoDAL();

        public frmPeriodoLiquidacaoImposto()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmPeriodoLiquidacaoImpostoCad cad = new frmPeriodoLiquidacaoImpostoCad(new PeriodoLiquidacaoImposto());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmPeriodoLiquidacaoImposto_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmPeriodoLiquidacaoImpostoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtCodigo.Text, txtDescricao.Text);

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
            Util.Util.ExpotaGridToCsv(dgv, "PeriodoLiquidacaoImposto.csv");
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
                    PeriodoLiquidacaoImposto pli = dal.GetByID(id);
                    frmPeriodoLiquidacaoImpostoCad cad = new frmPeriodoLiquidacaoImpostoCad(pli);
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
            txtCodigo.Text = "";
            txtDescricao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lista = dal.getByParams(txtCodigo.Text, txtDescricao.Text);

            var rel = (from p in lista
                       select new
                       {
                           Id = p.IdPeriodoLiquidacaoImposto,
                           Código = p.Codigo,
                           Descrição = p.Descricao,
                           Condição_Pgto =  p.CondicaoPagamento == null?  "-": p.CondicaoPagamento.Descricao,
                           Autoridade = p.Autoridade == null? "-": p.Autoridade.Descricao,
                           Intervalo = p.IntervaloPeriodo == 1 ? "Dias" :
                                       p.IntervaloPeriodo == 2 ? "Meses" :
                                       p.IntervaloPeriodo == 3 ? "Anos" : "-",
                            Número_Unidade = p.NumeroUnidade
                       }).OrderBy(o => o.Código).ToList();

            DataTable dt = Util.Aplicacao.LINQToDataTable(rel);

            if (dt.Rows.Count > 0)
            {
                ERP.Relatorios.frmRelatorioGenerico frm = new ERP.Relatorios.frmRelatorioGenerico(dt);
                frm.Text = "Relatório Período Liquidação Imposto";
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}