using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmContasPagarAberto : RibbonForm
    {
        public ContasPagarDAL pagDal;
        ContasPagarAberto c = new ContasPagarAberto();
        public ContasPagar cp;

        public frmContasPagarAberto(ContasPagarAberto pC)
        {
            c = pC;
            InitializeComponent();
        }

        public frmContasPagarAberto()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            if (c.IdContasPagar == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaCombos()
        {
            cboCodigoJuros.DataSource = new CodigoJurosDAL().GetCombo();
            cboCodigoJuros.DisplayMember = "Text";
            cboCodigoJuros.ValueMember = "iValue";
            cboCodigoJuros.SelectedIndex = -1;

            cboCodigoMulta.DataSource = new CodigoMultasDAL().GetCombo();
            cboCodigoMulta.DisplayMember = "Text";
            cboCodigoMulta.ValueMember = "iValue";
            cboCodigoMulta.SelectedIndex = -1;

            cboContaBancariaFornecedor.DataSource = new FornecedorDAL().GetContasBancarias(Convert.ToInt32(cp.IdFornecedor));
            cboContaBancariaFornecedor.DisplayMember = "Text";
            cboContaBancariaFornecedor.ValueMember = "iValue";
            cboContaBancariaFornecedor.SelectedIndex = -1;
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            cboCodigoJuros.SelectedValue = c.IdCodigoJuros == null ? 0 : c.IdCodigoJuros;
            cboCodigoMulta.SelectedValue = c.IdCodigoMulta == null ? 0 : c.IdCodigoMulta;
            cboContaBancariaFornecedor.SelectedValue = c.IdFornecedorContaBancaria == null ? 0 : c.IdFornecedorContaBancaria;
            chkCalculaRetencao.Checked = Convert.ToBoolean(c.Retencao);
            txtDesconto.Text = c.Desconto == null ? "" : c.Desconto.ToString();
            txtDescontoAVista.Text = c.ValorDescontoVista == null ? "" : c.ValorDescontoVista.ToString();
            txtDocumentoBancario.Text = c.NumeroDocumentoBancario == null ? "" : c.NumeroDocumentoBancario.ToString();
            txtHistorico.Text = c.Historico == null ? "" : c.Historico.ToString();
            txtNumeroParcela.Text = c.NumeroParcela == null ? "" : c.NumeroParcela.ToString();
            txtNumeroParcelaOriginal.Text = c.NumeroParcelaOriginal == null ? "" : c.NumeroParcelaOriginal.ToString();
            txtNumeroRemessa.Text = c.NumeroRemessa == null ? "" : c.NumeroRemessa.ToString();
            txtValorJuros.Text = c.ValorJuros == null ? "" : c.ValorJuros.ToString();
            txtValorLiquido.Text = c.ValorLiquido == null ? "" : c.ValorLiquido.ToString();
            txtValorMulta.Text = c.ValorMulta == null ? "" : c.ValorMulta.ToString();
            txtValorTitulo.Text = c.ValorTitulo == null ? "" : c.ValorTitulo.ToString();
            txtVencimento.Text = c.Vencimento == null ? "" : c.Vencimento.ToString();
            txtVencimentoOriginal.Text = c.VencimentoOriginal == null ? "" : c.VencimentoOriginal.ToString();
            cboTipoCodigoBarras.Text = c.TipoCodigoBarras;
            txtCodigoBarras.Text = c.CodigoBarras;
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }



        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new ContasPagarAberto();
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    c.Retencao = chkCalculaRetencao.Checked;
                    c.NumeroDocumentoBancario = null;
                    c.Historico = null;
                    c.IdCodigoJuros = null;
                    c.IdCodigoMulta = null;
                    c.IdFornecedorContaBancaria = null;
                    c.NumeroParcela = null;
                    c.NumeroParcelaOriginal = null;
                    c.NumeroRemessa = null;
                    c.Vencimento = null;
                    c.VencimentoOriginal = null;
                    c.Desconto = 0;
                    c.ValorDescontoVista = 0;
                    c.ValorJuros = 0;
                    c.ValorLiquido = 0;
                    c.ValorMulta = 0;
                    if (!String.IsNullOrEmpty(cboCodigoJuros.Text)) c.IdCodigoJuros = Convert.ToInt32(cboCodigoJuros.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoMulta.Text)) c.IdCodigoMulta = Convert.ToInt32(cboCodigoMulta.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaBancariaFornecedor.Text)) c.IdFornecedorContaBancaria = Convert.ToInt32(cboContaBancariaFornecedor.SelectedValue);
                    if (!String.IsNullOrEmpty(txtDesconto.Text)) c.Desconto = Convert.ToDecimal(txtDesconto.Text);
                    if (!String.IsNullOrEmpty(txtDescontoAVista.Text)) c.ValorDescontoVista = Convert.ToDecimal(txtDescontoAVista.Text);
                    if (!String.IsNullOrEmpty(txtDocumentoBancario.Text)) c.NumeroDocumentoBancario = txtDocumentoBancario.Text;
                    if (!String.IsNullOrEmpty(txtHistorico.Text)) c.Historico = txtHistorico.Text;
                    if (!String.IsNullOrEmpty(txtNumeroParcela.Text)) c.NumeroParcela = Convert.ToInt32(txtNumeroParcela.Text);
                    if (!String.IsNullOrEmpty(txtNumeroParcelaOriginal.Text)) c.NumeroParcelaOriginal = Convert.ToInt32(txtNumeroParcelaOriginal.Text);
                    if (!String.IsNullOrEmpty(txtNumeroRemessa.Text)) c.NumeroRemessa = txtNumeroRemessa.Text;
                    if (!String.IsNullOrEmpty(txtValorJuros.Text)) c.ValorJuros = Convert.ToDecimal(txtValorJuros.Text);
                    if (!String.IsNullOrEmpty(txtValorLiquido.Text)) c.ValorLiquido = Convert.ToDecimal(txtValorLiquido.Text);
                    if (!String.IsNullOrEmpty(txtValorMulta.Text)) c.ValorMulta = Convert.ToDecimal(txtValorMulta.Text);
                    if (!String.IsNullOrEmpty(txtValorTitulo.Text)) c.ValorTitulo = Convert.ToDecimal(txtValorTitulo.Text);
                    if (!String.IsNullOrEmpty(txtVencimento.Text)) c.Vencimento = Convert.ToDateTime(txtVencimento.Text);
                    if (!String.IsNullOrEmpty(txtVencimentoOriginal.Text)) c.VencimentoOriginal = Convert.ToDateTime(txtVencimentoOriginal.Text);
                    c.TipoCodigoBarras = cboTipoCodigoBarras.Text;
                    c.CodigoBarras = txtCodigoBarras.Text;


                    //Monta o valor liquido
                    c.ValorLiquido = c.ValorTitulo - (Convert.ToDecimal(c.Desconto) + Convert.ToDecimal(c.ValorDescontoVista)) + (Convert.ToDecimal(c.ValorMulta) + Convert.ToDecimal(c.ValorJuros));
                    c.IdContasPagar = cp.IdContasPagar;
                    if (c.IdContasPagarAberto == 0)
                    {
                        pagDal.EmAbertoDal.Insert(c);
                    }
                    else
                    {
                        pagDal.EmAbertoDal.Update(c);
                    }

                    pagDal.EmAbertoDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    pagDal.CalculaPagamento(cp);
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
            else
            {
                Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == System.Windows.Forms.DialogResult.Yes)
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = c.IdContasPagarAberto;
                pagDal.EmAbertoDal.Delete(id);
                pagDal.EmAbertoDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CarregaGrid()
        {
            var lista = pagDal.GetBaixas(c.IdContasPagarAberto);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
            try
            {
                //Calcula o valor pago
                decimal Soma = 0;
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    Soma += Convert.ToDecimal(dr.Cells[5].Value);
                }
                txtValorPago.Text = Soma.ToString();

                if (Soma == c.ValorLiquido)
                {
                    if (!c.Liquidada)
                    {
                        c.Liquidada = true;
                        pagDal.EmAbertoDal.Update(c);
                        pagDal.EmAbertoDal.Save();
                    }
                }
            }
            catch { }


        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (c.Liquidada)
            {
                Util.Aplicacao.ShowMessage("O vencimento foi totalmente pago, não é possível efetuar mais baixas.");
                return;
            }

            if (c.IdContasPagarAberto == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados antes de continuar");
                return;
            }

            //Verifica os valores pagos
            decimal Soma = 0;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                Soma += Convert.ToDecimal(dr.Cells[5].Value);
            }

            ContasPagarBaixa ci = new ContasPagarBaixa();
            ci.Valor = c.ValorLiquido - Soma;
            ci.IdContasPagarAberto = c.IdContasPagarAberto;
            using (frmContasPagarBaixa bxcad = new frmContasPagarBaixa(ci))
            {
                bxcad.pagDal = pagDal;
                bxcad.cp = cp;
                bxcad.ShowDialog();
                CarregaGrid();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
                ContasPagarBaixa ci = pagDal.BaixasDal.GetByID(id);
                using (frmContasPagarBaixa bxcad = new frmContasPagarBaixa(ci))
                {
                    bxcad.pagDal = pagDal;
                    bxcad.cp = cp;
                    bxcad.ShowDialog();
                    CarregaGrid();
                }
            }
        }




    }
}

