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
    public partial class frmFornecedor : Form
    {
        FornecedorDAL dal = new FornecedorDAL();
        public frmFornecedor()
        {
            InitializeComponent();
        }

        private void frmFornecedor_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmFornecedorCad", btnNovo);
            CarregaGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmFornecedorCad cad = new frmFornecedorCad(new Fornecedor());
            cad.dal = dal;
            cad.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
            txtCNPJ.Text = "";
            txtRazao.Text = "";
        }

        private void planilhaExcelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "Fornecedor.csv");
        }

        private void CarregaGrid()
        {
            var lista = dal.getByParams(txtRazao.Text, txtCNPJ.Text).Select(x => new
            {
                x.IdFornecedor,
                x.RazaoSocial,
                x.NomeFantasia,
                CNPJ = x.Tipo == 1 ? Convert.ToUInt64(x.CNPJ).ToString(@"000\.000\.000\-00") :
                       x.Tipo == 2 ? Convert.ToUInt64(x.CNPJ).ToString(@"00\.000\.000\/0000\-00") :
                       x.Tipo == 3 ? x.CNPJ : "-"
            }).ToList();

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Fornecedor f = dal.FRepository.GetByID(id);
                    frmFornecedorCad cad = new frmFornecedorCad(f);
                    cad.dal = dal;
                    cad.Show();
                }
            }
            catch { }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void txtRazao_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
