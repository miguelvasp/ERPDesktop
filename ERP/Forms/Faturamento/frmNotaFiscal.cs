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
using ERP.Fiscal;
using ERP.Vendas;
using ERP.Faturamento;
using ERP.Forms.Faturamento;
using ERP.ModelView;

namespace ERP
{
    public partial class frmNotaFiscal : Form
    {
        NotaFiscalDAL dal = new NotaFiscalDAL();
        NotaFiscalItemDAL iDal = new NotaFiscalItemDAL();
        NotaFiscalVencimentosDAL vDal = new NotaFiscalVencimentosDAL();
        RecebimentoDAL rDal = new RecebimentoDAL();


        public frmNotaFiscal()
        {
            InitializeComponent(); 
        }
        
        private void CarregaGrid()
        {
            DateTime de = Convert.ToDateTime(txtEmissaoDe.Text + " 00:00:00");
            DateTime ate = Convert.ToDateTime(txtEmissaoAte.Text + " 23:59:00");
            int Tipo = Convert.ToInt32(cboTPNf.SelectedValue);
            int destinatario = String.IsNullOrEmpty(cboDestinatario.Text) ? 0 : Convert.ToInt32(cboDestinatario.SelectedValue);
            var lista = dal.getByParams(de, ate, Tipo, destinatario);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    int iTipoDocumento = Convert.ToInt32(cboTPNf.SelectedValue);
                    NotaFiscal n = dal.GetByID(id);
                    frmNotaFiscalCad cad = new frmNotaFiscalCad(n, iTipoDocumento);
                    cad.dal = dal;
                    cad.iDal = iDal;
                    cad.vDal = vDal;
                    cad.rDal = rDal;
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
            frmContasPagarCad cad = new frmContasPagarCad(new ContasPagar());
            
            cad.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            
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
            txtEmissaoDe.Text = DateTime.Now.Subtract(TimeSpan.FromDays(30)).ToShortDateString();
            txtEmissaoAte.Text = DateTime.Now.ToShortDateString();
            CarregaCombos();
            


           // CarregaGrid();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CarregaCombos()
        {
            List<ComboItem> tpNF = new List<ComboItem>();
            tpNF.Add(new ComboItem() { iValue = 6, Text = "Nota Fiscal Vendas" });
            tpNF.Add(new ComboItem() { iValue = 3, Text = "Nota Fiscal Entrada" });
            tpNF.Add(new ComboItem() { iValue = 8, Text = "Nota Fiscal Devolução" });

            cboTPNf.DataSource = tpNF;
            cboTPNf.DisplayMember = "Text";
            cboTPNf.ValueMember = "iValue"; 

 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void notaFiscalEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelecionaRecebimentos frmSelReceb = new frmSelecionaRecebimentos();
            frmSelReceb.dal = dal;
            frmSelReceb.iDal = iDal;
            frmSelReceb.vDal = vDal;
            frmSelReceb.rDal = rDal;
            frmSelReceb.ShowDialog();

            if(frmSelReceb.NF != null)
            {
                frmNotaFiscalCad cad = new frmNotaFiscalCad(frmSelReceb.NF, 3);
                cad.dal = dal;
                cad.iDal = iDal;
                cad.vDal = vDal;
                cad.rDal = rDal;
                cad.ShowDialog();
            }
        }

        private void notaFiscalVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPedidoVendaSeparacaoFat pvSep = new frmPedidoVendaSeparacaoFat();
            pvSep.dal = dal;
            pvSep.iDal = iDal;
            pvSep.vDal = vDal;
            pvSep.ShowDialog();

            if (pvSep.NF != null)
            {
                frmNotaFiscalCad cad = new frmNotaFiscalCad(pvSep.NF, 6);
                cad.dal = dal;
                cad.iDal = iDal;
                cad.vDal = vDal;
                cad.rDal = rDal;
                cad.ShowDialog();
            }
        }

        private List<int> MontaSelecao()
        {
            List<int> Notas = new List<int>();
            foreach(DataGridViewRow dr in dgv.Rows)
            {
                if(Convert.ToBoolean(dr.Cells[1].Value))
                {
                    int id = Convert.ToInt32(dr.Cells[0].Value);
                    Notas.Add(id);
                }
            }
            return Notas;
        }

        private void ExecutarEventoNFe(string Evento)
        {
            dgv.EndEdit();
            List<int> NotasSelecionadas = new List<int>();
            foreach (DataGridViewRow dr in dgv.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[1].Value))
                {
                    int id = Convert.ToInt32(dr.Cells[0].Value);
                    NotasSelecionadas.Add(id);
                }
            }
            using (frmNFeProcessa frm = new frmNFeProcessa(NotasSelecionadas, Evento))
            {
                frm.nfDal = dal;
                frm.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ExecutarEventoNFe("Salvar");
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            ExecutarEventoNFe("Validar");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExecutarEventoNFe("Transmitir");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ExecutarEventoNFe("Consultar");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ExecutarEventoNFe("Impressao");
            //dgv.EndEdit();
            //List<int> NotasSelecionadas = new List<int>();
            //foreach (DataGridViewRow dr in dgv.Rows)
            //{
            //    if (Convert.ToBoolean(dr.Cells["CheckBox"].Value))
            //    {
            //        int id = Convert.ToInt32(dr.Cells[0].Value);
            //        NotasSelecionadas.Add(id);
            //    }
            //}

            //if(NotasSelecionadas.Count == 0)
            //{
            //    Util.Aplicacao.ShowMessage("Nenhuma nota foi selecionada");
            //    return;
            //}

            //using (frmSelecionaDanfe fs = new frmSelecionaDanfe(NotasSelecionadas))
            //{
            //    fs.ShowDialog();
            //}
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            dgv.EndEdit();
            List<int> NotasSelecionadas = new List<int>();
            foreach (DataGridViewRow dr in dgv.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["CheckBox"].Value))
                {
                    int id = Convert.ToInt32(dr.Cells[0].Value);
                    NotasSelecionadas.Add(id);
                }
            }

            frmNotaFiscalEnviaEmail frmemail = new frmNotaFiscalEnviaEmail(NotasSelecionadas);
            frmemail.ShowDialog();

        }

        private void notaFiscalDevoluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDevolucao frmd = new frmDevolucao();
            frmd.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime de = Convert.ToDateTime(txtEmissaoDe.Text + " 00:00:00");
            DateTime ate = Convert.ToDateTime(txtEmissaoAte.Text + " 23:59:00");
            int Tipo = Convert.ToInt32(cboTPNf.SelectedValue);
            int destinatario = String.IsNullOrEmpty(cboDestinatario.Text) ? 0 : Convert.ToInt32(cboDestinatario.SelectedValue);
          
            List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "de", Valor = de.ToString("yyyyMMdd") });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "ate", Valor = ate.ToString("yyyyMMdd") });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "IdDocumento", Valor = Tipo.ToString() });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "IdDestinatario", Valor = destinatario.ToString() });
             
            CrystalReports.frmCrystalReportViewer frmv = new CrystalReports.frmCrystalReportViewer("NotaFiscalLista");
            frmv.FiltrosRelatorio = FiltrosRelatorio;
            frmv.ShowDialog();
        }

        private void notaFiscalEntradaAPartirDoXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLeituraXMLEntrada frml = new frmLeituraXMLEntrada();
            frml.dal = dal;
            frml.iDal = iDal;
            frml.vdal = vDal;
            frml.ShowDialog();
        }
    }
}
