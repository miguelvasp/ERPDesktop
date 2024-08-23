using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmLancamentoAtivo : Form
    {
        LancamentoAtivoDAL dal = new LancamentoAtivoDAL();

        public frmLancamentoAtivo()
        {
            InitializeComponent();
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmLancamentoAtivoCad cad = new frmLancamentoAtivoCad(new LancamentoAtivo());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmLancamentoAtivo_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmLancamentoAtivoCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "LancamentoAtivo.csv");
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
                    LancamentoAtivo la = dal.GetByID(id);
                    frmLancamentoAtivoCad cad = new frmLancamentoAtivoCad(la);
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

            var rel = (from a in lst
                       select new
                       {
                           Id = a.IdLancamentoAtivo,
                           Descrição = a.Descricao,
                           Tipo_Conta_Ativo = a.TipoContaAtivo == 1 ? "Ajuste de Aquisição" :
                                            a.TipoContaAtivo == 2 ? "Ajuste de Depreciação" :
                                            a.TipoContaAtivo == 3 ? "Ajuste de Desvalorização" :
                                            a.TipoContaAtivo == 4 ? "Ajuste de Valorização" :
                                            a.TipoContaAtivo == 5 ? "Alienação - Sucata" :
                                            a.TipoContaAtivo == 6 ? "Alienação - Venda" :
                                            a.TipoContaAtivo == 7 ? "Aquisição" :
                                            a.TipoContaAtivo == 8 ? "Depreciação" :
                                            a.TipoContaAtivo == 9 ? "Reavaliação" :
                                            a.TipoContaAtivo == 10 ? "Tipo de transação" : "-",
                           Relação_Ativo = a.RelacaoAtivo == 1 ? "Tabela" :
                                           a.RelacaoAtivo == 2 ? "Grupo" :
                                           a.RelacaoAtivo == 3 ? "Todos" : "-",
                           Grupo_Ativo = a.GrupoAtivo == null ? "-" : a.GrupoAtivo.Codigo + " - " + a.GrupoAtivo.Descricao,
                           Relação_Operação = a.RelacaoOperacao == 1 ? "Grupo" :
                                              a.RelacaoOperacao == 2 ? "Tabela" :
                                              a.RelacaoOperacao == 3 ? "Todos" : "-",
                           Operação = a.Operacao == null ? "-" : a.Operacao.Codigo + " - " + a.Operacao.Descricao,
                           Relação_Valores = a.RelacaoValores == 1 ? "Perda" :
                                             a.RelacaoValores == 2 ? "Lucro" :
                                             a.RelacaoValores == 3 ? "Todos" : "-"
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
