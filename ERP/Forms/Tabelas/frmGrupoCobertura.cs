using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoCobertura : Form
    {
        GrupoCoberturaDAL dal = new GrupoCoberturaDAL();

        public frmGrupoCobertura()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmGrupoCoberturaCad cad = new frmGrupoCoberturaCad(new GrupoCobertura());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmGrupoCobertura_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmGrupoCoberturaCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "GrupoCobertura.csv");
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
                    GrupoCobertura gc = dal.GetByID(id);
                    frmGrupoCoberturaCad cad = new frmGrupoCoberturaCad(gc);
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

            var rel = (from g in lst
                       select new
                       {
                           Id = g.IdGrupoCobertura,
                           Código = g.Codigo,
                           Descrição = g.Descricao,
                           Cobertura = g.Cobertura == 1 ? "Perído" :
                                       g.Cobertura == 2 ? "Necessidade" :
                                       g.Cobertura == 3 ? "Mín e Máx" :
                                       g.Cobertura == 4 ? "Manual" : "-",
                           Perído = g.Periodo,
                           Limite_Tempo = g.LimiteTempo,
                           Dias_Negativo = g.DiasNegativo,
                           Dias_Positivo = g.DiasPositivo,
                           Status_Produção = g.StatusProducao == 1 ? "Criado" :
                                             g.StatusProducao == 2 ? "Previsto" :
                                             g.StatusProducao == 3 ? "Progrado" :
                                             g.StatusProducao == 4 ? "Liberada" :
                                             g.StatusProducao == 5 ? "Iniciada" :
                                             g.StatusProducao == 6 ? "Informada como Concluída" :
                                             g.StatusProducao == 7 ? "Concluída" : "-",
                           Limite_de_Tempo_Cobertura = g.LimiteTempoCobertura,
                           Limite_de_Tempo_Detalhamento = g.LimiteTempoDetalhamento,
                           Limite_de_Tempo_Capacidade = g.LimiteTempoCapacidade,
                           Limite_Plano_de_Previsao = g.LimiteTempoDetalhamento,
                           Reduzir_Previsão = g.ReduziPrevisao == 1 ? "Ordens" :
                                              g.ReduziPrevisao == 2 ? "Todas as Transações" : "-"
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
