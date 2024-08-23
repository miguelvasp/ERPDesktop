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
using ERP.Forms.Faturamento;

namespace ERP
{
    public partial class frmProduto : Form
    {
        ProdutoDAL dal = new ProdutoDAL();
        public frmProduto()
        {

            InitializeComponent();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = true;
            txtCodigo.Focus();
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmProdutoCad", btnNovo);

            cboGrupoProduto.DataSource = new GrupoProdutoDAL().GetCombo();
            cboGrupoProduto.ValueMember = "iValue";
            cboGrupoProduto.DisplayMember = "Text";
            cboGrupoProduto.SelectedIndex = -1;


            CarregaGrid();
        }

        private void CarregaGrid()
        {
            int tipo = 0;
            if (!String.IsNullOrEmpty(cboGrupoProduto.Text)) tipo = Convert.ToInt32(cboGrupoProduto.SelectedValue);
            var lista = dal.getProdutos(txtCodigo.Text, txtNome.Text, "", tipo);

            var produtos = lista.Select(x => new {
                IdProduto = x.IdProduto,
                Codigo = x.Codigo,
                NomeProduto = x.NomeProduto,
                VendaPrecoUnit = x.VendaPrecoUnit,
                VendaMagemLucro = x.VendaMagemLucro,
                Nome = x.GrupoProduto == null ? "" : x.GrupoProduto.Nome
                                                    }).ToList();

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = produtos;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Produto p = dal.ProdutoRepository.GetByID(id);
                    frmProdutoCad cad = new frmProdutoCad(p, dal);
                    cad.Show(); 
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmProdutoCad cad = new frmProdutoCad(new Produto(), dal);
            cad.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
            txtCodigo.Text = "";
            txtNome.Text = ""; 
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmCorrigeProdutos frmcc = new frmCorrigeProdutos(0);
            frmcc.pdal = dal;
            frmcc.ShowDialog();
            CarregaGrid();
        }
    }
}
