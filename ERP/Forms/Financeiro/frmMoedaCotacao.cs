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
    public partial class frmMoedaCotacao : Form
    {

        MoedaDAL dal = new MoedaDAL();
        public frmMoedaCotacao()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCotacaoMoedaCad cad = new frmCotacaoMoedaCad(new MoedaCotacao());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmMoedaCotacao_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCotacaoMoedaCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = dal.MCRepository.Get().Select(x => new { x.Moeda.Descricao, x.IdMoedaCotacao, x.Data, x.Valor }).OrderByDescending(x => x.Data).ToList();

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = lista;

        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dataGridView2);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                    MoedaCotacao m = dal.MCRepository.Get().Where(w => w.IdMoedaCotacao.Equals(id)).FirstOrDefault();
                    frmCotacaoMoedaCad cad = new frmCotacaoMoedaCad(m);
                    cad.dal = dal;
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }
    }
}
