using ERP.Auxiliares;
using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmClienteCad : RibbonForm
    {
        Cliente c = new Cliente();
        public ClienteDAL dal = new ClienteDAL();
        ClienteCentroCustoDAL cdal = new ClienteCentroCustoDAL();

        public frmClienteCad()
        { InitializeComponent(); }

        public frmClienteCad(Cliente cliente)
        {
            c = cliente;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmClienteCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaCombos();

            if (c.IdCliente == 0)
            {
                cboPais.SelectedValue = 1;
                cboUF.SelectedValue = 26;

                //Marca Pilar como padrão
                List<ComboItem> cid = new List<ComboItem>();
                cid.Add(new ComboItem() { Text = "Pilar do Sul", iValue = 5213 });
                cboCidade.DataSource = cid;
                cboCidade.DisplayMember = "Text";
                cboCidade.ValueMember = "iValue";
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void CarregaCombos()
        {
            CarregarTipo();
            CarregaGrupoCliente();
            CarregaFornecedores();
            CarregaLinhaNegocio();
            CarregaSegmento();
            CarregarAvaliacaoCredito();
            CarregarBloqueado();
            CarregaGrupoComissao();
            CarregaGrupoEncargos();
            CarregaGrupoImposto();
            CarregaCondicaoPagamento();
            CarregaMetodoPagamento();
            CarregaPlanoPagamento();
            CarregaEspecificaoPagamento();
            CarregaDiasPagamento();
            CarregarCodigoJuros();
            CarregarCodigoMultas();
            CarregaCentrosdeCusto();
            CarregaTextoPadrao();

            cboGrupoComissao.DataSource = new GrupoComissaoDAL().GetCombo();
            cboGrupoComissao.DisplayMember = "Text";
            cboGrupoComissao.ValueMember = "iValue";
            cboGrupoComissao.SelectedIndex = -1;

            cboGrupoVendas.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoPreços, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Vendas);
            cboGrupoVendas.DisplayMember = "Text";
            cboGrupoVendas.ValueMember = "iValue";
            cboGrupoVendas.SelectedIndex = -1;

            cboDescontoVista.DataSource = new DescontoaVistaDAL().GetCombo();
            cboDescontoVista.DisplayMember = "Text";
            cboDescontoVista.ValueMember = "iValue";
            cboDescontoVista.SelectedIndex = -1;

            cboCondicaoFrete.DataSource = new CondicaoFreteDAL().GetCombo();
            cboCondicaoFrete.DisplayMember = "Text";
            cboCondicaoFrete.ValueMember = "iValue";
            cboCondicaoFrete.SelectedIndex = -1;

            cboModoEntrega.DataSource = new ModoEntregaDAL().GetCombo();
            cboModoEntrega.DisplayMember = "Text";
            cboModoEntrega.ValueMember = "iValue";
            cboModoEntrega.SelectedIndex = -1;

            cboImpostoRetido.DataSource = new ImpostoRetidoDAL().GetCombo();
            cboImpostoRetido.DisplayMember = "Text";
            cboImpostoRetido.ValueMember = "iValue";
            cboImpostoRetido.SelectedIndex = -1;

            cboNumeroIsencao.DataSource = new NumeroIsencaoDAL().GetCombo();
            cboNumeroIsencao.DisplayMember = "Text";
            cboNumeroIsencao.ValueMember = "iValue";
            cboNumeroIsencao.SelectedIndex = -1;

            cboDescontoCombinado.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoDescontoCombinado, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Vendas);
            cboDescontoCombinado.DisplayMember = "Text";
            cboDescontoCombinado.ValueMember = "iValue";
            cboDescontoCombinado.SelectedIndex = -1;

            cboDescontoTotal.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoDescontoTotal, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Vendas);
            cboDescontoTotal.DisplayMember = "Text";
            cboDescontoTotal.ValueMember = "iValue";
            cboDescontoTotal.SelectedIndex = -1;

            cboDescontoVarejista.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoDescontoVarejo, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Vendas);
            cboDescontoVarejista.DisplayMember = "Text";
            cboDescontoVarejista.ValueMember = "iValue";
            cboDescontoVarejista.SelectedIndex = -1;

            cboVendedor.DataSource = new VendedorDAL().GetCombo();
            cboVendedor.DisplayMember = "Text";
            cboVendedor.ValueMember = "iValue";
            cboVendedor.SelectedIndex = -1;
            

            //carrega paises
            var paises = new PaisDAL().Get().OrderBy(x => x.NomePais).ToList();
            cboPais.DataSource = paises;
            cboPais.DisplayMember = "NomePais";
            cboPais.ValueMember = "IdPais";
            cboPais.SelectedIndex = -1;

            //Carrega uf
            var ufs = new UnidadeFederacaoDAL(new DB_ERPContext()).Get().OrderBy(x => x.UF).ToList();
            cboUF.DataSource = ufs;
            cboUF.DisplayMember = "UF";
            cboUF.ValueMember = "IdUF";
            cboUF.SelectedIndex = -1;
        }

        private void frmClienteCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = c.IdCliente.ToString();
            txtRazao.Text = c.RazaoSocial;
            txtFantasia.Text = c.NomeFantasia;
            if (c.Tipo != null) cboTipo.SelectedValue = Convert.ToInt32(c.Tipo);
            if (c.Tipo == 1)
            {
                CNPJ.Text = "CPF";
                txtCNPJ.Mask = "999.999.999-99";
            }
            else
            {
                CNPJ.Text = "CNPJ";
                txtCNPJ.Mask = "99.999.999/9999-99";
            }
            txtCNPJ.Text = c.CNPJ;
            txtInscricao.Text = c.InscricaoEstadual;

            txtCCM.Text = c.CCM;
            txtNIT.Text = c.NIT;
            txtINSSCEI.Text = c.INSSCEI;
            txtCNAE.Text = c.CNAE;
            txtEmail.Text = c.Email;
            txtInternet.Text = c.Internet;
            txtCelular.Text = c.Celular;
            txtTelefone.Text = c.Telefone1;
            txtFax.Text = c.Telefone2;
            chkServicoEnderecoEntrega.Checked = c.ServicoEnderecoEntrega;
            chkUsuarioFinal.Checked = c.UsuarioFinal;
            chkGerarNotaRecebida.Checked = c.GerarNotaRecebida;
            chkDescontarPISCofins.Checked = c.DescontarPiseCofins;
            chkContribuinteICMS.Checked = c.ContribuinteICMS;
            chkImpostoRetido.Checked = c.ImpostoRetido;
            chkSuframa.Checked = c.Suframa;
            txtCodigoSuframa.Text = c.CodigoSuframa;
            lblCodigoSuframa.Visible = false;
            txtCodigoSuframa.Visible = false;
            if (chkSuframa.Checked)
            {
                lblCodigoSuframa.Visible = true;
                txtCodigoSuframa.Visible = true;
            }

            if (c.IdGrupoCliente != null) cboGrupoCliente.SelectedValue = c.IdGrupoCliente;
            if (c.IdFornecedor != null) cboFornecedor.SelectedValue = c.IdFornecedor;
            if (c.IdLinhaNegocio != null) cboLinhaNegocio.SelectedValue = c.IdLinhaNegocio;
            if (c.IdSegmento != null) cboSegmento.SelectedValue = c.IdSegmento;
            if (c.IdSubSegmento != null) cboSubSegmento.SelectedValue = c.IdSubSegmento;
            if (c.Bloqueado != null) cboBloqueado.SelectedValue = c.Bloqueado.ToString();
            if (c.IdAvaliacaoCredito != null) cboAvaliacaoCredito.SelectedValue = c.IdAvaliacaoCredito;
            if (c.IdPais != null) cboPais.SelectedValue = c.IdPais;
            if (c.IdUf != null) cboUF.SelectedValue = c.IdUf;
            if (c.IdCidade != null) cboCidade.SelectedValue = c.IdCidade;
            txtLog.Text = c.Logradouro;
            txtNumero.Text = c.Nro;
            txtCompl.Text = c.Compl;
            txtBairro.Text = c.Bairro;
            txtCEP.Text = c.CEP;

            chkLimiteCreditoObrigatorio.Checked = c.LimiteCreditoObrigatorio;
            txtLimiteCredito.Text = c.LimiteCredito.ToString("N4");
            lblLimiteCredito.Visible = false;
            txtLimiteCredito.Visible = false;
            if (chkLimiteCreditoObrigatorio.Checked)
            {
                lblLimiteCredito.Visible = true;
                txtLimiteCredito.Visible = true;
            }

            if (c.IdGrupoComissao != null) cboGrupoComissao.SelectedValue = c.IdGrupoComissao;
            if (c.IdGrupoEncargos != null) cboGrupoEncargos.SelectedValue = c.IdGrupoEncargos;
            if (c.IdCondicaoPagamento != null) cboCondPgto.SelectedValue = c.IdCondicaoPagamento;
            if (c.IdMetodoPagamento != null) cboMetodoPagamento.SelectedValue = c.IdMetodoPagamento;
            if (c.IdPlanoPagamento != null) cboPlanoPagamento.SelectedValue = c.IdPlanoPagamento;
            if (c.IdEspecificacaoPagamento != null) cboEspecificacaoPagamento.SelectedValue = c.IdEspecificacaoPagamento;
            if (c.IdDiasPagamento != null) cboDiasPagamento.SelectedValue = c.IdDiasPagamento;
            if (c.IdCodigoJuros != null) cboCodigoJuros.SelectedValue = c.IdCodigoJuros;
            if (c.IdCodigoMultas != null) cboCodigoMultas.SelectedValue = c.IdCodigoMultas;
            if (c.IdGrupoImposto != null) cboGrupoImpostos.SelectedValue = c.IdGrupoImposto;
            cboTextoPadrao.SelectedValue = c.IdTextoPadrao == null ? 0 : c.IdTextoPadrao;

            cboGrupoComissao.SelectedValue = c.IdGrupoComissao == null ? 0 : c.IdGrupoComissao;
            cboGrupoVendas.SelectedValue = c.IdGrupoVendas == null ? 0 : c.IdGrupoVendas;
            cboDescontoCombinado.SelectedValue = c.IdDescontoCombinado == null ? 0 : c.IdDescontoCombinado;
            cboDescontoTotal.SelectedValue = c.IdDescontoTotal == null ? 0 : c.IdDescontoTotal;
            cboDescontoVarejista.SelectedValue = c.IdDescontoVarejista == null ? 0 : c.IdDescontoVarejista;
            cboDescontoVista.SelectedValue = c.IdDescontoAVista == null ? 0 : c.IdDescontoAVista;
            cboCondicaoFrete.SelectedValue = c.IdCondicaoFrete == null ? 0 : c.IdCondicaoFrete;
            cboModoEntrega.SelectedValue = c.IdModoEntrega == null ? 0 : c.IdModoEntrega;
            cboImpostoRetido.SelectedValue = c.IdImpostoRetido == null ? 0 : c.IdImpostoRetido;
            cboNumeroIsencao.SelectedValue = c.IdNumeroIsencao == null ? 0 : c.IdNumeroIsencao;
            cboVendedor.SelectedValue = c.IdVendedor == null ? 0 : c.IdVendedor;

            CarregaEnderecos();
            CarregaTelefones();
            CarregaContatos();
            CarregaContasBancarias();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaContatos()
        {
            ContatoDAL cdal = new ContatoDAL();
            var lista = cdal.getCliente(c.IdCliente).Select(x => new { x.IdClienteContato, x.IdContato, x.Contato.Nome, x.Contato.EMail }).ToList();
            grContato.AutoGenerateColumns = false;
            grContato.RowHeadersVisible = false;
            grContato.DataSource = lista;
        }

        protected void CarregaEnderecos()
        {
            
        }

        protected void CarregaTelefones()
        {
            TelefoneDAL tDal = new TelefoneDAL(new DB_ERPContext());
            var telefones = tDal.getCliente(c.IdCliente).Select(x => new { x.IdClienteTelefone, x.IdTelefone, x.Telefone.TipoTelefone.Descricao, x.Telefone.CodigoPais, x.Telefone.DDD, x.Telefone.NumeroTelefone }).ToList();
            grTelefone.AutoGenerateColumns = false;
            grTelefone.RowHeadersVisible = false;
            grTelefone.DataSource = telefones;
        }

        protected void CarregaCentrosdeCusto()
        {
            var lista = cdal.GetByCliente(c.IdCliente);
            dgCentros.AutoGenerateColumns = false;
            dgCentros.DataSource = lista;
        }

        protected void CarregaContasBancarias()
        {
            ContaBancariaDAL cbdal = new ContaBancariaDAL();
            var lista = cbdal.getCliente(c.IdCliente).Select(x => new { x.IdClienteContaBancaria, x.IdContaBancaria, x.IdCliente, Banco = x.ContaBancaria.Banco.NomeBanco, Agencia = x.ContaBancaria.Agencia + "-" + x.ContaBancaria.DigitoAgencia, Conta = x.ContaBancaria.Conta + "-" + x.ContaBancaria.DigitoConta }).ToList();
            grContaBancaria.AutoGenerateColumns = false;
            grContaBancaria.RowHeadersVisible = false;
            grContaBancaria.DataSource = lista;
        }

        protected void CarregaFornecedores()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        protected void CarregaEspecificaoPagamento()
        {
            cboEspecificacaoPagamento.DataSource = new EspecificacaoPagamentoDAL().GetCombo();
            cboEspecificacaoPagamento.DisplayMember = "Text";
            cboEspecificacaoPagamento.ValueMember = "iValue";
            cboEspecificacaoPagamento.SelectedIndex = -1;
        }

        protected void CarregaGrupoCliente()
        {
            GrupoClienteDAL gcdal = new GrupoClienteDAL();

            var gc = gcdal.Get().OrderBy(o => o.Descricao).ToList();
            cboGrupoCliente.DataSource = gc;
            cboGrupoCliente.ValueMember = "IdGrupoCliente";
            cboGrupoCliente.DisplayMember = "Descricao";
            cboGrupoCliente.SelectedIndex = -1;
        }

        protected void CarregaGrupoComissao()
        {
            cboGrupoComissao.DataSource = new GrupoComissaoDAL().GetCombo();
            cboGrupoComissao.DisplayMember = "Text";
            cboGrupoComissao.ValueMember = "iValue";
            cboGrupoComissao.SelectedIndex = -1;
        }

        protected void CarregaGrupoEncargos()
        {
            cboGrupoEncargos.DataSource = new GrupoEncargosDAL().getCombo();
            cboGrupoEncargos.DisplayMember = "Text";
            cboGrupoEncargos.ValueMember = "iValue";
            cboGrupoEncargos.SelectedIndex = -1;
        }

        protected void CarregaGrupoImposto()
        {
            cboGrupoImpostos.DataSource = new GrupoImpostoDAL().getCombo();
            cboGrupoImpostos.DisplayMember = "Text";
            cboGrupoImpostos.ValueMember = "iValue";
            cboGrupoImpostos.SelectedIndex = -1;
        }

        protected void CarregaLinhaNegocio()
        {
            LinhaNegocioDAL lndal = new LinhaNegocioDAL();

            var ln = lndal.Get().OrderBy(o => o.Nome).ToList();
            cboLinhaNegocio.DataSource = ln;
            cboLinhaNegocio.ValueMember = "IdLinhaNegocio";
            cboLinhaNegocio.DisplayMember = "Nome";
            cboLinhaNegocio.SelectedIndex = -1;
        }

        protected void CarregaSegmento()
        {
            SegmentoDAL sdal = new SegmentoDAL();

            var s = sdal.Get().OrderBy(o => o.Nome).ToList();
            cboSegmento.DataSource = s;
            cboSegmento.ValueMember = "IdSegmento";
            cboSegmento.DisplayMember = "Nome";
            cboSegmento.SelectedIndex = -1;
        }

        protected void CarregaSubSegmento(int idSegmento)
        {
            SubSegmentoDAL ssdal = new SubSegmentoDAL();

            var ss = ssdal.GetByIDSegmento(idSegmento).OrderBy(o => o.Nome).ToList();
            cboSubSegmento.DataSource = ss;
            cboSubSegmento.ValueMember = "IdSegmento";
            cboSubSegmento.DisplayMember = "Nome";
            cboSubSegmento.SelectedIndex = -1;
        }

        protected void CarregaTextoPadrao()
        {
            cboTextoPadrao.DataSource = new TextoPadraoDAL().GetCombo();
            cboTextoPadrao.DisplayMember = "Text";
            cboTextoPadrao.ValueMember = "iValue";
            cboTextoPadrao.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new Cliente();
            lbCodigo.Text = "0";
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            string cnpj = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Trim();

            if (cboTipo.SelectedValue != null && cboTipo.SelectedValue.ToString() != "3")
            {
                if (cnpj.Length == 14)
                {
                    if (!Util.Validacao.ValidaCNPJ.IsCnpj(cnpj))
                    {
                        Util.Aplicacao.ShowMessage("CNPJ inválido!");
                        return;
                    }
                }
                else
                {
                    if (!Util.Validacao.ValidaCPF.IsCpf(cnpj))
                    {
                        Util.Aplicacao.ShowMessage("CPF inválido!");
                        return;
                    }
                }

                if (c.IdCliente == 0)
                {
                    if (dal.ConsultaCNPJ(cnpj, c.IdCliente))
                    {
                        Util.Aplicacao.ShowMessage("CNPJ/CPF já existe na base de dados.");
                        return;
                    }
                }
            }

            if (!String.IsNullOrEmpty(txtEmail.Text))
            {
                if (!Util.Validacao.ValidaEmail(txtEmail.Text))
                {
                    Util.Aplicacao.ShowMessage("Email inválido!");
                    return;
                }
            }

            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    //limpa os campos antes de salvar
                    c.CCM = null;
                    c.CNAE = null;
                    c.CNPJ = null;
                    c.CodigoSuframa = null;
                    c.Email = null;
                    c.NomeFantasia = null;
                    c.IdAvaliacaoCredito = null;
                    c.Bloqueado = null;
                    c.IdCodigoJuros = null;
                    c.IdCodigoMultas = null;
                    c.IdCondicaoFrete = null;
                    c.IdCondicaoPagamento = null;
                    c.IdDescontoCombinado = null;
                    c.IdDescontoTotal = null;
                    c.IdDescontoVarejista = null;
                    c.IdDescontoAVista = null;
                    c.IdDiasPagamento = null;
                    c.IdEspecificacaoPagamento = null;
                    c.IdFornecedor = null;
                    c.IdGrupoCliente = null;
                    c.IdGrupoComissao = null;
                    c.IdGrupoEncargos = null;
                    c.IdGrupoImposto = null;
                    c.IdGrupoVendas = null;
                    c.IdImpostoRetido = null;
                    c.IdLinhaNegocio = null;
                    c.IdMetodoPagamento = null;
                    c.IdModoEntrega = null;
                    c.IdNumeroIsencao = null;
                    c.IdPlanoPagamento = null;
                    c.IdSegmento = null;
                    c.IdSubSegmento = null;
                    c.IdTextoPadrao = null;
                    c.Tipo = null;
                    c.InscricaoEstadual = null;
                    c.INSSCEI = null;
                    c.Internet = null;
                    c.LimiteCredito = 0;
                    c.NIT = null;
                    c.RazaoSocial = null;

                    c.RazaoSocial = txtRazao.Text;
                    c.NomeFantasia = txtFantasia.Text;
                    c.Tipo = Convert.ToInt32(cboTipo.SelectedValue);
                    c.CNPJ = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Trim();
                    c.InscricaoEstadual = txtInscricao.Text;

                    c.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));

                    if (!String.IsNullOrEmpty(cboTipo.Text))
                        c.Tipo = Convert.ToInt32(cboTipo.SelectedValue);

                    c.CCM = txtCCM.Text;
                    c.NIT = txtNIT.Text;
                    c.INSSCEI = txtINSSCEI.Text;
                    c.CNAE = txtCNAE.Text;
                    c.UsuarioFinal = chkUsuarioFinal.Checked;
                    c.ServicoEnderecoEntrega = chkServicoEnderecoEntrega.Checked;
                    c.GerarNotaRecebida = chkGerarNotaRecebida.Checked;
                    c.DescontarPiseCofins = chkDescontarPISCofins.Checked;
                    c.ContribuinteICMS = chkContribuinteICMS.Checked;
                    c.ImpostoRetido = chkImpostoRetido.Checked;
                    c.Suframa = chkSuframa.Checked;
                    if (chkSuframa.Checked)
                    {
                        c.CodigoSuframa = txtCodigoSuframa.Text;
                    }
                    else
                    {
                        c.CodigoSuframa = "";
                    }

                    c.Email = txtEmail.Text;
                    c.Internet = txtInternet.Text;

                    if (!String.IsNullOrEmpty(cboGrupoCliente.Text)) c.IdGrupoCliente = Convert.ToInt32(cboGrupoCliente.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFornecedor.Text)) c.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLinhaNegocio.Text)) c.IdLinhaNegocio = Convert.ToInt32(cboLinhaNegocio.SelectedValue);
                    if (!String.IsNullOrEmpty(cboSegmento.Text)) c.IdSegmento = Convert.ToInt32(cboSegmento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboSubSegmento.Text)) c.IdSubSegmento = Convert.ToInt32(cboSubSegmento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboBloqueado.Text)) c.Bloqueado = Convert.ToInt32(cboBloqueado.SelectedValue);
                    if (!String.IsNullOrEmpty(cboAvaliacaoCredito.Text)) c.IdAvaliacaoCredito = Convert.ToInt32(cboAvaliacaoCredito.SelectedValue);
                    c.LimiteCreditoObrigatorio = chkLimiteCreditoObrigatorio.Checked;
                    if (!String.IsNullOrEmpty(txtLimiteCredito.Text)) c.LimiteCredito = Convert.ToDecimal(txtLimiteCredito.Text);
                    if (!String.IsNullOrEmpty(cboGrupoComissao.Text)) c.IdGrupoComissao = Convert.ToInt32(cboGrupoComissao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoEncargos.Text)) c.IdGrupoEncargos = Convert.ToInt32(cboGrupoEncargos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCondPgto.Text)) c.IdCondicaoPagamento = Convert.ToInt32(cboCondPgto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMetodoPagamento.Text)) c.IdMetodoPagamento = Convert.ToInt32(cboMetodoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPlanoPagamento.Text)) c.IdPlanoPagamento = Convert.ToInt32(cboPlanoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboEspecificacaoPagamento.Text)) c.IdEspecificacaoPagamento = Convert.ToInt32(cboEspecificacaoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDiasPagamento.Text)) c.IdDiasPagamento = Convert.ToInt32(cboDiasPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoJuros.Text)) c.IdCodigoJuros = Convert.ToInt32(cboCodigoJuros.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoMultas.Text)) c.IdCodigoMultas = Convert.ToInt32(cboCodigoMultas.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImpostos.Text)) c.IdGrupoImposto = Convert.ToInt32(cboGrupoImpostos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTextoPadrao.Text)) c.IdTextoPadrao = Convert.ToInt32(cboTextoPadrao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoComissao.Text)) c.IdGrupoComissao = Convert.ToInt32(cboGrupoComissao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoVendas.Text)) c.IdGrupoVendas = Convert.ToInt32(cboGrupoVendas.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDescontoCombinado.Text)) c.IdDescontoCombinado = Convert.ToInt32(cboDescontoCombinado.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDescontoTotal.Text)) c.IdDescontoTotal = Convert.ToInt32(cboDescontoTotal.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDescontoVarejista.Text)) c.IdDescontoVarejista = Convert.ToInt32(cboDescontoVarejista.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDescontoVista.Text)) c.IdDescontoAVista = Convert.ToInt32(cboDescontoVista.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCondicaoFrete.Text)) c.IdCondicaoFrete = Convert.ToInt32(cboCondicaoFrete.SelectedValue);
                    if (!String.IsNullOrEmpty(cboModoEntrega.Text)) c.IdModoEntrega = Convert.ToInt32(cboModoEntrega.SelectedValue);
                    if (!String.IsNullOrEmpty(cboImpostoRetido.Text)) c.IdImpostoRetido = Convert.ToInt32(cboImpostoRetido.SelectedValue);

                    if (!String.IsNullOrEmpty(cboNumeroIsencao.Text)) c.IdNumeroIsencao = Convert.ToInt32(cboNumeroIsencao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVendedor.Text)) c.IdVendedor = Convert.ToInt32(cboVendedor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPais.Text)) c.IdPais = Convert.ToInt32(cboPais.SelectedValue);
                    if (!String.IsNullOrEmpty(cboUF.Text)) c.IdUf = Convert.ToInt32(cboUF.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCidade.Text)) c.IdCidade = Convert.ToInt32(cboCidade.SelectedValue);
                    
                    c.Logradouro = txtLog.Text;
                    c.Nro = txtNumero.Text;
                    c.Compl = txtCompl.Text;
                    c.Bairro = txtBairro.Text;
                    c.CEP = txtCEP.Text;

                    c.Celular = txtCelular.Text;
                    c.Telefone1 = txtTelefone.Text;
                    c.Telefone2 = txtFax.Text;

                    if (c.IdCliente == 0)
                    {
                        dal.CRepository.Insert(c);
                    }
                    else
                    {
                        dal.CRepository.Update(c);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
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
            try
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = c.IdCliente;
                    dal.CRepository.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
            }
        }

        private void tsbAdicionarEndereco_Click(object sender, EventArgs e)
        {
            if (c.IdCliente != 0)
            {
                frmEndereco cad = new frmEndereco("Cliente", c.IdCliente, new Endereco());
                cad.ShowDialog();
                CarregaEnderecos();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar endereços.");
            }
        }

        private void tsbExcluirEndereco_Click(object sender, EventArgs e)
        {
           
        }

        private void CarregaCidades()
        {

        }

        private void grEndereco_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tsbAdicionarTelefone_Click(object sender, EventArgs e)
        {
            if (c.IdCliente != 0)
            {
                frmTelefone cad = new frmTelefone("Cliente", c.IdCliente, new Telefone());
                cad.ShowDialog();
                CarregaTelefones();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar telefones.");
            }
        }

        private void tsbExcluirTelefone_Click(object sender, EventArgs e)
        {
            if (grTelefone.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão do telefone") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(grTelefone.Rows[grTelefone.SelectedRows[0].Index].Cells[0].Value.ToString());
                    ClienteTelefone te = dal.CTRepository.GetByID(id);
                    int Idtelefone = te.IdTelefone;

                    //apaga o relacionamento
                    dal.CTRepository.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    //apaga o endereço
                    TelefoneDAL eDal = new TelefoneDAL(new DB_ERPContext());
                    eDal.Delete(te.IdTelefone);
                    eDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaTelefones();
                }
            }
        }

        private void grTelefone_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grTelefone.Rows.Count > 0)
            {
                string sId = grTelefone.Rows[e.RowIndex].Cells[1].Value.ToString();
                int id = Convert.ToInt32(sId);
                TelefoneDAL tDal = new TelefoneDAL(new DB_ERPContext());
                Telefone te = tDal.GetByID(id);
                frmTelefone cad = new frmTelefone("Cliente", c.IdCliente, te);
                cad.tDal = tDal;
                cad.ShowDialog();
                CarregaEnderecos();
            }
        }

        private void tsbAdicionarContato_Click(object sender, EventArgs e)
        {
            if (c.IdCliente != 0)
            {
                frmContato cad = new frmContato("Cliente", c.IdCliente, new Contato());
                cad.ShowDialog();
                CarregaContatos();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar contatos.");
            }
        }

        private void tsbExcluirContato_Click(object sender, EventArgs e)
        {
            if (grContato.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão do contato") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(grContato.Rows[grContato.SelectedRows[0].Index].Cells[0].Value.ToString());
                    ClienteContato te = dal.CCRepository.GetByID(id);
                    int IdContato = te.IdContato;

                    //apaga o relacionamento
                    dal.CCRepository.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    //apaga o endereço
                    ContatoDAL eDal = new ContatoDAL();
                    eDal.CRepository.Delete(te.IdContato);
                    eDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaContatos();
                }
            }
        }

        private void grContato_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grContato.Rows.Count > 0)
            {
                string sId = grContato.Rows[e.RowIndex].Cells[1].Value.ToString();
                int id = Convert.ToInt32(sId);
                ContatoDAL cDal = new ContatoDAL();
                Contato te = cDal.CRepository.GetByID(id);
                frmContato cad = new frmContato("Cliente", c.IdCliente, te);
                cad.contatoDal = cDal;
                cad.ShowDialog();
                CarregaContatos();
            }
        }

        private void CarregarTipo()
        {
            List<ComboItem> Tipo = new List<ComboItem>();
            Tipo.Add(new ComboItem() { iValue = 1, Text = "Física" });
            Tipo.Add(new ComboItem() { iValue = 2, Text = "Jurídica" });
            Tipo.Add(new ComboItem() { iValue = 3, Text = "Extrangeiro" });

            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "iValue";
            cboTipo.DataSource = Tipo;
            cboTipo.SelectedIndex = -1;
        }

        private void CarregarAvaliacaoCredito()
        {
            cboAvaliacaoCredito.DataSource = new AvaliacaoCreditoDAL().GetCombo();
            cboAvaliacaoCredito.DisplayMember = "Text";
            cboAvaliacaoCredito.ValueMember = "iValue";
            cboAvaliacaoCredito.SelectedIndex = -1;
        }

        private void CarregarBloqueado()
        {
            List<DropList> lista = Util.EnumERP.CarregarBloqueado();

            cboBloqueado.DisplayMember = "Text";
            cboBloqueado.ValueMember = "Value";
            cboBloqueado.DataSource = lista;
            cboBloqueado.SelectedIndex = -1;
        }

        private void CarregarCodigoJuros()
        {
            cboCodigoJuros.DataSource = new CodigoJurosDAL().GetCombo();
            cboCodigoJuros.DisplayMember = "Text";
            cboCodigoJuros.ValueMember = "iValue";
            cboCodigoJuros.SelectedIndex = -1;
        }

        private void CarregarCodigoMultas()
        {
            cboCodigoMultas.DataSource = new CodigoMultasDAL().GetCombo();
            cboCodigoMultas.DisplayMember = "Text";
            cboCodigoMultas.ValueMember = "iValue";
            cboCodigoMultas.SelectedIndex = -1;
        }

        protected void CarregaCondicaoPagamento()
        {
            cboCondPgto.DataSource = new CondicaoPagamentoDAL().GetCombo();
            cboCondPgto.DisplayMember = "Text";
            cboCondPgto.ValueMember = "iValue";
            cboCondPgto.SelectedIndex = -1;
        }

        protected void CarregaMetodoPagamento()
        {
            cboMetodoPagamento.DataSource = new MetodoPagamentoDAL().GetCombo();
            cboMetodoPagamento.DisplayMember = "Text";
            cboMetodoPagamento.ValueMember = "iValue";
            cboMetodoPagamento.SelectedIndex = -1;
        }

        protected void CarregaPlanoPagamento()
        {
            cboPlanoPagamento.DataSource = new PlanoPagamentoDAL().GetCombo();
            cboPlanoPagamento.DisplayMember = "Text";
            cboPlanoPagamento.ValueMember = "iValue";
            cboPlanoPagamento.SelectedIndex = -1;
        }

        protected void CarregaDiasPagamento()
        {
            cboDiasPagamento.DataSource = new DiasPagamentoDAL().GetCombo();
            cboDiasPagamento.DisplayMember = "Text";
            cboDiasPagamento.ValueMember = "iValue";
            cboDiasPagamento.SelectedIndex = -1;
        }

        private void chkSuframa_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboSegmento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSegmento.SelectedIndex >= 0)
            {
                var segmento = cboSegmento.Items[cboSegmento.SelectedIndex];

                int idSegmento = ((ERP.Models.Segmento)(segmento)).IdSegmento;
                CarregaSubSegmento(idSegmento);
            }
            else
            {
                CarregaSubSegmento(0);
            }
        }

        private void chkLimiteCreditoObrigatorio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSuframa.Checked)
            {
                lblLimiteCredito.Visible = true;
                txtLimiteCredito.Visible = true;
                txtLimiteCredito.Text = "";
            }
            else
            {
                lblLimiteCredito.Visible = false;
                txtLimiteCredito.Visible = false;
            }
        }

        private void txtLimiteCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtLimiteCredito.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void tsbAdicionarContaBancaria_Click(object sender, EventArgs e)
        {
            if (c.IdCliente != 0)
            {
                frmContaBancaria cad = new frmContaBancaria("Cliente", c.IdCliente, new ContaBancaria());
                cad.ShowDialog();
                CarregaContasBancarias();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar contas bancárias.");
            }
        }

        private void tsbExcluirContaBancaria_Click(object sender, EventArgs e)
        {
            if (grContaBancaria.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão da conta bancária") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(grContaBancaria.Rows[grContaBancaria.SelectedRows[0].Index].Cells[0].Value.ToString());
                    ClienteContaBancaria ccb = dal.CCBRepository.GetByID(id);
                    int IdContaBancaria = ccb.IdContaBancaria;

                    //apaga o relacionamento
                    dal.CCBRepository.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    //apaga a Conta Bancária
                    ContaBancariaDAL cbDal = new ContaBancariaDAL();
                    cbDal.Delete(ccb.IdContaBancaria);
                    cbDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaContasBancarias();
                }
            }
        }

        private void grContaBancaria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grContaBancaria.Rows.Count > 0)
            {
                string sId = grContaBancaria.Rows[e.RowIndex].Cells[1].Value.ToString();
                int id = Convert.ToInt32(sId);
                ContaBancariaDAL cbDal = new ContaBancariaDAL();
                ContaBancaria cb = cbDal.GetByID(id);
                frmContaBancaria cad = new frmContaBancaria("Cliente", c.IdCliente, cb);
                cad.dal = cbDal;
                cad.ShowDialog();
                CarregaContasBancarias();
            }
        }

        private void cboTipo_Leave(object sender, EventArgs e)
        {
            if (cboTipo.SelectedValue != null)
            {
                if (cboTipo.SelectedValue.ToString() == "1")
                {
                    CNPJ.Text = "CPF";
                    txtCNPJ.Mask = "999.999.999-99";
                }
                else
                {
                    CNPJ.Text = "CNPJ";
                    txtCNPJ.Mask = "99.999.999/9999-99";
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (c.IdCliente == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados do fornecedor antes de adicionar centros de custo.");
                return;
            }
            frmCentroCustoAux frmCC = new frmCentroCustoAux("C", c.IdCliente);
            frmCC.cdal = cdal;
            frmCC.ShowDialog();
            CarregaCentrosdeCusto();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dgCentros.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir o centro de custo selecionado?") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgCentros.Rows[dgCentros.SelectedRows[0].Index].Cells[0].Value);
                    try
                    {
                        cdal.Delete(id);
                        cdal.Save();
                        CarregaCentrosdeCusto();
                    }
                    catch (Exception ex)
                    {
                        Util.Aplicacao.ShowErrorMessage(ex);
                    }
                }
            }
        }

        private void cboGrupoCliente_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboGrupoCliente.Text))
            {
                var gc = new GrupoClienteDAL().GetByID(Convert.ToInt32(cboGrupoCliente.SelectedValue));
                if (gc != null)
                {
                    if (String.IsNullOrEmpty(cboGrupoImpostos.Text))
                    {
                        cboGrupoImpostos.SelectedValue = gc.IdGrupoImposto == null ? 0 : Convert.ToInt32(gc.IdGrupoImposto);
                    }

                    if (String.IsNullOrEmpty(cboCondPgto.Text))
                    {
                        cboCondPgto.SelectedValue = gc.IdCondicaoPagamento == null ? 0 : Convert.ToInt32(gc.IdCondicaoPagamento);
                    }
                }
            }
        }

        private void cboUF_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboUF.Text))
            {
                int IdUF = Convert.ToInt32(cboUF.SelectedValue);
                var cidades = new CidadeDAL().Get().Where(x => x.IdUF == IdUF).ToList();
                cboCidade.DataSource = cidades;
                cboCidade.DisplayMember = "Nome";
                cboCidade.ValueMember = "IdCidade";
                cboCidade.SelectedIndex = -1;
            }
        }
    }
}
