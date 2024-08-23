using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPedidoVendaPesq : Form
    {
        PedidoBalcaoDAL dal = new PedidoBalcaoDAL();

        public frmPedidoVendaPesq()
        {
            InitializeComponent();
            txtDataFim.Text = DateTime.Now.ToShortDateString();
            txtDataInicio.Text = DateTime.Now.ToShortDateString();
        }

        private void frmPedidoVendas_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            CarregaGrid();
            cboStatus.SelectedIndex = 0;
        }

        private void CarregaCombos()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");
              
        }

        private void CarregaGrid()
        {
            DateTime de = Convert.ToDateTime(txtDataInicio.Text + " 00:00");
            DateTime ate = Convert.ToDateTime(txtDataFim.Text + " 23:59");
            int pedido = string.IsNullOrEmpty(txtNumPedido.Text) ? 0 : Convert.ToInt32(txtNumPedido.Text);
            string Nome = txtNome.Text;
            var lista = dal.getByParams(de, ate, pedido, Nome, cboStatus.Text);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
        }

        

        private string MontarTextoFiltros()
        {
            string filtros = "";

            if (Util.Validacao.IsDateTime(txtDataInicio.Text) != null)
            {
                filtros += "Data De: " + txtDataInicio.Text + "; ";
            }

            if (Util.Validacao.IsDateTime(txtDataFim.Text) != null)
            {
                filtros += "Data Até: " + txtDataFim.Text + "; ";
            }

            

            return filtros;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());

                    frmPedidoVendasBalcao cad = new frmPedidoVendasBalcao(id);
                    cad.dal = dal;
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
            frmPedidoVendasBalcao cad = new frmPedidoVendasBalcao(0);
            cad.dal = dal;
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
            Util.Util.ExpotaGridToCsv(dgv, "PedidoVenda.csv");
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

        private void cboCliente_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboProduto_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void txtNumPedido_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void txtNumPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboGrupoCliente_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboArmazem_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboDeposito_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboLocalizacao_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }
        
        private void cboTipoOrdem_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboTeleVendas_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboVendedor_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboVariantesConfig_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboEstilo_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboCor_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboTamanho_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboStatus_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void cboStatusAprovacao_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnPesquisa;
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            DateTime de = Convert.ToDateTime(txtDataInicio.Text + " 00:00");
            DateTime ate = Convert.ToDateTime(txtDataFim.Text + " 23:59");
            int pedido = string.IsNullOrEmpty(txtNumPedido.Text) ? 0 : Convert.ToInt32(txtNumPedido.Text);
            string Nome = txtNome.Text;
            string Filtros = $"Filtros:    De: {de.ToShortDateString()} Até: {ate.ToShortDateString()} Pedido: {pedido.ToString()} Cliente: {Nome} ";

            CrystalReports.frmCrystalReportViewer frmv = new CrystalReports.frmCrystalReportViewer("PedidoBalcaoLista");
            List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "de", Valor = de.ToString("yyyyMMdd") });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "ate", Valor = ate.ToString("yyyyMMdd") });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Pedido", Valor = pedido.ToString() });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Nome", Valor = Nome });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Status", Valor = cboStatus.Text });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Filtros", Valor = Filtros });
            frmv.FiltrosRelatorio = FiltrosRelatorio;
            frmv.ShowDialog();
        }
    }
}
