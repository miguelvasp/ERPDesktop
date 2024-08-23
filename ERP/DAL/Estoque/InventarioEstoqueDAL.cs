using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class InventarioEstoqueDAL : Repository<InventarioEstoque>
    {
        public int getMaxInventario()
        {
            var i = db.InventarioEstoque.Max(x => x.Numero);
            return (i == null ? 0 : Convert.ToInt32(i)) + 1;
        }

        public List<InventarioEstoque> getByNumero(int numero)
        {
           // db.Configuration.LazyLoadingEnabled = true;
            return (from i in db.InventarioEstoque
                    where i.Numero == numero
                    select i).ToList();
        }

        public List<InventarioEstoque> getByParams(int numero, int IdProduto,
                    int IdDeposito,
                    int IdArmazem,
                    int IdLocalizacao,
                    int IdVariantesConfig,
                    int IdVariantesTamanho,
                    int IdVariantesCor,
                    int IdVariantesEstilo)
        {
            return (from i in db.InventarioEstoque
                    where (numero == 0 || i.Numero == numero)
                    && (IdDeposito == 0 || i.IdDeposito == IdDeposito)
                    && (IdArmazem == 0 || i.IdArmazem == IdArmazem)
                    && (IdLocalizacao == 0 || i.IdLocalizacao == IdLocalizacao)
                    && (IdVariantesConfig == 0 || i.IdVariantesConfig == IdVariantesConfig)
                    && (IdVariantesCor == 0 || i.IdVariantesCor == IdVariantesCor)
                    && (IdVariantesEstilo == 0 || i.IdVariantesEstilo == IdVariantesEstilo)
                    && (IdVariantesTamanho == 0 || i.IdVariantesTamanho == IdVariantesTamanho)
                    select i).ToList();
        }

    }
}
