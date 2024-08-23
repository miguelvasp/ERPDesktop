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
    public partial class frmTextoTransacao : Form
    {
        TextoTransacaoDAL dal = new TextoTransacaoDAL();

        public frmTextoTransacao()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            
        }

        private void frmCentroCusto_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmTextoTransacaoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var Lista = new TextoTransacaoDAL().Get().Select(x => new { x.IdTextoTransacao, x.Texto, x.OrigemLancamento.Descricao }).ToList();
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = Lista;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "CentroCusto.csv");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    TextoTransacao cc = dal.GetByID(id);
                    frmTextoTransacaoCad cad = new frmTextoTransacaoCad(cc);
                    cad.dal = dal;
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch { }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
             
        }
    }
}