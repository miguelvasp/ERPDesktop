using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmConfGrupoImpostoItem : Form
    {
        ConfGrupoImpostoItemDAL dal = new ConfGrupoImpostoItemDAL();

        public frmConfGrupoImpostoItem()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmConfGrupoImpostoItemCad cad = new frmConfGrupoImpostoItemCad(new ConfGrupoImpostoItem());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmConfGrupoImpostoItem_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmConfGrupoImpostoItemCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "ConfGrupoImpostoItem.csv");
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
                    ConfGrupoImpostoItem cgi = dal.GetByID(id);
                    frmConfGrupoImpostoItemCad cad = new frmConfGrupoImpostoItemCad(cgi);
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
            var lst = dal.getByParams(txtCodigo.Text);

            var rel = (from c in lst
                       select new
                       {
                           Id = c.IdConfGrupoImpostoItem, 
                           Grupo_Imposto_Item = c.GrupoImpostoItem == null ? "-" : c.GrupoImpostoItem.Descricao,
                           Tributação = c.CodigoTributacao == null ? "-" : c.CodigoTributacao.Descricao,
                           Sem_Crédito_Imposto = c.SemCreditoImposto == true ? "Sim" : "Não",
                           Isento = c.Isento == true ? "Sim" : "Não"
                       }).ToList();

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
