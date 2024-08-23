using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmSelecaoChequeTerceiros : Form
    {
        ChequeTerceirosDAL dal = new ChequeTerceirosDAL();
        List<ChequeTerceiroModelView> lista = new List<ChequeTerceiroModelView>();
        public List<ChequeTerceiroModelView> Selecao = new List<ChequeTerceiroModelView>();
        decimal Soma = 0;
        public frmSelecaoChequeTerceiros()
        {
            InitializeComponent();
            CarregaCombos();
        }

        private void CarregaCombos()
        {
            cboBanco.DataSource = new BancoDAL().GetCombo();
            cboBanco.ValueMember = "iValue";
            cboBanco.DisplayMember = "Text";
            cboBanco.SelectedIndex = -1;
        }

        private void CarregaGrid()
        {
            int IdBanco = String.IsNullOrEmpty(cboBanco.Text) ? 0 : Convert.ToInt32(cboBanco.SelectedValue);
            lista = dal.GetListagemCheques(IdBanco, txtNumeroCheque.Text);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
        }

        private void AdicionaSelecao()
        {
            if(dgv.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value); 
                ChequeTerceiroModelView ch = new ChequeTerceiroModelView();
                ch.Id = id;
                ch.Cheque = dgv.Rows[dgv.SelectedRows[0].Index].Cells[1].Value.ToString();
                ch.Banco = dgv.Rows[dgv.SelectedRows[0].Index].Cells[2].Value.ToString();
                ch.Agencia = dgv.Rows[dgv.SelectedRows[0].Index].Cells[3].Value.ToString();
                ch.Conta = dgv.Rows[dgv.SelectedRows[0].Index].Cells[4].Value.ToString();
                ch.Nome = dgv.Rows[dgv.SelectedRows[0].Index].Cells[5].Value.ToString();
                ch.Data = Convert.ToDateTime(dgv.Rows[dgv.SelectedRows[0].Index].Cells[6].Value.ToString());
                ch.Valor = Convert.ToDecimal(dgv.Rows[dgv.SelectedRows[0].Index].Cells[7].Value.ToString().Replace(".", ""));
                Selecao.Add(ch);
                CarregaSelecionados();
            }
            Soma = 0;
            foreach(var i in Selecao)
            {
                Soma += Convert.ToInt32(i.Valor);
            }
            lbTotal.Text = "Valor Total Cheques Selecionados R$ " + Soma.ToString("N2");
        }

        private void CarregaSelecionados()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Selecao;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void cboGrupoVariantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void frmBuscaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        

        private void frmBuscaProduto_Load(object sender, EventArgs e)
        { 
        }

        private void LimpaPagamento()
        {
            
        }

        

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cell = dgv[e.ColumnIndex, e.RowIndex];
                if (cell.OwningColumn.Name == "chkSelecionar")
                {
                    if (cell.EditedFormattedValue.ToString().ToLower() == "true")
                    {
                        dgv[9, e.RowIndex].Value = dgv[8, e.RowIndex].Value;
                    }
                    else
                    {
                        dgv[9, e.RowIndex].Value = "";
                    }
                }
            }
            CalculaSelecao();
            //if (e.RowIndex >= 0)
            //{
            //    if(Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells[2].Value))
            //    {
            //        dgv.Rows[e.RowIndex].Cells[9].Value = dgv.Rows[e.RowIndex].Cells[8].Value;
            //    } 
            //    else
            //    {
            //        dgv.Rows[e.RowIndex].Cells[9].Value = "";
            //    }
            //}
        }

        private void CalculaSelecao()
        {
            dgv.EndEdit();
            Soma = 0;
            foreach(DataGridViewRow dr in dgv.Rows)
            {
                if(Convert.ToBoolean(dr.Cells[2].Value))
                {
                    Soma += Convert.ToDecimal(dr.Cells[9].Value.ToString().Replace(".", ""));
                }
            }

            lbTotal.Text = "Valor selecionado R$ " + Soma.ToString("N2");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AdicionaSelecao();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
                foreach(var i in Selecao)
                {
                    if(i.Id == id)
                    {
                        Selecao.Remove(i);
                    }
                }
                CarregaSelecionados();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
