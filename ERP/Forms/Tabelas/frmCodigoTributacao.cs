using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCodigoTributacao : Form
    {
        CodigoTributacaoDAL dal = new CodigoTributacaoDAL();

        public frmCodigoTributacao()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCodigoTributacaoCad cad = new frmCodigoTributacaoCad(new CodigoTributacao());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCodigoTributacao_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCodigoTributacaoCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "CodigoTributacao.csv");
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
                    CodigoTributacao ct = dal.GetByID(id);
                    frmCodigoTributacaoCad cad = new frmCodigoTributacaoCad(ct);
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

            var rel = (from c in lst
                       select new
                       {
                           Id = c.IdCodigoTributacao,
                           Código = c.Codigo,
                           Descrição = c.Descricao,
                           De = c.De.Value.ToShortDateString(),
                           Ate = c.Ate.Value.ToShortDateString(),
                           Tipo_Imposto = c.TipoImposto == 1 ? "IPI" :
                           c.TipoImposto == 2 ? "PIS" :
                           c.TipoImposto == 3 ? "ICMS" :
                           c.TipoImposto == 4 ? "COFINS" :
                           c.TipoImposto == 5 ? "ISS" :
                           c.TipoImposto == 6 ? "IRRF" :
                           c.TipoImposto == 7 ? "INSS" :
                           c.TipoImposto == 8 ? "Imposto de Importação" :
                           c.TipoImposto == 9 ? "Outros Impostos" :
                           c.TipoImposto == 10 ? "CSLL" :
                           c.TipoImposto == 11 ? "ICMSST" :
                           c.TipoImposto == 12 ? "ICMSDiff" : "-",
                           Valor_Fiscal = c.ValorFiscal == 1 ? "Com Crédito/Débito" :
                                     c.ValorFiscal == 2 ? "Sem Crédito/Débito (Isento ou Não Tributável)" :
                                     c.ValorFiscal== 3 ? "Sem Crédito/Débito (Outros)" : "-",
                           Sped = c.CodigoSped,
                           Entrada = c.CodigoEntrada,
                           Saída = c.CodigoSaida
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
