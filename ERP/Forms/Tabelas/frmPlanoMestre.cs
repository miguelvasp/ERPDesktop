using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPlanoMestre : Form
    {
        PlanoMestreDAL dal = new PlanoMestreDAL();

        public frmPlanoMestre()
        {
            InitializeComponent();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmPlanoMestreCad cad = new frmPlanoMestreCad(new PlanoMestre());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmPlanoMestre_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmPlanoMestreCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "PlanoMestre.csv");
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
                    PlanoMestre pm = dal.GetByID(id);
                    frmPlanoMestreCad cad = new frmPlanoMestreCad(pm);
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

            var rel = (from p in lst
                       select new
                       {
                           Id = p.IdPlanoMestre,
                           Código = p.Codigo,
                           Descrição = p.Descricao,
                           Incluir_Cotação_Compra = p.IncluirCotacaoCompra == true ? "Sim" : "Não",
                           Incluir_Cotação_Venda = p.IncluirCotacaoVenda == true ? "Sim" : "Não",
                           Incluir_Estoque_Disponível = p.IncluirEstoqueDisponivel == true ? "Sim" : "Não",
                           Incluir_Previsão_Demanda = p.IncluirPrevisaoDemanda == true ? "Sim" : "Não",
                           Incluir_Previsão_Fornecimento = p.IncluirPrevisaoFornecimento == true ? "Sim" : "Não",
                           Incluir_Requisições = p.IncluirRequisicoes == true ? "Sim" : "Não",
                           Incluir_Transações_Estoque = p.IncluirTransacoesEstoque == true ? "Sim" : "Não",
                           Limite_de_Tempo_Capacidade = p.LimiteTempoCapacidade,
                           Limite_de_Tempo_Cobertura = p.LimiteTempoCobertura
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
