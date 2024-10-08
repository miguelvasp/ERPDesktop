﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("GRUPOFORNECEDOR", Schema = "DBO")]
    public class GrupoFornecedor
    {
        [Key]
        [DisplayName("Id Grupo Fornecedor")]
        [Column("IDGRUPOFORNECEDOR")]
        public int IdGrupoFornecedor { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Id Condição Pagamento")]
        [Column("IDCONDICAOPAGAMENTO")]
        public int? IdCondicaoPagamento { get; set; }
        public virtual CondicaoPagamento CondicaoPagamento { get; set; }

        [DisplayName("Id Grupo Imposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }
        public virtual GrupoImposto GrupoImposto { get; set; }

        [DisplayName("Id Período Liquidação Imposto")]
        [Column("IDPERIODOLIQUIDACAOIMPOSTO")]
        public int? IdPeriodoLiquidacaoImposto { get; set; }
        public virtual PeriodoLiquidacaoImposto PeriodoLiquidacaoImposto { get; set; }
    }
}
