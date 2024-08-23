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
using ERP.Compras;
using ERP.Relatorios;

namespace ERP
{
    public partial class frmMovimentacaoBancaria : Form
    {
        MovimentacaoBancariaDAL dal = new MovimentacaoBancariaDAL();

        public frmMovimentacaoBancaria()
        {
            InitializeComponent(); 




        }
        
        private void CarregaGrid()
        {
            try
            {
                DateTime Di = Convert.ToDateTime(txtDataInicio.Text);
                DateTime Df = Convert.ToDateTime(txtDataFim.Text);
                int IdConta = Convert.ToInt32(cboContaBancaria.SelectedValue);
                var lista = dal.getByParams(Di, Df, IdConta);
                dgv.AutoGenerateColumns = false;
                dgv.RowHeadersVisible = false;
                dgv.DataSource = lista;
            }
            catch (Exception)
            {
                Util.Aplicacao.ShowMessage("Verifique as informações de pesquisa.");
            }
            
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    MovimentacaoBancaria c = dal.GetByID(id);
                    frmMovimentacaoBancariaCad cad = new frmMovimentacaoBancariaCad(c);
                    cad.dal = dal;
                    cad.Show();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmMovimentacaoBancariaCad cad = new frmMovimentacaoBancariaCad(new MovimentacaoBancaria());
            cad.dal = dal;
            cad.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "Calendario.csv");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void frmPedidoCompras_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            txtDataFim.Text = DateTime.Now.ToShortDateString();
            txtDataInicio.Text = DateTime.Now.ToShortDateString();
        }

        public void CarregaCombos()
        {
            cboContaBancaria.DataSource = new EmpresaDAL().GetContasBancarias(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            cboContaBancaria.ValueMember = "iValue";
            cboContaBancaria.DisplayMember = "Text";
            //cboContaBancaria.SelectedIndex = -1;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = !pnlPesquisa.Visible;
        }

        private void btnPesquisa_Click_1(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void planilhaExcelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "MovimentacaoBancaria.csv");
        }

        private void RelatorioMovimentacaoBancaria_Click(object sender, EventArgs e)
        {
            DateTime Di = Convert.ToDateTime(txtDataInicio.Text);
            DateTime Df = Convert.ToDateTime(txtDataFim.Text);
            int IdConta = Convert.ToInt32(cboContaBancaria.SelectedValue);
            var lista = dal.getByParams(Di, Df, IdConta);

            DataTable dt = Util.Aplicacao.LINQToDataTable(lista);

            if (dt.Rows.Count > 0)
            {                
                frmRepMovimentacaoBancaria frm = new frmRepMovimentacaoBancaria(dt,"Relatório de Movimentação Bancária", txtDataInicio.Text, txtDataFim.Text, cboContaBancaria.Text);
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}
