using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCodigoImpostoRetido : Form
    {
        CodigoImpostoRetidoDAL dal = new CodigoImpostoRetidoDAL();

        public frmCodigoImpostoRetido()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCodigoImpostoRetidoCad cad = new frmCodigoImpostoRetidoCad(new CodigoImpostoRetido());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCodigoImpostoRetido_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCodigoImpostoRetidoCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "CodigoImpostoRetido.csv");
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
                    CodigoImpostoRetido cir = dal.GetByID(id);
                    cir = dal.GetByID(id);
                    frmCodigoImpostoRetidoCad cad = new frmCodigoImpostoRetidoCad(cir);
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
                           Id = c.IdCodigoImpostoRetido,
                           Descrição = c.Descricao,
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
                           Período_Liquidação_Imposto = c.PeriodoLiquidacaoImposto == null ? "-" : c.PeriodoLiquidacaoImposto.Codigo,
                           Moeda = c.Moeda == null ? "-" : c.Moeda.Codigo + " - " + c.Moeda.Descricao,
                           Código_Receita = c.CodigoReceita, 
                           Base = c.Base == 1 ? "Percentual do valor bruto no mês" :
                                  c.Base == 2 ? "Percentual do valor bruto" :
                                  c.Base == 3 ? "Percentual do valor Líquido" : "-",
                           Deduzir_INSS = c.DeduzirINSS == true ? "Sim" : "Não",
                           Arredondamento = c.Arredondamento,
                           Forma_de_Arredondamento = c.FormaArredondamento == 1 ? "Normal" :
                                                     c.FormaArredondamento == 1 ? "Para Baixo" : "-",
                           Método_Cálculo = c.MetodoCalculo == 1 ? "Intervalo" :
                                            c.MetodoCalculo == 2 ? "Valor Total" : "-"
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
