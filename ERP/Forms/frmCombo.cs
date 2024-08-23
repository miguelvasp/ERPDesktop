using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Models;

/*********************************************************************************************************
 * Chamada no form a partir do metodo Enter do combo
 * O combo deve estar com as seguintes alterações
 * 1 - DropDownStyle = Simple
 * 2 - Setar tambem o metodo TextChanged do combo com o evento Enter
 * private void cboContaPlanoReferencial_Enter(object sender, EventArgs e)
        {
          
            frmCombo combo = new frmCombo(listaPlanoReferencial);
            combo.Top = this.Top + cboContaPlanoReferencial.Top;
            combo.Left = this.Left + cboContaPlanoReferencial.Left;
            combo.ShowDialog();
            if(!String.IsNullOrEmpty(combo.Id))
            {
                cboContaPlanoReferencial.SelectedValue = Convert.ToInt32(combo.Id);
            }
        }
*********************************************************************************************************/

namespace ERP
{
    public partial class frmCombo : Form
    {
        public string Id { get; set; }

        List<MultiComboItem> l;
        public frmCombo(List<MultiComboItem> Lista)
        {
            this.l = Lista;
            InitializeComponent();
            CarregarGrid();
        }


        private void CarregarGrid()
        {
            string texto = textBox1.Text.ToUpper();
            var ds = l.Where(x => x.Text1.ToUpper().Contains(texto) || x.Text2.ToUpper().Contains(texto)).ToList();
            dataGridView1.DataSource = ds;
            dataGridView1.AutoGenerateColumns = false;
            Util.Aplicacao.DataGridViewAutosizeColumns(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Id = "";
            Text = "";
            this.Close();
        }

        private void frmCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        Id = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString(); 
                        this.Close();
                    }

                }
                catch (Exception ex) { }
            }

            if(e.KeyCode == Keys.Escape)
            {
                Id = "";
                Text = "";
                this.Close();
            }

            if(e.KeyCode == Keys.Down)
            {
                int i = dataGridView1.SelectedRows[0].Index;
                i++;
                dataGridView1.Rows[i].Selected = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                int i = dataGridView1.SelectedRows[0].Index;
                if(i > 0)
                {
                    dataGridView1.Rows[i - 1].Selected = true;
                }
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); 
                this.Close();
            }
            catch (Exception ex) { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CarregarGrid();
        }
    }
}
