using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoArmazenamento : Form
    {
        GrupoArmazenamentoDAL dal = new GrupoArmazenamentoDAL();

        public frmGrupoArmazenamento()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmGrupoArmazenamentoCad cad = new frmGrupoArmazenamentoCad(new GrupoArmazenamento());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmGrupoArmazenamento_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmGrupoArmazenamentoCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "GrupoArmazenamento.csv");
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
                    GrupoArmazenamento ga = dal.GetByID(id);
                    frmGrupoArmazenamentoCad cad = new frmGrupoArmazenamentoCad(ga);
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
                           Id = g.IdGrupoArmazenamento,
                           Nome = g.Nome,
                           Descrição = g.Descricao,
                           Obrigatório = g.Obrigatorio == true ? "Sim" : "Não",
                           Site_Ativo = g.SiteAtivo == true ? "Sim" : "Não",
                           Site_Saída = g.SiteSaida == true ? "Sim" : "Não",
                           Site_Entrada = g.SiteEntrada == true ? "Sim" : "Não",
                           Depósito_Ativo = g.DepositoAtivo == true ? "Sim" : "Não",
                           Depósito_Saída = g.DepositoSaida == true ? "Sim" : "Não",
                           Depósito_Entrada = g.DepositoEntrada == true ? "Sim" : "Não",
                           Localização_Ativo = g.LocalizacaoAtivo == true ? "Sim" : "Não",
                           Localização_Saída = g.LocalizacaoSaida == true ? "Sim" : "Não",
                           Localização_Entrada = g.LocalizacaoEntrada == true ? "Sim" : "Não"
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
