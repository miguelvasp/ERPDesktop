using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmChaveMinemax : Form
    {
        ChaveMinemaxDAL dal = new ChaveMinemaxDAL();

        public frmChaveMinemax()
        {
            InitializeComponent();
        }
        
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmChaveMinemaxCad cad = new frmChaveMinemaxCad(new ChaveMinemax());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmChaveMinemax_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmChaveMinemaxCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "ChaveMinemax.csv");
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
                    ChaveMinemax cm = dal.GetByID(id);
                    frmChaveMinemaxCad cad = new frmChaveMinemaxCad(cm);
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

            var rel = (from c in lst
                       select new
                       {
                           Id = c.IdChaveMinemax,
                           Código = c.Codigo,
                           Descrição = c.Descricao,
                           Fixo = c.Fixo == true ? "Sim" : "Não",
                           Data_Inicial = c.DataInicial,
                           Unidade = c.Unidade == 1 ? "Dias" :
                                     c.Unidade == 2 ? "Mês" :
                                     c.Unidade == 3 ? "Ano" : "-",
                           De = c.De,
                           Até = c.Ate,
                           Mês = c.Mes
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
