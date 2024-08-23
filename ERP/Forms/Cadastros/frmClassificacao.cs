using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.DAL;
using ERP.Models;

namespace ERP
{
    public partial class frmClassificacao : Form
    {
        ClassificacaoFiscalDAL dal = new ClassificacaoFiscalDAL();
        List<ClassificacaoFiscal> classificacao = new List<ClassificacaoFiscal>();

        public frmClassificacao()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmClassificacaoCad cad = new frmClassificacaoCad(new ClassificacaoFiscal());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmClassificacao_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmClassificacaoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            classificacao = dal.getByParams(txtNCM.Text, txtDescricao.Text);

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = classificacao;
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
                    ClassificacaoFiscal cl = dal.GetByID(id);
                    frmClassificacaoCad cad = new frmClassificacaoCad(cl);
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
