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
using ERP.Forms.Produção;

namespace ERP
{
    public partial class frmDemandaProducao : Form
    {
      
        List<vwDemandaProducao> lista = new List<vwDemandaProducao>();
        public frmDemandaProducao()
        {
            InitializeComponent(); 
        }
        
        private void CarregaGrid(string Order = "Codigo")
        {
            try
            {
                lista = new vwDemandaProducaoDAL().Get().ToList();
                dgv.AutoGenerateColumns = false;
                dgv.RowHeadersVisible = false;

                switch (Order)
                {
                    case "Codigo": dgv.DataSource = lista.OrderBy(x => x.Codigo).ToList(); break;
                    case "Descricao": dgv.DataSource = lista.OrderBy(x => x.Descricao).ToList(); break;
                    case "Cor": dgv.DataSource = lista.OrderBy(x => x.Cor).ToList(); break;
                    case "Tamanho": dgv.DataSource = lista.OrderBy(x => x.Tamanho).ToList(); break;
                    case "Estilo": dgv.DataSource = lista.OrderBy(x => x.Estilo).ToList(); break;
                    case "Config": dgv.DataSource = lista.OrderBy(x => x.Configuracao).ToList(); break;
                }

                dgv.DataBindingComplete += MakeColumnsSortable_DataBindingComplete;
            }
            catch (Exception ex)
            {
                 
            }
            
        }

        void MakeColumnsSortable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Add this as an event on DataBindingComplete
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView == null)
            {
                var ex = new InvalidOperationException("This event is for a DataGridView type senders only.");
                ex.Data.Add("Sender type", sender.GetType().Name);
                throw ex;
            }

            foreach (DataGridViewColumn column in dataGridView.Columns)
                column.SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
             
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
            CarregaGrid();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                frmGeraOP frmg = new frmGeraOP();
                frmg.ShowDialog(); 
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                int column = e.ColumnIndex;
                switch(column)
                {
                    case 7 : CarregaGrid("Codigo");break;
                    case 8: CarregaGrid("Descricao"); break;
                    case 9: CarregaGrid("Cor"); break;
                    case 10: CarregaGrid("Tamanho"); break;
                    case 11: CarregaGrid("Estilo"); break;
                    case 12: CarregaGrid("Config"); break;
                }
            }
        }
    }
}
