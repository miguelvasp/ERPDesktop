using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmTempoDepreciacao : Form
    {
        TempoDepreciacaoDAL dal = new TempoDepreciacaoDAL();

        public frmTempoDepreciacao()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmTempoDepreciacaoCad cad = new frmTempoDepreciacaoCad(new TempoDepreciacao());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmTempoDepreciacao_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmTempoDepreciacaoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtGrupoAtivo.Text).Select(x => new
            {
                x.IdTempoDepreciacao,
                GrupoAtivo = x.GrupoAtivo == null ? "-" : x.GrupoAtivo.Descricao,
                x.Arredondamento,
                x.Periodo,
                x.VidaUtil
            }).ToList();

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
            Util.Util.ExpotaGridToCsv(dgv, "TempoDepreciacao.csv");
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
                    TempoDepreciacao td = dal.GetByID(id);
                    frmTempoDepreciacaoCad cad = new frmTempoDepreciacaoCad(td);
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
            txtGrupoAtivo.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtGrupoAtivo.Text);

            var rel = (from t in lst
                       select new
                       {
                           Id = t.IdGrupoAtivo,
                           Grupo_Ativo = t.GrupoAtivo == null ? "-" : t.GrupoAtivo.Descricao,
                           Nível_Lançamento = t.NivelLancamento == 1 ? "Atual" :
                                              t.NivelLancamento == 2 ? "Operação" :
                                              t.NivelLancamento == 3 ? "Impostos" : "-'",
                           Arredondamento = t.Arredondamento,
                           Período = t.Periodo,
                           Vida_Útil = t.VidaUtil,
                           Convenção = t.Convencao == 1 ? "Semestre" :
                                       t.Convencao == 2 ? "Meio do Mês ( Primeiro dia)" :
                                       t.Convencao == 3 ? "Meio do Mês ( Décimo quinto dia)" :
                                       t.Convencao == 4 ? "Mês inteiro" :
                                       t.Convencao == 5 ? "Meio do trimeste" :
                                       t.Convencao == 6 ? "Semestre(início)" :
                                       t.Convencao == 7 ? "Semestre(próximo ano)" : "-",
                           Depreciação = t.Depreciacao == true ? "Sim" : "Não"
                       }).OrderBy(o => o.Grupo_Ativo).ToList();

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
