using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PEDIDOVENDA", Schema = "DBO")]
    public class PedidoVenda
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPEDIDOVENDA")]
        public int IdPedidoVenda { get; set; }
        
        [DisplayName("Pedido Número")]
        [Column("PEDIDONUMERO")]
        public int PedidoNumero { get; set; }

        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime Data { get; set; }

        [DisplayName("Id Empresa")]
        [Column("IDEMPRESA")]
        public int IdEmpresa { get; set; }

        [DisplayName("IdCliente")]
        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [DisplayName("IdMoeda")]
        [Column("IDMOEDA")]
        public int? IdMoeda { get; set; }

        [DisplayName("Data Entrega")]
        [Column("DATAENTREGA")]
        public DateTime DataEntrega { get; set; }

        [DisplayName("Prazo Entrega")]
        [Column("PRAZOENTREGA")]
        public int PrazoEntrega { get; set; }

        [DisplayName("IdEndereco")]
        [Column("IDENDERECO")]
        public int IdEndereco { get; set; }

        [DisplayName("IdEnderecoEntrega")]
        [Column("IDENDERECOENTREGA")]
        public int IdEnderecoEntrega { get; set; }

        [DisplayName("EMail")]
        [Column("EMAIL")]
        public string EMail { get; set; }

        [DisplayName("IdCondicaoPagamento")]
        [Column("IDCONDICAOPAGAMENTO")]
        public int IdCondicaoPagamento { get; set; }

        [DisplayName("IdMetodoPagamento")]
        [Column("IDMETODOPAGAMENTO")]
        public int IdMetodoPagamento { get; set; }

        [DisplayName("IdPlanoPagamento")]
        [Column("IDPLANOPAGAMENTO")]
        public int? IdPlanoPagamento { get; set; }

        [DisplayName("Emissão")]
        [Column("EMISSAO")]
        public DateTime Emissao { get; set; }

        [DisplayName("Status")]
        [Column("STATUS")]
        public int Status { get; set; }

        [DisplayName("IdGrupoCliente")]
        [Column("IDGRUPOCLIENTE")]
        public int? IdGrupoCliente { get; set; }

        [DisplayName("IdPerfilCliente")]
        [Column("IDPERFILCLIENTE")]
        public int? IdPerfilCliente { get; set; }

        [DisplayName("Status Aprovação")]
        [Column("STATUSAPROVACAO")]
        public int StatusAprovacao { get; set; }

        [DisplayName("IdGrupoEncargos")]
        [Column("IDGRUPOENCARGOS")]
        public int? IdGrupoEncargos { get; set; }

        [DisplayName("IdGrupoDesconto")]
        [Column("IDGRUPODESCONTO")]
        public int? IdGrupoDesconto { get; set; }

        [DisplayName("DescontoPercentual")]
        [Column("DESCONTOPERCENTUAL")]
        public decimal DescontoPercentual { get; set; }

        [DisplayName("DescontoVarejista")]
        [Column("DESCONTOVAREJISTA")]
        public decimal DescontoVarejista { get; set; }

        [DisplayName("Id Desconto Varejista")]
        [Column("IDDESCONtOVAREJISTA")]
        public int IdDescontoVarejista { get; set; }
        
        [DisplayName("Observação")]
        [Column("OBSERVACAO")]
        public string Observacao { get; set; }

        [DisplayName("Id TeleVendas")]
        [Column("IDTELEVENDAS")]
        public int IdTeleVendas { get; set; }
        
        [DisplayName("Id Vendedor")]
        [Column("IDVENDEDOR")]
        public int IdVendedor { get; set; }

        [DisplayName("Id Grupo Vendas")]
        [Column("IDGRUPOVENDAS")]
        public int? IdGrupoVendas { get; set; }

        [DisplayName("Id Código Juros")]
        [Column("IDCODIGOJUROS")]
        public int? IdCodigoJuros { get; set; }

        [DisplayName("Id Código Multas")]
        [Column("IDCODIGOMULTAS")]
        public int? IdCodigoMultas { get; set; }

        [DisplayName("Id Grupo Imposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }

        [DisplayName("Id Grupo Imposto Retido")]
        [Column("IDGRUPOIMPOSTORETIDO")]
        public int? IdGrupoImpostoRetido { get; set; }

        [DisplayName("Movimenta Estoque")]
        [Column("MOVIMENTAESTOQUE")]
        public bool MovimentaEstoque { get; set; }

        [DisplayName("Id Modo Entrega")]
        [Column("IDMODOENTREGA")]
        public int IdModoEntrega { get; set; }

        [DisplayName("Id Condição Entrega")]
        [Column("IDCONDICAOENTREGA")]
        public int IdCondicaoEntrega { get; set; }

        [DisplayName("Tipo Frete")]
        [Column("TIPOFRETE")]
        public int TipoFrete { get; set; }

        [DisplayName("Id Transportadora")]
        [Column("IDTRANSPORTADORA")]
        public int? IdTransportadora { get; set; }

        [DisplayName("Placa Veículo")]
        [Column("PLACAVEICULO")]
        public string PlacaVeiculo { get; set; }

        [DisplayName("Id Armazém")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }

        [DisplayName("Id Depósito")]
        [Column("IDDEPOSITO")]
        public int? IdDeposito { get; set; }

        [DisplayName("Id Operação")]
        [Column("IDOPERACAO")]
        public int? IdOperacao { get; set; }
        public virtual Operacao Operacao { get; set; }

        [DisplayName("Id Documento Fiscal")]
        [Column("IDDOCUMENTOFISCAL")]
        public int? IdDocumentoFiscal { get; set; }

        [DisplayName("Id Espécie")]
        [Column("IDESPECIE")]
        public int? IdEspecie { get; set; }

        [DisplayName("IdCFPS")]
        [Column("IDCFPS")]
        public int? IdCFPS { get; set; }

        [DisplayName("Série")]
        [Column("SERIE")]
        public string Serie { get; set; }

        [DisplayName("Tipo Ordem")]
        [Column("TIPOORDEM")]
        public int TipoOrdem { get; set; }

        [DisplayName("Título Financeiro")]
        [Column("TITULOFINANCEIRO")]
        public bool TituloFinanceiro { get; set; }

        [DisplayName("Serviço no Endereço Entrega")]
        [Column("SERVICONOENDERECOENTREGA")]
        public string ServicoNoEnderecoEntrega { get; set; }

        [DisplayName("Usuário Final")]
        [Column("USUARIOFINAL")]
        public bool UsuarioFinal { get; set; }

        [DisplayName("Número Suframa")]
        [Column("NUMEROSUFRAMA")]
        public string NumeroSuframa { get; set; }

        [DisplayName("Suframa")]
        [Column("SUFRAMA")]
        public bool Suframa { get; set; }

        [DisplayName("Motivo Devolução")]
        [Column("MOTIVODEVOLUCAO")]
        public string MotivoDevolucao { get; set; }

        [DisplayName("Criar Transações Contábeis")]
        [Column("CRIARTRANSACOESCONTABEIS")]
        public bool CriarTransacoesContabeis { get; set; }

        [DisplayName("Calcular Retenção")]
        [Column("CALCULARRETENCAO")]
        public bool CalcularRetencao { get; set; }

        [DisplayName("Descontar Pis e Cofins")]
        [Column("DESCONTARPISECOFINS")]
        public bool DescontarPiseCofins { get; set; }

        [DisplayName("Id Contrato Comercial")]
        [Column("IDCONTRATOCOMERCIAL")]
        public int? IdContratoComercial { get; set; }

        [DisplayName("Id Ordem Referencia")]
        [Column("IDORDEMREFERENCIA")]
        public int? IdOrdemReferencia { get; set; }

        [DisplayName("Substituição Adiantada")]
        [Column("SUBSTITUICAOADIANTADA")]
        public string SubstituicaoAdiantada { get; set; }

        [DisplayName("Id Texto Padrão")]
        [Column("IDTEXTOPADRAO")]
        public int? IdTextoPadrao { get; set; }

        [Column("TIPOATENDIMENTO")]
        public int? TipoAtendimento { get; set; }

        public int? IdCFOP { get; set; }

        public virtual ICollection<PedidoVendaItem> PedidoVendaItem { get; set; }
    }
}
