using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmAutoridade : Form
    {
        AutoridadeDAL dal = new AutoridadeDAL();

        public frmAutoridade()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmAutoridadeCad cad = new frmAutoridadeCad(new Autoridade());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmAutoridade_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmAutoridadeCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtAutoridade.Text, txtDescricao.Text);

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
            Util.Util.ExpotaGridToCsv(dgv, "Autoridade.csv");
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
                    Autoridade aut = dal.GetByID(id);
                    frmAutoridadeCad cad = new frmAutoridadeCad(aut);
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
            txtAutoridade.Text = "";
            txtDescricao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lista = dal.getByParams(txtAutoridade.Text, txtDescricao.Text);

            var rel = (from a in lista
                       select new
                       {
                           Id = a.IdAutoridade,
                           Autoridade = a.NomeAutoridade,
                           Descrição = a.Descricao,
                           Identificação = a.IdentificacaoAutoridade,
                           Agência = a.Agencia == 1 ? "Justiça Federal" :
                                     a.Agencia == 2 ? "Justiça Estadual" :
                                     a.Agencia == 3 ? "Secex/RFB" :
                                     a.Agencia == 4 ? "Sefaz" :
                                     a.Agencia == 5 ? "Outros" : "-",
                           Fornecedor = a.Fornecedor == null ? "-" : a.Fornecedor.RazaoSocial,
                           Forma_Arredondamento = a.FormaArredondamento == 1 ? "Normal" :
                                                  a.FormaArredondamento == 2 ? "Para Baixo" :
                                                  a.FormaArredondamento == 3 ? "Vantagem Própria" : "-",
                           Arredondamento = a.Arredondamento
                       }).OrderBy(o => o.Autoridade).ToList();

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