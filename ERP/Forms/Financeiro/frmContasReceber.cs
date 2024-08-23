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
using ERP.Financeiro;
using ERP.Relatorios;
using ERP.ModelView;
using ERP.Forms.Financeiro;

namespace ERP
{
    public partial class frmContasReceber : Form
    {
        ContasReceberDAL dal = new ContasReceberDAL();
        BoletoBancarioDAL bDal = new BoletoBancarioDAL();
        //variaveis de seleção do boleto e sua conta
        int IdContaBoleto = 0;
        bool MantemContaBoleto = false;


        public frmContasReceber()
        {
            InitializeComponent(); 
        }
        
        private void CarregaGrid()
        {
            int Cliente = String.IsNullOrEmpty(cboCliente.Text) ? 0 : Convert.ToInt32(cboCliente.SelectedValue);
            string strCliente = txtFornecedor.Text;
            DateTime VencimentoDe = Convert.ToDateTime(txtVencimentoDe.Text);
            DateTime VencimentoAte = Convert.ToDateTime(txtVencimentoAte.Text);
            string Situacao = cboSituacao.SelectedValue.ToString();
            decimal? ValorDe = -1;
            if (!String.IsNullOrEmpty(txtValor.Text)) ValorDe = Convert.ToDecimal(txtValor.Text);
            decimal? ValorAte = -1;
            if (!String.IsNullOrEmpty(txtValorAte.Text)) ValorAte = Convert.ToDecimal(txtValorAte.Text);
            var lista = dal.getByParams(Cliente, strCliente, VencimentoDe, VencimentoAte, Situacao, ValorDe, ValorAte);
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
                    ContasReceber c = dal.GetByID(id);
                    frmContasReceberCad cad = new frmContasReceberCad(c);
                    cad.dal = dal;
                    cad.Show();
                    CarregaGrid();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmContasReceberCad cad = new frmContasReceberCad(new ContasReceber());
            cad.dal = dal;
            cad.Show();
            CarregaGrid();
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
            txtVencimentoDe.Text = DateTime.Now.ToShortDateString();
            txtVencimentoAte.Text = DateTime.Now.AddMonths(6).ToShortDateString();
            CarregaCombos(); 
            CarregaGrid();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CarregaCombos()
        {
            cboCliente.DataSource = new ClienteDAL().GetCombo(Util.Util.GetAppSettings("IdEmpresa"));
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;


            List<ComboItem> situacao = new List<ComboItem>();
            situacao.Add(new ComboItem() { iValue = 1, Text = "A Receber" });
            situacao.Add(new ComboItem() { iValue = 2, Text = "Recebido" });
            cboSituacao.DataSource = situacao;
            cboSituacao.DisplayMember = "Text";
            cboSituacao.ValueMember = "iValue"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGerarBoleto_Click(object sender, EventArgs e)
        {

            if (dgv.RowCount == 0)
            {
                return;
            }


            if(!MantemContaBoleto || IdContaBoleto == 0)
            {
                frmSelecionaContaBoleto frm = new frmSelecionaContaBoleto();
                frm.ShowDialog();

                IdContaBoleto = frm.IdBanco;
                MantemContaBoleto = frm.Continuar;
            }
            int idConta = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString());
            BLL.BLBoletoBancario bl = new BLL.BLBoletoBancario();
            bl.dal = bDal;
            bl.GeraBoletoContasReceber(idConta, IdContaBoleto);
            frmBoletoBancario frmb = new frmBoletoBancario();
            frmb.IdContasReceber = idConta;
            frmb.ShowDialog();


            //var v = new ContasReceberAbertoDAL().getProximoVencimento(idConta);
            //BoletoBancario boleto;
            //if (v != null)
            //{
            //    boleto = bDal.getBoletoGerado(idConta, v.IdContasReceberAberto);
            //    if(boleto == null)
            //    {
            //        boleto = 
            //    }
            //    frmBoletoBancarioCad bol = new frmBoletoBancarioCad(boleto);
            //    bol.dal = bDal;
            //    bol.pDal = dal;
            //    bol.ShowDialog();
            //    CarregaGrid();
            //} 
            //else
            //{
            //    Util.Aplicacao.ShowMessage("Não é possível gerar boleto bancário para este título!");
            //}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Cliente = String.IsNullOrEmpty(cboCliente.Text) ? 0 : Convert.ToInt32(cboCliente.SelectedValue);
            string strCliente = txtFornecedor.Text;
            DateTime VencimentoDe = Convert.ToDateTime(txtVencimentoDe.Text);
            DateTime VencimentoAte = Convert.ToDateTime(txtVencimentoAte.Text);
            string Situacao = cboSituacao.SelectedValue.ToString();

            List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "de", Valor = VencimentoDe.ToString("yyyyMMdd") });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "ate", Valor = VencimentoAte.ToString("yyyyMMdd") });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "IdCliente", Valor = Cliente.ToString() });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Cliente", Valor = strCliente.ToString() });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Situacao", Valor = Situacao.ToString() });

            CrystalReports.frmCrystalReportViewer frmv = new CrystalReports.frmCrystalReportViewer("ContasReceberList");
            frmv.FiltrosRelatorio = FiltrosRelatorio;
            frmv.ShowDialog();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            frmRelContasReceberFiltro frmf = new frmRelContasReceberFiltro();
            frmf.ShowDialog();
        }
    }
}
