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
using ERP.ModelView;

namespace ERP
{
    public partial class frmContaBancariaPesq : Form
    {
        ContaBancariaDAL dal = new ContaBancariaDAL();
        List<ContaBancariaModelView> Lista = new List<ContaBancariaModelView>();
        public frmContaBancariaPesq()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void CarregaGrid()
        {
            Lista = dal.GetListaEmpresa().ToList();
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = Lista;

        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dataGridView2);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                ContaBancaria conta = dal.GetByID(id);
                frmContaBancariaCad contabancaria = new frmContaBancariaCad(conta);
                contabancaria.dal = dal;
                contabancaria.ShowDialog();
                CarregaGrid();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmContaBancariaCad contabancaria = new frmContaBancariaCad(new ContaBancaria());
            contabancaria.dal = dal;
            contabancaria.ShowDialog();
            CarregaGrid();
        }

        private void frmContaBancaria_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmContaBancariaCad", btnNovo);
            CarregaGrid();
        }
    }
}
