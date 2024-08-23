using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMatrizImposto : Form
    {
        MatrizImpostosDAL dal = new MatrizImpostosDAL();

        public frmMatrizImposto()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmMatrizImpostoCad cad = new frmMatrizImpostoCad(new MatrizImpostos());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmMatrizImposto_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmMatrizImpostoCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "MatrizImposto.csv");
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
                    MatrizImpostos mi = dal.GetByID(id);
                    frmMatrizImpostoCad cad = new frmMatrizImpostoCad(mi);
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

            var rel = (from m in lst
                       select new
                       {
                           Id = m.IdMatrizImpostos,
                           Descrição = m.Descricao,
                           Empresa = m.Empresa == null ? "-" : m.Empresa.RazaoSocial,
                           Grupo_CFOP = m.GrupoCFOP == null ? "-" : m.GrupoCFOP.Descricao,
                           Relação_Grupo = m.RelacaoGrupo == 1 ? "Grupo" :
                                     m.RelacaoGrupo == 2 ? "Tabela" :
                                     m.RelacaoGrupo == 3 ? "Todos" : "-",
                           Cliente = m.Cliente == null ? "-" : m.Cliente.RazaoSocial,
                           Grupo_Cliente = m.GrupoCliente == null ? "-" : m.GrupoCliente.Descricao,
                           Fornecedor = m.Fornecedor == null ? "-" : m.Fornecedor.RazaoSocial,
                           Grupo_Fornecedor = m.GrupoFornecedor == null ? "-" : m.GrupoFornecedor.Descricao,
                           Relação_Item = m.RelacaoItem == 1 ? "Tabela" :
                                     m.RelacaoItem == 2 ? "Grupo" :
                                     m.RelacaoItem == 3 ? "Todos" : "-",
                           Produto = m.Produto == null ? "-" : m.Produto.Descricao,
                           Grupo_Impostos = m.GrupoImposto == null ? "-" : m.GrupoImposto.Descricao,
                           Grupo_Impostos_Item = m.GrupoImpostoItem == null ? "-" : m.GrupoImpostoItem.Descricao
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
