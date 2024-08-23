using ERP.DAL;
using ERP.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmLocalizacao : Form
    {
        LocalizacaoDAL dal = new LocalizacaoDAL();

        public frmLocalizacao()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmLocalizacaoCad cad = new frmLocalizacaoCad(new Localizacao());
            cad.dal = dal;
            cad.ShowDialog();
            CarregaGrid();
        }

        private void frmLocalizacao_Load(object sender, EventArgs e)
        {
            Util.Aplicacao.BloqueiaControles("frmLocalizacaoCad", btnNovo);
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            Cursor.Current = Cursors.WaitCursor;

            var lista = dal.getByParams(txtNome.Text);

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
            Util.Util.ExpotaGridToCsv(dgv, "Localizacao.csv");
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
                    Localizacao local = dal.GetByID(id);
                    frmLocalizacaoCad cad = new frmLocalizacaoCad(local);
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
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var lst = dal.getByParams(txtNome.Text);

            var rel = (from l in lst
                       select new
                       {
                           Id = l.IdLocalizacao,
                           Nome = l.Nome,
                           Depósito = l.Deposito == null ? "-" : l.Deposito.Descricao,
                           Corredor = l.Corredor == null ? "-" : l.Corredor.Nome,
                           Tipo_de_Localização = l.TipoLocalizacao == 1 ? "Local de Separação" :
                                                  l.TipoLocalizacao == 2 ? "Doca de Entrada" :
                                                  l.TipoLocalizacao == 3 ? "Doca de Saída" :
                                                  l.TipoLocalizacao == 4 ? "Local de Entrada de Produção" :
                                                  l.TipoLocalizacao == 5 ? "Local de Inspeção" : "-",
                           l.Rack,
                           l.Prateleira,
                           Localização = l.LocalizacaoDesc,
                           Máximo_de_Paletes = l.MaxDePaletes,
                           l.Altura,
                           l.Largura,
                           l.Profundidade,
                           l.Volume,
                           Altura_Absoluta = l.AlturaAbsoluta,
                           Peso_Máximo = l.PesoMaximo,
                           Volume_Máximo = l.VolumeMaximo
                       }).OrderBy(o => o.Nome).ToList();

            DataTable dt = Util.Aplicacao.LINQToDataTable(rel);

            if (dt.Rows.Count > 0)
            {
                ERP.Relatorios.frmRelatorioGenerico frm = new ERP.Relatorios.frmRelatorioGenerico(dt);
                frm.Text = "Relatório de CFPS";
                frm.ShowDialog();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não existe dados para gerar o relatório!");
            }
        }
    }
}
