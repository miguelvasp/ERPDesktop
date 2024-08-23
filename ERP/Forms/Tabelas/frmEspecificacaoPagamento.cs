using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmEspecificacaoPagamento : Form
    {
        EspecificacaoPagamentoDAL dal = new EspecificacaoPagamentoDAL();

        public frmEspecificacaoPagamento()
        {
            InitializeComponent();
        }
                
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmEspecificacaoPagamentoCad cad = new frmEspecificacaoPagamentoCad(new EspecificacaoPagamento());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmEspecificacaoPagamento_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmEspecificacaoPagamentoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtNome.Text);

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
            Util.Util.ExpotaGridToCsv(dgv, "EspecificacaoPagamento.csv");
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
                    EspecificacaoPagamento ep = dal.GetByID(id);
                    frmEspecificacaoPagamentoCad cad = new frmEspecificacaoPagamentoCad(ep);
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
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtNome.Text);

            var rel = (from ep in lst
                       select new
                       {
                           Id = ep.IdEspecificacaoPagamento,
                           Nome = ep.Nome,
                           Método = ep.MetodoPagamento == null? "-": ep.MetodoPagamento.Nome,
                           Controle_Exportação = ep.ControleExportacao == 1 ? "Conta Bancária Fornecedor" :
                                               ep.ControleExportacao == 2 ? "Código de Barras" : "-",
                           Tipo = ep.IdTipoPagamento == null ? "-" : ep.TipoPagamento.Descricao,
                           Forma = ep.IdFormaPagamento == null ? "-" : ep.FormaPagamento.Descricao
                       }).OrderBy(o => o.Nome).ToList();

            DataTable dt = Util.Aplicacao.LINQToDataTable(rel);

            if (dt.Rows.Count > 0)
            {
                ERP.Relatorios.frmRelatorioGenerico frm = new ERP.Relatorios.frmRelatorioGenerico(dt);
                frm.Text = "Relatório de CFPS";
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}