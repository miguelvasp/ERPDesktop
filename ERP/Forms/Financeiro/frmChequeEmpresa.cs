using ERP.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Financeiro
{
    public partial class frmChequeEmpresa : Form
    {
        ChequeDAL dal = new ChequeDAL();
        public frmChequeEmpresa()
        {
            InitializeComponent();
            txtVencimentoDe.Text = DateTime.Now.ToShortDateString();
            txtVencimentoAte.Text = DateTime.Now.ToShortDateString();
            CarregaCombos();
        }

        private void CarregaGrid()
        {
            DateTime De = Convert.ToDateTime(txtVencimentoDe.Text + " 00:00:00");
            DateTime Ate = Convert.ToDateTime(txtVencimentoAte.Text + " 23:59:00");
            int IdFornecedor = 0;//String.IsNullOrEmpty(cboFornecedor.Text) ? 0 : Convert.ToInt32(cboFornecedor.SelectedValue);
            int IdContaBancaria = String.IsNullOrEmpty(cboContaBancaria.Text) ? 0 : Convert.ToInt32(cboContaBancaria.SelectedValue);
            int IdCliente = 0;// String.IsNullOrEmpty(cboCliente.Text) ? 0 : Convert.ToInt32(cboCliente.SelectedValue); 
            var lista = dal.GetList(De, Ate, IdFornecedor, IdCliente, IdContaBancaria, chkTodos.Checked);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista; 
        }

        private void CarregaCombos()
        {
            //cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(Util.Util.GetAppSettings("IdEmpresa"));
            //cboFornecedor.DisplayMember = "Text";
            //cboFornecedor.ValueMember = "iValue";
            //cboFornecedor.SelectedIndex = -1;

            //cboCliente.DataSource = new ClienteDAL().GetCombo(Util.Util.GetAppSettings("IdEmpresa"));
            //cboCliente.DisplayMember = "Text";
            //cboCliente.ValueMember = "iValue";
            //cboCliente.SelectedIndex = -1;

            cboContaBancaria.DataSource = new EmpresaDAL().GetContasBancarias(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            cboContaBancaria.ValueMember = "iValue";
            cboContaBancaria.DisplayMember = "Text";
            cboContaBancaria.SelectedIndex = -1;

            //cboContaContabil.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            //cboContaContabil.ValueMember = "iValue";
            //cboContaContabil.DisplayMember = "Text";
            //cboContaContabil.SelectedIndex = -1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                ChequeEmpresaCad frmCad = new ChequeEmpresaCad(id);
                frmCad.ShowDialog();
                CarregaGrid();
            }
        }
    }
}
