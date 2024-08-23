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
    public partial class frmRamoAtividade : Form
    {


        private RamoAtividadeDAL pRepository = new RamoAtividadeDAL(new DB_ERPContext());

        public frmRamoAtividade()
        {
            InitializeComponent();
        }

        private void frmRamoAtividade_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmRamoAtividadeCad", btnNovo);
            CarregaGrid();
        }
        
        private void CarregaGrid()
        {
            var lista = pRepository.Get().OrderBy(x => x.Nome).ToList();

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    RamoAtividade ra = pRepository.GetByID(id);
                    frmRamoAtividadeCad cad = new frmRamoAtividadeCad(ra);
                    cad.ShowDialog();
                    CarregaGrid();
                    dgv.Focus();
                }
            }
            catch (Exception ex) 
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmRamoAtividadeCad cad = new frmRamoAtividadeCad(new RamoAtividade());
            cad.ShowDialog();
            CarregaGrid();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }
    }
}
