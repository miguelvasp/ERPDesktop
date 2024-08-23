using ERP.BLL;
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

namespace ERP.Forms.VendasBalcao
{
    public partial class frmPesquisaProdutoEtiqueta : Form
    {
        public List<Util.Etiqueta> et = new List<Util.Etiqueta>();
        public frmPesquisaProdutoEtiqueta()
        {
            InitializeComponent();
            et.Clear();
        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {
            txtCodigoBarras.Text = "";
            BuscaProduto(); 
        }

        public void BuscaProduto()
        {
            try
            {
                BLInventario blInv = new BLInventario();
                if (!string.IsNullOrEmpty(txtCodigoBarras.Text))
                {
                    var lista = blInv.ConsultaEstoqueSintetico(
                    Convert.ToInt32(txtCodigoBarras.Text.TrimStart('0')),
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    "");
                    

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = lista;
                }
                else
                {
                    int IdGrupo = string.IsNullOrEmpty(cboGrupo.Text) ? 0 : Convert.ToInt32(cboGrupo.SelectedValue);
                    var lista = blInv.ConsultaEstoqueSintetico(
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    txtProduto.Text,
                    IdGrupo);


                    

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = lista;
                }


                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    dr.Cells[4].Value = 1;
                }

            }
            catch(Exception ex)
            {
               // MessageBox.Show("");
            }
            
            

            

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dr in dataGridView1.Rows)
            {
                if(Convert.ToBoolean(dr.Cells[0].Value))
                {
                    Util.Etiqueta ee = new Util.Etiqueta();
                    ee.CodigoBarras = dr.Cells[1].Value.ToString();
                    ee.Codigo = dr.Cells[2].Value.ToString();
                    ee.Descricao = dr.Cells[3].Value.ToString();
                    ee.Qtde = Convert.ToInt32(dr.Cells[4].Value);
                    et.Add(ee);
                }
            }
            this.Close();
        }

        private void frmPesquisaProdutoEtiqueta_Load(object sender, EventArgs e)
        {
            cboGrupo.DataSource = new GrupoProdutoDAL().GetCombo();
            cboGrupo.ValueMember = "iValue";
            cboGrupo.DisplayMember = "Text";
            cboGrupo.SelectedIndex = -1;
        }

        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            BuscaProduto();
        }

        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigoBarras.Text = "";
            BuscaProduto();
        }
    }
}
