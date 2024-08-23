using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmRepresentanteVendas : Form
    {
        RepresentanteVendasDAL dal = new RepresentanteVendasDAL();

        public frmRepresentanteVendas()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmRepresentanteVendasCad cad = new frmRepresentanteVendasCad(new RepresentanteVendas());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmRepresentanteVendas_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmRepresentanteVendasCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtDescricao.Text).Select(x => new { x.IdRepresentanteVendas, x.Descricao, Nome = x.Funcionario == null ? "-" : x.Funcionario.Nome, x.CotaComissao }).ToList();

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
            Util.Util.ExpotaGridToCsv(dgv, "RepresentanteVendas.csv");
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
                    RepresentanteVendas rv = dal.GetByID(id);
                    frmRepresentanteVendasCad cad = new frmRepresentanteVendasCad(rv);
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

            var rel = (from r in lst
                       select new
                       {
                           Id = r.IdFuncionario,
                           Descrição = r.Descricao,
                           Funcionario = r.Funcionario == null ? "-" : r.Funcionario.Nome,
                           Cota_Comissão = r.CotaComissao
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
