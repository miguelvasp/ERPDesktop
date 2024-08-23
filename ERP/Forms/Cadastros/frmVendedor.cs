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

namespace ERP.Cadastros
{
    public partial class frmVendedor : Form
    {
        public frmVendedor()
        {
            InitializeComponent();
        }


        VendedorDAL dal = new VendedorDAL();
        List<ClassificacaoFiscal> classificacao = new List<ClassificacaoFiscal>();

        
       

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmVendedorCad cad = new frmVendedorCad(new Vendedor());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmVendedor_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmVendedorCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var vendedores = dal.getByParams(txtPesquisa.Text);

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = vendedores;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
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
                    Vendedor v = dal.VendedorRepository.GetByID(id);
                    frmVendedorCad cad = new frmVendedorCad(v);
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
            txtPesquisa.Text = "";
        }
    }
}
