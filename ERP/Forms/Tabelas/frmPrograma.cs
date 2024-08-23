using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPrograma : Form
    {
        ProgramaDAL dal = new ProgramaDAL();

        public frmPrograma()
        {
            InitializeComponent();
        }

        private void frmPrograma_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmProgramaCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtNome.Text, txtDescricao.Text, txtFormulario.Text);

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmProgramaCad cad = new frmProgramaCad(new Programa());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "Programas.csv");
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
                    Programa p = dal.GetByID(id);
                    frmProgramaCad cad = new frmProgramaCad(p);
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
            txtFormulario.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtNome.Text, txtDescricao.Text, txtFormulario.Text);

            var rel = (from p in lst
                       select new
                       {
                           Id = p.IdPrograma,
                           Nome = p.Nome,
                           Descrição = p.Descricao,
                           Manuteção = p.Manutencao == true ? "Sim" : "Não",
                           Tipo_Programa = p.TipoPrograma == 1 ? "Formulário" :
                                           p.TipoPrograma == 2 ? "Cadastro" :
                                           p.TipoPrograma == 3 ? "Relatório" : "-"
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
