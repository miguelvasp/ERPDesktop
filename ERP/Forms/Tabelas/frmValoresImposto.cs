using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmValoresImposto : Form
    {
        ValoresImpostoDAL dal = new ValoresImpostoDAL();

        public frmValoresImposto()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmValoresImpostoCad cad = new frmValoresImpostoCad(new ValoresImposto());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmValoresImposto_Load(object sender, EventArgs e)
        {
            LimparCamposPesquisa();

            Util.Aplicacao.BloqueiaControles("frmValoresImpostoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(dtpDe.Text.Trim(), dtpAte.Text.Trim());

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void LimparCamposPesquisa()
        {
            dtpDe.Checked = false;
            dtpDe.CustomFormat = " ";
            dtpDe.Format = DateTimePickerFormat.Custom;

            dtpAte.Checked = false;
            dtpAte.CustomFormat = " ";
            dtpAte.Format = DateTimePickerFormat.Custom;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "ValoresImposto.csv");
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
                    ValoresImposto vi = dal.GetByID(id);
                    frmValoresImpostoCad cad = new frmValoresImpostoCad(vi);
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
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(dtpDe.Text.Trim(), dtpAte.Text.Trim());

            var rel = (from v in lst
                       select new
                       {
                           Id = v.IdValoresImposto,
                           Codigo_Imposto = v.CodigoImposto == null ? "-" : v.CodigoImposto.Descricao,
                           De = v.De.Value.ToShortDateString(),
                           Ate = v.Ate.Value.ToShortDateString(),
                           Alíquota = v.Aliquota,
                           Limite_Mínimo = v.LimiteMinimo,
                           Limite_Máximo = v.LimiteMaximo,
                           Percentual_de_Redução = v.PercentualReducao,
                           Markup = v.Markup,
                           Percentual_Isenção = v.PercentualIsencao
                       }).OrderBy(o => o.Id).ThenBy(t => t.Codigo_Imposto).ToList();

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

        private void dtpDe_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpDe.Checked)
            {
                dtpDe.CustomFormat = " ";
                dtpDe.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpDe.CustomFormat = null;
                dtpDe.Format = DateTimePickerFormat.Short;
            }
        }

        private void dtpAte_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpAte.Checked)
            {
                dtpAte.CustomFormat = " ";
                dtpAte.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpAte.CustomFormat = null;
                dtpAte.Format = DateTimePickerFormat.Short;
            }
        }
    }
}
