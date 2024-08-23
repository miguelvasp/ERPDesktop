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
    public partial class frmBancos : Form
    {
        BancoDAL dal = new BancoDAL();
        List<Banco> Bancos = new List<Banco>();
        public frmBancos()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadBanco cadBanco = new frmCadBanco(new Banco());
            cadBanco.ShowDialog();
            CarregaGrid();
        }

        private void frmBancos_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCadBanco", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtNumero.Text, txtNome.Text);

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Deseja salvar as alterações?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    try
            //    {
            //        dal.Delete(Convert.ToInt32(lbCodigo.Text));
            //        dal.Save();
            //        CarregaGrid();
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show("Não é possível apagar o registro.");
            //    }
            //}
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

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
                    Banco banco = Bancos.Find(x => x.IdBanco == id);
                    frmCadBanco cadBanco = new frmCadBanco(banco);
                    cadBanco.ShowDialog();
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
            txtNumero.Text = "";
            txtNome.Text = "";
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
