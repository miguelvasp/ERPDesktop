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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmRecebimentoCompraAddItem : Form
    {
        RecebimentoDAL dal = new RecebimentoDAL();
        RecebimentoItem r = new RecebimentoItem();
        RecebimentoItemLoteDAL lDal = new RecebimentoItemLoteDAL();
        List<RecebimentoItemLote> Lotes = new List<RecebimentoItemLote>();
        int IdRecebimento = 0;
        bool RecebimentoConfirmado = false;
        public frmRecebimentoCompraAddItem(RecebimentoDAL pDal, RecebimentoItem recebimentoItem, bool Confirmado)
        {
            RecebimentoConfirmado = Confirmado;
            dal = pDal;
            r = recebimentoItem;
            IdRecebimento = r.IdRecebimento;

            InitializeComponent();

            if (Confirmado)
            {
                btnAdiciona.Visible = false;
                btnExcluir.Visible = false;
                btnGrava.Visible = false;
            }


        }

        private void frmRecebimentoCompraAddItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void frmRecebimentoCompraAddItem_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            if (r.IdRecebimentoItem != 0)
            {
                CarregaDados();
            }
            else
            {
                CarregaNovoItem();
            }

            cboProduto.Focus();
        }

        private void CarregaDados()
        {
            cboProduto.SelectedValue = r.IdProduto;
            txtQuantidade.Text = r.QuantidadeRecebida.ToString();
            cboUnidade.SelectedValue = r.IdUnidade;
            txtPrecoUnitario.Text = r.ValorUnitario.ToString();
            txtValorTotal.Text = r.ValorTotal.ToString();

            txtDescontoValor.Text = r.Desconto.ToString();
            txtSeguro.Text = r.Seguro.ToString();
            txtFrete.Text = r.Frete.ToString();
            txtDespesasAcessorias.Text = r.DespesasAcessorias.ToString();
            txtRoyalties.Text = r.Royalties.ToString();
            txtValorLiquido.Text = r.ValorLiquido.ToString();

            cboEstilo.SelectedValue = r.IdVariantesEstilo == null ? 0 : r.IdVariantesEstilo;
            cboCor.SelectedValue = r.IdVariantesCor == null ? 0 : r.IdVariantesCor;
            cboTamanho.SelectedValue = r.IdVariantesTamanho == null ? 0 : r.IdVariantesTamanho;

            cboGrupoLotes.SelectedValue = r.IdGrupoLotes == null ? 0 : r.IdGrupoLotes;
            cboGrupoSeries.SelectedValue = r.IdGrupoSeries == null ? 0 : r.IdGrupoSeries;
            cboArmazem.SelectedValue = r.IdArmazem == null ? 0 : r.IdArmazem;
            cboDeposito.SelectedValue = r.IdDeposito == null ? 0 : r.IdDeposito;
            cboLocalizacao.SelectedValue = r.IdLocalizacao == null ? 0 : r.IdLocalizacao;

            cboAtivoFixo.SelectedValue = r.IdAtivoFixo == null ? 0 : r.IdAtivoFixo;
            cboGrupoAtivo.SelectedValue = r.IdGrupoAtivo == null ? 0 : r.IdGrupoAtivo;
            cboMetodoPreciacao.SelectedValue = r.IdMetodoDepreciacao == null ? 0 : r.IdMetodoDepreciacao;

            CarregaNovoItem();

            CarregaLotes();

            if (RecebimentoConfirmado) Util.Aplicacao.BloqueiaControles(this);

        }

        private void CarregaLotes()
        {
            Lotes = lDal.GetLotes(r.IdRecebimentoItem);
            if (RecebimentoConfirmado)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = Lotes;
            }
            else
            {
                dataGridView1.Rows.Clear();

                foreach (RecebimentoItemLote lt in Lotes)
                {
                    dataGridView1.Rows.Add(
                        lt.IdLote,
                        lt.LoteFornecedor,
                        lt.LoteInterno,
                        lt.Quantidade.ToString(),
                        lt.DataVencimento == null ? "" : lt.DataVencimento.ToString(),
                        lt.DataFabricacao == null ? "" : lt.DataFabricacao.ToString(),
                        lt.DataAvisoPrateleira == null ? "" : lt.DataAvisoPrateleira.ToString(),
                        lt.DataValidade == null ? "" : lt.DataValidade.ToString()
                        );
                }

            }
        }

        private void CarregaNovoItem()
        {
            if (r.IdRecebimentoItem == 0)
            {
                PedidoCompra pc = new PedidoCompraDAL().PCRepository.GetByID(r.IdPedidoCompra);
                if (pc != null)
                {
                    cboArmazem.SelectedValue = pc.IdArmazem == null ? 0 : pc.IdArmazem;
                    cboDeposito.SelectedValue = pc.IdDeposito == null ? 0 : pc.IdDeposito;
                }
            }
        }

        private void CarregaCombos()
        {
            cboProduto.DataSource = new ProdutoDAL().GetComboCompras();
            cboProduto.DisplayMember = "Text";
            cboProduto.ValueMember = "iValue";
            cboProduto.SelectedIndex = -1;

            cboUnidade.DataSource = new UnidadeDAL().GetCombo();
            cboUnidade.DisplayMember = "Text";
            cboUnidade.ValueMember = "iValue";
            cboUnidade.SelectedIndex = -1;

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

            cboGrupoLotes.DataSource = new GrupoLotesDAL().GetCombo();
            cboGrupoLotes.DisplayMember = "Text";
            cboGrupoLotes.ValueMember = "iValue";
            cboGrupoLotes.SelectedIndex = -1;

            cboGrupoSeries.DataSource = new GrupoSeriesDAL().GetCombo();
            cboGrupoSeries.DisplayMember = "Text";
            cboGrupoSeries.ValueMember = "iValue";
            cboGrupoSeries.SelectedIndex = -1;

            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;

            cboDeposito.DataSource = new DepositoDAL().GetCombo();
            cboDeposito.DisplayMember = "Text";
            cboDeposito.ValueMember = "iValue";
            cboDeposito.SelectedIndex = -1;

            cboLocalizacao.DataSource = new LocalizacaoDAL().GetCombo();
            cboLocalizacao.DisplayMember = "Text";
            cboLocalizacao.ValueMember = "iValue";
            cboLocalizacao.SelectedIndex = -1;

            cboGrupoAtivo.DataSource = new GrupoAtivoDAL().GetCombo();
            cboGrupoAtivo.DisplayMember = "Text";
            cboGrupoAtivo.ValueMember = "iValue";
            cboGrupoAtivo.SelectedIndex = -1;

            cboMetodoPreciacao.DataSource = new MetodoDepreciacaoDAL().GetCombo();
            cboMetodoPreciacao.DisplayMember = "Text";
            cboMetodoPreciacao.ValueMember = "iValue";
            cboMetodoPreciacao.SelectedIndex = -1;

            cboAtivoFixo.DataSource = new AtivoImobilizadoDAL().GetCombo();
            cboAtivoFixo.DisplayMember = "Text";
            cboAtivoFixo.ValueMember = "iValue";
            cboAtivoFixo.SelectedIndex = -1;
        }

        private void LimpaControles()
        {
            cboProduto.Text = "";
            txtQuantidade.Text = "";
            cboUnidade.Text = "";
            txtPrecoUnitario.Text = "";
            txtValorTotal.Text = "";
            txtDescontoValor.Text = "";
            txtFrete.Text = "";
            txtSeguro.Text = "";
            txtDespesasAcessorias.Text = "";
            txtRoyalties.Text = "";
            txtValorLiquido.Text = "";

            cboEstilo.Text = "";
            cboCor.Text = "";
            cboTamanho.Text = "";
            cboGrupoLotes.Text = "";
            cboGrupoSeries.Text = "";
            cboArmazem.Text = "";
            cboDeposito.Text = "";
            cboLocalizacao.Text = "";
            cboGrupoAtivo.Text = "";
            cboMetodoPreciacao.Text = "";
            cboAtivoFixo.Text = "";
        }

        private bool ValidaCampos()
        {
            bool ok = true;
            if (cboProduto.Text == "") ok = false;
            if (txtPrecoUnitario.Text == "") ok = false;
            if (txtQuantidade.Text == "") ok = false;
            return ok;
        }

        private void cboProduto_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboProduto.Text))
            {
                Produto pr = new ProdutoDAL().ProdutoRepository.GetByID(Convert.ToInt32(cboProduto.SelectedValue));
                if (pr != null)
                {
                    cboUnidade.SelectedValue = pr.ComprasIdUnidade == null ? 0 : pr.ComprasIdUnidade;
                    cboEstilo.SelectedValue = pr.IdVariantesEstilo == null ? 0 : pr.IdVariantesEstilo;
                    cboCor.SelectedValue = pr.IdVariantesCor == null ? 0 : pr.IdVariantesCor;
                    cboTamanho.SelectedValue = pr.IdVariantesTamanho == null ? 0 : pr.IdVariantesTamanho;

                    cboGrupoLotes.SelectedValue = pr.EstoqueIdGrupoLotes == null ? 0 : pr.EstoqueIdGrupoLotes;
                    cboGrupoSeries.SelectedValue = pr.EstoqueIdGrupoSeries == null ? 0 : pr.EstoqueIdGrupoSeries;
                }
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            txtValorTotal.Text = "0,0000";

            if (!string.IsNullOrEmpty(txtQuantidade.Text))
            {
                int qtde = Convert.ToInt32(txtQuantidade.Text);

                if (!string.IsNullOrEmpty(txtPrecoUnitario.Text))
                {
                    decimal precoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
                    decimal vlTotal = qtde * precoUnitario;

                    txtValorTotal.Text = vlTotal.ToString();
                }
            }
        }

        private void txtPrecoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtPrecoUnitario.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }


        private void txtPrecoUnitario_Leave(object sender, EventArgs e)
        {
            txtValorTotal.Text = "0,0000";

            if (!string.IsNullOrEmpty(txtPrecoUnitario.Text))
            {
                decimal precoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);

                if (!string.IsNullOrEmpty(txtQuantidade.Text))
                {
                    int qtde = Convert.ToInt32(txtQuantidade.Text);
                    decimal vlTotal = qtde * precoUnitario;

                    txtValorTotal.Text = vlTotal.ToString();
                }
            }
        }

        private void txtValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtValorTotal.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtDescontoValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtDescontoValor.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtSeguro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtSeguro.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtFrete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtFrete.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtDespesasAcessorias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtDespesasAcessorias.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtRoyalties_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtRoyalties.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtValorLiquido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtValorLiquido.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            LimpaControles();
            r = new RecebimentoItem();
            r.IdRecebimento = IdRecebimento;
            CarregaNovoItem();
            cboProduto.Focus();
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            try
            {
                if (Util.Validacao.ValidaCampos(this))
                {
                    r.IdRecebimento = IdRecebimento;
                    r.IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
                    r.NomeProduto = cboProduto.SelectedText;

                    r.QuantidadeRecebida = Convert.ToDecimal(txtQuantidade.Text);
                    if (!String.IsNullOrEmpty(cboUnidade.Text)) r.IdUnidade = Convert.ToInt32(cboUnidade.SelectedValue);
                    if (!String.IsNullOrEmpty(txtPrecoUnitario.Text)) r.ValorUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
                    if (!String.IsNullOrEmpty(txtValorTotal.Text)) r.ValorTotal = Convert.ToDecimal(txtValorTotal.Text);

                    if (!String.IsNullOrEmpty(txtDescontoValor.Text)) r.Desconto = Convert.ToDecimal(txtDescontoValor.Text);
                    if (!String.IsNullOrEmpty(txtSeguro.Text)) r.Seguro = Convert.ToDecimal(txtSeguro.Text);
                    if (!String.IsNullOrEmpty(txtFrete.Text)) r.Frete = Convert.ToDecimal(txtFrete.Text);
                    if (!String.IsNullOrEmpty(txtDespesasAcessorias.Text)) r.DespesasAcessorias = Convert.ToDecimal(txtDespesasAcessorias.Text);
                    if (!String.IsNullOrEmpty(txtRoyalties.Text)) r.Royalties = Convert.ToDecimal(txtRoyalties.Text);
                    if (!String.IsNullOrEmpty(txtValorLiquido.Text)) r.ValorLiquido = Convert.ToDecimal(txtValorLiquido.Text);

                    if (!String.IsNullOrEmpty(cboEstilo.Text)) r.IdVariantesEstilo = Convert.ToInt32(cboEstilo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCor.Text)) r.IdVariantesCor = Convert.ToInt32(cboCor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTamanho.Text)) r.IdVariantesTamanho = Convert.ToInt32(cboTamanho.SelectedValue);

                    if (!String.IsNullOrEmpty(cboGrupoLotes.Text)) r.IdGrupoLotes = Convert.ToInt32(cboGrupoLotes.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoSeries.Text)) r.IdGrupoSeries = Convert.ToInt32(cboGrupoSeries.SelectedValue);
                    if (!String.IsNullOrEmpty(cboArmazem.Text)) r.IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDeposito.Text)) r.IdDeposito = Convert.ToInt32(cboDeposito.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLocalizacao.Text)) r.IdLocalizacao = Convert.ToInt32(cboLocalizacao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboGrupoAtivo.Text)) r.IdGrupoAtivo = Convert.ToInt32(cboGrupoAtivo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMetodoPreciacao.Text)) r.IdMetodoDepreciacao = Convert.ToInt32(cboMetodoPreciacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboAtivoFixo.Text)) r.IdAtivoFixo = Convert.ToInt32(cboAtivoFixo.SelectedValue);

                    if (r.IdRecebimentoItem == 0)
                    {
                        dal.RIRepository.Insert(r);
                    }
                    else
                    {
                        dal.RIRepository.Update(r);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close();
                }
                else
                {
                    Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (r.IdRecebimentoItem > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este item?") == DialogResult.Yes)
                {
                    try
                    {
                        dal.ApagarItemRecebimento(r.IdRecebimentoItem);
                        //dal.RIRepository.Delete(r.IdRecebimentoItem);
                        //dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                        Close();
                    }
                    catch (Exception ex)
                    {
                        Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                    }
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (frmBuscaProduto frmBusca = new frmBuscaProduto())
            {
                frmBusca.ShowDialog();
                if (frmBusca.ProdutoSelecionado != null)
                {
                    Produto pr = new ProdutoDAL().ProdutoRepository.GetByID(frmBusca.ProdutoSelecionado.IdProduto);
                    if (pr != null)
                    {
                        cboProduto.SelectedValue = frmBusca.ProdutoSelecionado.IdProduto;
                        cboUnidade.SelectedValue = pr.ComprasIdUnidade == null ? 0 : pr.ComprasIdUnidade;
                        cboEstilo.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesEstilo == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesEstilo;
                        cboCor.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesCor == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesCor;
                        cboTamanho.SelectedValue = frmBusca.ProdutoSelecionado.IdVariantesTamanho == null ? 0 : frmBusca.ProdutoSelecionado.IdVariantesTamanho;

                        cboGrupoLotes.SelectedValue = pr.EstoqueIdGrupoLotes == null ? 0 : pr.EstoqueIdGrupoLotes;
                        cboGrupoSeries.SelectedValue = pr.EstoqueIdGrupoSeries == null ? 0 : pr.EstoqueIdGrupoSeries;
                    }
                }
            }
        }

        private void btnAddLotes_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            if (r.IdRecebimentoItem == 0)
            {
                Util.Aplicacao.ShowMessage("Adicione um item do recebimento.");
                return;
            }

            bool Erro = false;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                try
                {
                    if ((dr.Cells[1].Value != null || dr.Cells[2].Value != null) && dr.Cells[3].Value != null)
                    {
                        int id = dr.Cells[0].Value == null ? 0 : Convert.ToInt32(dr.Cells[0].Value.ToString());
                        RecebimentoItemLote l;
                        if (id == 0)
                        {
                            l = new RecebimentoItemLote();
                            l.IdLote = 0;
                        }
                        else
                        {
                            l = Lotes.Where(x => x.IdLote == id).FirstOrDefault();
                        }

                        l.IdRecebimentoItem = r.IdRecebimentoItem;
                        l.LoteFornecedor = dr.Cells[1].Value == null ? "" : dr.Cells[1].Value.ToString();
                        l.LoteInterno = dr.Cells[2].Value == null ? "" : dr.Cells[2].Value.ToString();
                        l.Quantidade = Convert.ToDecimal(dr.Cells[3].Value.ToString());
                        if (dr.Cells[4].Value != null && !String.IsNullOrEmpty(dr.Cells[4].Value.ToString())) l.DataVencimento = Convert.ToDateTime(dr.Cells[4].Value.ToString());
                        if (dr.Cells[5].Value != null && !String.IsNullOrEmpty(dr.Cells[5].Value.ToString())) l.DataFabricacao = Convert.ToDateTime(dr.Cells[5].Value.ToString());
                        if (dr.Cells[6].Value != null && !String.IsNullOrEmpty(dr.Cells[6].Value.ToString())) l.DataAvisoPrateleira = Convert.ToDateTime(dr.Cells[6].Value.ToString());
                        if (dr.Cells[7].Value != null && !String.IsNullOrEmpty(dr.Cells[7].Value.ToString())) l.DataValidade = Convert.ToDateTime(dr.Cells[7].Value.ToString());
                        if (String.IsNullOrEmpty(l.LoteFornecedor) && String.IsNullOrEmpty(l.LoteInterno))
                        {
                            Erro = true;
                        }
                        if (id == 0)
                            Lotes.Add(l);
                    }
                }
                catch (Exception ex)
                {
                    Erro = true;
                    Util.Aplicacao.ShowMessage("Verifique as informações.");
                }
            }

            if (!Erro)
            {
                decimal? Soma = Lotes.Sum(x => x.Quantidade);

                if (r.QuantidadeRecebida < Convert.ToDecimal(Soma))
                {
                    Util.Aplicacao.ShowMessage("A quantidade informada supera a quantidade recebida.");
                    return;
                }

                foreach (RecebimentoItemLote lote in Lotes)
                {
                    if (lote.IdLote == 0)
                    {
                        lDal.Insert(lote);
                    }
                    else
                    {
                        lDal.Update(lote);
                    }
                    lDal.Save();
                }
            }
            Util.Aplicacao.ShowMessage("Lotes confirmados");
            this.Close();

        }
    }
}
