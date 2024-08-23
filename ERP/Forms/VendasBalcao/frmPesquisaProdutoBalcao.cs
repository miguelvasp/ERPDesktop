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
    public partial class frmPesquisaProdutoBalcao : Form
    {
        public List<vwEstoqueSintetico> listapROD = new List<vwEstoqueSintetico>();
        public vwEstoqueSintetico selecionado = null;
        bool pesquisa = false;



        public frmPesquisaProdutoBalcao(string Texto)
        {
            InitializeComponent();

            if(Util.Util.IsNumber(Texto.TrimStart('0')))
            {
                txtCodigoBarras.Text = Texto;
            }
            else
            {
                txtProduto.Text = Texto;
            }

            pesquisa = true;
            BuscaProduto();
        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {
            txtCodigoBarras.Text = "";
            if(txtProduto.Text.Length > 2)
            {
                BuscaProduto();
            }
            
        }

        public void BuscaProduto()
        {
            if(!pesquisa)
            {
                return;
            }


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
                    if (lista.Count == 1)
                    {
                        selecionado = lista[0];
                        this.Close();
                    }

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = lista;
                    listapROD = lista;
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

                    if (lista.Count == 1)
                    {
                        selecionado = lista[0];
                        this.Close();
                    }


                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = lista;
                    listapROD = lista;
                }


                

            }
            catch (Exception ex)
            {
                // MessageBox.Show("");
            } 
        }

        //public void BuscaProdutox()
        //{
        //    try
        //    {
        //        BLInventario blInv = new BLInventario();
        //        if (rbCodigo.Checked)
        //        {
        //            lista = blInv.ConsultaEstoqueSintetico(
        //            Convert.ToInt32(txtProduto.Text.TrimStart('0')),
        //            0,
        //            0,
        //            0,
        //            0,
        //            0,
        //            0,
        //            0,
        //            0,
        //            "");
        //            if (lista.Count == 1)
        //            {
        //                selecionado = lista[0];
        //                this.Close();
        //            }

        //            dataGridView1.AutoGenerateColumns = false;
        //            dataGridView1.DataSource = lista;
        //        }
        //        else
        //        {
        //            lista = blInv.ConsultaEstoqueSintetico(
        //            0,
        //            0,
        //            0,
        //            0,
        //            0,
        //            0,
        //            0,
        //            0,
        //            0,
        //            txtProduto.Text );
        //            if (lista.Count == 1)
        //            {
        //                selecionado = lista[0];
        //                this.Close();
        //            }

        //            dataGridView1.AutoGenerateColumns = false;
        //            dataGridView1.DataSource = lista;
        //        }
        //    }
        //    catch 
        //    {
        //        Util.Aplicacao.ShowMessage("Verifique as informações");
        //    }
            
            

            

        //}

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                selecionado = listapROD.Where(x => x.ID == id).FirstOrDefault();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
                selecionado = listapROD.Where(x => x.ID == id).FirstOrDefault();
                this.Close();
            }
        }

        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtCodigoBarras.Text))
            {
                txtProduto.Text = "";
                BuscaProduto();
            }
           
        }

        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigoBarras.Text = "";
            BuscaProduto();
        }

        private void frmPesquisaProdutoBalcao_Load(object sender, EventArgs e)
        {
            cboGrupo.DataSource = new GrupoProdutoDAL().GetCombo();
            cboGrupo.DisplayMember = "Text";
            cboGrupo.ValueMember = "iValue";
            cboGrupo.SelectedIndex = -1;
        }

        private void frmPesquisaProdutoBalcao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
                        selecionado = listapROD.Where(x => x.ID == id).FirstOrDefault();
                        this.Close();
                    }

                }
                catch (Exception ex) { }
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Down)
            {
                int i = dataGridView1.SelectedRows[0].Index;
                i++;
                dataGridView1.SelectedRows[0].Selected = false;
                dataGridView1.Rows[i].Selected = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                int i = dataGridView1.SelectedRows[0].Index;
                if (i > 0)
                {
                    dataGridView1.Rows[i].Selected = false;
                    dataGridView1.Rows[i - 1].Selected = true;
                }
            }
        }
    }
}
