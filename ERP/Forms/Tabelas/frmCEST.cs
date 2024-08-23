using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ERP.Models;
using ERP.DAL.Fiscal;

namespace ERP
{
    public partial class frmCEST : Form
    {
        CESTDAL dal = new CESTDAL();
        List<CEST> ListCest  = new List<CEST>();

        public frmCEST()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCESTCad cad = new frmCESTCad(new CEST());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCEST_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCESTCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            ListCest = dal.getByParams(txtNCM.Text, txtDescricao.Text);

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = ListCest;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
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
                    CEST cl = dal.GetByID(id);
                    frmCESTCad cad = new frmCESTCad(cl);
                    cad.dal = dal;
                    cad.ShowDialog();                    
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
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
            txtNCM.Text = "";
            txtDescricao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lista = dal.getByParams(txtNCM.Text, txtDescricao.Text);
            DataTable dt = Util.Aplicacao.LINQToDataTable(lista);

            if (dt.Rows.Count > 0)
            {
                ERP.Relatorios.frmRelatorioGenerico frm = new ERP.Relatorios.frmRelatorioGenerico(dt);
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}
