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
    public partial class frmSearchForm : Form
    {
        public string frmNome { get; set; }
        int id;
        List<Programa> lista = new List<Programa>();

        public frmSearchForm(int IdUsuario)
        {
            id = IdUsuario;
            InitializeComponent();
        }

        private void Buscar()
        {
            string busca = txtInformePrograma.Text.ToUpper();
            dtgPrograma.DataSource = lista.Where(x => x.Nome.ToUpper().Contains(busca)).Select(x => new { x.Nome, x.Formulario }).ToList();
            dtgPrograma.AutoGenerateColumns = false;
        }

        private void dtgPrograma_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmNome = dtgPrograma.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.Close();
            }
            catch (Exception ex) { }
            
        }

        private void frmSearchForm_Load(object sender, EventArgs e)
        {
            lista = new ProgramaDAL().GetByUserId(id);
            Buscar();
            txtInformePrograma.Focus();
        }

        private void txtInformePrograma_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void frmSearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if(dtgPrograma.Rows.Count > 0)
                    {
                        frmNome = dtgPrograma.Rows[dtgPrograma.SelectedRows[0].Index].Cells[1].Value.ToString();
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
                int i = dtgPrograma.SelectedRows[0].Index;
                i++;
                dtgPrograma.SelectedRows[0].Selected = false;
                dtgPrograma.Rows[i].Selected = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                int i = dtgPrograma.SelectedRows[0].Index;
                if (i > 0)
                {
                    dtgPrograma.Rows[i].Selected = false;
                    dtgPrograma.Rows[i - 1].Selected = true;
                }
            }
        }
    }
}
