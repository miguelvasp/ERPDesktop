using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoRastreamento : Form
    {
        GrupoRastreamentoDAL dal = new GrupoRastreamentoDAL();

        public frmGrupoRastreamento()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmGrupoRastreamentoCad cad = new frmGrupoRastreamentoCad(new GrupoRastreamento());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmGrupoRastreamento_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmGrupoRastreamentoCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "GrupoRastreamento.csv");
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
                    GrupoRastreamento gr = dal.GetByID(id);
                    frmGrupoRastreamentoCad cad = new frmGrupoRastreamentoCad(gr);
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

            var rel = (from g in lst
                       select new
                       {
                           Id = g.IdGrupoRastreamento,
                           Nome = g.Nome,
                           Descrição = g.Descricao,
                           Obrigatório = g.Obrigatorio == true ? "Sim" : "Não",
                           Número_Lote_Ativo = g.NumeroLoteAtivo == true ? "Sim" : "Não",
                           Número_Lote_Saída = g.NumeroLoteSaida == true ? "Sim" : "Não",
                           Número_Lote_Entrada = g.NumeroLoteEntrada == true ? "Sim" : "Não",
                           
                           Número_Série_Ativo = g.NumeroSerieAtivo== true ? "Sim" : "Não",
                           Número_Série_Saída = g.NumeroSerieSaida == true ? "Sim" : "Não",
                           Número_Série_Entrada = g.NumeroSerieEntrada == true ? "Sim" : "Não" 
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
