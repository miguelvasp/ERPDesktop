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

namespace ERP.Forms.VendasBalcao
{
    public partial class frmBuscaCliente : Form
    {
        public string IdCliente = "0";
        public string Nome = "";

        public frmBuscaCliente()
        {
            InitializeComponent();
        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {
            ClienteDAL dal = new ClienteDAL();
            var lista = dal.getPesquisaPedidoBalcao(txtCliente.Text);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Seleciona();
        }

        private void Seleciona()
        {
            if(dataGridView1.Rows.Count > 0)
            {
                IdCliente = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString();
                Nome = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
                this.Close();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não foi selecionado nenhum cliente.");
            }
        }

        private void frmBuscaCliente_Load(object sender, EventArgs e)
        {
             IdCliente = "0";
             Nome = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seleciona();
        }
    }
}
