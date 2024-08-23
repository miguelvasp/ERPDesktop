using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmGrupoAtivo : Form
    {
        GrupoAtivoDAL dal = new GrupoAtivoDAL();

        public frmGrupoAtivo()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmGrupoAtivoCad cad = new frmGrupoAtivoCad(new GrupoAtivo());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmGrupoAtivo_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmGrupoAtivoCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "GrupoAtivo.csv");
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
                    GrupoAtivo ga = dal.GetByID(id);
                    frmGrupoAtivoCad cad = new frmGrupoAtivoCad(ga);
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
                           Id = g.IdGrupoAtivo,
                           Código = g.Codigo,
                           Descrição = g.Descricao,
                           Tipo = g.Tipo == 1 ? "Tângivel" :
                                  g.Tipo == 2 ? "Intângivel" :
                                  g.Tipo == 3 ? "Financeiro" :
                                  g.Tipo == 4 ? "Terrenos e Edifícios" :
                                  g.Tipo == 5 ? "Reputação da empresa" :
                                  g.Tipo == 6 ? "Outros" : "-",
                           Sequência_Ativo = g.SequenciaAtivo,
                           Numerar_Código_de_Barras = g.NumerarCodigoBarras == true ? "Sim" : "Não",
                           Sequência_Código_de_Barras = g.SequenciaCodigoBarras,
                           Tipo_Propriedade = g.TipoPropriedade == 1 ? "Ativo Fixo" :
                                              g.TipoPropriedade == 2 ? "Propiedade duradora" :
                                              g.TipoPropriedade == 3 ? "Outros" : "-",
                           Limite_de_Capitalização = g.LimiteCapitalizacao,
                           Crédito_ICMS = g.CreditoICMS == true ? "Sim" : "Não",
                           Crédito_PIS_Cofins = g.CreditoPisCofins == true ? "Sim" : "Não",
                           Parcelas_do_Crédito = g.ParcelasDoCredito
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
