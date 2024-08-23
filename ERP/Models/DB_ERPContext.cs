using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using System.Data;
using ERP.DAL;
using System.Data.SqlClient;

namespace ERP.Models
{
    public class DB_ERPContext : DbContext
    {
        List<string> EntitiesToLog = new List<string>();

        public DB_ERPContext()
        {
            Database.SetInitializer<DB_ERPContext>(null);
            this.Configuration.LazyLoadingEnabled = true;

        }

        public DbSet<AjusteEstoque> AjusteEstoque { get; set; }
        public DbSet<AprovacaoDocumento> AprovacaoDocumento { get; set; }
        public DbSet<AprovacaoNivel> AprovacaoNivel { get; set; }
        public DbSet<AprovacaoUsuario> AprovacaoUsuario { get; set; }
        public DbSet<Armazem> Armazem { get; set; }
        public DbSet<AtivoImobilizado> AtivoImobilizado { get; set; }
        public DbSet<AvaliacaoCredito> AvaliacaoCredito { get; set; }
        public DbSet<Autoridade> Autoridade { get; set; }
        public DbSet<Banco> Banco { get; set; }
        public DbSet<BoletoBancario> BoletoBancario { get; set; }
        public DbSet<CadastroDiarioProducao> CadastroDiarioProducao { get; set; }
        public DbSet<CalculoComissao> CalculoComissao { get; set; }
        public DbSet<Calendario> Calendario { get; set; }
        public DbSet<CalendarioData> CalendarioData { get; set; }
        public DbSet<CalendarioDataLinhas> CalendarioDataLinhas { get; set; }
        public DbSet<CapacidadeRecursos> CapacidadeRecursos { get; set; }
        public DbSet<CapacidadeRecursosLinhas> CapacidadeRecursosLinhas { get; set; }
        public DbSet<CentroCusto> CentroCusto { get; set; }
        public DbSet<CEST> CEST { get; set; }
        public DbSet<CFOP> CFOP { get; set; }
        public DbSet<CFPS> CFPS { get; set; }
        public DbSet<ChaveMinemax> ChaveMinemax { get; set; }
        public DbSet<ChaveReducao> ChaveReducao { get; set; }
        public DbSet<Cheque> Cheque { get; set; }
        public DbSet<ChequeItem> ChequeItem { get; set; }
        public DbSet<ChequeTerceiros> ChequeTerceiros { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<ClassificacaoFiscal> ClassificacaoFiscal { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ClienteContato> ClienteContato { get; set; }
        public DbSet<ClienteEndereco> ClienteEndereco { get; set; }
        public DbSet<ClienteTelefone> ClienteTelefone { get; set; }
        public DbSet<ClienteContaBancaria> ClienteContaBancaria { get; set; }
        public DbSet<ClienteCentroCusto> ClienteCentroCusto { get; set; }
        public DbSet<CodigoContratoComercial> CodigoContratoComercial { get; set; }
        public DbSet<CodigoEncargo> CodigoEncargo { get; set; }
        public DbSet<CodigoFaturamento> CodigoFaturamento { get; set; }
        public DbSet<CodigoImposto> CodigoImposto { get; set; }
        public DbSet<CodigoImpostoRetido> CodigoImpostoRetido { get; set; }
        public DbSet<CodigoIsencao> CodigoIsencao { get; set; }
        public DbSet<CodigoJuros> CodigoJuros { get; set; }
        public DbSet<CodigoMultas> CodigoMultas { get; set; }
        public DbSet<CodigoServico> CodigoServico { get; set; }
        public DbSet<CodigoTributacao> CodigoTributacao { get; set; }
        public DbSet<ComissaoContaCorrente> ComissaoContaCorrente { get; set; }
        public DbSet<CodigoProdutoExterno> CodigoProdutoExterno { get; set; }
        public DbSet<CondicaoFrete> CondicaoFrete { get; set; }
        public DbSet<CondicaoPagamento> CondicaoPagamento { get; set; }
        public DbSet<CondicaoPagamentoIntervalo> CondicaoPagamentoIntervalo { get; set; }
        public DbSet<Configuracao> Configuracao { get; set; }
        public DbSet<ConfiguracaoCheque> ConfiguracaoCheque { get; set; }
        public DbSet<ContaBancaria> ContaBancaria { get; set; }
        public DbSet<Contabilidade> Contabilidade { get; set; }
        public DbSet<ContaContabil> ContaContabil { get; set; }
        public DbSet<Contador> Contador { get; set; }
        public DbSet<ContadorEndereco> ContadorEndereco { get; set; }
        public DbSet<ContadorTelefone> ContadorTelefone { get; set; }
        public DbSet<ContaGerencial> ContaGerencial { get; set; }
        public DbSet<ContaPlanoReferencial> ContaPlanoReferencial { get; set; }
        public DbSet<ContasPagar> ContasPagar { get; set; }
        public DbSet<ContasPagarAberto> ContasPagarAberto { get; set; }
        public DbSet<ContasPagarBaixa> ContasPagarBaixa { get; set; }
        public DbSet<ContasPagarChequeTerceiros> ContasPagarChequeTerceiros { get; set; }
        public DbSet<ContasReceber> ContasReceber { get; set; }
        public DbSet<ContasReceberAberto> ContasReceberAberto { get; set; }
        public DbSet<ContasReceberBaixa> ContasReceberBaixa { get; set; }
        public DbSet<ContasReceberChequeTerceiros> ContasReceberChequeTerceiros { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<ContatoEndereco> ContatoEndereco { get; set; }
        public DbSet<ContatoTelefone> ContatoTelefone { get; set; }
        public DbSet<ContratoComercial> ContratoComercial { get; set; }
        public DbSet<ContratoComercialCondPgto> ContratoComercialCondPgto { get; set; }
        public DbSet<ConversaoUnidade> ConversaoUnidade { get; set; }
        public DbSet<Corredor> Corredor { get; set; }
        public DbSet<DescontoVarejista> DescontoVarejista { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Deposito> Deposito { get; set; }
        public DbSet<DepreciacaoEspecial> DepreciacaoEspecial { get; set; }
        public DbSet<DescontoaVista> DescontoaVista { get; set; }
        public DbSet<DiarioBOM> DiarioBOM { get; set; }
        public DbSet<DiarioBomLinha> DiarioBomLinha { get; set; }
        public DbSet<DiarioBomLinhaCentroCusto> DiarioBomLinhaCentroCusto { get; set; }
        public DbSet<DiasPagamento> DiasPagamento { get; set; }
        public DbSet<DiasPagamentoItem> DiasPagamentoItem { get; set; }
        public DbSet<DocumentoFiscal> DocumentoFiscal { get; set; }
        public DbSet<Favoritos> Favoritos { get; set; }
        public DbSet<Embalagem> Embalagem { get; set; }
        public DbSet<EmpresaContaBancaria> EmpresaContaBancaria { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<EncargosAutomaticos> EncargosAutomaticos { get; set; }
        public DbSet<Especie> Especie { get; set; }
        public DbSet<EspecificacaoPagamento> EspecificacaoPagamento { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Feriado> Feriado { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<FornecedorCentroCusto> FornecedorCentroCusto { get; set; }
        public DbSet<FornecedorContaBancaria> FornecedorContaBancaria { get; set; }
        public DbSet<FornecedorContato> FornecedorContato { get; set; }
        public DbSet<FornecedorEndereco> FornecedorEndereco { get; set; }
        public DbSet<FornecedorTelefone> FornecedorTelefone { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<FuncionarioEndereco> FuncionarioEndereco { get; set; }
        public DbSet<FuncionarioTelefone> FuncionarioTelefone { get; set; }
        public DbSet<FuncionarioContaBancaria> FuncionarioContaBancaria { get; set; }
        public DbSet<GrupoAlocacaoFrete> GrupoAlocacaoFrete { get; set; }
        public DbSet<GrupoAtivo> GrupoAtivo { get; set; }
        public DbSet<GrupoArmazenamento> GrupoArmazenamento { get; set; }
        public DbSet<GrupoCFOP> GrupoCFOP { get; set; }
        public DbSet<GrupoCompras> GrupoCompras { get; set; }
        public DbSet<GrupoComissao> GrupoComissao { get; set; }
        public DbSet<GrupoCliente> GrupoCliente { get; set; }
        public DbSet<GrupoCobertura> GrupoCobertura { get; set; }
        public DbSet<GrupoCusto> GrupoCusto { get; set; }
        public DbSet<GrupoDescontos> GrupoDescontos { get; set; }
        public DbSet<GrupoDescontoVarejista> GrupoDescontoVarejista { get; set; }
        public DbSet<GrupoEncargos> GrupoEncargos { get; set; }
        public DbSet<GrupoEncargosCodigoEncargo> GrupoEncargosCodigoEncargo { get; set; }
        public DbSet<GrupoEstoque> GrupoEstoque { get; set; }
        public DbSet<GrupoFornecedor> GrupoFornecedor { get; set; }
        public DbSet<GrupoImposto> GrupoImposto { get; set; }
        public DbSet<GrupoImpostoCodigos> GrupoImpostoCodigos { get; set; }
        public DbSet<ConfGrupoImposto> ConfGrupoImposto { get; set; }
        public DbSet<GrupoImpostoItem> GrupoImpostoItem { get; set; }
        public DbSet<GrupoImpostoRetido> GrupoImpostoRetido { get; set; }
        public DbSet<GrupoImpostoRetidoItem> GrupoImpostoRetidoItem { get; set; }
        public DbSet<ConfGrupoImpostoRetido> ConfGrupoImpostoRetido { get; set; }
        public DbSet<ConfGrupoImpostosItemRetido> ConfGrupoImpostosItemRetido { get; set; }
        public DbSet<ConfGrupoImpostoItem> ConfGrupoImpostoItem { get; set; }
        public DbSet<FluxoCaixa> FluxoCaixa { get; set; }
        public DbSet<GrupoItensSuplementares> GrupoItensSuplementares { get; set; }
        public DbSet<GrupoLancamentoContabil> GrupoLancamentoContabil { get; set; }
        public DbSet<GrupoLancamento> GrupoLancamento { get; set; }
        public DbSet<GrupoLotes> GrupoLotes { get; set; }
        public DbSet<GrupoPrecoDesconto> GrupoPrecoDesconto { get; set; }
        public DbSet<GrupoProducao> GrupoProducao { get; set; }
        public DbSet<GrupoProduto> GrupoProduto { get; set; }
        public DbSet<GrupoRastreamento> GrupoRastreamento { get; set; }
        public DbSet<GrupoRecursoLinha> GrupoRecursoLinha { get; set; }
        public DbSet<GrupoRecursos> GrupoRecursos { get; set; }
        public DbSet<GrupoRoteiro> GrupoRoteiro { get; set; }
        public DbSet<GrupoRoteiroLinha> GrupoRoteiroLinha { get; set; }
        public DbSet<GrupoSeries> GrupoSeries { get; set; }
        public DbSet<GrupoVendas> GrupoVendas { get; set; }
        public DbSet<ImpostoRetido> ImpostoRetido { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<InventarioEstoque> InventarioEstoque { get; set; }
        public DbSet<JuridicaoImposto> JuridicaoImposto { get; set; }
        public DbSet<Kardex> Kardex { get; set; }
        public DbSet<Lancamento> Lancamento { get; set; }
        public DbSet<LancamentoAtivo> LancamentoAtivo { get; set; }
        public DbSet<LimiteImposto> LimiteImposto { get; set; }
        public DbSet<LimiteImpostoRetido> LimiteImpostoRetido { get; set; }
        public DbSet<LinhaNegocio> LinhaNegocio { get; set; }
        public DbSet<ListaMateriais> ListaMateriais { get; set; }
        public DbSet<ListaMateriaisItem> ListaMateriaisItem { get; set; }
        public DbSet<ListaMateriaisLinhas> ListaMateriaisLinhas { get; set; }
        public DbSet<Localizacao> Localizacao { get; set; }
        public DbSet<LocalizacaoAtivo> LocalizacaoAtivo { get; set; }
        public DbSet<LocalProducao> LocalProducao { get; set; }
        public DbSet<LogItem> LogItem { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<RecebimentoItemLote> RecebimentoItemLote { get; set; }
        public DbSet<MatrizCFOP> MatrizCFOP { get; set; }
        public DbSet<MatrizImpostos> MatrizImpostos { get; set; }
        public DbSet<MetodoDepreciacao> MetodoDepreciacao { get; set; }
        public DbSet<ModeloDocumento> ModeloDocumento { get; set; }
        public DbSet<ModoEntrega> ModoEntrega { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamento { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<ModuloPrograma> ModuloPrograma { get; set; }
        public DbSet<Moeda> Moeda { get; set; }
        public DbSet<MoedaCotacao> MoedaCotacao { get; set; }
        public DbSet<MovimentoEstoque> MovimentoEstoque { get; set; }
        public DbSet<MovimentacaoBancaria> MovimentacaoBancaria { get; set; }
        public DbSet<MovimentacaoAtivo> MovimentacaoAtivo { get; set; }
        public DbSet<MotivoFinanceiro> MotivoFinanceiro { get; set; }
        public DbSet<NotaFiscal> NotaFiscal { get; set; }
        public DbSet<NotaFiscalNFe> NotaFiscalNFe { get; set; }
        public DbSet<NotaFiscalItem> NotaFiscalItem { get; set; }
        public DbSet<NotaFiscalItemApuracaoImposto> NotaFiscalItemApuracaoImposto { get; set; }
        public DbSet<NotaFiscalObs> NotaFiscalObs { get; set; }
        public DbSet<NotaFiscalVencimentos> NotaFiscalVencimentos { get; set; }
        public DbSet<NumeroIsencao> NumeroIsencao { get; set; }
        public DbSet<Operacao> Operacao { get; set; }
        public DbSet<OrigemLancamento> OrigemLancamento { get; set; }
        public DbSet<OrdemProducao> OrdemProducao { get; set; }
        public DbSet<OrdemProducaoEtapa> OrdemProducaoEtapa { get; set; }
        public DbSet<OrdemProducaoMateriaPrima> OrdemProducaoMateriaPrima { get; set; }
        public DbSet<OrdemProducaoProduto> OrdemProducaoProduto { get; set; }
        public DbSet<OrdemProducaoControleQualidade> OrdemProducaoControleQualidade { get; set; }
        public DbSet<OrdemProducaoHistorico> OrdemProducaoHistorico { get; set; }
        //public DbSet<OrdemProducaoCentroCusto> OrdemProducaoCentroCusto { get; set; }
        //public DbSet<OrdemProducaoLinha> OrdemProducaoLinha { get; set; }
        //public DbSet<OrdemProducaoLinhaCentroCusto> OrdemProducaoLinhaCentroCusto { get; set; }
        public DbSet<PagamentoLote> PagamentoLote { get; set; }
        public DbSet<PagamentoLoteChequeTerceiro> PagamentoLoteChequeTerceiro { get; set; }
        public DbSet<PagamentoLoteItem> PagamentoLoteItem { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<PedidoBalcao> PedidoBalcao { get; set; }
        public DbSet<PedidoBalcaoPagamento> PedidoBalcaoPagamento { get; set; }
        public DbSet<PedidoBalcaoProduto> PedidoBalcaoProduto { get; set; }
        public DbSet<PedidoBalcaoCrediario> PedidoBalcaoCrediario { get; set; }
        public DbSet<PedidoCompra> PedidoCompra { get; set; }
        public DbSet<PedidoCompraAprovacao> PedidoCompraAprovacao { get; set; }
        public DbSet<PedidoCompraAlocacaoEncargos> PedidoCompraAlocacaoEncargos { get; set; }
        public DbSet<PedidoCompraContabilidade> PedidoCompraContabilidade { get; set; }
        public DbSet<PedidoCompraEncargos> PedidoCompraEncargos { get; set; }
        public DbSet<PedidoCompraItemEncargo> PedidoCompraItemEncargo { get; set; }
        public DbSet<PedidoCompraCentroCusto> PedidoCompraCentroCusto { get; set; }
        public DbSet<PedidoCompraItem> PedidoCompraItem { get; set; }
        public DbSet<PedidoCompraItemCentroCusto> PedidoCompraItemCentroCusto { get; set; }
        public DbSet<PedidoVenda> PedidoVenda { get; set; }
        public DbSet<PedidoVendaAlocacaoEncargos> PedidoVendaAlocacaoEncargos { get; set; }
        public DbSet<PedidoVendaContabilidade> PedidoVendaContabilidade { get; set; }
        public DbSet<PedidoVendaEncargos> PedidoVendaEncargos { get; set; }
        public DbSet<PedidoVendaItemEncargo> PedidoVendaItemEncargo { get; set; }
        public DbSet<PedidoVendaAprovacao> PedidoVendaAprovacao { get; set; }
        public DbSet<PedidoVendaCentroCusto> PedidoVendaCentroCusto { get; set; }
        public DbSet<PedidoVendaItem> PedidoVendaItem { get; set; }
        public DbSet<PedidoCompraItemApuracaoImposto> PedidoCompraItemApuracaoImposto { get; set; }
        public DbSet<PedidoVendaItemApuracaoImposto> PedidoVendaItemApuracaoImposto { get; set; }
        public DbSet<PedidoVendaItemCentroCusto> PedidoVendaItemCentroCusto { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<PerfilCliente> PerfilCliente { get; set; }
        public DbSet<PerfilFornecedor> PerfilFornecedor { get; set; }
        public DbSet<PerfilDepreciacao> PerfilDepreciacao { get; set; }
        public DbSet<PerfilModulo> PerfilModulo { get; set; }
        public DbSet<PerfilProducao> PerfilProducao { get; set; }
        public DbSet<PeriodoLiquidacaoImposto> PeriodoLiquidacaoImposto { get; set; }
        public DbSet<PeriodoLiquidacaoImpostoVenc> PeriodoLiquidacaoImpostoVenc { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<PlanoMestre> PlanoMestre { get; set; }
        public DbSet<PlanoPagamento> PlanoPagamento { get; set; }
        public DbSet<PlanoPagamentoItem> PlanoPagamentoItem { get; set; }
        public DbSet<PlanoPrevisao> PlanoPrevisao { get; set; }
        public DbSet<PlanoProducao> PlanoProducao { get; set; }
        public DbSet<PlanoProducaoControleQualidade> PlanoProducaoControleQualidade { get; set; }
        public DbSet<PlanoProducaoEtapa> PlanoProducaoEtapa { get; set; }
        public DbSet<PlanoProducaoMateriaPrima> PlanoProducaoMateriaPrima { get; set; }
        public DbSet<PlanoProducaoProduto> PlanoProducaoProduto { get; set; }
        public DbSet<PlanoProducaoRecurso> PlanoProducaoRecurso { get; set; } 
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutoCentroCusto> ProdutoCentroCusto { get; set; }
        public DbSet<Programa> Programa { get; set; }
        public DbSet<RamoAtividade> RamoAtividade { get; set; }
        public DbSet<Recebimento> Recebimento { get; set; }
        public DbSet<RecebimentoItem> RecebimentoItem { get; set; }
        public DbSet<RecebimentoLote> RecebimentoLote { get; set; }
        public DbSet<RecebimentoLoteChequeTerceiro> RecebimentoLoteChequeTerceiro { get; set; }
        public DbSet<RecebimentoLoteItem> RecebimentoLoteItem { get; set; }
        public DbSet<Recursos> Recursos { get; set; }
        public DbSet<ReportCubo> ReportCubo { get; set; }
        public DbSet<ReportCuboFields> ReportCuboFields { get; set; }
        public DbSet<ReportFields> ReportFields { get; set; }
        public DbSet<ReportHeader> ReportHeader { get; set; }
        public DbSet<RepresentanteVendas> RepresentanteVendas { get; set; }
        public DbSet<Roteiro> Roteiro { get; set; }
        public DbSet<RoteiroOperacao> RoteiroOperacao { get; set; }
        public DbSet<RoteiroOperacaoLinhas> RoteiroOperacaoLinhas { get; set; }
        public DbSet<RoteiroOperacaoRecursos> RoteiroOperacaoRecursos { get; set; }
        public DbSet<Royalties> Royalties { get; set; }
        public DbSet<Segmento> Segmento { get; set; }
        public DbSet<SegmentoBancario> SegmentoBancario { get; set; }
        public DbSet<SubSegmento> SubSegmento { get; set; }
        public DbSet<TargetFields> TargetFields { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<TempoDepreciacao> TempoDepreciacao { get; set; }
        public DbSet<TempoTrabalho> TempoTrabalho { get; set; }
        public DbSet<TempoTrabalhoLinhas> TempoTrabalhoLinhas { get; set; }
        public DbSet<TextoPadrao> TextoPadrao { get; set; }
        public DbSet<TextoTransacao> TextoTransacao { get; set; }
        public DbSet<TextoTransacaoSubs> TextoTransacaoSubs { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<TipoEndereco> TipoEndereco { get; set; }
        public DbSet<TipoItem> TipoItem { get; set; }
        public DbSet<TipoOperacaoBancaria> TipoOperacaoBancaria { get; set; }
        public DbSet<TipoLancamento> TipoLancamento { get; set; }
        public DbSet<TipoPagamento> TipoPagamento { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }
        public DbSet<TipoTransacaoBancaria> TipoTransacaoBancaria { get; set; }
        public DbSet<TotalDimensoes> TotalDimensoes { get; set; }
        public DbSet<Transportadora> Transportadora { get; set; }
        public DbSet<TransportadoraContato> TransportadoraContato { get; set; }
        public DbSet<TransportadoraEndereco> TransportadoraEndereco { get; set; }
        public DbSet<TransportadoraTelefone> TransportadoraTelefone { get; set; }
        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<UnidadeFederacao> UnidadeFederacao { get; set; }
        public DbSet<UnidadeFederacaoNCM> UnidadeFederacaoNCM { get; set; }
        public DbSet<UnidadeProducao> UnidadeProducao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ValoresCentroCusto> ValoresCentroCusto { get; set; }
        public DbSet<ValoresImposto> ValoresImposto { get; set; }
        public DbSet<ValoresImpostoRetido> ValoresImpostoRetido { get; set; }
        public DbSet<VariantesConfig> VariantesConfig { get; set; }
        public DbSet<VariantesCor> VariantesCor { get; set; }
        public DbSet<VariantesEstilo> VariantesEstilo { get; set; }
        public DbSet<VariantesGrupo> VariantesGrupo { get; set; }
        public DbSet<VariantesGrupoItem> VariantesGrupoItem { get; set; }
        public DbSet<VariantesTamanho> VariantesTamanho { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<VendedorMetas> VendedorMetas { get; set; }
        public DbSet<vwTableRelations> vwTableRelations { get; set; }
        public DbSet<vwTargetFields> vwTargetFields { get; set; }
        public DbSet<vwDemandaProducao> vwDemandaProducao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(18, 4));
            modelBuilder.Properties<decimal?>().Configure(config => config.HasPrecision(18, 4));
            //modelBuilder.Entity<PedidoCompraItem>().Property(x => x.PrecoUnitario).HasPrecision(18, 4);
            //modelBuilder.
        }

        public int SaveChanges(string IdUsuarioCorrente, bool HasMasterKey = false)
        {
            //get the username e pick the first name and the last name
            UsuarioDAL ur = new UsuarioDAL();

            vwTableRelationsDAL TablesRelationsRepostitory = new vwTableRelationsDAL(new DB_ERPViewContext());
            LogRepository lr = new LogRepository();
            int idUsuario = Convert.ToInt32(IdUsuarioCorrente);

            Usuario us = ur.URepository.GetByID(idUsuario);
            string userName = us.Login;

            // Detecta as alterações existentes na instância corrente do DbContext.
            this.ChangeTracker.DetectChanges();
            // Identifica as entidades que devem gerar registros em log.
            List<DbEntityEntry> entries = DetectEntries();
            // Cria lista para armazenamento temporário dos registros em log.

            List<Log> ListaLogs = new List<Log>();

            List<Log> logs = new List<Log>();
            List<LogItem> LogItensList = new List<LogItem>();
            // Varre as entidades que devem gerar registros em log.
            foreach (var entry in entries)
            {
                Type entityType = entry.Entity.GetType();
                string EntryName = entityType.Name;


                if (EntryName.Contains("_"))
                {
                    EntryName = EntryName.Substring(0, EntryName.LastIndexOf('_'));
                }

                //verify if entity needs log on DB
                if (EntitiesToLog.Contains(EntryName))
                {
                    if (entry.State == EntityState.Deleted || entry.State == EntityState.Modified)
                    {
                        Log log = new Log();
                        log.LogDate = DateTime.Now;
                        log.LogForm = EntryName;
                        log.Type = entry.State.ToString();
                        log.SamId = userName;
                        log.KeyValue = GetPrimaryKeyValue(entry).ToString();

                        ////verifi if table has a Masterkey
                        if (HasMasterKey)
                        {
                            vwTableRelations vwtr = TablesRelationsRepostitory.GetMasterKey(EntryName);
                            if (vwtr != null)
                            {
                                DbPropertyValues dbValues = entry.GetDatabaseValues();
                                var MasterValue = dbValues[vwtr.FK_COLUMN_NAME];
                                log.MasterKey = MasterValue.ToString();
                            }
                        }

                        //select modified data
                        if (entry.State == EntityState.Modified)
                        {
                            DbPropertyValues dbValues = entry.GetDatabaseValues();
                            foreach (var propertyName in entry.OriginalValues.PropertyNames)
                            {
                                var oldVal = dbValues[propertyName];
                                var newVal = entry.CurrentValues[propertyName];
                                //there are bpth values
                                if (oldVal != null && newVal != null && !Equals(oldVal, newVal))
                                {
                                    LogItem item = new LogItem();
                                    if (HasMasterKey)
                                    {
                                        string targetFieldName = getTargetFieldByTable(EntryName);
                                        if (!String.IsNullOrEmpty(targetFieldName))
                                        {
                                            item.LgiField = entry.CurrentValues[targetFieldName] + "-" + propertyName;
                                        }
                                        else
                                        {
                                            item.LgiField = propertyName;
                                        }
                                    }
                                    else
                                    {
                                        item.LgiField = propertyName;
                                    }
                                    item.LgiNewValue = newVal.ToString();
                                    item.LgiOldValue = oldVal.ToString();
                                    item.LogId = log.LogId;
                                    LogItensList.Add(item);
                                } //the record has been deleted
                                else if (oldVal != null && newVal == null)
                                {
                                    LogItem item = new LogItem();
                                    if (HasMasterKey)
                                    {
                                        string targetFieldName = getTargetFieldByTable(EntryName);
                                        if (!String.IsNullOrEmpty(targetFieldName))
                                        {
                                            item.LgiField = entry.CurrentValues[targetFieldName] + "-" + propertyName;
                                        }
                                        else
                                        {
                                            item.LgiField = propertyName;
                                        }
                                    }
                                    else
                                    {
                                        item.LgiField = propertyName;
                                    }
                                    item.LgiNewValue = "";
                                    item.LgiOldValue = oldVal.ToString();
                                    item.LogId = log.LogId;
                                    LogItensList.Add(item);
                                }//add new value to a empty field
                                else if (oldVal == null && newVal != null)
                                {
                                    LogItem item = new LogItem();
                                    if (HasMasterKey)
                                    {
                                        string targetFieldName = getTargetFieldByTable(EntryName);
                                        if (!String.IsNullOrEmpty(targetFieldName))
                                        {
                                            item.LgiField = entry.CurrentValues[targetFieldName] + "-" + propertyName;
                                        }
                                        else
                                        {
                                            item.LgiField = propertyName;
                                        }
                                    }
                                    else
                                    {
                                        item.LgiField = propertyName;
                                    }
                                    item.LgiNewValue = newVal.ToString();
                                    item.LgiOldValue = "";
                                    item.LogId = log.LogId;
                                    LogItensList.Add(item);
                                }
                            }
                        }
                        else if (entry.State == EntityState.Deleted)
                        {
                            DbPropertyValues dbValues = entry.GetDatabaseValues();
                            foreach (var propertyName in entry.OriginalValues.PropertyNames)
                            {
                                var Val = entry.OriginalValues[propertyName];
                                LogItem item = new LogItem();
                                item.LgiField = propertyName;
                                item.LgiNewValue = "";
                                if (Val != null)
                                {
                                    item.LgiOldValue = Val.ToString();
                                }
                                else
                                {
                                    item.LgiOldValue = "";
                                }


                                item.LogId = log.LogId;
                                LogItensList.Add(item);
                            }
                        }

                        if (log.Logitens == null)
                        {
                            log.Logitens = new List<LogItem>();
                        }

                        foreach (LogItem li in LogItensList)
                        {
                            log.Logitens.Add(li);
                        }
                        LogItensList.Clear();
                        if (log.Logitens.Count > 0)
                        {
                            ListaLogs.Add(log);
                        }
                    }
                }
            }

            foreach (Log l in ListaLogs)
            {

                this.Entry(l).State = EntityState.Added;
                this.SaveChanges();
            }

            return base.SaveChanges();
        }

        /// <summary>
        /// Identifica quais entidades devem ser gerar registros de log.
        /// </summary>
        private List<DbEntityEntry> DetectEntries()
        {
            List<DbEntityEntry> List = new List<DbEntityEntry>();
            foreach (var e in ChangeTracker.Entries())
            {
                if (e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified)
                {
                    List.Add(e);
                }
            }
            return List;
        }

        private string getTargetFieldByTable(string TableName)
        {
            string TargetFieldName = "";
            using (var db = new DB_ERPViewContext())
            {
                vwTargetFields targetFields = db.vwTargetFields.Where(x => (x.TABLE_NAME == TableName || x.TABLE_NAME == TableName + "s")).FirstOrDefault();
                if (targetFields != null)
                {
                    TargetFieldName = targetFields.FieldName;
                }
            }
            return TargetFieldName;
        }

        private string getIdValue(string Logform, string Field, string Value)
        {
            string NewValue = Value;
            string upperField = Field.ToUpper();
            if (Logform != "" && Field != "" && Value != "")
            {
                if (upperField.Contains("ID"))
                {
                    using (var db = new DB_ERPViewContext())
                    {
                        vwTargetFields targetFields = db.vwTargetFields.Where(x => (x.TABLE_NAME == Logform || x.TABLE_NAME == Logform + "s")
                                                        && x.FK_COLUMN_NAME == Field).FirstOrDefault();
                        if (targetFields != null)
                        {
                            var parameters = new[] { 
                            new SqlParameter("@value", Value)
                            };
                            string sql = " SELECT top 1[" + targetFields.FieldName + "] as Value  FROM " + targetFields.REFERENCED_TABLE_NAME +
                                         " WHERE " + Field + " = @value";
                            //var aux = db.vwScalarAux.SqlQuery(sql, parameters);
                            var aux = db.Database.SqlQuery<string>(sql, parameters).ToList();
                            if (aux != null)
                            {
                                NewValue = aux[0].ToString();
                            }
                        }
                    }
                }

            }

            return NewValue;
        }

        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }



    }
}
