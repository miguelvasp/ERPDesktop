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
    public partial class frmContaContabil : Form
    {
        ContaContabilDAL dal = new ContaContabilDAL(new DB_ERPContext());
        List<ContaContabil> cc = new List<ContaContabil>();

        public frmContaContabil()
        {
            InitializeComponent();
        }

        private void frmContaContabil_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmContaContabilCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            cc = dal.getByParams(txtCodigo.Text, txtDescricao.Text);

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = cc;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "ContaContabil.csv");
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
                    ContaContabil cc = dal.GetByID(id);
                    frmContaContabilCad cad = new frmContaContabilCad(cc);
                    cad.dal = dal;
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
            txtCodigo.Text = "";
            txtDescricao.Text = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmContaContabilCad cad = new frmContaContabilCad(new ContaContabil());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
