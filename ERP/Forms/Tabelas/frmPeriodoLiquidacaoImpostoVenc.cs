using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPeriodoLiquidacaoImpostoVenc : Form
    {
        PeriodoLiquidacaoImpostoVencDAL dal = new PeriodoLiquidacaoImpostoVencDAL();

        public frmPeriodoLiquidacaoImpostoVenc()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmPeriodoLiquidacaoImpostoVencCad cad = new frmPeriodoLiquidacaoImpostoVencCad(new PeriodoLiquidacaoImpostoVenc());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmPeriodoLiquidacaoImpostoVenc_Load(object sender, EventArgs e)
        {
            LimparCamposPesquisa();

            Util.Aplicacao.BloqueiaControles("frmPeriodoLiquidacaoImpostoVencCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "PeriodoLiquidacaoImpostoVenc.csv");
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
                    PeriodoLiquidacaoImpostoVenc pli = dal.GetByID(id);
                    frmPeriodoLiquidacaoImpostoVencCad cad = new frmPeriodoLiquidacaoImpostoVencCad(pli);
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
                           Id = v.IdPeriodoLiquidacaoImpostoVenc,
                           Período_Liquidação_Imposto = v.PeriodoLiquidacaoImposto == null ? "-" : v.PeriodoLiquidacaoImposto.Descricao,
                           De = v.De.Value.ToShortDateString(),
                           Ate = v.Ate.Value.ToShortDateString(),
                       }).OrderBy(o => o.Id).ToList();

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
