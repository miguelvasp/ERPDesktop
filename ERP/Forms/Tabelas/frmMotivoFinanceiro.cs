using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMotivoFinanceiro : Form
    {
        MotivoFinanceiroDAL dal = new MotivoFinanceiroDAL();

        public frmMotivoFinanceiro()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmMotivoFinanceiroCad cad = new frmMotivoFinanceiroCad(new MotivoFinanceiro());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmMotivoFinanceiro_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmMotivoFinanceiroCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "MotivoFinanceiro.csv");
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
                    MotivoFinanceiro mf = dal.GetByID(id);
                    frmMotivoFinanceiroCad cad = new frmMotivoFinanceiroCad(mf);
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

            var rel = (from m in lst
                       select new
                       {
                           Id = m.IdMotivoFinanceiro,
                           Nome = m.Nome,
                           Descrição = m.Descricao,
                           Ativo = m.Ativo == true ? "Sim" : "Não",
                           Banco = m.Banco == true ? "Sim" : "Não",
                           Cliente = m.Cliente == true ? "Sim" : "Não",
                           Conta_Contabil = m.ContaContabil == true ? "Sim" : "Não",
                           Fornecedor = m.Fornecedor == true ? "Sim" : "Não"
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
