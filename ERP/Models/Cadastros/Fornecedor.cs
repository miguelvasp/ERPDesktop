using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("FORNECEDOR", Schema = "DBO")]
    public class Fornecedor
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDFORNECEDOR")]
        public int IdFornecedor { get; set; }

        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }

        [DisplayName("RazaoSocial")]
        [Column("RAZAOSOCIAL")]
        public string RazaoSocial { get; set; }

        [DisplayName("NomeFantasia")]
        [Column("NOMEFANTASIA")]
        public string NomeFantasia { get; set; }

        [DisplayName("CNPJ")]
        [Column("CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("InscricaoEstadual")]
        [Column("INSCRICAOESTADUAL")]
        public string InscricaoEstadual { get; set; }

        [DisplayName("CCM")]
        [Column("CCM")]
        public string CCM { get; set; }

        [DisplayName("NIT")]
        [Column("NIT")]
        public string NIT { get; set; }

        [DisplayName("INSSCEI")]
        [Column("INSSCEI")]
        public string INSSCEI { get; set; }

        [DisplayName("CNAE")]
        [Column("CNAE")]
        public string CNAE { get; set; }

        [DisplayName("OptanteSimples")]
        [Column("OPTANTESIMPLES")]
        public bool OptanteSimples { get; set; }

        [DisplayName("SIMEI")]
        [Column("SIMEI")]
        public bool SIMEI { get; set; }

        [DisplayName("ServicoEnderecoEntrega")]
        [Column("SERVICOENDERECOENTREGA")]
        public bool ServicoEnderecoEntrega { get; set; }

        [DisplayName("ContribuinteICMS")]
        [Column("CONTRIBUINTEICMS")]
        public bool ContribuinteICMS { get; set; }

        [DisplayName("GerarNotaRecebida")]
        [Column("GERARNOTARECEBIDA")]
        public bool GerarNotaRecebida { get; set; }

        [DisplayName("UsoConsumo")]
        [Column("USOCONSUMO")]
        public bool UsoConsumo { get; set; }

        [DisplayName("Código Rendimento")]
        [Column("CODIGORENDIMENTO")]
        public bool CodigoRendimento { get; set; }

        [DisplayName("Email")]
        [Column("EMAIL")]
        public string Email { get; set; }

        [DisplayName("Internet")]
        [Column("INTERNET")]
        public string Internet { get; set; }

        [DisplayName("IdGrupoFornecedor")]
        [Column("IDGRUPOFORNECEDOR")]
        public int? IdGrupoFornecedor { get; set; }

        [DisplayName("IdLinhaNegocio")]
        [Column("IDLINHANEGOCIO")]
        public int? IdLinhaNegocio { get; set; }

        [DisplayName("IdSegmento")]
        [Column("IDSEGMENTO")]
        public int? IdSegmento { get; set; }

        [DisplayName("IdSubSegmento")]
        [Column("IDSUBSEGMENTO")]
        public int? IdSubSegmento { get; set; }

        [DisplayName("LimiteCredito")]
        [Column("LIMITECREDITO")]
        public bool LimiteCredito { get; set; }

        [DisplayName("IdAvaliacaoCredito")]
        [Column("IDAVALIACAOCREDITO")]
        public int? IdAvaliacaoCredito { get; set; }

        [DisplayName("Suspenso")]
        [Column("SUSPENSO")]
        public int? Suspenso { get; set; }

        [DisplayName("IdMoeda")]
        [Column("IDMOEDA")]
        public int? IdMoeda { get; set; }

        [DisplayName("IdGrupoImposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }

        [DisplayName("ImpostoRetido")]
        [Column("IMPOSTORETIDO")]
        public bool ImpostoRetido { get; set; }

        [DisplayName("IdGrupoComissao")]
        [Column("IDGRUPOCOMISSAO")]
        public int? IdGrupoComissao { get; set; }

        [DisplayName("IdCondicaoPagamento")]
        [Column("IDCONDICAOPAGAMENTO")]
        public int? IdCondicaoPagamento { get; set; }

        [DisplayName("IdMetodoPagamento")]
        [Column("IDMETODOPAGAMENTO")]
        public int? IdMetodoPagamento { get; set; }

        [DisplayName("IdEspecificacaoPagamento")]
        [Column("IDESPECIFICACAOPAGAMENTO")]
        public int? IdEspecificacaoPagamento { get; set; }

        [DisplayName("IdPlanoPagamento")]
        [Column("IDPLANOPAGAMENTO")]
        public int? IdPlanoPagamento { get; set; }

        [DisplayName("IdDiasPagamento")]
        [Column("IDDIASPAGAMENTO")]
        public int? IdDiasPagamento { get; set; }

        [DisplayName("IdCodigoJuros")]
        [Column("IDCODIGOJUROS")]
        public int? IdCodigoJuros { get; set; }

        [DisplayName("IdCodigoMultas")]
        [Column("IDCODIGOMULTAS")]
        public int? IdCodigoMultas { get; set; }



        [DisplayName("IdTextoPadrao")]
        [Column("IDTEXTOPADRAO")]
        public int? IdTextoPadrao { get; set; }

        [DisplayName("Tipo")]
        [Column("TIPO")]
        public int? Tipo { get; set; }

        [DisplayName("IdCliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }

        [DisplayName("IdMotivoFinanceiro")]
        [Column("IDMOTIVOFINANCEIRO")]
        public int? IdMotivoFinanceiro { get; set; }

        [DisplayName("IdNumeroIsencao")]
        [Column("IDNUMEROISENCAO")]
        public int? IdNumeroIsencao { get; set; }

        [DisplayName("IdRoyalties")]
        [Column("IDROYALTIES")]
        public int? IdRoyalties { get; set; }

        [DisplayName("IdGrupoCompras")]
        [Column("IDGRUPOCOMPRAS")]
        public int? IdGrupoCompras { get; set; }

        [DisplayName("IdDescontoCombinado")]
        [Column("IDDESCONTOCOMBINADO")]
        public int? IdDescontoCombinado { get; set; }

        [DisplayName("IdDescontoTotal")]
        [Column("IDDESCONTOTOTAL")]
        public int? IdDescontoTotal { get; set; }

        [DisplayName("IdDescontoAVista")]
        [Column("IDDESCONTOAVISTA")]
        public int? IdDescontoAVista { get; set; }

        [DisplayName("IdContaBancaria")]
        [Column("IDCONTABANCARIA")]
        public int? IdContaBancaria { get; set; }

        [DisplayName("IdImpostoRetido")]
        [Column("IDIMPOSTORETIDO")]
        public int? IdImpostoRetido { get; set; }

        [Column("RPA")]
        public bool? RPA { get; set; }

        [DisplayName("Endereco")]
        [Column("ENDERECO")]
        public string Endereco { get; set; }

        [DisplayName("Numero")]
        [Column("NUMERO")]
        public string Numero { get; set; }

        [DisplayName("Bairro")]
        [Column("BAIRRO")]
        public string Bairro { get; set; }

        [DisplayName("Complemento")]
        [Column("COMPLEMENTO")]
        public string Complemento { get; set; }

        [DisplayName("Cidade")]
        [Column("CIDADE")]
        public string Cidade { get; set; }

        [DisplayName("Pais")]
        [Column("PAIS")]
        public string Pais { get; set; }

        [DisplayName("Fone")]
        [Column("FONE")]
        public string Fone { get; set; }

        [DisplayName("CEP")]
        [Column("CEP")]
        public string CEP { get; set; }

        public virtual ICollection<FornecedorContato> FornecedorContato { get; set; }
        public virtual ICollection<FornecedorEndereco> FornecedorEndereco { get; set; }
        public virtual ICollection<FornecedorTelefone> FornecedorTelefone { get; set; }
        public virtual ICollection<FornecedorContaBancaria> FornecedorContaBancaria { get; set; }
        public virtual GrupoFornecedor GrupoFornecedor { get; set; }

    }
}
