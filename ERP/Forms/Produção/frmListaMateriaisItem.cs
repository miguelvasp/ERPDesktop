using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Models;
using ERP.DAL;

namespace ERP
{
    public partial class frmListaMateriaisItem : RibbonForm
    {
        public ListaMateriaisItemDAL dal = new ListaMateriaisItemDAL();
        ListaMateriaisLinhasDAL mDal = new ListaMateriaisLinhasDAL();
        ListaMateriaisItem li = new ListaMateriaisItem();
        List<MultiComboItem> Produtos = new List<MultiComboItem>();
        public frmListaMateriaisItem(ListaMateriaisItem item)
        {
            li = item;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmClassificacaoCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            if (li.IdListaMateriaisItem == 0)
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
            Produtos = new ProdutoDAL().getProdutosMultiCombo();
            cboProduto.DataSource = Produtos;
            cboProduto.DisplayMember = "Text2";
            cboProduto.ValueMember = "iValue";
            cboProduto.SelectedIndex = -1;

            cboConfiguracao.DataSource = new VariantesConfigDAL().GetCombo();
            cboConfiguracao.DisplayMember = "Text";
            cboConfiguracao.ValueMember = "iValue";
            cboConfiguracao.SelectedIndex = -1;

            cboEstilo.DataSource = new VariantesEstiloDAL().GetCombo();
            cboEstilo.DisplayMember = "Text";
            cboEstilo.ValueMember = "iValue";
            cboEstilo.SelectedIndex = -1;

            cboCor.DataSource = new VariantesCorDAL().GetCombo();
            cboCor.DisplayMember = "Text";
            cboCor.ValueMember = "iValue";
            cboCor.SelectedIndex = -1;

            cboTamanho.DataSource = new VariantesTamanhoDAL().GetCombo();
            cboTamanho.DisplayMember = "Text";
            cboTamanho.ValueMember = "iValue";
            cboTamanho.SelectedIndex = -1;

            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;

            cboUnidade.DataSource = new UnidadeDAL().GetCombo();
            cboUnidade.DisplayMember = "Text";
            cboUnidade.ValueMember = "iValue";
            cboUnidade.SelectedIndex = -1;

            List<ComboItem> Alocacao = new List<ComboItem>();
            Alocacao.Add(new ComboItem { iValue = 1, Text = "Nenhum" });
            Alocacao.Add(new ComboItem { iValue = 2, Text = "TCA" });
            Alocacao.Add(new ComboItem { iValue = 3, Text = "Manual" });
            cboAlocacaoCustoTotal.DataSource = Alocacao;
            cboAlocacaoCustoTotal.DisplayMember = "Text";
            cboAlocacaoCustoTotal.ValueMember = "iValue";
            cboAlocacaoCustoTotal.SelectedIndex = -1;

        }

        private void CarregaDados()
        {
            cboProduto.SelectedValue = li.IdProduto;
            cboConfiguracao.SelectedValue = li.IdConfiguracao == null ? 0 : Convert.ToInt32(li.IdConfiguracao);
            cboEstilo.SelectedValue = li.IdEstilo == null ? 0 : Convert.ToInt32(li.IdEstilo);
            cboCor.SelectedValue = li.IdCor == null ? 0 : Convert.ToInt32(li.IdCor);
            cboTamanho.SelectedValue = li.IdTamanho == null ? 0 : Convert.ToInt32(li.IdTamanho);
            cboArmazem.SelectedValue = li.IdArmazem == null ? 0 : Convert.ToInt32(li.IdArmazem);
            if (li.De != null) dtpDe.Value = Convert.ToDateTime(li.De);
            if (li.Ate != null) dtpAte.Value = Convert.ToDateTime(li.Ate);
            txtQtde.Text = li.QuantidadeOrigem.ToString();
            cboUnidade.SelectedValue = li.IdUnidadeBom == null ? 0 : Convert.ToInt32(li.IdUnidadeBom);
            chkAtivo.Checked = li.Ativo;

            //Configurações
            cboAlocacaoCustoTotal.SelectedValue = li.AlocacaoCustoTotal == null ? 0 : Convert.ToInt32(li.AlocacaoCustoTotal);
            chkConstrucao.Checked = li.Construcao;
            txtMultiploFormula.Text = li.MultiploFormula.ToString();
            txtPrioridade.Text = li.Prioridade.ToString();
            txtTamanhoFormula.Text = li.TamanhoFormula.ToString();
            chkUsarCalculo.Checked = li.UsarParaCalculo;
            chkVariacoesCoProduto.Checked = li.VariacoesCoProdutos;

            CarregaGrid();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            li = new ListaMateriaisItem(); 
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
                    li.IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
                    if (cboConfiguracao.SelectedValue != null) li.IdConfiguracao = Convert.ToInt32(cboConfiguracao.SelectedValue);
                    if (cboEstilo.SelectedValue != null) li.IdEstilo = Convert.ToInt32(cboEstilo.SelectedValue);
                    if (cboCor.SelectedValue != null) li.IdCor = Convert.ToInt32(cboCor.SelectedValue);
                    if (cboTamanho.SelectedValue != null) li.IdTamanho = Convert.ToInt32(cboTamanho.SelectedValue);
                    if (cboArmazem.SelectedValue != null) li.IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
                    if (dtpDe.Checked) li.De = dtpDe.Value;
                    if (dtpAte.Checked) li.Ate = dtpAte.Value;
                    if (!String.IsNullOrEmpty(txtQtde.Text)) li.QuantidadeOrigem = Convert.ToInt32(txtQtde.Text);
                    if (cboUnidade.SelectedValue != null) li.IdUnidadeBom = Convert.ToInt32(cboUnidade.SelectedValue);
                    li.Ativo = chkAtivo.Checked;

                    //Configurações
                    if (cboAlocacaoCustoTotal.SelectedValue != null) li.AlocacaoCustoTotal = Convert.ToInt32(cboAlocacaoCustoTotal.SelectedValue);

                    li.Construcao = chkConstrucao.Checked;
                    li.MultiploFormula = Convert.ToInt32(txtMultiploFormula.Text);
                    li.Prioridade = Convert.ToInt32(txtPrioridade.Text);
                    li.TamanhoFormula = Convert.ToDecimal(txtTamanhoFormula.Text);
                    li.UsarParaCalculo = chkUsarCalculo.Checked;
                    li.VariacoesCoProdutos = chkVariacoesCoProduto.Checked;

                    if (li.IdListaMateriaisItem == 0)
                    {
                        li.DataFormula = DateTime.Now;
                        li.QuantidadeProducao = 100;
                        dal.Insert(li);
                    }
                    else
                    {
                        dal.Update(li);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch(Exception ex)
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
                    int id = li.IdListaMateriaisItem;
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmCombo combo = new frmCombo(Produtos);
            combo.Top = this.Top + tabControl1.Top + cboProduto.Top + 18;
            combo.Left = this.Left + cboProduto.Left + 12;
            combo.ShowDialog();
            if (!String.IsNullOrEmpty(combo.Id))
            {
                cboProduto.SelectedValue = Convert.ToInt32(combo.Id);
                BuscaProdutoDados();
            }
        }

        private void cboProduto_Leave(object sender, EventArgs e)
        {
            BuscaProdutoDados();
        }

        private void BuscaProdutoDados()
        {
            if (cboProduto.Text != "")
            {
                Produto pr = new ProdutoDAL().ProdutoRepository.GetByID(Convert.ToInt32(cboProduto.SelectedValue));
                if (pr != null)
                {
                    cboConfiguracao.SelectedValue = pr.IdVariantesConfig == null ? 0 : Convert.ToInt32(pr.IdVariantesConfig);
                    cboEstilo.SelectedValue = pr.IdVariantesEstilo == null ? 0 : Convert.ToInt32(pr.IdVariantesEstilo);
                    cboCor.SelectedValue = pr.IdVariantesCor == null ? 0 : Convert.ToInt32(pr.IdVariantesCor);
                    cboTamanho.SelectedValue = pr.IdVariantesTamanho == null ? 0 : Convert.ToInt32(pr.IdVariantesTamanho);
                    cboUnidade.SelectedValue = pr.ProducaoIdUnidade == null ? 0 : Convert.ToInt32(pr.ProducaoIdUnidade);
                }
            }
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            ListaMateriaisLinhas lm = new ListaMateriaisLinhas();
            lm.IdListaMateriaisItem = li.IdListaMateriaisItem;
            frmListaMateriaisLinhas frmlinha = new frmListaMateriaisLinhas(lm);
            frmlinha.dal = mDal; 
            frmlinha.ShowDialog();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            dgMateriais.AutoGenerateColumns = false;
            dgMateriais.DataSource = mDal.GetLinhasByItem(li.IdListaMateriaisItem);
        }

        private void dgMateriais_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgMateriais.Rows[dgMateriais.SelectedRows[0].Index].Cells[0].Value);
            ListaMateriaisLinhas lm = mDal.GetByID(id);
            frmListaMateriaisLinhas frmlinha = new frmListaMateriaisLinhas(lm);
            frmlinha.dal = mDal; 
            frmlinha.ShowDialog();
            CarregaGrid();
        }
    }
}
