using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmContasReceberCad : RibbonForm
    {
        public ContasReceberDAL dal = new ContasReceberDAL();
        ContasReceberAbertoDAL aDal = new ContasReceberAbertoDAL();
        ContasReceber c = new ContasReceber();

        public frmContasReceberCad(ContasReceber pC)
        {
            c = pC; 
            InitializeComponent();
            
        }

        public frmContasReceberCad()
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
                c = dal.CalculaRecebimento(c);
                CarregaDados();
            }
        }

        private void CarregaCombos()
        {
            cboCliente.DataSource = new ClienteDAL().GetCombo(Util.Util.GetAppSettings("IdEmpresa"));
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;

            cboCondicaoPagamento.DataSource = new CondicaoPagamentoDAL().GetCombo();
            cboCondicaoPagamento.DisplayMember = "Text";
            cboCondicaoPagamento.ValueMember = "iValue";
            cboCondicaoPagamento.SelectedIndex = -1;

            cboMoeda.DataSource = new MoedaDAL().GetCombo();
            cboMoeda.DisplayMember = "Text";
            cboMoeda.ValueMember = "iValue";
            cboMoeda.SelectedIndex = -1;
             
            List<ComboItem> cStatus = new List<ComboItem>();
            cStatus.Add(new ComboItem() { iValue = 1, Text = "Faturado"});
            cStatus.Add(new ComboItem() { iValue = 2, Text = "Liquidado"});
            cStatus.Add(new ComboItem() { iValue = 3, Text = "Protestado"});
            cboStatus.DataSource = cStatus;
            cboStatus.DisplayMember = "Text";
            cboStatus.ValueMember = "iValue";
            cboStatus.SelectedIndex = -1;

            cboMetodoPagamento.DataSource = new MetodoPagamentoDAL().GetCombo();
            cboMetodoPagamento.DisplayMember = "Text";
            cboMetodoPagamento.ValueMember = "iValue";
            cboMetodoPagamento.SelectedIndex = -1;

            cboEspecificacaoPagamento.DataSource = new EspecificacaoPagamentoDAL().GetCombo();
            cboEspecificacaoPagamento.DisplayMember = "Text";
            cboEspecificacaoPagamento.ValueMember = "iValue";
            cboEspecificacaoPagamento.SelectedIndex = -1;

            cboPerfilCliente.DataSource = new PerfilClienteDAL().GetCombo();
            cboPerfilCliente.DisplayMember = "Text";
            cboPerfilCliente.ValueMember = "iValue";
            cboPerfilCliente.SelectedIndex = -1; 

            List<ComboItem> tptrans = new List<ComboItem>();
            tptrans.Add(new ComboItem() { iValue = 1, Text = "Nota Fiscal"});
            tptrans.Add(new ComboItem() { iValue = 2, Text = "Carta de Cobrança"}); 
            tptrans.Add(new ComboItem() { iValue = 4, Text = "Cancelamento"});
            tptrans.Add(new ComboItem() { iValue = 5, Text = "Liquidação"}); 
            tptrans.Add(new ComboItem() { iValue = 6, Text = "Desconto a vista"});
            tptrans.Add(new ComboItem() { iValue = 7, Text = "Totalizado"});

            cboTipoTransacao.DataSource = tptrans;
            cboTipoTransacao.DisplayMember = "Text";
            cboTipoTransacao.ValueMember = "iValue";
            cboTipoTransacao.SelectedIndex = -1;

            cboContaContabil.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabil.DisplayMember = "Text";
            cboContaContabil.ValueMember = "iValue";
            cboContaContabil.SelectedIndex = -1; 

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
            cboContaContabil.SelectedValue = c.IdContaContabil == null ? 0 : c.IdContaContabil;
            cboEspecificacaoPagamento.SelectedValue = c.IdEspecificacaoPagamento == null ? 0 : c.IdEspecificacaoPagamento;
            cboCliente.SelectedValue = c.IdCliente == null ? 0 : c.IdCliente;
            cboMetodoPagamento.SelectedValue = c.IdMetodoPagamento == null ? 0 : c.IdMetodoPagamento;
            cboMoeda.SelectedValue = c.IdMoeda == null ? 0 : c.IdMoeda;
            cboPerfilCliente.SelectedValue = c.IdPerfilCliente == null ? 0 : c.IdPerfilCliente;
            cboStatus.SelectedValue = c.Status == null ? 0 : c.Status;
            cboCondicaoPagamento.SelectedValue = c.IdCondicaoPagamento == null ? 0 : c.IdCondicaoPagamento;
            cboTipoTransacao.SelectedValue = c.TipoTransacao == null ? 0 : c.TipoTransacao;
            chkCalculaRetencao.Checked = Convert.ToBoolean(c.CalculaRetencao);
            txtAcrescimo.Text = c.Acrecimo == null ? "" : c.Acrecimo.ToString();
            txtDataDocumento.Text = c.DataDocumento == null ? "" : c.DataDocumento.ToString();
            txtDesconto.Text = c.Desconto == null ? "" : c.Desconto.ToString();
            txtDocumento.Text = c.Documento == null ? "" : c.Documento.ToString();
            txtEmissao.Text = c.Emissao == null ? "" : c.Emissao.ToString();
            txtIdContasPagar.Text = c.IdContasReceber == null ? "" : c.IdContasReceber.ToString(); 
            txtOBS.Text = c.Observacao == null ? "" : c.Observacao.ToString(); 
            txtSaldo.Text = c.Saldo == null ? "" : c.Saldo.ToString();
            txtValorLiquido.Text = c.ValorLiquido == null ? "" : c.ValorLiquido.ToString();
            txtValorPago.Text = c.ValorPago == null ? "" : c.ValorPago.ToString(); 
            txtValorTitulo.Text = c.ValorTitulo == null ? "" : c.ValorTitulo.ToString();
            txtVencimento.Text = c.Vencimento == null ? "" : c.Vencimento.ToString();
            txtVencimentoOriginal.Text = c.VencimentoOriginal == null ? "" : c.VencimentoOriginal.ToString(); 
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }



        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new ContasReceber();
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
                    c.Acrecimo = null;
                    c.DataDocumento = null;
                    c.Desconto = 0;
                    c.Documento = null;
                    c.Emissao = null;
                    c.IdContaContabil = null; 
                    c.IdEspecificacaoPagamento = null;
                    c.IdCliente = null;
                    c.IdMetodoPagamento = null;
                    c.IdMoeda = null;
                    c.IdPerfilCliente = null;
                    c.Status = null;
                    c.TipoTransacao = null;  
                    c.Saldo = null;
                    c.ValorLiquido = null;
                    c.ValorPago = null; 
                    c.ValorTitulo = null;
                    c.Vencimento = null;
                    c.VencimentoOriginal = null;
                    c.CalculaRetencao = chkCalculaRetencao.Checked;
                    if (!String.IsNullOrEmpty(cboContaContabil.Text)) c.IdContaContabil = Convert.ToInt32(cboContaContabil.SelectedValue);
                    if (!String.IsNullOrEmpty(cboEspecificacaoPagamento.Text)) c.IdEspecificacaoPagamento = Convert.ToInt32(cboEspecificacaoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCliente.Text)) c.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMetodoPagamento.Text)) c.IdMetodoPagamento = Convert.ToInt32(cboMetodoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMoeda.Text)) c.IdMoeda = Convert.ToInt32(cboMoeda.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPerfilCliente.Text)) c.IdPerfilCliente = Convert.ToInt32(cboPerfilCliente.SelectedValue);
                    if (!String.IsNullOrEmpty(cboStatus.Text)) c.Status = Convert.ToInt32(cboStatus.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoTransacao.Text)) c.TipoTransacao = Convert.ToInt32(cboTipoTransacao.SelectedValue);
                    if (!String.IsNullOrEmpty(txtAcrescimo.Text)) c.Acrecimo = Convert.ToDecimal(txtAcrescimo.Text);
                    if (!String.IsNullOrEmpty(txtDataDocumento.Text)) c.DataDocumento = Convert.ToDateTime(txtDataDocumento.Text);
                    if (!String.IsNullOrEmpty(txtDesconto.Text)) c.Desconto = Convert.ToDecimal(txtDesconto.Text);
                    if (!String.IsNullOrEmpty(txtDocumento.Text)) c.Documento = txtDocumento.Text;
                    if (!String.IsNullOrEmpty(txtEmissao.Text)) c.Emissao = Convert.ToDateTime(txtEmissao.Text);  
                    if (!String.IsNullOrEmpty(txtOBS.Text)) c.Observacao = txtOBS.Text; 
                    if (!String.IsNullOrEmpty(txtSaldo.Text)) c.Saldo = Convert.ToDecimal(txtSaldo.Text);
                    if (!String.IsNullOrEmpty(txtValorLiquido.Text)) c.ValorLiquido = Convert.ToDecimal(txtValorLiquido.Text);
                    if (!String.IsNullOrEmpty(txtValorPago.Text)) c.ValorPago = Convert.ToDecimal(txtValorPago.Text); 
                    if (!String.IsNullOrEmpty(txtValorTitulo.Text)) c.ValorTitulo = Convert.ToDecimal(txtValorTitulo.Text);
                    if (!String.IsNullOrEmpty(txtVencimento.Text)) c.Vencimento = Convert.ToDateTime(txtVencimento.Text);
                    if (!String.IsNullOrEmpty(txtVencimentoOriginal.Text)) c.VencimentoOriginal = Convert.ToDateTime(txtVencimentoOriginal.Text);
                    if (!String.IsNullOrEmpty(cboCondicaoPagamento.Text)) c.IdCondicaoPagamento = Convert.ToInt32(cboCondicaoPagamento.SelectedValue);

                    if (c.IdContasReceber == 0)
                    {
                        dal.Insert(c);
                    }
                    else
                    {
                        dal.Update(c);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    int Contador = 0;
                    //Verifica se o pagamento já possui vencimentos, caso possua ele gera os vencimentos automaticamente conforme a condiçao de pagamento
                    var lista = dal.GetContasEmAberto(c.IdContasReceber);
                    if (lista == null || lista.Count == 0)
                    {
                        var vencimentos = new CondicaoPagamentoDAL().CalculaVencimentos(Convert.ToInt32(c.IdCondicaoPagamento), Convert.ToDecimal(c.ValorLiquido), Convert.ToDateTime(c.Emissao));
                        foreach (var v in vencimentos)
                        {
                            Contador++;
                            ContasReceberAberto pa = new ContasReceberAberto();
                            pa.IdContasReceber = c.IdContasReceber;
                            pa.Vencimento = v.Data;
                            pa.VencimentoOriginal = pa.Vencimento;
                            pa.NumeroParcela = Contador;
                            pa.NumeroParcelaOriginal = Contador;
                            pa.ValorTitulo = v.Valor;
                            pa.Desconto = 0;
                            pa.ValorJuros = 0;
                            pa.ValorMulta = 0;
                            pa.ValorDescontoVista = 0;
                            pa.ValorLiquido = v.Valor;
                            aDal.Insert(pa);
                            aDal.Save();
                        }
                    }

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
                int id = c.IdContasReceber;
                dal.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CarregaGrid()
        {
            var lista = dal.GetContasEmAberto(c.IdContasReceber);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
             {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value);
                ContasReceberAberto ca = dal.EmAbertoDal.GetByID(id);
                using (frmContasReceberAberto frmCadAberto = new frmContasReceberAberto(ca))
                {
                    frmCadAberto.pagDal = dal;
                    frmCadAberto.cp = c;
                    frmCadAberto.ShowDialog();
                    c = dal.CalculaRecebimento(c);
                    CarregaDados();
                    CarregaGrid();
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void CalculaValores()
        {
            decimal ValorTitulo = Convert.ToDecimal(txtValorTitulo.Text);
            decimal Desconto = String.IsNullOrEmpty(txtDesconto.Text) ? 0 : Convert.ToDecimal(txtDesconto.Text);
            decimal Acrescimo = String.IsNullOrEmpty(txtAcrescimo.Text) ? 0 : Convert.ToDecimal(txtAcrescimo.Text);
            decimal ValorPago = String.IsNullOrEmpty(txtValorPago.Text) ? 0 : Convert.ToDecimal(txtValorPago.Text);
            decimal ValorLiquido = ValorTitulo - Desconto + Acrescimo;
            txtValorLiquido.Text = ValorLiquido.ToString();
            decimal ValorAPagar = ValorLiquido - ValorPago;
            txtSaldo.Text = ValorAPagar.ToString();
        }

        private void txtValorTitulo_Leave(object sender, EventArgs e)
        {
            CalculaValores();
        }

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            CalculaValores();
        }

        private void txtAcrescimo_Leave(object sender, EventArgs e)
        {
            CalculaValores();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(c.IdContasReceber == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados da conta a pagar antes de adicionar vencimentos.");
                return;
            }

            ContasReceberAberto ca = new ContasReceberAberto();
            using (frmContasReceberAberto frmCadAberto = new frmContasReceberAberto(ca))
            {
                frmCadAberto.cp = c; 
                frmCadAberto.pagDal = dal;
                frmCadAberto.ShowDialog();
                c = dal.CalculaRecebimento(c);
                CarregaDados();
                CarregaGrid();
            }
        }
    }
}

