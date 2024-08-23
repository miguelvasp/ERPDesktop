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
    public partial class frmEmpresa : Form
    {
        EmpresaDAL dal = new EmpresaDAL();

        public frmEmpresa()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmEmpresaCad cad = new frmEmpresaCad(new Empresa());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmEmpresa_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmEmpresaCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = dal.getByParams(txtRazaoSocial.Text, txtNomeFantasia.Text);

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "Empresa.csv");
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
                    Empresa emp = dal.ERepository.GetByID(id);
                    frmEmpresaCad cad = new frmEmpresaCad(emp);
                    cad.dal = dal;
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
            txtRazaoSocial.Text = "";
            txtNomeFantasia.Text = "";
        }
    }
}