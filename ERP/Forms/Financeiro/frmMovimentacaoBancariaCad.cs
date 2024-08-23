using ERP.DAL;
using ERP.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using ERP.BLL;

namespace ERP
{
    public partial class frmMovimentacaoBancariaCad : RibbonForm
    {
        public MovimentacaoBancariaDAL dal = new MovimentacaoBancariaDAL(); 
        MovimentacaoBancaria c = new MovimentacaoBancaria(); 

        public frmMovimentacaoBancariaCad()
        { 
            InitializeComponent();
        }

        public frmMovimentacaoBancariaCad(MovimentacaoBancaria pC)
        {
            c = pC;
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
            if (c.IdMovimentacao == 0)
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
            cboContaBancaria.DataSource = new EmpresaDAL().GetContasBancarias(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            cboContaBancaria.ValueMember = "iValue";
            cboContaBancaria.DisplayMember = "Text";
            cboContaBancaria.SelectedIndex = -1;



            List<ComboItem> Tipos = new List<ComboItem>();
            Tipos.Add(new ComboItem() { iValue = 1, Text = "Entrada" });
            Tipos.Add(new ComboItem() { iValue = 2, Text = "Saída" });
            cboTipoMovimento.DataSource = Tipos;
            cboTipoMovimento.ValueMember = "iValue";
            cboTipoMovimento.DisplayMember = "Text";
            cboTipoMovimento.SelectedIndex = -1;

            cboContaContabil.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabil.ValueMember = "iValue";
            cboContaContabil.DisplayMember = "Text";
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
            //Get Values//
            cboContaBancaria.SelectedValue = c.IdContaBancaria == null ? 0 : c.IdContaBancaria;
            cboContaContabil.SelectedValue = c.IdContaContabil == null ? 0 : c.IdContaContabil;
            cboTipoMovimento.SelectedValue = c.TipoMovimento == null ? 0 : c.TipoMovimento;
            txtData.Text = c.DataMovimentacao == null ? "" : c.DataMovimentacao.ToString();
            txtHistorico.Text = c.Historico == null ? "" : c.Historico.ToString();
            txtNumeroDocumento.Text = c.NumeroDocumento == null ? "" : c.NumeroDocumento.ToString();
            txtValor.Text = c.Valor == null ? "" : c.Valor.ToString();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }



        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new MovimentacaoBancaria();
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if(c.IdContasPagarBaixa != null || c.IdContasReceberBaixa != null)
            {
                Util.Aplicacao.ShowMessage("O Registro não pode ser alterado.");
                return;
            }


            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        { 

            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    c.DataMovimentacao = null;
                    c.Historico = null;
                    c.IdContaBancaria = null;
                    c.IdContaContabil = null;
                    c.TipoMovimento = null;
                    c.NumeroDocumento = null;
                    c.Valor = null;
                    if (!String.IsNullOrEmpty(cboContaBancaria.Text)) c.IdContaBancaria = Convert.ToInt32(cboContaBancaria.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaContabil.Text)) c.IdContaContabil = Convert.ToInt32(cboContaContabil.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoMovimento.Text)) c.TipoMovimento = Convert.ToInt32(cboTipoMovimento.SelectedValue);
                    if (!String.IsNullOrEmpty(txtData.Text)) c.DataMovimentacao = Convert.ToDateTime(txtData.Text);
                    if (!String.IsNullOrEmpty(txtHistorico.Text)) c.Historico = txtHistorico.Text;
                    if (!String.IsNullOrEmpty(txtNumeroDocumento.Text)) c.NumeroDocumento = txtNumeroDocumento.Text;
                    if (!String.IsNullOrEmpty(txtValor.Text)) c.Valor = Convert.ToDecimal(txtValor.Text);
                    if (c.IdMovimentacao == 0)
                    {
                        c.IdBanco = new ContaBancariaDAL().GetByID((int)c.IdContaBancaria).IdBanco;
                        c.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                        dal.Insert(c);
                    }
                    else
                    {
                        dal.Update(c);
                    }

                    dal.Save();
                    CarregaDados();
                    //Apos Salvar os dados efetua a movimentação do estoque
                   
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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
          
    }
}

