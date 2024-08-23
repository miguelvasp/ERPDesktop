using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("VENDEDOR", Schema = "DBO")]
    public class Vendedor
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDVENDEDOR")]
        public int IdVendedor { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("ComissaoPrincipal")]
        [Column("COMISSAOPRINCIPAL")]
        public decimal? ComissaoPrincipal { get; set; }

        [DisplayName("ComissaoAdicional")]
        [Column("COMISSAOADICIONAL")]
        public decimal? ComissaoAdicional { get; set; }

        [DisplayName("IdGerente")]
        [Column("IDGERENTE")]
        public int IdGerente { get; set; }

        [DisplayName("Bloqueado")]
        [Column("BLOQUEADO")]
        public bool Bloqueado { get; set; }

        [DisplayName("MotivoBloqueio")]
        [Column("MOTIVOBLOQUEIO")]
        public string MotivoBloqueio { get; set; }

        [DisplayName("Gerência")]
        [Column("GERENCIA")]
        public bool Gerencia { get; set; }

        [DisplayName("CPF_CNPJ")]
        [Column("CPF_CNPJ")]
        public string CPF_CNPJ { get; set; }

        [DisplayName("IE_RG")]
        [Column("IE_RG")]
        public string IE_RG { get; set; }

        [DisplayName("Endereço")]
        [Column("ENDERECO")]
        public string Endereco { get; set; }

        [DisplayName("Número")]
        [Column("NUMERO")]
        public string Numero { get; set; }

        [DisplayName("Complemento")]
        [Column("COMPLEMENTO")]
        public string Complemento { get; set; }

        [DisplayName("Bairro")]
        [Column("BAIRRO")]
        public string Bairro { get; set; }

        [DisplayName("IdUF")]
        [Column("IDUF")]
        public int IdUF { get; set; }
        public virtual UnidadeFederacao UF { get; set; }

        [DisplayName("IdCidade")]
        [Column("IDCIDADE")]
        public int IdCidade { get; set; }
        public virtual Cidade Cidade { get; set; }

        [DisplayName("Telefone")]
        [Column("TELEFONE")]
        public string Telefone { get; set; }

        [DisplayName("Telefone2")]
        [Column("TELEFONE2")]
        public string Telefone2 { get; set; }

        [DisplayName("Celular")]
        [Column("CELULAR")]
        public string Celular { get; set; }

        [DisplayName("Site")]
        [Column("SITE")]
        public string Site { get; set; }

        [DisplayName("E-Mail")]
        [Column("EMAIL")]
        public string Email { get; set; }

        [DisplayName("Observação")]
        [Column("OBS")]
        public string Obs { get; set; }

        [DisplayName("Representante")]
        [Column("REPRESENTANTE")]
        public bool Representante { get; set; }

        [DisplayName("Comissão Extra")]
        [Column("COMISSAOEXTRA")]
        public bool? ComissaoExtra { get; set; }

        [Column("IDPERFILFORNECEDOR")]
        public int? IdPerfilFornecedor { get; set; }

        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }

        public virtual ICollection<VendedorMetas> VendedorMetas { get; set; }
    }
}
