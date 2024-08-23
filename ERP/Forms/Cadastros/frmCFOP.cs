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

namespace ERP.Cadastros
{
    public partial class frmCFOP : Form
    {
        CFOPDAL dal = new CFOPDAL();

        public frmCFOP()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCFOPCad cad = new frmCFOPCad(new CFOP());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCFOP_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCFOPCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = dal.getByParams(txtCodigo.Text, txtDescricao.Text);

            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = lista;
        }

        private void planilhaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridExcel(dgv);
        }

        private void arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Util.ExpotaGridToCsv(dgv, "CFOP.csv");
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
                    CFOP cfop = dal.GetByID(id);
                    frmCFOPCad cad = new frmCFOPCad(cfop);
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
            txtCodigo.Text = "";
            txtDescricao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtCodigo.Text, txtDescricao.Text);

            var rel = (from c in lst
                       select new
                       {
                           Id = c.IdCFOP,
                           CFOP = c.CFOPCOD,
                           Descrição = c.Descricao,
                           Localização = c.Localizacao == 1 ? "Entrada" :
                                         c.Localizacao == 2 ? "Saída" : "-",
                           Direção = c.Direcao == 1 ? "Mesmo Estado" :
                                     c.Direcao == 2 ? "Fora do Estado" :
                                     c.Direcao == 3 ? "Fora do País/Região" : "-",
                           Texto_Padrão = c.TextoPadrao == null ? "-" : c.TextoPadrao.Codigo,
                           Finalidade = c.Finalidade == 1 ? "Nenhum" :
                                        c.Finalidade == 2 ? "Transferência entre Empresas" :
                                        c.Finalidade == 3 ? "Remessa" :
                                        c.Finalidade == 4 ? "Devolução" : "-",
                           Considerar_CIAP = c.ConsiderarCIAP == true ? "Sim" : "Não"
                       }).OrderBy(o => o.CFOP).ToList();

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
