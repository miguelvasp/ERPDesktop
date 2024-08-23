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
using ERP.Compras;
using ERP.ModelView;

namespace ERP
{
    public partial class frmContasPagar : Form
    {
        ContasPagarDAL dal = new ContasPagarDAL();

        public frmContasPagar()
        {
            InitializeComponent(); 
        }
        
        private void CarregaGrid()
        {

            if(cboSituacao.SelectedValue.ToString() == "1")
            {
                btnEfetuarPagamento.Enabled = true;
            }
            else
            {
                btnEfetuarPagamento.Enabled = false;
            }

            int Fornecedor = String.IsNullOrEmpty(cboFornecedor.Text) ? 0 : Convert.ToInt32(cboFornecedor.SelectedValue);
            string strFornecedor = txtFornecedor.Text;
            DateTime VencimentoDe = Convert.ToDateTime(txtVencimentoDe.Text);
            DateTime VencimentoAte = Convert.ToDateTime(txtVencimentoAte.Text);
            string Situacao = cboSituacao.SelectedValue.ToString();
            decimal? ValorDe = -1;
            if (!String.IsNullOrEmpty(txtValor.Text)) ValorDe = Convert.ToDecimal(txtValor.Text);
            decimal? ValorAte = -1;
            if (!String.IsNullOrEmpty(txtValorAte.Text)) ValorAte = Convert.ToDecimal(txtValorAte.Text);
            var lista = dal.getByParams(Fornecedor, strFornecedor, VencimentoDe, VencimentoAte, Situacao, ValorDe, ValorAte);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    ContasPagar c = dal.GetByID(id);
                    frmContasPagarCad cad = new frmContasPagarCad(c);
                    cad.dal = dal;
                    cad.Show();
                    CarregaGrid();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmContasPagarCad cad = new frmContasPagarCad(new ContasPagar());
            cad.dal = dal;
            cad.Show();
            CarregaGrid();
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
            Util.Util.ExpotaGridToCsv(dgv, "Calendario.csv");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void frmPedidoCompras_Load(object sender, EventArgs e)
        {
            txtVencimentoDe.Text = DateTime.Now.Subtract(TimeSpan.FromDays(30)).ToShortDateString();
            txtVencimentoAte.Text = DateTime.Now.ToShortDateString();
            CarregaCombos(); 
            CarregaGrid();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CarregaCombos()
        {
            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(Util.Util.GetAppSettings("IdEmpresa"));
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;


            List<ComboItem> situacao = new List<ComboItem>();
            situacao.Add(new ComboItem() { iValue = 1, Text = "A pagar" });
            situacao.Add(new ComboItem() { iValue = 2, Text = "Pago" });
            cboSituacao.DataSource = situacao;
            cboSituacao.DisplayMember = "Text";
            cboSituacao.ValueMember = "iValue"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void btnEfetuarPagamento_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString());
            ContasPagar cp = dal.GetByID(id);
            decimal valor = 0;
            ContasPagarAberto ca = dal.GetProximoAberto(id, out valor);
            ContasPagarBaixa ci = new ContasPagarBaixa();
            ci.Valor = valor;
            ci.IdContasPagarAberto = ca.IdContasPagarAberto;
            using (frmContasPagarBaixa bxcad = new frmContasPagarBaixa(ci))
            {
                bxcad.pagDal = dal;
                bxcad.cp = cp;
                bxcad.LancamentoDireto = true;
                bxcad.ShowDialog();
                CarregaGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Fornecedor = String.IsNullOrEmpty(cboFornecedor.Text) ? 0 : Convert.ToInt32(cboFornecedor.SelectedValue);
            string strFornecedor = txtFornecedor.Text;
            DateTime VencimentoDe = Convert.ToDateTime(txtVencimentoDe.Text);
            DateTime VencimentoAte = Convert.ToDateTime(txtVencimentoAte.Text);
            string Situacao = cboSituacao.SelectedValue.ToString();

            List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "de", Valor = VencimentoDe.ToString("yyyyMMdd") });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "ate", Valor = VencimentoAte.ToString("yyyyMMdd") });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "IdFornecedor", Valor = Fornecedor.ToString() });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Fornecedor", Valor = strFornecedor.ToString() });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Situacao", Valor = Situacao.ToString() });

            CrystalReports.frmCrystalReportViewer frmv = new CrystalReports.frmCrystalReportViewer("ContasPagarList");
            frmv.FiltrosRelatorio = FiltrosRelatorio;
            frmv.ShowDialog();
        }
    }
}
