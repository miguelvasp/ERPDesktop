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

namespace ERP.Forms.Estoques
{
    public partial class frmHistorico : Form
    {
        int Id = 0;
        public frmHistorico(int IdProduto)
        {
            Id = IdProduto;
            InitializeComponent();
        }

        private void frmHistorico_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = new InventarioDAL().getHistorico(Id);
        }
    }
}
