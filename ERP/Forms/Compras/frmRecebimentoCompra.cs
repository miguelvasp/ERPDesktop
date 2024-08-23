using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmRecebimentoCompra : Form
    {
        RecebimentoDAL dal = new RecebimentoDAL();
        List<ModelView.RecebimentoComprasModelView> lista;
        public frmRecebimentoCompra()
        {
            InitializeComponent();
            txtDataFim.Text = DateTime.Now.ToShortDateString();
            txtDataInicio.Text = DateTime.Now.AddYears(-1).ToShortDateString();
        }

        private void frmRecebimentoCompra_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmRecebimentoCompraCad", btnNovo);

            CarregaCombos();

            CarregaGrid();
        }

        private void CarregaCombos()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        private void CarregaGrid()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");
            string sFornecedor = ""; if (cboFornecedor.SelectedValue != null) sFornecedor = cboFornecedor.SelectedValue.ToString();

            lista = dal.GetRecebimentos(txtDataInicio.Text, txtDataFim.Text, sEmpresa, sFornecedor).ToList();

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Recebimento r = dal.RRepository.Get(w => w.IdRecebimento.Equals(id), null, "Usuario,Empresa").FirstOrDefault();
                    frmRecebimentoCompraCad cad = new frmRecebimentoCompraCad(dal, r);
                    cad.Show();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmRecebimentoCompraCad cad = new frmRecebimentoCompraCad(dal, new Recebimento());
            cad.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "RecebimentoCompra.csv");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
        }

        private void txtDataInicio_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void txtDataFim_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboFornecedor_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }
    }
}
