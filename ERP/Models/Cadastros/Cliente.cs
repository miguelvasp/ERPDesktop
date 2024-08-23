using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CLIENTE", Schema = "DBO")]
    public class Cliente
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCLIENTE")]
        public int IdCliente { get; set; }

        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }

        [DisplayName("Tipo")]
        [Column("TIPO")]
        public int? Tipo { get; set; }

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

        [DisplayName("ServicoEnderecoEntrega")]
        [Column("SERVICOENDERECOENTREGA")]
        public bool ServicoEnderecoEntrega { get; set; }

        [DisplayName("Suframa")]
        [Column("SUFRAMA")]
        public bool Suframa { get; set; }

        [DisplayName("Código Suframa")]
        [Column("CODIGOSUFRAMA")]
        public string CodigoSuframa { get; set; }

        [DisplayName("DescontarPiseCofins")]
        [Column("DESCONTARPISECOFINS")]
        public bool DescontarPiseCofins { get; set; }

        [DisplayName("GerarNotaRecebida")]
        [Column("GERARNOTARECEBIDA")]
        public bool GerarNotaRecebida { get; set; }

        [DisplayName("UsuarioFinal")]
        [Column("USUARIOFINAL")]
        public bool UsuarioFinal { get; set; }

        [DisplayName("ContribuinteICMS")]
        [Column("CONTRIBUINTEICMS")]
        public bool ContribuinteICMS { get; set; }

        [DisplayName("Email")]
        [Column("EMAIL")]
        public string Email { get; set; }

        [DisplayName("Internet")]
        [Column("INTERNET")]
        public string Internet { get; set; }

        [DisplayName("IdGrupoCliente")]
        [Column("IDGRUPOCLIENTE")]
        public int? IdGrupoCliente { get; set; }

        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }

        [DisplayName("IdLinhaNegocio")]
        [Column("IDLINHANEGOCIO")]
        public int? IdLinhaNegocio { get; set; }

        [DisplayName("IdSegmento")]
        [Column("IDSEGMENTO")]
        public int? IdSegmento { get; set; }

        [DisplayName("IdSubSegmento")]
        [Column("IDSUBSEGMENTO")]
        public int? IdSubSegmento { get; set; }

        [DisplayName("Bloqueado")]
        [Column("BLOQUEADO")]
        public int? Bloqueado { get; set; }

        [DisplayName("IdAvaliacaoCredito")]
        [Column("IDAVALIACAOCREDITO")]
        public int? IdAvaliacaoCredito { get; set; }

        [DisplayName("LimiteCreditoObrigatorio")]
        [Column("LIMITECREDITOOBRIGATORIO")]
        public bool LimiteCreditoObrigatorio { get; set; }

        [DisplayName("LimiteCredito")]
        [Column("LIMITECREDITO")]
        public decimal LimiteCredito { get; set; }

        [DisplayName("IdGrupoEncargos")]
        [Column("IDGRUPOENCARGOS")]
        public int? IdGrupoEncargos { get; set; }

        [DisplayName("IdGrupoComissao")]
        [Column("IDGRUPOCOMISSAO")]
        public int? IdGrupoComissao { get; set; }

        [DisplayName("IdCondicaoPagamento")]
        [Column("IDCONDICAOPAGAMENTO")]
        public int? IdCondicaoPagamento { get; set; }

        [DisplayName("IdMetodoPagamento")]
        [Column("IDMETODOPAGAMENTO")]
        public int? IdMetodoPagamento { get; set; }

        [DisplayName("IdPlanoPagamento")]
        [Column("IDPLANOPAGAMENTO")]
        public int? IdPlanoPagamento { get; set; }

        [DisplayName("IdEspecificacaoPagamento")]
        [Column("IDESPECIFICACAOPAGAMENTO")]
        public int? IdEspecificacaoPagamento { get; set; }

        [DisplayName("IdDiasPagamento")]
        [Column("IDDIASPAGAMENTO")]
        public int? IdDiasPagamento { get; set; }

        [DisplayName("IdCodigoJuros")]
        [Column("IDCODIGOJUROS")]
        public int? IdCodigoJuros { get; set; }

        [DisplayName("IdCodigoMultas")]
        [Column("IDCODIGOMULTAS")]
        public int? IdCodigoMultas { get; set; } 

        [DisplayName("IdGrupoImposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }

        [DisplayName("ImpostoRetido")]
        [Column("IMPOSTORETIDO")]
        public bool ImpostoRetido { get; set; }

        [DisplayName("IdTextoPadrao")]
        [Column("IDTEXTOPADRAO")]
        public int? IdTextoPadrao { get; set; }

        [DisplayName("IdGrupoVendas")]
        [Column("IDGRUPOVENDAS")]
        public int? IdGrupoVendas { get; set; }

        [DisplayName("IdDescontoCombinado")]
        [Column("IDDESCONTOCOMBINADO")]
        public int? IdDescontoCombinado { get; set; }

        [DisplayName("IdDescontoTotal")]
        [Column("IDDESCONTOTOTAL")]
        public int? IdDescontoTotal { get; set; }

        [DisplayName("IdDescontoVarejista")]
        [Column("IDDESCONTOVAREJISTA")]
        public int? IdDescontoVarejista { get; set; }

        [DisplayName("IdDescontoAVista")]
        [Column("IDDESCONTOAVISTA")]
        public int? IdDescontoAVista { get; set; }

        [DisplayName("IdCondicaoFrete")]
        [Column("IDCONDICAOFRETE")]
        public int? IdCondicaoFrete { get; set; }

        [DisplayName("IdModoEntrega")]
        [Column("IDMODOENTREGA")]
        public int? IdModoEntrega { get; set; }

        [DisplayName("IdNumeroIsencao")]
        [Column("IDNUMEROISENCAO")]
        public int? IdNumeroIsencao { get; set; }

        [DisplayName("IdImpostoRetido")]
        [Column("IDIMPOSTORETIDO")]
        public int? IdImpostoRetido { get; set; }

        [DisplayName("Id Vendedor")]
        [Column("IDVENDEDOR")]
        public int? IdVendedor { get; set; }

        public int? IdPais { get; set; }
        public int? IdUf { get; set; }
        public int? IdCidade { get; set; }
        public string Logradouro { get; set; }
        public string Nro { get; set; }
        public string Compl { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Celular { get; set; }

        public virtual ICollection<ClienteContato> ClienteContato { get; set; }
        public virtual ICollection<ClienteEndereco> ClienteEndereco { get; set; }
        public virtual ICollection<ClienteTelefone> ClienteTelefone { get; set; }
        public virtual ICollection<ClienteContaBancaria> ClienteContaBancaria { get; set; }
    }
}
