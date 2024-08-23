using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmContaContabilCad : RibbonForm
    {
        public ContaContabilDAL dal;
        ContaContabil cc = new ContaContabil();
        MoedaDAL mDal = new MoedaDAL();
        List<MultiComboItem> listaPlanoReferencial = new List<MultiComboItem>();

        public frmContaContabilCad(ContaContabil cContabil)
        {
            cc = cContabil;
            InitializeComponent();
        }

        public frmContaContabilCad()
        {
            InitializeComponent();
        }

        private void frmContaContabilCad_Load(object sender, EventArgs e)
        {
            CarregaTipoLancamento();
            CarregarPropostaDECR();
            CarregaContaPai();
            CarregaContaConsolidacao();
            CarregarMoedas();
            CarregaTipoConta();
            CarregarContaPlanoReferencial();
            CarregarNatureza();
            CarregarNivel();
            CarregaTipoReceitaDespesa();
            listaPlanoReferencial = new ContaPlanoReferencialDAL().GetMultiCombo();

            if (cc.IdContaContabil == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void CarregaDados()
        {
            
            txtCodigo.Text = cc.Codigo;
            txtDescricao.Text = cc.Descricao;
            if (cc.IdContaTipoLancamento != null)
            {
                cboTipoLancamento.SelectedValue = cc.IdContaTipoLancamento;
            }
            if (cc.PropostaDEBCRE != null)
                cboDebitoCredito.SelectedValue = cc.PropostaDEBCRE.ToString();
            chkFechar.Checked = cc.Fechar;
            if (cc.IdContaHierarquia != null)
                cboContaPai.SelectedValue = cc.IdContaHierarquia;
            if (cc.IdContaConsolidacao != null)
                cboContaConsolidacao.SelectedValue = cc.IdContaConsolidacao;
            if (cc.IdMoeda != null)
                cboMoeda.SelectedValue = cc.IdMoeda;
            if (cc.IdTipoConta != null)
                cboTipoConta.SelectedValue = cc.IdTipoConta;
            if (cc.IdContaPlanoReferencial != null)
                cboContaPlanoReferencial.SelectedValue = cc.IdContaPlanoReferencial;

            cboNivel.SelectedValue = cc.Nivel == null ? 0 : cc.Nivel;
            cboNatureza.SelectedValue = cc.Natureza == null ? 0 : cc.Natureza;
            cboTipoReceitaDespesa.SelectedValue = cc.TipoReceitaDespesa == null ? 0 : cc.TipoReceitaDespesa;

            txtDePara.Text = cc.DePara == null ? "" : cc.DePara;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        protected void CarregaTipoLancamento()
        {
            cboTipoLancamento.DataSource = new ContaGerencialDAL().GetCombo();
            cboTipoLancamento.DisplayMember = "Text";
            cboTipoLancamento.ValueMember = "iValue";
            cboTipoLancamento.SelectedIndex = -1;
        }

        protected void CarregaTipoConta()
        {
            List<ComboItem> tipos = new List<ComboItem>();
            tipos.Add(new ComboItem() { iValue = 1, Text = "A" });
            tipos.Add(new ComboItem() { iValue = 2, Text = "S" });
            cboTipoConta.DataSource = tipos;
            cboTipoConta.DisplayMember = "Text";
            cboTipoConta.ValueMember = "iValue";
            cboTipoConta.SelectedIndex = -1;
        }

        protected void CarregaContaPai()
        {
            cboContaPai.DataSource = new ContaContabilDAL().GetCombo();
            cboContaPai.DisplayMember = "Text";
            cboContaPai.ValueMember = "iValue";
            cboContaPai.SelectedIndex = -1;
        }

        protected void CarregaContaConsolidacao()
        {
            cboContaConsolidacao.DataSource = new ContaContabilDAL().GetCombo();
            cboContaConsolidacao.DisplayMember = "Text";
            cboContaConsolidacao.ValueMember = "iValue";
            cboContaConsolidacao.SelectedIndex = -1;
        }

        private void CarregarMoedas()
        {
            var moedas = mDal.MRepository.Get().OrderBy(x => x.Codigo).ToList();
            cboMoeda.DataSource = moedas;
            cboMoeda.ValueMember = "IdMoeda";
            cboMoeda.DisplayMember = "Codigo";
            cboMoeda.SelectedIndex = -1;
        }

        private void CarregarPropostaDECR()
        {
            List<DropList> lista = Util.EnumERP.CarregarPropostaDECR();

            cboDebitoCredito.DisplayMember = "Text";
            cboDebitoCredito.ValueMember = "Value";
            cboDebitoCredito.DataSource = lista;
            cboDebitoCredito.SelectedIndex = -1;
        }

        protected void CarregarContaPlanoReferencial()
        {
            cboContaPlanoReferencial.DataSource = new ContaPlanoReferencialDAL().GetCombo();
            cboContaPlanoReferencial.DisplayMember = "Text";
            cboContaPlanoReferencial.ValueMember = "iValue";
            cboContaPlanoReferencial.SelectedIndex = -1;
            
        }
        
        protected void CarregarNatureza()
        {
            List<ComboItem> nat = new List<ComboItem>();
            nat.Add(new ComboItem() { iValue = 1, Text = "Ativo" });
            nat.Add(new ComboItem() { iValue = 2, Text = "Passivo" });
            nat.Add(new ComboItem() { iValue = 3, Text = "Patrimônio Liquido" });
            nat.Add(new ComboItem() { iValue = 4, Text = "Resultado" });
            cboNatureza.DataSource = nat;
            cboNatureza.DisplayMember = "Text";
            cboNatureza.ValueMember = "iValue";
            cboNatureza.SelectedIndex = -1;

        }

        protected void CarregarNivel()
        {
            List<ComboItem> nivel = new List<ComboItem>();
            nivel.Add(new ComboItem() { iValue = 1, Text = "1" });
            nivel.Add(new ComboItem() { iValue = 2, Text = "2" });
            nivel.Add(new ComboItem() { iValue = 3, Text = "3" });
            nivel.Add(new ComboItem() { iValue = 4, Text = "4" });
            nivel.Add(new ComboItem() { iValue = 5, Text = "5" });
            cboNivel.DataSource = nivel;
            cboNivel.DisplayMember = "Text";
            cboNivel.ValueMember = "iValue";
            cboNivel.SelectedIndex = -1;


          
        }

        protected void CarregaTipoReceitaDespesa()
        { 
            List<ComboItem> tp = new List<ComboItem>();
            tp.Add(new ComboItem() { iValue = 1, Text = "Despesas com Produtos" });
            tp.Add(new ComboItem() { iValue = 2, Text = "Despesas com Serviços" });
            tp.Add(new ComboItem() { iValue = 3, Text = "Despesas não Operacionais" });
            tp.Add(new ComboItem() { iValue = 4, Text = "Despesas com Folha, Despesas" });
            tp.Add(new ComboItem() { iValue = 5, Text = "Operacionais, Despesas de Marketing" });
            tp.Add(new ComboItem() { iValue = 6, Text = "Impostos" });
            tp.Add(new ComboItem() { iValue = 7, Text = "Investimentos" });
            tp.Add(new ComboItem() { iValue = 8, Text = "Receitas com Produtos" });
            tp.Add(new ComboItem() { iValue = 9, Text = "Receitas com Serviços" });
            tp.Add(new ComboItem() { iValue = 10, Text = "Receitas não Operacionais" });
            cboTipoReceitaDespesa.DataSource = tp;
            cboTipoReceitaDespesa.DisplayMember = "Text";
            cboTipoReceitaDespesa.ValueMember = "iValue";
            cboTipoReceitaDespesa.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cc = new ContaContabil(); 
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
                    //limpa os campos
                    cc.Codigo = null;
                    cc.DePara = null;
                    cc.Descricao = null;
                    cc.IdContaConsolidacao = null;
                    cc.IdContaHierarquia = null;
                    cc.IdContaPlanoReferencial = null;
                    cc.PropostaDEBCRE = null;
                    cc.IdMoeda = null;
                    cc.IdTipoConta = null;
                    cc.IdContaTipoLancamento = null;
                    cc.Natureza = null;
                    cc.Nivel = null;
                    cc.TipoReceitaDespesa = null;
                    cc.Codigo = txtCodigo.Text;
                    cc.Descricao = txtDescricao.Text;

                    if (!String.IsNullOrEmpty(cboTipoLancamento.Text))
                        cc.IdContaTipoLancamento = Convert.ToInt32(cboTipoLancamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDebitoCredito.Text))
                        cc.PropostaDEBCRE = Convert.ToInt32(cboDebitoCredito.SelectedValue);
                    cc.Fechar = chkFechar.Checked;
                    if (!String.IsNullOrEmpty(cboContaPai.Text))
                        cc.IdContaHierarquia = Convert.ToInt32(cboContaPai.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaConsolidacao.Text))
                        cc.IdContaConsolidacao = Convert.ToInt32(cboContaConsolidacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMoeda.Text))
                        cc.IdMoeda = Convert.ToInt32(cboMoeda.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoConta.Text))
                        cc.IdTipoConta = Convert.ToInt32(cboTipoConta.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaPlanoReferencial.Text))
                        cc.IdContaPlanoReferencial = Convert.ToInt32(cboContaPlanoReferencial.SelectedValue);

                    if (!String.IsNullOrEmpty(cboNatureza.Text)) cc.Natureza = Convert.ToInt32(cboNatureza.SelectedValue);
                    if (!String.IsNullOrEmpty(cboNivel.Text)) cc.Nivel = Convert.ToInt32(cboNivel.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoReceitaDespesa.Text)) cc.TipoReceitaDespesa = Convert.ToInt32(cboTipoReceitaDespesa.SelectedValue);


                    cc.DePara = txtDePara.Text;

                    if (cc.IdContaContabil == 0)
                    {
                        dal.Insert(cc);
                    }
                    else
                    {
                        dal.Update(cc);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
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
                try
                {
                    int id = cc.IdContaContabil;
                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
        }

        private void cboContaPlanoReferencial_Enter(object sender, EventArgs e)
        {
          
            
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCombo combo = new frmCombo(listaPlanoReferencial);
            combo.Top = this.Top + cboContaPlanoReferencial.Top;
            combo.Left = this.Left + cboContaPlanoReferencial.Left;
            combo.ShowDialog();
            if (!String.IsNullOrEmpty(combo.Id))
            {
                cboContaPlanoReferencial.SelectedValue = Convert.ToInt32(combo.Id);
            }
        }
    }
}
