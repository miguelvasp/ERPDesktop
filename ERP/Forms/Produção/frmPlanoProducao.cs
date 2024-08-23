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
    public partial class frmPlanoProducao : Form
    {
        PlanoProducaoDAL dal = new PlanoProducaoDAL();

        public frmPlanoProducao()
        {
            InitializeComponent(); 
        }
        
        private void CarregaGrid()
        {
            try
            {
                int id = string.IsNullOrEmpty(comboBox1.Text) ? 0 : Convert.ToInt32(comboBox1.SelectedValue);
                var lista = new PlanoProducaoDAL().getByParams(textBox1.Text, id);
                dgv.AutoGenerateColumns = false;
                dgv.RowHeadersVisible = false;
                var dados = lista.Select(x => new {
                    Id = x.IdPlanoProducao,
                    Nome = x.Nome, 
                    Cor = x.Cor == null ? "" : x.Cor.Descricao
                }).ToList();
                dgv.DataSource = dados;
            }
            catch (Exception ex)
            {
                 
            }
            
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    var p = dal.GetByID(id);
                    frmPlanoProducaoCad cad = new frmPlanoProducaoCad(p);
                    cad.dal = dal;
                    cad.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmPlanoProducaoCad cad = new frmPlanoProducaoCad(new PlanoProducao());
            cad.dal = dal;
            cad.ShowDialog();
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
            Util.Util.ExpotaGridToCsv(dgv, "Calendario.csv");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void frmPedidoCompras_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new ProdutoDAL().GetComboProducao();
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "iValue";
            comboBox1.SelectedIndex = -1;
            CarregaGrid();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
