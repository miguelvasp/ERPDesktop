using ERP.Auxiliares;
using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmFornecedorCad : RibbonForm
    {
        Fornecedor f = new Fornecedor();
        public FornecedorDAL dal = new FornecedorDAL();
        FornecedorCentroCustoDAL ccDal = new FornecedorCentroCustoDAL();

        public frmFornecedorCad(Fornecedor fornecedor)
        {
            f = fornecedor;
            InitializeComponent();
        }

        public frmFornecedorCad()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmFornecedorCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaCombos();

            if (f.IdFornecedor == 0)
            {
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
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            CarregaLinhaNegocio();
            CarregaSegmento();
            CarregarSuspenso();
            CarregaMoeda();
            CarregaGrupoImposto();
            CarregaRoyalties();
            CarregaCondicaoPagamento();
            CarregaMetodoPagamento();
            CarregaPlanoPagamento();
            CarregaEspecificaoPagamento();
            CarregaDiasPagamento();
            CarregarCodigoJuros();
            CarregarCodigoMultas();
            CarregaCentrosdeCusto();
            CarregarAvaliacaoCredito();
            CarregaTextoPadrao();
            CarregarGrupoFornecedor();

            cboImpostoRetido.DataSource = new ImpostoRetidoDAL().GetCombo();
            cboImpostoRetido.DisplayMember = "Text";
            cboImpostoRetido.ValueMember = "iValue";
            cboImpostoRetido.SelectedIndex = -1;

            cboCliente.DataSource = new ClienteDAL().GetCombo(sEmpresa);
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;

            cboMotivoFinanceiro.DataSource = new MotivoFinanceiroDAL().GetComboFornecedor();
            cboMotivoFinanceiro.DisplayMember = "Text";
            cboMotivoFinanceiro.ValueMember = "iValue";
            cboMotivoFinanceiro.SelectedIndex = -1;

            cboNumeroIsencao.DataSource = new NumeroIsencaoDAL().GetCombo();
            cboNumeroIsencao.DisplayMember = "Text";
            cboNumeroIsencao.ValueMember = "iValue";
            cboNumeroIsencao.SelectedIndex = -1;

            cboDescontoVista.DataSource = new DescontoaVistaDAL().GetCombo();
            cboDescontoVista.DisplayMember = "Text";
            cboDescontoVista.ValueMember = "iValue";
            cboDescontoVista.SelectedIndex = -1;

            cboDescontoTotal.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoDescontoTotal, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Compras);
            cboDescontoTotal.DisplayMember = "Text";
            cboDescontoTotal.ValueMember = "iValue";
            cboDescontoTotal.SelectedIndex = -1;

            cboDescontoCombinado.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoDescontoCombinado, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Compras);
            cboDescontoCombinado.DisplayMember = "Text";
            cboDescontoCombinado.ValueMember = "iValue";
            cboDescontoCombinado.SelectedIndex = -1;

            cboGrupoCompras.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoPreços, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Compras); ;
            cboGrupoCompras.DisplayMember = "Text";
            cboGrupoCompras.ValueMember = "iValue";
            cboGrupoCompras.SelectedIndex = -1;

            List<ComboItem> Tipo = new List<ComboItem>();
            Tipo.Add(new ComboItem() { iValue = 1, Text = "Física" });
            Tipo.Add(new ComboItem() { iValue = 2, Text = "Jurídica" });

            cboTipo.DataSource = Tipo;
            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "iValue";
            cboTipo.SelectedIndex = -1;
        }

        private void frmFornecedorCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = f.IdFornecedor.ToString();
            txtRazao.Text = f.RazaoSocial;
            txtFantasia.Text = f.NomeFantasia;
            if (f.Tipo != null)
                cboTipo.SelectedValue = f.Tipo;

            if (f.Tipo == 1)
            {
                lblCNPJ.Text = "CPF";
                txtCNPJ.Mask = "999.999.999-99";
            }
            else
            {
                lblCNPJ.Text = "CNPJ";
                txtCNPJ.Mask = "99.999.999/9999-99";
            }

            txtCNPJ.Text = f.CNPJ;

            txtInscricao.Text = f.InscricaoEstadual;
            txtCCM.Text = f.CCM;
            txtNIT.Text = f.NIT;
            txtINSSCEI.Text = f.INSSCEI;
            txtCNAE.Text = f.CNAE;
            chkOptanteSimples.Checked = f.OptanteSimples;
            chkSIMEI.Checked = f.SIMEI;
            chkServicoEnderecoEntrega.Checked = f.ServicoEnderecoEntrega;
            chkContribuinteICMS.Checked = f.ContribuinteICMS;
            chkGerarNotaRecebida.Checked = f.GerarNotaRecebida;
            chkUsoConsumo.Checked = f.UsoConsumo;
            chkCodigoRendimento.Checked = f.CodigoRendimento;
            txtEmail.Text = f.Email;
            txtInternet.Text = f.Internet;

            if (f.IdEspecificacaoPagamento != null)
                cboEspecificacaoPagamento.SelectedValue = f.IdEspecificacaoPagamento;

            if (f.IdGrupoFornecedor != null)
                cboGrupoFornecedor.SelectedValue = f.IdGrupoFornecedor;
            if (f.IdLinhaNegocio != null)
                cboLinhaNegocio.SelectedValue = f.IdLinhaNegocio;
            if (f.IdSegmento != null)
                cboSegmento.SelectedValue = f.IdSegmento;
            if (f.IdSubSegmento != null)
                cboSubSegmento.SelectedValue = f.IdSubSegmento;
            chkLimiteCredito.Checked = f.LimiteCredito;
            if (f.Suspenso != null)
                cboSuspenso.SelectedValue = f.Suspenso.ToString();
            if (f.IdMoeda != null)
                cboMoeda.SelectedValue = f.IdMoeda;
            if (f.IdGrupoImposto != null)
                cboGrupoImpostos.SelectedValue = f.IdGrupoImposto;
            chkImpostoRetido.Checked = f.ImpostoRetido;
            if (f.IdRoyalties != null)
                cboRoyalties.SelectedValue = f.IdRoyalties;
            if (f.IdCondicaoPagamento != null)
                cboCondPgto.SelectedValue = f.IdCondicaoPagamento;
            if (f.IdMetodoPagamento != null)
                cboMetodoPagamento.SelectedValue = f.IdMetodoPagamento;
            if (f.IdPlanoPagamento != null)
                cboPlanoPagamento.SelectedValue = f.IdPlanoPagamento;
            if (f.IdEspecificacaoPagamento != null)
                cboEspecificacaoPagamento.SelectedValue = f.IdEspecificacaoPagamento;
            if (f.IdDiasPagamento != null)
                cboDiasPagamento.SelectedValue = f.IdDiasPagamento;
            if (f.IdCodigoJuros != null)
                cboCodigoJuros.SelectedValue = f.IdCodigoJuros;
            if (f.IdCodigoMultas != null)
                cboCodigoMultas.SelectedValue = f.IdCodigoMultas;

            if (f.IdAvaliacaoCredito != null)
                cboAvaliacaoCredito.SelectedValue = f.IdAvaliacaoCredito;
            cboTextoPadrao.SelectedValue = f.IdTextoPadrao == null ? 0 : f.IdTextoPadrao;

            cboTipo.SelectedValue = f.Tipo == null ? 0 : f.Tipo;

            cboCliente.SelectedValue = f.IdCliente == null ? 0 : f.IdCliente;
            cboMotivoFinanceiro.SelectedValue = f.IdMotivoFinanceiro == null ? 0 : f.IdMotivoFinanceiro;
            cboNumeroIsencao.SelectedValue = f.IdNumeroIsencao == null ? 0 : f.IdNumeroIsencao;
            cboGrupoCompras.SelectedValue = f.IdGrupoCompras == null ? 0 : f.IdGrupoCompras;
            cboDescontoCombinado.SelectedValue = f.IdDescontoCombinado == null ? 0 : f.IdDescontoCombinado;
            cboDescontoTotal.SelectedValue = f.IdDescontoTotal == null ? 0 : f.IdDescontoTotal;
            cboDescontoVista.SelectedValue = f.IdDescontoAVista == null ? 0 : f.IdDescontoAVista;
            chkRPA.Checked = Convert.ToBoolean(f.RPA);
            cboImpostoRetido.SelectedValue = f.IdImpostoRetido == null ? 0 : f.IdImpostoRetido;

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
            var lista = cdal.getFornecedor(f.IdFornecedor).Select(x => new { x.IdFornecedorContato, x.IdContato, x.Contato.Nome, x.Contato.EMail }).ToList();
            grContato.AutoGenerateColumns = false;
            grContato.RowHeadersVisible = false;
            grContato.DataSource = lista;
        }

        protected void CarregaEnderecos()
        {
            EnderecoDAL Edal = new EnderecoDAL(new DB_ERPContext());
            var Enderecos = Edal.getFornecedor(f.IdFornecedor).Select(x => new { x.IdFornecedorEndereco, x.Endereco.IdEndereco, x.Endereco.TipoEndereco.Descricao, x.Endereco.Logradouro, x.Endereco.Numero, x.Endereco.Bairro, x.Endereco.Cidade.Nome }).ToList();
            grEndereco.AutoGenerateColumns = false;
            grEndereco.RowHeadersVisible = false;
            grEndereco.DataSource = Enderecos;
        }

        protected void CarregaTelefones()
        {
            TelefoneDAL tDal = new TelefoneDAL(new DB_ERPContext());
            var telefones = tDal.getFornecedor(f.IdFornecedor).Select(x => new { x.IdFornecedorTelefone, x.IdTelefone, x.Telefone.TipoTelefone.Descricao, x.Telefone.CodigoPais, x.Telefone.DDD, x.Telefone.NumeroTelefone }).ToList();
            grTelefone.AutoGenerateColumns = false;
            grTelefone.RowHeadersVisible = false;
            grTelefone.DataSource = telefones;
        }

        private void CarregarAvaliacaoCredito()
        {
            cboAvaliacaoCredito.DataSource = new AvaliacaoCreditoDAL().GetCombo();
            cboAvaliacaoCredito.DisplayMember = "Text";
            cboAvaliacaoCredito.ValueMember = "iValue";
            cboAvaliacaoCredito.SelectedIndex = -1;
        }

        protected void CarregaCentrosdeCusto()
        {
            var lista = ccDal.GetByFornecedor(f.IdFornecedor);
            dgCentros.AutoGenerateColumns = false;
            dgCentros.DataSource = lista;
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

        protected void CarregaContasBancarias()
        {
            ContaBancariaDAL cbdal = new ContaBancariaDAL();
            var lista = cbdal.getFornecedor(f.IdFornecedor).Select(x => new { x.IdFornecedorContaBancaria, x.IdContaBancaria, x.IdFornecedor, Banco = x.ContaBancaria.Banco.NomeBanco, Agencia = x.ContaBancaria.Agencia + "-" + x.ContaBancaria.DigitoAgencia, Conta = x.ContaBancaria.Conta + "-" + x.ContaBancaria.DigitoConta }).ToList();
            grContaBancaria.AutoGenerateColumns = false;
            grContaBancaria.RowHeadersVisible = false;
            grContaBancaria.DataSource = lista;
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
            cboSubSegmento.ValueMember = "IdSubSegmento";
            cboSubSegmento.DisplayMember = "Nome";
            cboSubSegmento.SelectedIndex = -1;
        }

        private void CarregarSuspenso()
        {
            List<DropList> lista = Util.EnumERP.CarregarSuspenso();

            cboSuspenso.DisplayMember = "Text";
            cboSuspenso.ValueMember = "Value";
            cboSuspenso.DataSource = lista;
            cboSuspenso.SelectedIndex = -1;
        }

        protected void CarregaRoyalties()
        {
            cboRoyalties.DataSource = new RoyaltiesDAL().GetCombo();
            cboRoyalties.DisplayMember = "Text";
            cboRoyalties.ValueMember = "iValue";
            cboRoyalties.SelectedIndex = -1;
        }

        protected void CarregaGrupoImposto()
        {
            cboGrupoImpostos.DataSource = new GrupoImpostoDAL().getCombo();
            cboGrupoImpostos.DisplayMember = "Text";
            cboGrupoImpostos.ValueMember = "iValue";
            cboGrupoImpostos.SelectedIndex = -1;
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

        protected void CarregaEspecificaoPagamento()
        {
            cboEspecificacaoPagamento.DataSource = new EspecificacaoPagamentoDAL().GetCombo();
            cboEspecificacaoPagamento.DisplayMember = "Text";
            cboEspecificacaoPagamento.ValueMember = "iValue";
            cboEspecificacaoPagamento.SelectedIndex = -1;
        }

        protected void CarregaDiasPagamento()
        {
            cboDiasPagamento.DataSource = new DiasPagamentoDAL().GetCombo();
            cboDiasPagamento.DisplayMember = "Text";
            cboDiasPagamento.ValueMember = "iValue";
            cboDiasPagamento.SelectedIndex = -1;
        }

        protected void CarregaMoeda()
        {
            cboMoeda.DataSource = new MoedaDAL().MRepository.Get();
            cboMoeda.DisplayMember = "Codigo";
            cboMoeda.ValueMember = "IdMoeda";
            cboMoeda.SelectedIndex = -1;
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
            try
            {
                f = new Fornecedor();
                lbCodigo.Text = "0";
                Util.Aplicacao.LimpaControles(this);
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            string CNPJ = txtCNPJ.Text.Replace(",", "").Replace(".", "").Replace("-", "").Replace("/", "");

            if (CNPJ.Length == 14)
            {
                if (!Util.Validacao.ValidaCNPJ.IsCnpj(CNPJ))
                {
                    Util.Aplicacao.ShowMessage("CNPJ inválido!");
                    return;
                }
            }
            else
            {
                if (!Util.Validacao.ValidaCPF.IsCpf(CNPJ))
                {
                    Util.Aplicacao.ShowMessage("CPF inválido!");
                    return;
                }
            }

            if (dal.ConsultaCNPJ(CNPJ, f.IdFornecedor))
            {
                Util.Aplicacao.ShowMessage("CNPJ já existe na base de dados.");
                return;
            }

            if (!Util.Validacao.ValidaEmail(txtEmail.Text))
            {
                Util.Aplicacao.ShowMessage("Email inválido!");
                return;
            }

            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    //limpa os campos
                    f.CCM = null;
                    f.CNAE = null;
                    f.CNPJ = null;
                    f.Email = null;
                    f.NomeFantasia = null;
                    f.IdAvaliacaoCredito = null;
                    f.IdCliente = null;
                    f.IdCodigoJuros = null;
                    f.IdCodigoMultas = null;
                    f.IdCondicaoPagamento = null;
                    f.IdDescontoCombinado = null;
                    f.IdDescontoTotal = null;
                    f.IdDescontoAVista = null;
                    f.IdDiasPagamento = null;
                    f.IdEspecificacaoPagamento = null;
                    f.IdGrupoCompras = null;
                    f.IdGrupoFornecedor = null;
                    f.IdGrupoImposto = null;
                    f.IdImpostoRetido = null;
                    f.IdLinhaNegocio = null;
                    f.IdMetodoPagamento = null;
                    f.IdMoeda = null;
                    f.IdMotivoFinanceiro = null;
                    f.IdNumeroIsencao = null;
                    f.IdPlanoPagamento = null;
                    f.IdRoyalties = null;
                    f.IdSegmento = null;
                    f.IdSubSegmento = null;
                    f.Suspenso = null;
                    f.IdTextoPadrao = null;
                    f.Tipo = null;
                    f.InscricaoEstadual = null;
                    f.INSSCEI = null;
                    f.Internet = null;
                    f.NIT = null;
                    f.RazaoSocial = null;

                    f.RazaoSocial = txtRazao.Text;
                    f.NomeFantasia = txtFantasia.Text;
                    f.CNPJ = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "");
                    f.InscricaoEstadual = txtInscricao.Text;
                    f.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));

                    if (!String.IsNullOrEmpty(cboTipo.Text))
                        f.Tipo = Convert.ToInt32(cboTipo.SelectedValue);

                    f.CCM = txtCCM.Text;
                    f.NIT = txtNIT.Text;
                    f.INSSCEI = txtINSSCEI.Text;
                    f.CNAE = txtCNAE.Text;
                    f.OptanteSimples = chkOptanteSimples.Checked;
                    f.SIMEI = chkSIMEI.Checked;
                    f.ServicoEnderecoEntrega = chkServicoEnderecoEntrega.Checked;
                    f.ContribuinteICMS = chkContribuinteICMS.Checked;
                    f.GerarNotaRecebida = chkGerarNotaRecebida.Checked;
                    f.UsoConsumo = chkUsoConsumo.Checked;
                    f.CodigoRendimento = chkCodigoRendimento.Checked;
                    f.Email = txtEmail.Text;
                    f.Internet = txtInternet.Text;
                    f.RPA = chkRPA.Checked;
                    f.Tipo = Convert.ToInt32(cboTipo.SelectedValue);

                    if (!String.IsNullOrEmpty(cboGrupoFornecedor.Text))
                        f.IdGrupoFornecedor = Convert.ToInt32(cboGrupoFornecedor.SelectedValue);

                    if (!String.IsNullOrEmpty(cboLinhaNegocio.Text))
                        f.IdLinhaNegocio = Convert.ToInt32(cboLinhaNegocio.SelectedValue);

                    if (!String.IsNullOrEmpty(cboSegmento.Text))
                        f.IdSegmento = Convert.ToInt32(cboSegmento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboSubSegmento.Text))
                        f.IdSubSegmento = Convert.ToInt32(cboSubSegmento.SelectedValue);
                    f.LimiteCredito = chkLimiteCredito.Checked;
                    if (!String.IsNullOrEmpty(cboSuspenso.Text))
                        f.Suspenso = Convert.ToInt32(cboSuspenso.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMoeda.Text))
                        f.IdMoeda = Convert.ToInt32(cboMoeda.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImpostos.Text))
                        f.IdGrupoImposto = Convert.ToInt32(cboGrupoImpostos.SelectedValue);
                    f.ImpostoRetido = chkImpostoRetido.Checked;
                    if (!String.IsNullOrEmpty(cboRoyalties.Text))
                        f.IdRoyalties = Convert.ToInt32(cboRoyalties.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCondPgto.Text))
                        f.IdCondicaoPagamento = Convert.ToInt32(cboCondPgto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMetodoPagamento.Text))
                        f.IdMetodoPagamento = Convert.ToInt32(cboMetodoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPlanoPagamento.Text))
                        f.IdPlanoPagamento = Convert.ToInt32(cboPlanoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboEspecificacaoPagamento.Text))
                        f.IdEspecificacaoPagamento = Convert.ToInt32(cboEspecificacaoPagamento.SelectedValue);


                    if (!String.IsNullOrEmpty(cboDiasPagamento.Text))
                        f.IdDiasPagamento = Convert.ToInt32(cboDiasPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoJuros.Text))
                        f.IdCodigoJuros = Convert.ToInt32(cboCodigoJuros.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoMultas.Text))
                        f.IdCodigoMultas = Convert.ToInt32(cboCodigoMultas.SelectedValue);

                    if (!String.IsNullOrEmpty(cboAvaliacaoCredito.Text))
                        f.IdAvaliacaoCredito = Convert.ToInt32(cboAvaliacaoCredito.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTextoPadrao.Text)) f.IdTextoPadrao = Convert.ToInt32(cboTextoPadrao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboGrupoCompras.Text)) f.IdGrupoCompras = Convert.ToInt32(cboGrupoCompras.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCliente.Text)) f.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    if (!String.IsNullOrEmpty(cboMotivoFinanceiro.Text)) f.IdMotivoFinanceiro = Convert.ToInt32(cboMotivoFinanceiro.SelectedValue);
                    if (!String.IsNullOrEmpty(cboNumeroIsencao.Text)) f.IdNumeroIsencao = Convert.ToInt32(cboNumeroIsencao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDescontoCombinado.Text)) f.IdDescontoCombinado = Convert.ToInt32(cboDescontoCombinado.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDescontoTotal.Text)) f.IdDescontoTotal = Convert.ToInt32(cboDescontoTotal.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDescontoVista.Text)) f.IdDescontoAVista = Convert.ToInt32(cboDescontoVista.SelectedValue);
                    if (!String.IsNullOrEmpty(cboImpostoRetido.Text)) f.IdImpostoRetido = Convert.ToInt32(cboImpostoRetido.SelectedValue);
                    if (f.IdFornecedor == 0)
                    {
                        dal.FRepository.Insert(f);
                    }
                    else
                    {
                        dal.FRepository.Update(f);
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
                    int id = f.IdFornecedor;
                    dal.FRepository.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    Close();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
            }
        }

        private void tsbAdicionarEndereco_Click(object sender, EventArgs e)
        {
            if (f.IdFornecedor != 0)
            {
                frmEndereco cad = new frmEndereco("Fornecedor", f.IdFornecedor, new Endereco());
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
            if (grEndereco.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão do endereço") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(grEndereco.Rows[grEndereco.SelectedRows[0].Index].Cells[0].Value.ToString());
                    FornecedorEndereco ce = dal.FERepository.GetByID(id);
                    int IdEndereco = ce.IdEndereco;

                    //apaga o relacionamento
                    dal.FERepository.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    //apaga o endereço
                    EnderecoDAL eDal = new EnderecoDAL(new DB_ERPContext());
                    eDal.Delete(ce.IdEndereco);
                    eDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaEnderecos();
                }
            }
        }

        private void grEndereco_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (f.IdFornecedor != 0)
            {
                if (grEndereco.Rows.Count > 0)
                {
                    string sId = grEndereco.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int id = Convert.ToInt32(sId);
                    EnderecoDAL endDal = new EnderecoDAL(new DB_ERPContext());
                    Endereco en = endDal.GetByID(id);
                    frmEndereco cad = new frmEndereco("Fornecedor", f.IdFornecedor, en);
                    cad.dal = endDal;
                    cad.ShowDialog();
                    CarregaEnderecos();
                }
            }
        }

        private void tsbAdicionarTelefone_Click(object sender, EventArgs e)
        {
            if (f.IdFornecedor != 0)
            {
                frmTelefone cad = new frmTelefone("Fornecedor", f.IdFornecedor, new Telefone());
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
                    int id = Convert.ToInt32(grTelefone.Rows[grTelefone.SelectedRows[0].Index].Cells[1].Value.ToString());
                    FornecedorTelefone te = dal.FTRepository.GetByID(id);
                    int Idtelefone = te.IdTelefone;

                    //apaga o relacionamento
                    dal.FTRepository.Delete(id);
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
            if (f.IdFornecedor != 0)
            {
                if (grTelefone.Rows.Count > 0)
                {
                    string sId = grTelefone.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int id = Convert.ToInt32(sId);
                    TelefoneDAL tDal = new TelefoneDAL(new DB_ERPContext());
                    Telefone te = tDal.GetByID(id);
                    frmTelefone cad = new frmTelefone("Fornecedor", f.IdFornecedor, te);
                    cad.tDal = tDal;
                    cad.ShowDialog();
                    CarregaEnderecos();
                }
            }
        }

        private void tsbAdicionarContato_Click(object sender, EventArgs e)
        {
            if (f.IdFornecedor != 0)
            {
                frmContato cad = new frmContato("Fornecedor", f.IdFornecedor, new Contato());
                cad.ShowDialog();
                CarregaContatos();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Salve as informações principais para poder cadastrar telefones.");
            }
        }

        private void tsbExcluirContato_Click(object sender, EventArgs e)
        {
            if (grContato.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Confirma a exclusão do contato") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(grContato.Rows[grContato.SelectedRows[0].Index].Cells[0].Value.ToString());
                    FornecedorContato te = dal.FCRepository.GetByID(id);
                    int IdContato = te.IdContato;

                    //apaga o relacionamento
                    dal.FCRepository.Delete(id);
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
            if (f.IdFornecedor != 0)
            {
                if (grContato.Rows.Count > 0)
                {
                    string sId = grContato.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int id = Convert.ToInt32(sId);
                    ContatoDAL cDal = new ContatoDAL();
                    Contato te = cDal.CRepository.GetByID(id);
                    frmContato cad = new frmContato("Fornecedor", f.IdFornecedor, te);
                    cad.contatoDal = cDal;
                    cad.ShowDialog();
                    CarregaContatos();
                }
            }
        }

        private void CarregarGrupoFornecedor()
        {
            cboGrupoFornecedor.DataSource = new GrupoFornecedorDAL().GetCombo();
            cboGrupoFornecedor.DisplayMember = "Text";
            cboGrupoFornecedor.ValueMember = "iValue";
            cboGrupoFornecedor.SelectedIndex = -1;
        }

        private void tsbAdicionarContaBancaria_Click(object sender, EventArgs e)
        {
            if (f.IdFornecedor != 0)
            {
                frmContaBancaria cad = new frmContaBancaria("Fornecedor", f.IdFornecedor, new ContaBancaria());
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
                    FornecedorContaBancaria fcb = dal.FCBRepository.GetByID(id);
                    int IdContaBancaria = fcb.IdContaBancaria;

                    //apaga o relacionamento
                    dal.FCBRepository.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    //apaga a Conta Bancária
                    ContaBancariaDAL cbDal = new ContaBancariaDAL();
                    cbDal.Delete(fcb.IdContaBancaria);
                    cbDal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaContasBancarias();
                }
            }
        }

        private void grContaBancaria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (f.IdFornecedor != 0)
            {
                if (grContaBancaria.Rows.Count > 0)
                {
                    string sId = grContaBancaria.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int id = Convert.ToInt32(sId);
                    ContaBancariaDAL cbDal = new ContaBancariaDAL();
                    ContaBancaria cb = cbDal.GetByID(id);
                    frmContaBancaria cad = new frmContaBancaria("Fornecedor", f.IdFornecedor, cb);
                    cad.dal = cbDal;
                    cad.ShowDialog();
                    CarregaContasBancarias();
                }
            }
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

        private void cboTipo_Leave(object sender, EventArgs e)
        {
            if (cboTipo.SelectedValue != null)
            {
                if (cboTipo.SelectedValue.ToString() == "1")
                {
                    lblCNPJ.Text = "CPF";
                    txtCNPJ.Mask = "999.999.999-99";
                }
                else
                {
                    lblCNPJ.Text = "CNPJ";
                    txtCNPJ.Mask = "99.999.999/9999-99";
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (f.IdFornecedor == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados do fornecedor antes de adicionar centros de custo.");
                return;
            }
            frmCentroCustoAux frmCC = new frmCentroCustoAux("F", f.IdFornecedor);
            frmCC.fdal = ccDal;
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
                        ccDal.Delete(id);
                        ccDal.Save();
                        CarregaCentrosdeCusto();
                    }
                    catch (Exception ex)
                    {
                        Util.Aplicacao.ShowErrorMessage(ex);
                    }
                }
            }
        }

        private void cboGrupoFornecedor_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboGrupoFornecedor.Text))
            {
                var gf = new GrupoFornecedorDAL().GetByID(Convert.ToInt32(cboGrupoFornecedor.SelectedValue));
                if (gf != null)
                {
                    if (String.IsNullOrEmpty(cboGrupoImpostos.Text))
                    {
                        cboGrupoImpostos.SelectedValue = gf.IdGrupoImposto == null ? 0 : Convert.ToInt32(gf.IdGrupoImposto);
                    }

                    if (String.IsNullOrEmpty(cboCondPgto.Text))
                    {
                        cboCondPgto.SelectedValue = gf.IdCondicaoPagamento == null ? 0 : Convert.ToInt32(gf.IdCondicaoPagamento);
                    }
                }
            }
        }
    }
}
