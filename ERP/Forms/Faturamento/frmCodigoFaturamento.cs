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
    public partial class frmCodigoFaturamento : Form
    {
        CodigoFaturamentoDAL dal = new CodigoFaturamentoDAL();

        public frmCodigoFaturamento()
        {
            InitializeComponent();
        }
        
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCodigoFaturamentoCad cad = new frmCodigoFaturamentoCad(new CodigoFaturamento());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCodigoFaturamento_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCodigoFaturamentoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = dal.getByParams(txtCFOP.Text, txtDescricao.Text);

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
            Util.Util.ExpotaGridToCsv(dgv, "CodigoFaturamento.csv");
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
                    CodigoFaturamento cf = dal.GetByID(id);
                    frmCodigoFaturamentoCad cad = new frmCodigoFaturamentoCad(cf);
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
            txtCFOP.Text = "";
            txtDescricao.Text = "";
        }
    }
}