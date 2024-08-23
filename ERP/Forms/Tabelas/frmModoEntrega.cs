using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmModoEntrega : Form
    {
        ModoEntregaDAL dal = new ModoEntregaDAL();

        public frmModoEntrega()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmModoEntregaCad cad = new frmModoEntregaCad(new ModoEntrega());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmModoEntrega_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmModoEntregaCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtNome.Text, txtDescricao.Text);

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "ModoEntrega.csv");
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
                    ModoEntrega me = dal.GetByID(id);
                    frmModoEntregaCad cad = new frmModoEntregaCad(me);
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
            txtNome.Text = "";
            txtDescricao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtNome.Text, txtDescricao.Text);

            var rel = (from m in lst
                       select new
                       {
                           Id = m.IdModoEntrega,
                           Nome = m.Nome,
                           Descrição = m.Descricao,
                           Grupo_Encargos = m.GrupoEncargos == null ? "-" : m.GrupoEncargos.Descricao,
                           Serviços = m.Servicos == 1 ? "Diversos" :
                                      m.Servicos == 2 ? "Terrestre" :
                                      m.Servicos == 3 ? "Aereo" :
                                      m.Servicos == 4 ? "Retirada" : "-",
                           Transportadora = m.Transportadora == null ? "-" : m.Transportadora.RazaoSocial
                       }).OrderBy(o => o.Nome).ToList();

            DataTable dt = Util.Aplicacao.LINQToDataTable(rel);

            
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
