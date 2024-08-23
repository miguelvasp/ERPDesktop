using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmLocalizacaoAtivo : Form
    {
        LocalizacaoAtivoDAL dal = new LocalizacaoAtivoDAL();

        public frmLocalizacaoAtivo()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmLocalizacaoAtivoCad cad = new frmLocalizacaoAtivoCad(new LocalizacaoAtivo());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmLocalizacaoAtivo_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmLocalizacaoAtivoCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "LocalizacaoAtivo.csv");
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
                    LocalizacaoAtivo la = dal.GetByID(id);
                    frmLocalizacaoAtivoCad cad = new frmLocalizacaoAtivoCad(la);
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

            var rel = (from a in lst
                       select new
                       {
                           Id = a.IdLocalizacaoAtivo,
                           Descrição = a.Descricao,
                           Departamento = a.Departamento == null ? "-" : a.Departamento.Nome,
                           Sala = a.Sala,
                           Endereço = a.Endereco,
                           Número = a.Numero,
                           Complemento = a.Complemento,
                           Bairro = a.Bairro,
                           Cidade = a.Cidade == null ? "-" : a.Cidade.Nome,
                           UF = a.UnidadeFederacao == null ? "-" : a.UnidadeFederacao.UF
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