using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("PEDIDOCOMPRA", Schema = "DBO")]
    public class PedidoCompra
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPEDIDOCOMPRA")]
        public int IdPedidoCompra { get; set; }

        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime Data { get; set; }

        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }

        [DisplayName("IdMoeda")]
        [Column("IDMOEDA")]
        public int? IdMoeda { get; set; }

        [DisplayName("Data Entrega")]
        [Column("DATAENTREGA")]
        public DateTime DataEntrega { get; set; }

        [DisplayName("Observação")]
        [Column("OBSERVACAO")]
        public string Observacao { get; set; }

        [DisplayName("PrazoEntrega")]
        [Column("PRAZOENTREGA")]
        public string PrazoEntrega { get; set; }

        [DisplayName("IdCondicaoPagamento")]
        [Column("IDCONDICAOPAGAMENTO")]
        public int? IdCondicaoPagamento { get; set; }

        [DisplayName("Emissao")]
        [Column("EMISSAO")]
        public DateTime Emissao { get; set; }

        [DisplayName("Status")]
        [Column("STATUS")]
        public string Status { get; set; }

        [DisplayName("IdComprador")]
        [Column("IDCOMPRADOR")]
        public int? IdComprador { get; set; }

        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }

        [DisplayName("IdGrupoFornecedor")]
        [Column("IDGRUPOFORNECEDOR")]
        public int? IdGrupoFornecedor { get; set; }

        [DisplayName("IdPerfilFornecedor")]
        [Column("IDPERFILFORNECEDOR")]
        public int? IdPerfilFornecedor { get; set; }

        [DisplayName("IdTipoOprecacao")]
        [Column("IDTIPOOPRECACAO")]
        public int? IdTipoOprecacao { get; set; }

        [DisplayName("IdCFPS")]
        [Column("IDCFPS")]
        public int? IdCFPS { get; set; }

        [DisplayName("IdGrupoEncargos")]
        [Column("IDGRUPOENCARGOS")]
        public int? IdGrupoEncargos { get; set; }

        [DisplayName("IdGrupoDesconto")]
        [Column("IDGRUPODESCONTO")]
        public int? IdGrupoDesconto { get; set; }

        [DisplayName("IdGrupoFretes")]
        [Column("IDGRUPOFRETES")]
        public int? IdGrupoFretes { get; set; }

        [DisplayName("IdRoyalties")]
        [Column("IDROYALTIES")]
        public int? IdRoyalties { get; set; }

        [DisplayName("IdTextoPadrao")]
        [Column("IDTEXTOPADRAO")]
        public int? IdTextoPadrao { get; set; }

        [DisplayName("TipoOrdem")]
        [Column("TIPOORDEM")]
        public int? TipoOrdem { get; set; }

        [DisplayName("IdMetodoPagamento")]
        [Column("IDMETODOPAGAMENTO")]
        public int? IdMetodoPagamento { get; set; }

        [DisplayName("IdPlanoPagamento")]
        [Column("IDPLANOPAGAMENTO")]
        public int? IdPlanoPagamento { get; set; }

        [DisplayName("StatusAprovacao")]
        [Column("STATUSAPROVACAO")]
        public int? StatusAprovacao { get; set; }

        [DisplayName("MovimentaEstoque")]
        [Column("MOVIMENTAESTOQUE")]
        public bool MovimentaEstoque { get; set; }

        [DisplayName("CriaTransContabeis")]
        [Column("CRIATRANSCONTABEIS")]
        public bool CriaTransContabeis { get; set; }

        [DisplayName("CalculaRetencao")]
        [Column("CALCULARETENCAO")]
        public bool CalculaRetencao { get; set; }

        [DisplayName("DescontaPisCofins")]
        [Column("DESCONTAPISCOFINS")]
        public bool DescontaPisCofins { get; set; }

        [DisplayName("TituloFinanceiro")]
        [Column("TITULOFINANCEIRO")]
        public string TituloFinanceiro { get; set; }

        [DisplayName("IdGrupoImposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }

        [DisplayName("IdGrupoImpostoRetido")]
        [Column("IDGRUPOIMPOSTORETIDO")]
        public int? IdGrupoImpostoRetido { get; set; }

        [DisplayName("IdTransportadora")]
        [Column("IDTRANSPORTADORA")]
        public int? IdTransportadora { get; set; }

        [DisplayName("Armazém")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }

        [DisplayName("Depósito")]
        [Column("IDDEPOSITO")]
        public int? IdDeposito { get; set; }

        [DisplayName("MotivoDevolucao")]
        [Column("MOTIVODEVOLUCAO")]
        public string MotivoDevolucao { get; set; }

        [DisplayName("IdContratoComercial")]
        [Column("IDCONTRATOCOMERCIAL")]
        public int? IdContratoComercial { get; set; }

        [DisplayName("IdOrdemReferencia")]
        [Column("IDORDEMREFERENCIA")]
        public int? IdOrdemReferencia { get; set; }

        [DisplayName("NFSE")]
        [Column("NFSE")]
        public bool NFSE { get; set; }

        [DisplayName("RPA")]
        [Column("RPA")]
        public bool RPA { get; set; }

        [DisplayName("IdModoEntrega")]
        [Column("IDMODOENTREGA")]
        public int? IdModoEntrega { get; set; }

        [DisplayName("IdCondicaoEntrega")]
        [Column("IDCONDICAOENTREGA")]
        public int? IdCondicaoEntrega { get; set; }

        [DisplayName("TipoFrete")]
        [Column("TIPOFRETE")]
        public int? TipoFrete { get; set; }


        [Column("PEDIDONUMERO")]
        public int? PedidoNumero { get; set; }

        [Column("IDOPERACAO")]
        public int? IdOperacao { get; set; }

        [Column("CRIATRANSFINANCEIRAS")]
        public bool? CriaTransFinanceiras { get; set; }

        [DisplayName("IdDiasPagamento")]
        [Column("IDDIASPAGAMENTO")]
        public int? IdDiasPagamento { get; set; }

        //public virtual ICollection<NotaFiscal> NotaFiscal { get; set; }
        public virtual ICollection<PedidoCompraItem> PedidoCompraItem { get; set; }
        public virtual Operacao Operacao { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
