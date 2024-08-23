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
using ERP.BLL;

namespace ERP.Vendas
{
    public partial class frmPedidoVendaSeparacaoFat : Form
    {
        vwPedidoVendaSeparacaoDAL vwDal = new vwPedidoVendaSeparacaoDAL();
        PedidoVendaItemDAL idal = new PedidoVendaItemDAL();
        PedidoVendaDAL pDal = new PedidoVendaDAL();
        public NotaFiscalDAL dal;
        public NotaFiscalItemDAL iDal;
        public NotaFiscalVencimentosDAL vDal; 
        public NotaFiscal NF = null;


        public frmPedidoVendaSeparacaoFat()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void frmConfirmaSeparacao_Load(object sender, EventArgs e)
        {
            cbocliente.DataSource = vwDal.GetComboClientesPorFaturar();
            cbocliente.DisplayMember = "Text";
            cbocliente.ValueMember = "iValue";
            cbocliente.SelectedIndex = -1;
        }

        private void cbocliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaGrid();
            
        }

        private void CarregaGrid()
        {
            try
            { 
                if (!String.IsNullOrEmpty(cbocliente.Text))
                {
                    var lista = vwDal.GetByClientePorFaturar(Convert.ToInt32(cbocliente.SelectedValue));
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = lista;
                    foreach(DataGridViewRow dr in dataGridView1.Rows)
                    {
                        dr.Cells[1].Value = true;
                    }
                }
            }
            catch (Exception ex)
            { 
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Confirma a emissão da nota fiscal de vendas?") == System.Windows.Forms.DialogResult.Yes)
            {
                List<int> ItensSelecionados = new List<int>();
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells[1].Value))
                    {
                        int id = Convert.ToInt32(dr.Cells[0].Value);
                        ItensSelecionados.Add(id);
                    }
                }

                BLNotaFiscal blNotaFiscal = new BLNotaFiscal();
                blNotaFiscal.dal = this.dal;
                blNotaFiscal.iDal = iDal;
                blNotaFiscal.vDal = vDal;
                 
                 

                NF = blNotaFiscal.GeraNotaFiscalVendas(ItensSelecionados, Convert.ToInt32(cbocliente.SelectedValue));

                this.Close();
            }
        }
    }
}
