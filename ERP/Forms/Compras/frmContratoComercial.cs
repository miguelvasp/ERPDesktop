using ERP.DAL;
using ERP.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmContratoComercial : Form
    {
        ContratoComercialDAL dal = new ContratoComercialDAL();

        public frmContratoComercial()
        {
            InitializeComponent();
        }

        private void frmContratoComercial_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmContratoComercialCad", btnNovo);

            CarregaGrid();
        }

        private void CarregaGrid()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            var lista = dal.GetContratos(txtDataInicio.Text, txtDataFim.Text, txtCodigo.Text, txtDescricao.Text, sEmpresa).ToList();

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;
        }
        
        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void txtDataFim_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void txtDataInicio_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }
        
        private void btnAjustePreco_Click(object sender, EventArgs e)
        {
            frmAjustePreco frm = new frmAjustePreco();
            frm.Show();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmContratoComercialCad cad = new frmContratoComercialCad(dal, new ContratoComercial());
            cad.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "ContratoComercial.csv");
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    ContratoComercial cc = dal.GetByID(id);
                    frmContratoComercialCad cad = new frmContratoComercialCad(dal, cc);
                    cad.Show();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }
    }
}
