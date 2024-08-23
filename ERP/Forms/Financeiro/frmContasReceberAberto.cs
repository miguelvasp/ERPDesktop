using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmContasReceberAberto : RibbonForm
    {
        public ContasReceberDAL pagDal;
        ContasReceberAberto c = new ContasReceberAberto();
        public ContasReceber cp;

        public frmContasReceberAberto(ContasReceberAberto pC)
        {
            c = pC;
            InitializeComponent();
        }

        public frmContasReceberAberto()
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
            if (c.IdContasReceber == 0)
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
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }



        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new ContasReceberAberto();
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


                    //Monta o valor liquido
                    c.ValorLiquido = c.ValorTitulo - (Convert.ToDecimal(c.Desconto) + Convert.ToDecimal(c.ValorDescontoVista)) + (Convert.ToDecimal(c.ValorMulta) + Convert.ToDecimal(c.ValorJuros));
                    c.IdContasReceber = cp.IdContasReceber;
                    if (c.IdContasReceberAberto == 0)
                    {
                        pagDal.EmAbertoDal.Insert(c);
                    }
                    else
                    {
                        pagDal.EmAbertoDal.Update(c);
                    }

                    pagDal.EmAbertoDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    pagDal.CalculaRecebimento(cp);
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
                int id = (int)c.IdContasReceberAberto;
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
            if (c.IdContasReceberAberto == null) return;

            try
            {
                var lista = pagDal.GetBaixas((int)c.IdContasReceberAberto);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = lista;
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

            if (c.IdContasReceberAberto == 0)
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

            ContasReceberBaixa ci = new ContasReceberBaixa();
            ci.Valor = c.ValorLiquido - Soma;
            ci.IdContasReceberAberto = c.IdContasReceberAberto;
            using (frmContasReceberBaixa bxcad = new frmContasReceberBaixa(ci))
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
                ContasReceberBaixa ci = pagDal.BaixasDal.GetByID(id);
                using (frmContasReceberBaixa bxcad = new frmContasReceberBaixa(ci))
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

