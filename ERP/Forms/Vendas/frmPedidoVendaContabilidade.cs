using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPedidoVendaContabilidade : RibbonForm
    {
        public PedidoVendaContabilidadeDAL dal;
        PedidoVendaContabilidade ai = new PedidoVendaContabilidade();
        int IdItem;
        public frmPedidoVendaContabilidade(int Id)
        { 
            IdItem = Id;
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
            ai = dal.GetByID(IdItem); 
            CarregaDados();  
        }

        private void CarregaCombos()
        {
            cboContaContabil.DataSource = new ContaContabilDAL().GetComboByTipo(1);
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
            txtOrigemLancamento.Text = ai.OrigemLancamento.Descricao;
            cboContaContabil.SelectedValue = ai.IdContaContabil == null ? 0 : ai.IdContaContabil; ;
            txtIDLote.Text = ai.IdLote;
            txtValorCredito.Text = ai.ValorCredito == null ? 0.ToString("F2") : Convert.ToDecimal(ai.ValorCredito).ToString("F2");
            txtValorDebito.Text = ai.ValorDebito == null ? 0.ToString("F2") : Convert.ToDecimal(ai.ValorDebito).ToString("F2");
            txtData.Text = ai.DataHora.ToString();
            txtUsuario.Text = ai.Usuario;
            txtMoeda.Text = ai.Moeda.Codigo;
            txtFornecedor.Text = new ClienteDAL().CRepository.GetByID(ai.IdCliente).RazaoSocial;
            txtTextoTransacao.Text = ai.TextoTransacao;
            if(ai.TipoMovimento == "C")
            {
                txtValorAjustado.Text = ai.ValorCredito == null ? 0.ToString("F2") : Convert.ToDecimal(ai.ValorCredito).ToString("F2");
            }
            else
            {
                txtValorAjustado.Text = ai.ValorDebito == null ? 0.ToString("F2") : Convert.ToDecimal(ai.ValorDebito).ToString("F2");
            }
        }   

        private void btnAdiciona_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
             
            try
            {
                bool Ajustado = false;
                if(ai.TipoMovimento == "C")
                {
                    if (txtValorCredito.Text != txtValorAjustado.Text) Ajustado = true;
                }
                else
                {
                    if (txtValorDebito.Text != txtValorAjustado.Text) Ajustado = true;
                }

                if(ai.IdContaContabil != Convert.ToInt32(cboContaContabil.SelectedValue))
                {
                    Ajustado = true;
                }

                if(Ajustado)
                {
                    //converte o atual registro em historico
                    ai.Historico = true;
                    dal.Update(ai);
                    dal.Save();

                    //Gera o novo item ajustado
                    PedidoVendaContabilidade c = new PedidoVendaContabilidade();
                    c.IdOrigemLancamento = ai.IdOrigemLancamento;
                    c.IdContaContabil = Convert.ToInt32(cboContaContabil.SelectedValue);
                    c.IdLote = ai.IdLote;
                    c.ValorCredito = ai.ValorCredito;
                    c.ValorDebito = ai.ValorDebito;
                    c.DataHora = DateTime.Now;
                    c.Usuario = new UsuarioDAL().URepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"))).NomeCompleto;
                    c.IdMoeda = ai.IdMoeda;
                    if (ai.TipoMovimento == "C")
                    {
                        c.ValorAjusteCredito = Convert.ToDecimal(txtValorAjustado.Text);
                    }
                    else
                    {
                        c.ValorAjusteDebito = Convert.ToDecimal(txtValorAjustado.Text);
                    }
                    c.Preco = ai.Preco;
                    c.IdRegraDistribuicao = ai.IdRegraDistribuicao;
                    c.IdFornecedor = ai.IdFornecedor;
                    c.IdCliente = ai.IdCliente;
                    c.IdEmpresa = ai.IdEmpresa;
                    c.Aprovado = ai.Aprovado;
                    c.Data = ai.Data;
                    c.Aprovador = ai.Aprovador;
                    c.NumeroCheque = ai.NumeroCheque;
                    c.Origem = ai.Origem;
                    c.IdPedidoVenda = ai.IdPedidoVenda;
                    c.IdPedidoVendaItem = ai.IdPedidoVendaItem;
                    c.TipoMovimento = ai.TipoMovimento;
                    c.TextoTransacao = ai.TextoTransacao;
                    c.Historico = false;
                    dal.Insert(c);
                    dal.Save();

                }
                this.Close();
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            } 
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close(); 
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            
        } 
    }
}

