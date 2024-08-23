using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmComissaoVendedorContaCorrenteCad : RibbonForm
    {
        public ComissaoContaCorrenteDAL dal = new ComissaoContaCorrenteDAL(); 
        ComissaoContaCorrente c = new ComissaoContaCorrente();

        public frmComissaoVendedorContaCorrenteCad()
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
            Carregacombos();
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
         
        private void Carregacombos()
        {
            List<ComboItem> tpcomissao = new List<ComboItem>();
            tpcomissao.Add(new ComboItem() { iValue = 1, Text = "Comissão" });
            tpcomissao.Add(new ComboItem() { iValue = 2, Text = "Comissão Adicional" });
            tpcomissao.Add(new ComboItem() { iValue = 3, Text = "Choque" });
            cboTipoComissao.DataSource = tpcomissao;
            cboTipoComissao.DisplayMember = "Text";
            cboTipoComissao.ValueMember = "iValue";

            cboVendedor.DataSource = new VendedorDAL().GetCombo();
            cboVendedor.DisplayMember = "Text";
            cboVendedor.ValueMember = "iValue";
            cboVendedor.SelectedIndex = -1;

            cboTelevendas.DataSource = new FuncionarioDAL().GetComboTelevendas();
            cboTelevendas.DisplayMember = "Text";
            cboTelevendas.ValueMember = "iValue";
            cboTelevendas.SelectedIndex = -1;
        }


        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new ComissaoContaCorrente();
            Util.Aplicacao.LimpaControles(this); 
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        { 
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(cboTelevendas.Text))
            {
                cboVendedor.Tag = "";
            }
            else
            {
                cboVendedor.Tag = "1";
            }


            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    c.IdVendedor = Convert.ToInt32(cboVendedor.SelectedValue);
                    c.IdTeleVendas = null;
                    if(String.IsNullOrEmpty(cboTelevendas.Text)) c.IdTeleVendas = Convert.ToInt32(cboTelevendas.SelectedValue);
                    c.DataNotaFiscal = Convert.ToDateTime(txtData.Text);
                    c.Comissao = Convert.ToDecimal(txtComissao.Text);
                    c.TipoComissao = Convert.ToInt32(cboTipoComissao.SelectedValue);
                    c.TipoLancamento = 2;
                    c.ValorAPagar = c.Comissao;
                    c.ValorPago = 0;
                    c.ComissaoPercentual = 0;
                    dal.Insert(c);
                     

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close();
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
                this.Close();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
             
        }

        
          
    }
}

