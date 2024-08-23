using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCodigoServico : Form
    {
        CodigoServicoDAL dal = new CodigoServicoDAL();

        public frmCodigoServico()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCodigoServicoCad cad = new frmCodigoServicoCad(new CodigoServico());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCodigoServico_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCodigoServicoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtCodigo.Text, txtDescricao.Text, txtNome.Text);

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
            Util.Util.ExpotaGridToCsv(dgv, "CodigoServico.csv");
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
                    CodigoServico cs = dal.GetByID(id);
                    frmCodigoServicoCad cad = new frmCodigoServicoCad(cs);
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
            txtNome.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtCodigo.Text, txtDescricao.Text, txtNome.Text);
            var rel = (from cs in lst
                       select new
                       {
                           Id = cs.IdCodigoServico,
                           Código = cs.Codigo,
                           Descrição = cs.Descricao,
                           Nome = cs.Nome,
                           País = cs.Pais == null ? "-" : cs.Pais.NomePais,
                           UF = cs.UnidadeFederacao == null ? "-" : cs.UnidadeFederacao.Nome,
                           Cidade = cs.Cidade == null ? "-" : cs.Cidade.Nome
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
