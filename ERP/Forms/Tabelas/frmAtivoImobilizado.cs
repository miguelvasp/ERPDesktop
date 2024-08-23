using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmAtivoImobilizado : Form
    {
        AtivoImobilizadoDAL dal = new AtivoImobilizadoDAL();

        public frmAtivoImobilizado()
        {
            InitializeComponent();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmAtivoImobilizadoCad cad = new frmAtivoImobilizadoCad(new AtivoImobilizado());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmAtivoImobilizado_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmAtivoImobilizadoCad", btnNovo);
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
            Util.Util.ExpotaGridToCsv(dgv, "AtivoImobilizado.csv");
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
                    AtivoImobilizado ai = dal.GetByID(id);
                    frmAtivoImobilizadoCad cad = new frmAtivoImobilizadoCad(ai);
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

            var rel = (from a in lst
                       select new
                       {
                           Id = a.IdAtivoImobilizado,
                           Nome = a.Nome,
                           Descrição = a.Descricao,
                           Grupo_Ativo = a.GrupoAtivo == null ? "-" : a.GrupoAtivo.Codigo + " - " + a.GrupoAtivo.Descricao,
                           Número_Físico = a.NumeroFisico,
                           Tipo = a.Tipo == 1 ? "Tângivel" :
                                  a.Tipo == 2 ? "Intângivel" :
                                  a.Tipo == 3 ? "Financeiro" :
                                  a.Tipo == 4 ? "Terrenos e Edifícios" :
                                  a.Tipo == 5 ? "Reputação da empresa" :
                                  a.Tipo == 6 ? "Outros" : "-",
                           Tipo_Propriedade = a.TipoPropriedade == 1 ? "Ativo Fixo" :
                                  a.TipoPropriedade == 2 ? "Propiedade duradora" :
                                  a.TipoPropriedade == 3 ? "Outros" : "-",
                           Marca = a.Marca,
                           Modelo = a.Modelo,
                           Ano = a.Ano,
                           Número_Séria = a.NumeroSerie,
                           Data_Garantia = a.DataGarantia,
                           Apólice = a.Apolice,
                           Data_Apólice = a.DataApolice,
                           Valor_Segurado = a.ValorSegurado,
                           Funcionário = a.Funcionario == null ? "-" : a.Funcionario.Nome,
                           Ativo_Não_Localizado = a.AtivoNaoLocalizado == true ? "Sim" : "Não"
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
