using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmOperacao : Form
    {
        OperacaoDAL dal = new OperacaoDAL();

        public frmOperacao()
        {
            InitializeComponent();
        }

        private void frmOperacao_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmOperacaoCad", btnNovo);
            CarregaGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmOperacaoCad cad = new frmOperacaoCad(new Operacao());
            cad.dal = dal;
            cad.ShowDialog();
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
            Util.Util.ExpotaGridToCsv(dgv, "Operacao.csv");
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
                    Operacao op = dal.GetByID(id);
                    frmOperacaoCad cad = new frmOperacaoCad(op);
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
            var lst = dal.getByParams(txtCodigo.Text, txtDescricao.Text);

            var rel = (from op in lst
                       select new
                       {
                           Id = op.IdOperacao,
                           Código = op.Codigo,
                           Descrição = op.Descricao,
                           Movimento_Estoque = op.MovimentaEstoque == true ? "Sim" : "Não",
                           Trasações_Financeiras = op.TransacoesFinanceiras == true ? "Sim" : "Não",
                           Conta_Contábil = op.ContaContabil == null ? "-" : op.ContaContabil.Descricao,
                           Perfil_Cliente = op.PerfilCliente == null ? "-" : op.PerfilCliente.Descricao,
                           Perfil_Fornecedor = op.PerfilFornecedor == null ? "-" : op.PerfilFornecedor.Descricao
                       }).OrderBy(o => o.Código).ToList();

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
