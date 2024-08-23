using ERP.DAL;
using ERP.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using ERP.BLL;
using ERP.Forms.VendasBalcao;

namespace ERP
{
    public partial class frmAjusteEstoqueCad : RibbonForm
    {
        public AjusteEstoqueDAL dal = new AjusteEstoqueDAL(); 
        AjusteEstoque c = new AjusteEstoque();
        InventarioDAL iDal = new InventarioDAL();
        Inventario inv = new Inventario();

        public frmAjusteEstoqueCad()
        { 
            InitializeComponent();
        }

        public frmAjusteEstoqueCad(AjusteEstoque pC)
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
            if (c.IdAjusteEstoque == 0)
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
            

            cboProduto.DataSource = new ProdutoDAL().GetComboVendas();
            cboProduto.DisplayMember = "Text";
            cboProduto.ValueMember = "iValue";
            cboProduto.SelectedIndex = -1;

          

            List<ComboItem> TipoMov = new List<ComboItem>();
            TipoMov.Add(new ComboItem() { iValue = 1, Text = "Entrada no estoque" });
            TipoMov.Add(new ComboItem() { iValue = 2, Text = "Saída do estoque" });
            cboTipoMovimento.DataSource = TipoMov;
            cboTipoMovimento.DisplayMember = "Text";
            cboTipoMovimento.ValueMember = "iValue";
           // cboTipoMovimento.SelectedIndex = -1;

            cboUnidade.DataSource = new UnidadeDAL().GetCombo();
            cboUnidade.DisplayMember = "Text";
            cboUnidade.ValueMember = "iValue";
            cboUnidade.SelectedIndex = -1;


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
            cboProduto.SelectedValue = c.IdProduto; 
            cboTipoMovimento.SelectedValue = c.TipoMovimento == null ? 0 : c.TipoMovimento;
            cboUnidade.SelectedValue = c.IdUnidade == null ? 0 : c.IdUnidade; 
            txtMotivo.Text = c.Motivo == null ? "" : c.Motivo.ToString(); 
            txtQuantidade.Text = c.Quantidade.ToString();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }



        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new AjusteEstoque();
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Confirma a operação?") == DialogResult.No)
            {
                return;
            }


            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {

                    c.Data = DateTime.Now;
                    c.DataAvisoPrateleira = null;
                    c.DataFabricacao = null;
                    c.DataValidade = null;
                    c.DataVencimento = null;
                    c.IdArmazem = null;
                    c.IdVariantesCor = null;
                    c.IdDeposito = 1;
                    c.IdVariantesEstilo = null;
                    c.IdLocalizacao = null; 
                    c.IdVariantesTamanho = null;
                    c.TipoMovimento = null;
                    c.IdUnidade = null;
                    c.IdVariantesConfig = null;
                    c.LoteFornecedor = null;
                    c.LoteInterno = null;
                    c.Motivo = null;
                    c.QtdeLote = null;  
                    if (!String.IsNullOrEmpty(cboProduto.Text)) c.IdProduto = Convert.ToInt32(cboProduto.SelectedValue); 
                    if (!String.IsNullOrEmpty(cboTipoMovimento.Text)) c.TipoMovimento = Convert.ToInt32(cboTipoMovimento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboUnidade.Text)) c.IdUnidade = Convert.ToInt32(cboUnidade.SelectedValue); 
                    
                     
                    if (!String.IsNullOrEmpty(txtMotivo.Text)) c.Motivo = txtMotivo.Text; 
                    if (!String.IsNullOrEmpty(txtQuantidade.Text)) c.Quantidade = Convert.ToDecimal(txtQuantidade.Text);

                    if(Convert.ToDecimal(txtQuantidade.Text) == 0)
                    {
                        Util.Aplicacao.ShowMessage("Informe a quantidade a ser movimentada no estoque");
                        return;
                    }


                    if (c.IdAjusteEstoque == 0)
                    {
                        c.Data = DateTime.Now;
                        c.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                        c.IdDocumento = 7; 
                        dal.Insert(c);
                    }
                    else
                    {
                        dal.Update(c);
                    }

                    dal.Save();
                    CarregaDados();
                    //Apos Salvar os dados efetua a movimentação do estoque
                    BLInventario blinv = new BLInventario();
                    blinv.dal = iDal;
                    if(c.TipoMovimento == 1)
                    {
                        blinv.AjusteEstoqueEntrada(c);
                    }
                    else
                    {
                        blinv.AjusteEstoqueSaida(c);
                    }

                    Util.Aplicacao.ShowMessage("Alterações efetuadas com sucesso!");
                    this.Close();

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

        private void button1_Click_1(object sender, EventArgs e)
        {
             
        }

        private void cboTipoMovimento_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void btnBuscaProduto_Click(object sender, EventArgs e)
        {
            using (frmPesquisaProdutoBalcao frmBusca = new frmPesquisaProdutoBalcao(""))
            {
                frmBusca.ShowDialog();
                if (frmBusca.selecionado != null)
                {
                    Produto pr = new ProdutoDAL().ProdutoRepository.GetByID(frmBusca.selecionado.IdProduto);
                    if (pr != null)
                    {
                        cboProduto.SelectedValue = pr.IdProduto;
                        cboUnidade.SelectedValue = pr.VendaIdUnidade == null ? 0 : pr.VendaIdUnidade; 
                    }
                }
            }
        }
    }
}

