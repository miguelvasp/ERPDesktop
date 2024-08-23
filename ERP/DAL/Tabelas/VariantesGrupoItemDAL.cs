using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ERP.ModelView;

namespace ERP.DAL
{
    public class VariantesGrupoItemDAL : Repository<VariantesGrupoItem>
    {
        public List<VariantesGrupoItemModelView> GetByGrupoId(int id)
        {
            List<VariantesGrupoItemModelView> lista = (from v in db.VariantesGrupoItem
                                                       where v.IdVariantesGrupo == id

                                                       from vc in db.VariantesCor
                                                       .Where(x => x.IdVariantesCor == v.IdCor)
                                                       .DefaultIfEmpty()

                                                       from ve in db.VariantesEstilo
                                                       .Where(x => x.IdVariantesEstilo == v.IdEstilo)
                                                       .DefaultIfEmpty()

                                                       from vt in db.VariantesTamanho
                                                       .Where(x => x.IdVariantesTamanho == v.IdTamanho)
                                                       .DefaultIfEmpty()

                                                       from vf in db.VariantesConfig
                                                       .Where(x => x.IdVariantesConfig == v.IdConfiguracao)
                                                       .DefaultIfEmpty()

                                                       select new VariantesGrupoItemModelView
                                                       {
                                                           IdVariantesGrupoItem = v.IdVariantesGrupoItem,
                                                           Cor = vc.Descricao,
                                                           Estilo = ve.Descricao,
                                                           Tamanho = vt.Descricao,
                                                           Configuracao = vf.Descricao
                                                       }).OrderBy(x => x.Cor).ThenBy(x => x.Estilo).ThenBy(x => x.Tamanho).ThenBy(x => x.Configuracao).ToList();
            return lista;


        }

        public bool VerificaDuplicidade(int? IdVariantesGrupo, int? config, int? cor, int? estilo, int? tamanho)
        {
            bool duplicidade = false;
            var lista = (from vi in db.VariantesGrupoItem
                         where vi.IdVariantesGrupo == IdVariantesGrupo
                        & vi.IdConfiguracao == config
                        & vi.IdCor == cor
                        & vi.IdEstilo == estilo
                        & vi.IdTamanho == tamanho
                             select vi).FirstOrDefault();
            if(lista != null)
            {
                duplicidade = true;
            }
            return duplicidade;
        }


    }
}
