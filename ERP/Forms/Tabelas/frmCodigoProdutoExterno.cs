using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCodigoProdutoExterno : Form
    {
        CodigoProdutoExternoDAL dal = new CodigoProdutoExternoDAL();

        public frmCodigoProdutoExterno()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCodigoProdutoExternoCad cad = new frmCodigoProdutoExternoCad(new CodigoProdutoExterno());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCodigoProdutoExterno_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCodigoProdutoExternoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtNumeroExterno.Text, txtDescricao.Text);

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
            Util.Util.ExpotaGridToCsv(dgv, "CodigoProdutoExterno.csv");
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
                    CodigoProdutoExterno cpe = dal.GetByID(id);
                    frmCodigoProdutoExternoCad cad = new frmCodigoProdutoExternoCad(cpe);
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
            txtNumeroExterno.Text = "";
            txtDescricao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtNumeroExterno.Text, txtDescricao.Text);

            var rel = (from c in lst
                       select new
                       {
                           Id = c.IdCodigoProdutoExterno,
                           Número_Externo = c.NumeroExterno,
                           Descrição = c.Descricao,
                           Cliente = c.Cliente == null ? "-" : c.Cliente.RazaoSocial,
                           Fornecedor = c.Fornecedor == null ? "-" : c.Fornecedor.RazaoSocial,
                           Código_Padrão = c.CodigoPadrao == true? "Sim": "Não",
                           Produto = c.Produto == null ? "-" : c.Produto.Codigo,
                           Cor = c.VariantesCor == null?"-" : c.VariantesCor.Descricao,
                           Tamanho = c.VariantesTamanho == null ? "-" : c.VariantesTamanho.Descricao
                       }).OrderBy(o => o.Número_Externo).ToList();

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
