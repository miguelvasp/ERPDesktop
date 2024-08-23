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
    public partial class frmRoteiroOperacaoLinhas : RibbonForm
    {
        public RoteiroOperacaoLinhasDAL dal = new RoteiroOperacaoLinhasDAL();
        RoteiroOperacaoRecursosDAL idal = new RoteiroOperacaoRecursosDAL();
        RoteiroOperacaoLinhas ci = new RoteiroOperacaoLinhas();

        public frmRoteiroOperacaoLinhas(RoteiroOperacaoLinhas pci)
        {
            ci = pci;
            InitializeComponent();
        }

        public frmRoteiroOperacaoLinhas()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmConfGrupoImpostoRetidoCad_Load(object sender, EventArgs e)
        {
            CarregaCombo();
            CarregaDados();
        }

        private void CarregaDados()
        {
            cboArmazem.SelectedValue = ci.IdArmazem == null ? 0 : ci.IdArmazem;
            cboCodigoItem.SelectedValue = ci.CodigoItem == null ? 0 : ci.CodigoItem;
            cboFormula.SelectedValue = ci.Formula == null ? 0 : ci.Formula;
            cboGrupoLancamento.SelectedValue = ci.IdGrupoLancamento == null ? 0 : ci.IdGrupoLancamento;
            cboProduto.SelectedValue = ci.IdProduto == null ? 0 : ci.IdProduto;
            GrupoRoteiro.SelectedValue = ci.IdGrupoRoteiros == null ? 0 : ci.IdGrupoRoteiros;
            txtCarregar.Text = ci.Carregar == null ? "" : ci.Carregar.ToString();
            txtFator.Text = ci.Fator == null ? "" : ci.Fator.ToString();
            txtQtdeRecursos.Text = ci.QtdeRecursos == null ? "" : ci.QtdeRecursos.ToString();
            txtValorCustoOperacao.Text = ci.ValorCustoOperacao == null ? "" : ci.ValorCustoOperacao.ToString();
            txtVAlorCustoQuantidade.Text = ci.VAlorCustoQuantidade == null ? "" : ci.VAlorCustoQuantidade.ToString();
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            var lista = idal.GetByLinhaId(ci.IdRoteiroOperacaoLinhas);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void CarregaCombo()
        {
            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;

            List<ComboItem> codigoitem = new List<ComboItem>();
            codigoitem.Add(new ComboItem() { iValue = 1, Text = "Tabela" });
            codigoitem.Add(new ComboItem() { iValue = 2, Text = "Grupo" });
            codigoitem.Add(new ComboItem() { iValue = 3, Text = "Todos" });
            cboCodigoItem.DataSource = codigoitem;
            cboCodigoItem.DisplayMember = "Text";
            cboCodigoItem.ValueMember = "iValue";
            cboCodigoItem.SelectedIndex = -1;

            List<ComboItem> formula = new List<ComboItem>();
            formula.Add(new ComboItem() { iValue = 1, Text = "Padrão" });
            formula.Add(new ComboItem() { iValue = 2, Text = "Capacidade" });
            formula.Add(new ComboItem() { iValue = 3, Text = "Lote" });
            formula.Add(new ComboItem() { iValue = 4, Text = "Recurso" });
            cboFormula.DataSource = formula;
            cboFormula.DisplayMember = "Text";
            cboFormula.ValueMember = "iValue";
            cboFormula.SelectedIndex = -1;

            cboGrupoLancamento.DataSource = new GrupoLancamentoDAL().GetCombo();
            cboGrupoLancamento.DisplayMember = "Text";
            cboGrupoLancamento.ValueMember = "iValue";
            cboGrupoLancamento.SelectedIndex = -1;

            cboProduto.DataSource = new ProdutoDAL().GetComboProducao();
            cboProduto.DisplayMember = "Text";
            cboProduto.ValueMember = "iValue";
            cboProduto.SelectedIndex = -1;

            GrupoRoteiro.DataSource = new GrupoRoteiroDAL().GetCombo();
            GrupoRoteiro.DisplayMember = "Text";
            GrupoRoteiro.ValueMember = "iValue";
            GrupoRoteiro.SelectedIndex = -1;
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    ci.Carregar = null;
                    ci.Fator = null;
                    ci.IdArmazem = null;
                    ci.CodigoItem = null;
                    ci.Formula = null;
                    ci.IdGrupoLancamento = null;
                    ci.IdGrupoRoteiros = null;
                    ci.IdProduto = null;
                    ci.QtdeRecursos = null;
                    ci.ValorCustoOperacao = null;
                    ci.VAlorCustoQuantidade = null;
                    if (!String.IsNullOrEmpty(cboArmazem.Text)) ci.IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoItem.Text)) ci.CodigoItem = Convert.ToInt32(cboCodigoItem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFormula.Text)) ci.Formula = Convert.ToInt32(cboFormula.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoLancamento.Text)) ci.IdGrupoLancamento = Convert.ToInt32(cboGrupoLancamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboProduto.Text)) ci.IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
                    if (!String.IsNullOrEmpty(GrupoRoteiro.Text)) ci.IdGrupoRoteiros = Convert.ToInt32(GrupoRoteiro.SelectedValue);
                    if (!String.IsNullOrEmpty(txtCarregar.Text)) ci.Carregar = Convert.ToInt32(txtCarregar.Text);
                    if (!String.IsNullOrEmpty(txtFator.Text)) ci.Fator = Convert.ToDecimal(txtFator.Text);
                    if (!String.IsNullOrEmpty(txtQtdeRecursos.Text)) ci.QtdeRecursos = Convert.ToInt32(txtQtdeRecursos.Text);
                    if (!String.IsNullOrEmpty(txtValorCustoOperacao.Text)) ci.ValorCustoOperacao = Convert.ToDecimal(txtValorCustoOperacao.Text);
                    if (!String.IsNullOrEmpty(txtVAlorCustoQuantidade.Text)) ci.VAlorCustoQuantidade = Convert.ToDecimal(txtVAlorCustoQuantidade.Text);
                    if (ci.IdRoteiroOperacaoLinhas == 0)
                    {
                        dal.Insert(ci);
                    }
                    else
                    {
                        dal.Update(ci);
                    }
                    dal.Save();
                    this.Close();
                }
                catch
                {
                    Util.Aplicacao.ShowMessage("Verifique os dados informados");
                }
            }
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja remover a configuração?") == System.Windows.Forms.DialogResult.Yes)
            {
                dal.Delete(ci.IdRoteiroOperacaoLinhas);
                dal.Save();
                this.Close();
            }
        }

        private void btnAddRecursos_Click(object sender, EventArgs e)
        {
            if (ci.IdRoteiroOperacaoLinhas == 0)
            {
                Util.Aplicacao.ShowMessage("Por favor salve os dados antes de adicionar recursos");
                return;
            }
            RoteiroOperacaoRecursos r = new RoteiroOperacaoRecursos();
            r.IdRoteiroOperacaoLinha = ci.IdRoteiroOperacaoLinhas;
            frmRoteiroOperacaoRecursos frm = new frmRoteiroOperacaoRecursos(r);
            frm.dal = idal;
            frm.ShowDialog();
            CarregaGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && e.RowIndex > -1)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id"].Value);
                RoteiroOperacaoRecursos r = idal.GetByID(id);
                r.IdRoteiroOperacaoLinha = ci.IdRoteiroOperacaoLinhas;
                frmRoteiroOperacaoRecursos frm = new frmRoteiroOperacaoRecursos(r);
                frm.dal = idal;
                frm.ShowDialog();
                CarregaGrid();
            }
        }
    }
}
