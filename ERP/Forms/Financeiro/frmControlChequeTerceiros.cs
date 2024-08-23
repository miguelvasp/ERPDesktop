using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.DAL;
using ERP.Models;

namespace ERP.Financeiro
{
    public partial class frmControlChequeTerceiros : Form
    {
        
        ChequeTerceirosDAL chDal = new ChequeTerceirosDAL();

        public frmControlChequeTerceiros()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            vwChequeTerceirosDAL dal = new vwChequeTerceirosDAL(); 
            var lista = dal.GetListaChequeTerceiros(cboTipoMovimento.Text, txtRazao.Text, txtNome.Text, cboBanco.Text, txtCheque.Text, cboStatus.Text);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
            dal = null;

        }

        private void frmControlChequeTerceiros_Load(object sender, EventArgs e)
        {
            cboBanco.DataSource = new BancoDAL().GetCombo();
            cboBanco.ValueMember = "iValue";
            cboBanco.DisplayMember = "Text";
            cboBanco.SelectedIndex = -1;

            List<ComboItem> lStatus = new List<ComboItem>();
            lStatus.Add(new ComboItem() { iValue = 1, Text = "Em transito" });
            lStatus.Add(new ComboItem() { iValue = 2, Text = "Custodia" });
            lStatus.Add(new ComboItem() { iValue = 3, Text = "Depositado" });
            lStatus.Add(new ComboItem() { iValue = 4, Text = "Devolvido Custodia" });
            lStatus.Add(new ComboItem() { iValue = 5, Text = "Devolvido" });
            lStatus.Add(new ComboItem() { iValue = 6, Text = "Reapresentado" });
            lStatus.Add(new ComboItem() { iValue = 7, Text = "Protestado" });
            lStatus.Add(new ComboItem() { iValue = 8, Text = "Baixado" });
            cboStatus.DataSource = lStatus;
            cboStatus.ValueMember = "iValue";
            cboStatus.DisplayMember = "Text";
            cboStatus.SelectedIndex = -1;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            ChequeTerceiros c = chDal.GetByID(id);
            using(frmChequeTerceiro frmCheq = new frmChequeTerceiro(c))
            {
                frmCheq.ShowDialog();                                                
                CarregaGrid();                         
            }
        }
    }
}
