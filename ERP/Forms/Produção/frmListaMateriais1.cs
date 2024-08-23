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
using ERP.Compras;

namespace ERP
{
    public partial class frmListaMateriais1 : Form
    {
        ListaMateriaisDAL dal = new ListaMateriaisDAL();

        public frmListaMateriais1()
        {
            
            InitializeComponent(); 
        }
        private void CarregaCombos()
        {
            List<ComboItem> TipoProducao = new List<ComboItem>();
            TipoProducao.Add(new ComboItem() { iValue = 1, Text = "Nenhum" });
            TipoProducao.Add(new ComboItem() { iValue = 2, Text = "Co-Produto" });
            TipoProducao.Add(new ComboItem() { iValue = 3, Text = "Sub-Produto" });
            TipoProducao.Add(new ComboItem() { iValue = 4, Text = "Item de planejamento" });
            TipoProducao.Add(new ComboItem() { iValue = 5, Text = "BOM" });
            TipoProducao.Add(new ComboItem() { iValue = 6, Text = "Formula" });
            cboTipo.DataSource = TipoProducao;
            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "iValue";
            cboTipo.SelectedIndex = -1;

            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;

            cboProduto.DataSource = new ProdutoDAL().GetComboProducao();
            cboProduto.DisplayMember = "Text";
            cboProduto.ValueMember = "iValue";
            cboProduto.SelectedIndex = -1;
        }

        private void CarregaGrid()
        {
            int Empresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            string Nome = txtNome.Text;
            int Tipo = cboTipo.SelectedValue == null ? 0 : Convert.ToInt32(cboTipo.SelectedValue);
            int Armazem = cboArmazem.SelectedValue == null ? 0 : Convert.ToInt32(cboArmazem.SelectedValue);
            int Produto = cboProduto.SelectedValue == null ? 0 : Convert.ToInt32(cboProduto.SelectedValue);

            var lista = dal.GetByParams(Nome, Tipo, Armazem, Produto, Empresa); 
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
                    ListaMateriais lista = dal.GetByID(id);
                    frmListaMateriaisCad cad = new frmListaMateriaisCad(lista);
                    cad.dal = dal;
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
            frmListaMateriaisCad cad = new frmListaMateriaisCad(new ListaMateriais());
            cad.dal = dal;
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

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "ListaMateriais.csv");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
        }

        private void frmPedidoCompras_Load(object sender, EventArgs e)
        {
            CarregaCombos();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
