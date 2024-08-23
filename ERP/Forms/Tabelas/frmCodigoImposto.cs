using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCodigoImposto : Form
    {
        CodigoImpostoDAL dal = new CodigoImpostoDAL();

        public frmCodigoImposto()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCodigoImpostoCad cad = new frmCodigoImpostoCad(new CodigoImposto());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCodigoImposto_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCodigoImpostoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParamsMV(txtDescricao.Text);

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
            Util.Util.ExpotaGridToCsv(dgv, "CodigoImposto.csv");
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
                    CodigoImposto ci = dal.GetByID(id);
                    frmCodigoImpostoCad cad = new frmCodigoImpostoCad(ci);
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

            var rel = (from c in lst
                       select new
                       {
                           Id = c.IdCodigoImposto,
                           Descrição = c.Descricao,
                           Moeda = c.Moeda == null ? "-" : c.Moeda.Codigo + " - " + c.Moeda.Descricao,
                           Período_Liquidação_Imposto = c.PeriodoLiquidacaoImposto == null ? "-" : c.PeriodoLiquidacaoImposto.Codigo,
                           Grupo_Lancamento_Contábil = c.GrupoLancamentoContabil == null ? "-" : c.GrupoLancamentoContabil.Descricao,
                           PorcentagemNegativaImposto = c.PorcentagemNegativaImposto == true ? "Sim" : "Não",
                           Parâmetros_Cálculos = c.ParametrosCalculos == 1 ? "Porcentagem do Valor Líquido" :
                                                 c.ParametrosCalculos == 2 ? "Porcentagem do Valor Bruto" :
                                                 c.ParametrosCalculos == 3 ? "Porcentagem do Imposto" :
                                                 c.ParametrosCalculos == 4 ? "Valor por Unidade" :
                                                 c.ParametrosCalculos == 5 ? "Porcentagem do Valor Líquido Calculada" :
                                                 c.ParametrosCalculos == 6 ? "Porcentagem do Valor Bruto no Mês" : "-",
                           Base_Marginal = c.BaseMarginal == 1 ? "Valor Líquido por Linha" :
                                                 c.BaseMarginal == 2 ? "Valor Líquido por Unidade" :
                                                 c.BaseMarginal == 3 ? "Valor Líquido do Saldo da Fatura" :
                                                 c.BaseMarginal == 4 ? "Valor Bruto por Linha" :
                                                 c.BaseMarginal == 5 ? "Valor Bruto por Unidade" :
                                                 c.BaseMarginal == 6 ? "Total da Fatura Incluindo Outros Calores de Imposto" : "-",
                           Método_Cálculo = c.MetodoCalculo == 1 ? "Intervalo" :
                                            c.MetodoCalculo == 2 ? "Valor Total" : "-",
                           Unidade_Operacional = c.Unidade == null ? "-" : c.Unidade.Descricao,
                           Data_do_Cálculo = c.DataCalculo == 1 ? "Data de Lançamento" :
                                             c.DataCalculo == 2 ? "Data de Lançamento" : "-",
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
                           Código_Tributação = c.CodigoTributacao == null ? "-" : c.CodigoTributacao.Codigo,
                           Imposto_Retido_Recuperável = c.ImpostoRetidoRecuperavel == true ? "Sim" : "Não",
                           Imposto_Incluso = c.ImpostoIncluso == true ? "Sim" : "Não",
                           Método_Substituição_Tributaria = c.MetodoSubstituicaoTributaria == 1 ? "Nenhum" :
                                          c.MetodoSubstituicaoTributaria == 2 ? "Markup" :
                                          c.MetodoSubstituicaoTributaria == 12 ? "Estimativa" : "-",
                           Código_Receita = c.CodigoReceita
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