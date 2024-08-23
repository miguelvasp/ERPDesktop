using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMetodoDepreciacao : Form
    {
        MetodoDepreciacaoDAL dal = new MetodoDepreciacaoDAL();

        public frmMetodoDepreciacao()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmMetodoDepreciacaoCad cad = new frmMetodoDepreciacaoCad(new MetodoDepreciacao());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmMetodoDepreciacao_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmMetodoDepreciacaoCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "MetodoDepreciacao.csv");
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
                    MetodoDepreciacao md = dal.GetByID(id);
                    frmMetodoDepreciacaoCad cad = new frmMetodoDepreciacaoCad(md);
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

            var rel = (from m in lst
                       select new
                       {
                           Id = m.IdMetodoDepreciacao,
                           Descrição = m.Descricao,
                           Deprecição = m.Depreciacao == true ? "Sim" : "Não",
                           Arredondamento = m.Arredondamento,
                           Manter_Valor_Líquido = m.ManterValorLiquidoEm,
                           Nível_Lançamento = m.NivelLancamento == 1 ? "Atual" :
                                              m.NivelLancamento == 2 ? "Operação" :
                                              m.NivelLancamento == 3 ? "Impostos" : "-",
                           Convenção = m.Convencao == 1 ? "Semestre" :
                           m.Convencao == 2 ? "Meio do Mês ( Primeiro dia)" :
                           m.Convencao == 3 ? "Meio do Mês ( Decimo quinto dia)" :
                           m.Convencao == 4 ? "Mês inteiro" :
                           m.Convencao == 5 ? "Meio do trimeste" :
                           m.Convencao == 6 ? "Semestre (início)" :
                           m.Convencao == 7 ? "Semestre (próximo ano)" : "-",
                           Custo_Superior_Aquisição = m.PermitirCustoSuperiorAquisicao == true ? "Sim" : "Não",
                           Valor_Negativo = m.PermitirValorNegativo == true ? "Sim" : "Não"
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
