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
using ERP.BLL;
using ERP.ModelView;

namespace ERP
{
    public partial class frmComissaoVendedorContaCorrente : Form
    {
        ComissaoContaCorrenteDAL dal = new ComissaoContaCorrenteDAL();
        List<int> ListaComissaoSelecionada = new List<int>();
        decimal Soma = 0;
        public frmComissaoVendedorContaCorrente()
        {
            InitializeComponent(); 
        }
        
        private void CarregaGrid()
        {
            if(String.IsNullOrEmpty(cboVendedor.Text))
            {
                Util.Aplicacao.ShowMessage("Informe o vendedor");
                return;
            }
            DateTime DI;
            DateTime DF;
            try
            {
                DI = Convert.ToDateTime(txtDe.Text + " 00:00:00");
                DF = Convert.ToDateTime(txtAte.Text + " 23:59:00");
            }
            catch (Exception)
            {
                Util.Aplicacao.ShowMessage("Data inválida");
                return;
            }

            int idVendedor = Convert.ToInt32(cboVendedor.SelectedValue);
            int NotaFiscal = txtNF.Text == "" ? 0 : Convert.ToInt32(txtNF.Text);
            int TipoComissao = cboTipoComissao.Text == "" ? 0 : Convert.ToInt32(cboTipoComissao.SelectedValue);
            int status = Convert.ToInt32(cboStatus.SelectedValue);
            var lista = new ComissaoContaCorrenteDAL().getByParams(idVendedor, DI, DF, NotaFiscal, TipoComissao, status);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = lista;
            decimal totalBusca = 0;

            decimal comissaoTotal = 0;
            decimal choqueTotal = 0;


            foreach(var i in lista)
            {
                if(i.TipoComissao == "Choque")
                {
                    choqueTotal += i.ValorAPagar;
                }
                else
                {
                    comissaoTotal += i.ValorAPagar;
                }
                totalBusca += i.ValorAPagar;
            }
            lbTotal.Text = "";// "Total pagar: R$ " + totalBusca.ToString("N2");
            lbTotal.Text += " - Comissão: R$ " + comissaoTotal.ToString("N2");
            lbTotal.Text += " - Choque: R$ " + choqueTotal.ToString("N2");
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
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
            txtDe.Text = DateTime.Now.Subtract(TimeSpan.FromDays(30)).ToShortDateString();
            txtAte.Text = DateTime.Now.ToShortDateString();
            CarregaCombos();
            //CarregaGrid();
            VoltaPesquisa();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CarregaCombos()
        {
            cboVendedor.DataSource = new VendedorDAL().GetCombo();
            cboVendedor.DisplayMember = "Text";
            cboVendedor.ValueMember = "iValue";
            cboVendedor.SelectedIndex = -1;

            cboCondPagamento.DataSource = new CondicaoPagamentoDAL().GetCombo();
            cboCondPagamento.DisplayMember = "Text";
            cboCondPagamento.ValueMember = "iValue";
            cboCondPagamento.SelectedIndex = -1;

            cboMetodoPagamento.DataSource = new MetodoPagamentoDAL().GetCombo();
            cboMetodoPagamento.DisplayMember = "Text";
            cboMetodoPagamento.ValueMember = "iValue";
            cboMetodoPagamento.SelectedIndex = -1;
 

            List<ComboItem> tpcomissao = new List<ComboItem>();
            tpcomissao.Add(new ComboItem() { iValue = 0, Text = "" });
            tpcomissao.Add(new ComboItem() { iValue = 1, Text = "Comissão" });
            tpcomissao.Add(new ComboItem() { iValue = 2, Text = "Comissão Adicional" });
            tpcomissao.Add(new ComboItem() { iValue = 3, Text = "Choque" });
            cboTipoComissao.DataSource = tpcomissao;
            cboTipoComissao.DisplayMember = "Text";
            cboTipoComissao.ValueMember = "iValue";

            List<ComboItem> status = new List<ComboItem>();
            status.Add(new ComboItem() { iValue = 1, Text = "A pagar" });
            status.Add(new ComboItem() { iValue = 2, Text = "Pagos" });
            status.Add(new ComboItem() { iValue = 3, Text = "Todos" });
            cboStatus.DataSource = status;
            cboStatus.DisplayMember = "Text";
            cboStatus.ValueMember = "iValue";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void btnEfetuarPagamento_Click(object sender, EventArgs e)
        {
            

            Soma = 0;
            
            ListaComissaoSelecionada.Clear();
            dgv.EndEdit();
            foreach(DataGridViewRow dr in dgv.Rows)
            {
                if(Convert.ToBoolean(dr.Cells[1].Value))
                {
                    if(Convert.ToDecimal(dr.Cells[8].Value) != 0)
                    {
                        Soma += Convert.ToDecimal(dr.Cells[8].Value);
                        ListaComissaoSelecionada.Add(Convert.ToInt32(dr.Cells[0].Value));
                    }
                } 
            }

            if(Soma > 0)
            {
                pnlGera.Visible = true;
                pnlGera.Dock = DockStyle.Fill;
                dgv.Visible = false;
                dgv.Dock = DockStyle.None;
                lbMensagem.Text = "Deseja efetuar o pagamento de R$ " + Soma.ToString("N2") + " ao vendedor " + cboVendedor.Text;
                
            }

        }

        private void VoltaPesquisa()
        {
            pnlGera.Visible = false;
            pnlGera.Dock = DockStyle.None;
            dgv.Visible = true;
            dgv.Dock = DockStyle.Fill;
            cboMetodoPagamento.SelectedIndex = -1;
            cboCondPagamento.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VoltaPesquisa();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(cboCondPagamento.Text))
            {
                Util.Aplicacao.ShowMessage("Selecione a condição de pagamento");
                return;
            }

            if (String.IsNullOrEmpty(cboMetodoPagamento.Text))
            {
                Util.Aplicacao.ShowMessage("Selecione metodo de pagamento");
                return;
            }

            BLContasPagar blcp = new BLContasPagar();
            int IdVendedor = Convert.ToInt32(cboVendedor.SelectedValue);
            int condicaoPagamento = Convert.ToInt32(cboCondPagamento.SelectedValue);
            int MetodoPagamento = Convert.ToInt32(cboMetodoPagamento.SelectedValue);
            int IdContasPagar = 0;
            if(blcp.GeraAPartirComissaoVendedor(IdVendedor, condicaoPagamento, Soma, MetodoPagamento, out IdContasPagar))
            {
                if(IdContasPagar > 0)
                {
                    foreach (int i in ListaComissaoSelecionada)
                    {
                        ComissaoContaCorrente cc = dal.GetByID(i);
                        cc.ValorPago = cc.Comissao;
                        cc.ValorAPagar = 0;
                        cc.IdContasPagar = IdContasPagar;
                        dal.Update(cc);
                        dal.Save();
                    }

                    ///Gera o registro de baixa do pagamento
                    ComissaoContaCorrente cp = new ComissaoContaCorrente();
                    cp.IdVendedor = IdVendedor;
                    cp.DataNotaFiscal = DateTime.Now;
                    cp.ComissaoPercentual = 0;
                    cp.Comissao = 0;
                    cp.ValorAPagar = 0;
                    cp.ValorPago = Soma;
                    cp.Observacao = "Gerado contas a pagar";
                    cp.TipoLancamento = 3;
                    cp.TipoComissao = 1;
                    cp.IdContasPagar = IdContasPagar;
                    dal.Insert(cp);
                    dal.Save();

                    CarregaGrid();
                    VoltaPesquisa();
                } 
            }
            else
            {
                Util.Aplicacao.ShowMessage("Não foi possível efetuar sua solicitação. \n\rVerifique os cadastros e os dados do pagamento.");
            }

        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex > 2)
            //{
                //if (dgv.Rows[e.RowIndex].Cells[9].Value.ToString() == "Lançamento Manual")
                //{
                //    e.CellStyle.BackColor = Color.LightGray;
                //}


                if (dgv.Rows[e.RowIndex].Cells[9].Value.ToString() == "Pagamento efetuado")
                {
                    e.CellStyle.BackColor = Color.SkyBlue;
                }
           // }
            
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using (frmComissaoVendedorContaCorrenteCad frmCad = new frmComissaoVendedorContaCorrenteCad())
            {
                frmCad.ShowDialog();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dr in dgv.Rows)
            {
                dr.Cells[1].Value = checkBox1.Checked;
            }
        }

        private void dgv_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string tag = (sender as RadioButton).Tag.ToString();
            if(tag == "0")
            {
                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    if(dr.Cells["Tipo"].Value.ToString() != "Choque")
                    {
                        dr.Cells[1].Value = true;
                    } 
                }
            }

            if (tag == "1")
            {
                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    if (dr.Cells["Tipo"].Value.ToString() == "Choque")
                    {
                        dr.Cells[1].Value = true;
                    }
                }
            }

            if (tag == "2")
            {
                foreach (DataGridViewRow dr in dgv.Rows)
                { 
                    dr.Cells[1].Value = false;   
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cboVendedor.Text))
            {
                Util.Aplicacao.ShowMessage("Informe o vendedor");
                return;
            }
            DateTime DI;
            DateTime DF;
            try
            {
                DI = Convert.ToDateTime(txtDe.Text + " 00:00:00");
                DF = Convert.ToDateTime(txtAte.Text + " 23:59:00");
            }
            catch (Exception)
            {
                Util.Aplicacao.ShowMessage("Data inválida");
                return;
            }

            int idVendedor = Convert.ToInt32(cboVendedor.SelectedValue);
            int NotaFiscal = txtNF.Text == "" ? 0 : Convert.ToInt32(txtNF.Text);
            int TipoComissao = cboTipoComissao.Text == "" ? 0 : Convert.ToInt32(cboTipoComissao.SelectedValue);
            int status = Convert.ToInt32(cboStatus.SelectedValue);

            List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "de", Valor = DI.ToString("yyyyMMdd") });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "ate", Valor = DF.ToString("yyyyMMdd") });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "IdVendedor", Valor = idVendedor.ToString() });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "NotaFiscal", Valor = NotaFiscal == 0 ? "" : NotaFiscal.ToString() });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "TipoComissao", Valor = TipoComissao.ToString() });
            FiltrosRelatorio.Add(new FiltroRelatorio() { Nome = "Status", Valor = status.ToString() });

            CrystalReports.frmCrystalReportViewer frmv = new CrystalReports.frmCrystalReportViewer("ComissaoVendedor");
            frmv.FiltrosRelatorio = FiltrosRelatorio;
            frmv.ShowDialog();
        }
    }
}
