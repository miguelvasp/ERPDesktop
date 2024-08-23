using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmConfGrupoImposto : Form
    {
        ConfGrupoImpostoDAL dal = new ConfGrupoImpostoDAL();

        public frmConfGrupoImposto()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmConfGrupoImpostoCad cad = new frmConfGrupoImpostoCad(new ConfGrupoImposto());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmConfGrupoImposto_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmConfGrupoImpostoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtCodigo.Text);

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
            Util.Util.ExpotaGridToCsv(dgv, "ConfGrupoImposto.csv");
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
                    ConfGrupoImposto cgi = dal.GetByID(id);
                    frmConfGrupoImpostoCad cad = new frmConfGrupoImpostoCad(cgi);
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
       }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            //var lst = dal.getByParams(txtCodigo.Text);

            //var rel = (from c in lst
            //           select new
            //           {
            //               Id = c.IdConfGrupoImposto,
            //               Código = c.Codigo,
            //               Grupo_Imposto = c.GrupoImposto == null ? "-" : c.GrupoImposto.Descricao,
            //               Tributação = c.CodigoTributacao == null ? "-" : c.CodigoTributacao.Descricao,
            //               Imposto_Sobre_Uso = c.ImpostoSobreUso == true ? "Sim" : "Não",
            //               Isento = c.Isento == true ? "Sim" : "Não",
            //               Isenção = c.CodigoIsencao == null ? "-" : c.CodigoIsencao.Descricao,
            //               Aliquota = c.ValoresImposto == null ? "-" : c.ValoresImposto.Aliquota.ToString("N4")
            //           }).OrderBy(o => o.Código).ToList();

            //DataTable dt = Util.Aplicacao.LINQToDataTable(rel);

            //if (dt.Rows.Count > 0)
            //{
            //    ERP.Relatorios.frmRelatorioGenerico frm = new ERP.Relatorios.frmRelatorioGenerico(dt);
            //    frm.ShowDialog();
            //}
            //else
            //{
            //    Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            //}
        }
    }
}
