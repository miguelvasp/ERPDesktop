using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPerfilFornecedor : Form
    {
        PerfilFornecedorDAL dal = new PerfilFornecedorDAL();

        public frmPerfilFornecedor()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmPerfilFornecedorCad cad = new frmPerfilFornecedorCad(new PerfilFornecedor());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmPerfilFornecedor_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmPerfilFornecedorCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "PerfilFornecedor.csv");
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
                    PerfilFornecedor pf = dal.GetByID(id);
                    frmPerfilFornecedorCad cad = new frmPerfilFornecedorCad(pf);
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

            var rel = (from pf in lst
                       select new
                       {
                           Id = pf.IdPerfilFornecedor,
                           Nome = pf.Nome,
                           Descrição = pf.Descricao,
                           Relação_Grupo = pf.RelacaoGrupo == 1 ? "Grupo" :
                                           pf.RelacaoGrupo == 2 ? "Tabela" :
                                           pf.RelacaoGrupo == 3 ? "Todos" : "-",
                           Fornecedor = pf.Fornecedor == null ? "-" : pf.Fornecedor.RazaoSocial,
                           Grupo = pf.GrupoFornecedor == null ? "-" : pf.GrupoFornecedor.Descricao,
                           Baixa = pf.Baixa == true ? "Sim" : "Não"
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
