using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmUnidadeFederacaoNCM : Form
    {
        UnidadeFederacaoNCMDAL dal = new UnidadeFederacaoNCMDAL();

        public frmUnidadeFederacaoNCM()
        {
            InitializeComponent();
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmUnidadeFederacaoNCMCad cad = new frmUnidadeFederacaoNCMCad(new UnidadeFederacaoNCM());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmUnidadeFederacaoNCM_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmUnidadeFederacaoNCMCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtUF.Text, txtCodigoNCM.Text).Select(x => new { x.IdUFNCM, x.UnidadeFederacao.UF, x.ClassificacaoFiscal.NCM, x.ClassificacaoFiscal.Descricao }).ToList();

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
            Util.Util.ExpotaGridToCsv(dgv, "UnidadeFederacaoNCM.csv");
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
                    UnidadeFederacaoNCM uf = dal.GetByID(id);
                    frmUnidadeFederacaoNCMCad cad = new frmUnidadeFederacaoNCMCad(uf);
                    cad.dal = dal;
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
            txtUF.Text = "";
            txtCodigoNCM.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.Get().ToList();

            var UnidadeFederacaoNCM = (from u in lst
                                       select new { Id = u.IdUFNCM, UF = u.UnidadeFederacao.UF, NCM = u.ClassificacaoFiscal.NCM, Descrição = u.ClassificacaoFiscal.Descricao }).OrderBy(o => o.UF).ThenBy(t => t.NCM).ToList();

            DataTable dt = Util.Aplicacao.LINQToDataTable(UnidadeFederacaoNCM);

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
