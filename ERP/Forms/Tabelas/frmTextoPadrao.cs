using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmTextoPadrao : Form
    {
        TextoPadraoDAL dal = new TextoPadraoDAL();

        public frmTextoPadrao()
        {
            InitializeComponent();
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmTextoPadraoCad cad = new frmTextoPadraoCad(new TextoPadrao());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmTextoPadrao_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmTextoPadraoCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "TextoPadrao.csv");
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
                    TextoPadrao tp = dal.GetByID(id);
                    frmTextoPadraoCad cad = new frmTextoPadraoCad(tp);
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
            var lista = dal.getByParams(txtCodigo.Text, txtDescricao.Text);

            var rel = (from tp in lista
                       select new
                       {
                           Id = tp.IdTextoPadrao,
                           Código = tp.Codigo,
                           Descrição = tp.Descricao,
                           Restrição = tp.Restricao == 1 ? "Externo" :
                                       tp.Restricao == 2 ? "Interno" : "-",
                           Informações_Fiscais = tp.InformacoesFiscais == true ? "Sim" : "Não",
                           Agência = tp.Agencia == 1 ? "Justiça Federal" :
                                     tp.Agencia == 2 ? "Justiça Estadual" :
                                     tp.Agencia == 3 ? "Secex/RFB" :
                                     tp.Agencia == 4 ? "Sefaz" :
                                     tp.Agencia == 5 ? "Outros" : "-",
                           Número_Processo = tp.NumeroProcesso == null ? "-" : tp.NumeroProcesso
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
