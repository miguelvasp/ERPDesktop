using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCodigoEncargos : Form
    {
        CodigoEncargoDAL dal = new CodigoEncargoDAL();

        public frmCodigoEncargos()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCodigoEncargosCad cad = new frmCodigoEncargosCad(new CodigoEncargo());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCodigoEncargos_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCodigoEncargosCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams();

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
            Util.Util.ExpotaGridToCsv(dgv, "CodigoEncargos.csv");
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
                    CodigoEncargo ce = dal.GetByID(id);
                    frmCodigoEncargosCad cad = new frmCodigoEncargosCad(ce);
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
            //var lst = dal.getByParams(txtNome.Text, txtDescricao.Text);

            //var rel = (from c in lst
            //           select new
            //           {
            //               Id = c.IdCodigoEncargo,
            //               Nome = c.Nome,
            //               Descrição = c.Descricao,
            //               Tipo = c.Tipo == 1 ? "Frete":
            //                      c.Tipo == 2 ? "Seguro" :
            //                      c.Tipo == 3 ? "Siscomex" :
            //                      c.Tipo == 4 ? "Cota Patronal" :
            //                      c.Tipo == 5 ? "Outros Encargos" : "-",
            //               Grupo_Imposto = c.GrupoImposto == null ? "-" : c.GrupoImposto.Descricao ,
            //               Débito_Lançamento = c.LancamentoDebitoTipo == 1 ? "Item" :
            //                                    c.LancamentoDebitoTipo == 2 ? "Conta Contábil" :
            //                                    c.LancamentoDebitoTipo == 3 ? "Fornecedor/Cliente" : "-",
            //               Débito = c.DebitoTipoLancamentoContaContabil,
            //               Crédito_Lançamento = c.LancamentoCreditoTipo == 1 ? "Item" :
            //                                     c.LancamentoCreditoTipo == 2 ? "Conta Contábil" :
            //                                     c.LancamentoCreditoTipo == 3 ? "Fornecedor/Cliente" : "-",
            //               Crédito = c.CreditoTipoLancamentoContaContabil
            //                   }).OrderBy(o => o.Nome).ToList();

            //DataTable dt = Util.Aplicacao.LINQToDataTable(rel);
            
            //if (dt.Rows.Count > 0)
            //{
            //    ERP.Relatorios.frmRelatorioGenerico frm = new ERP.Relatorios.frmRelatorioGenerico(dt);
            //    frm.Text = "Relatório de Códigos de Encargos";
            //    frm.ShowDialog();
            //}
            //else
            //{
            //    Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            //}
        }
    }
}