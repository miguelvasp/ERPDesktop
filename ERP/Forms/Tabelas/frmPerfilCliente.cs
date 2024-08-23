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
    public partial class frmPerfilCliente : Form
    {
        PerfilClienteDAL dal = new PerfilClienteDAL();

        public frmPerfilCliente()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmPerfilClienteCad cad = new frmPerfilClienteCad(new PerfilCliente());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmPerfilCliente_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmPerfilClienteCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "PerfilCliente.csv");
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
                    PerfilCliente pc = dal.GetByID(id);
                    frmPerfilClienteCad cad = new frmPerfilClienteCad(pc);
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

            var rel = (from pc in lst
                       select new
                       {
                           Id = pc.IdPerfilCliente,
                           Nome = pc.Nome,
                           Descrição = pc.Descricao,
                           Relação_Grupo = pc.RelacaoGrupo == 1 ? "Grupo" :
                                           pc.RelacaoGrupo == 2 ? "Tabela" :
                                           pc.RelacaoGrupo == 3 ? "Todos" : "-",
                           Cliente = pc.Cliente == null ? "-" : pc.Cliente.RazaoSocial,
                           Grupo = pc.GrupoCliente == null ? "-" : pc.GrupoCliente.Descricao,
                           Baixa = pc.Baixa == true ? "Sim" : "Não"
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
