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
    public partial class frmCalculoComissao : Form
    {
        CalculoComissaoDAL dal = new CalculoComissaoDAL();

        public frmCalculoComissao()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCalculoComissaoCad cad = new frmCalculoComissaoCad(new CalculoComissao());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmCalculoComissao_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmCalculoComissaoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtGrupoCalculoComissao.Text).Select(x => new
            {
                x.IdCalculoComissao,
                GrupoComissao = x.GrupoComissao == null ? "-" : x.GrupoComissao.Descricao,
                Funcionario = x.Funcionario == null ? "-" : x.Funcionario.Nome,
                RelacaoItem = x.RelacaoItem == 1 ? "Tabela" :
                              x.RelacaoItem == 2 ? "Grupo" :
                              x.RelacaoItem == 3 ? "Todos" : "-",
                RelacaoGrupo = x.RelacaoGrupo == 1 ? "Grupo" :
                               x.RelacaoGrupo == 2 ? "Tabela" :
                               x.RelacaoGrupo == 3 ? "Todos" : "-"
            }).ToList();

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
            Util.Util.ExpotaGridToCsv(dgv, "CalculoComissao.csv");
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
                    CalculoComissao cc = dal.GetByID(id);
                    frmCalculoComissaoCad cad = new frmCalculoComissaoCad(cc);
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
            txtGrupoCalculoComissao.Text = "";
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtGrupoCalculoComissao.Text);

            var rel = (from x in lst
                       select new
                       {
                           Id = x.IdCalculoComissao,
                           GrupoComissao = x.GrupoComissao == null ? "-" : x.GrupoComissao.Descricao,
                           Relação_Item = x.RelacaoItem == 1 ? "Grupo" :
                                          x.RelacaoItem == 2 ? "Tabela" :
                                          x.RelacaoItem == 3 ? "Todos" : "-",
                           Cliente = x.Cliente == null ? "-" : x.Cliente.RazaoSocial,
                           Grupo_Cliente = x.GrupoCliente == null ? "-" : x.GrupoCliente.Descricao,
                           Fornecedor = x.Fornecedor == null ? "-" : x.Fornecedor.RazaoSocial,
                           Grupo_Fornecedor = x.GrupoFornecedor == null ? "-" : x.GrupoFornecedor.Descricao,
                           Grupo_Produto = x.GrupoProduto == null ? "-" : x.GrupoProduto.Descricao,
                           Produto = x.Produto == null ? "-" : x.Produto.Descricao,
                           Relação_Grupo = x.RelacaoGrupo == 1 ? "Grupo" :
                                           x.RelacaoGrupo == 2 ? "Tabela" :
                                           x.RelacaoGrupo == 3 ? "Todos" : "-",                                           
                           Grupo_Preço_Desconto = x.GrupoPrecoDesconto == null ? "-" : x.GrupoPrecoDesconto.Nome,
                           Funcionário = x.Funcionario == null ? "-" : x.Funcionario.Nome
                       }).OrderBy(o => o.GrupoComissao).ToList();

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