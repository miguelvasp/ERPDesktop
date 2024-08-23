using ERP.DAL;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Forms.Financeiro
{
    public partial class frmRelContasReceberFiltro : Form
    {
        public frmRelContasReceberFiltro()
        {
            InitializeComponent();
        }

        private void frmRelContasReceberFiltro_Load(object sender, EventArgs e)
        {
            txtDe.Text = DateTime.Now.ToShortDateString();
            txtAte.Text = DateTime.Now.ToShortDateString();
            cboCliente.DataSource = new ClienteDAL().GetCombo();
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;

            cboMetodo.DataSource = new MetodoPagamentoDAL().GetCombo();
            cboMetodo.DisplayMember = "Text";
            cboMetodo.ValueMember = "iValue";
            cboMetodo.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime de = Convert.ToDateTime(txtDe.Text + " 00:00");
            DateTime ate = Convert.ToDateTime(txtAte.Text + " 23:59");
            string TipoRelatorio = rbAnalitico.Checked ? "relContasReceberAnalitico" : "relContasReceberSintetico"; 
            string Filtros = $"Filtros:    De: {de.ToShortDateString()} Até: {ate.ToShortDateString()} Cliente: {cboCliente.Text} Método de Pagamento: {cboMetodo.Text} ";

            CrystalReports.frmCrystalReportViewer frmv = new CrystalReports.frmCrystalReportViewer(TipoRelatorio);
            List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "TipoData", Valor = rbEmissao.Checked ? "E" : "V" });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "de", Valor = de.ToString("yyyyMMdd") });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "ate", Valor = ate.ToString("yyyyMMdd") });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Cliente", Valor = string.IsNullOrEmpty(cboCliente.Text) ? "0" : cboCliente.SelectedValue.ToString() });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Metodo", Valor = string.IsNullOrEmpty(cboMetodo.Text) ? "0" : cboMetodo.SelectedValue.ToString() });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Filtros", Valor = Filtros });
            frmv.FiltrosRelatorio = FiltrosRelatorio;
            frmv.ShowDialog();
        }
    }
}
