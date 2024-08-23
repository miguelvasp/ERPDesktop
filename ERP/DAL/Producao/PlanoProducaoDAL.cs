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
    public class PlanoProducaoDAL : Repository<PlanoProducao>
    {
        public List<PlanoProducao> getByParams(string Nome, int IdProduto = 0)
        {
            return (from p in db.PlanoProducao
                    where p.Nome.Contains(Nome) 
                    
                    from pr in db.PlanoProducaoProduto
                    .Where(x => x.IdPlanoProducao == p.IdPlanoProducao && (IdProduto == 0 || x.IdProduto == IdProduto))
                    .DefaultIfEmpty()

                    select p).Distinct().ToList();
        }

        public List<ComboItem> getCombo()
        {
            return (from p in db.PlanoProducao
                    orderby p.Nome
                    select new ComboItem
                    {
                        iValue = p.IdPlanoProducao,
                        Text = p.Nome
                    }).ToList();
        }

        

        public void ImportaDados(int IdOrigem, int IdDestino)
        {
            PlanoProducaoEtapaDAL edal = new PlanoProducaoEtapaDAL();
            PlanoProducaoMateriaPrimaDAL mDal = new PlanoProducaoMateriaPrimaDAL();
            PlanoProducaoControleQualidadeDAL qDal = new PlanoProducaoControleQualidadeDAL();
            //Copia as etapas
            var etapas = (from e in db.PlanoProducaoEtapa
                          where e.IdPlanoProducao == IdOrigem
                          select e).ToList();

            foreach(var e in etapas)
            {
                PlanoProducaoEtapa ep = new PlanoProducaoEtapa();
                ep.IdPlanoProducao = IdDestino;
                ep.Nome = e.Nome;
                ep.Tempo = e.Tempo;
                edal.Insert(ep);
                edal.Save();

                foreach(var m in e.MateriaPrima)
                {
                    PlanoProducaoMateriaPrima mp = new PlanoProducaoMateriaPrima();
                    mp.IdPlanoProducao = IdDestino;
                    mp.IdPlanoProducaoEtapa = ep.IdPlanoProducaoEtapa;
                    mp.IdProduto = m.IdProduto;
                    mp.Quantidade = m.Quantidade;
                    mp.Densidade = m.Densidade;
                    mp.Volume = m.Volume;
                    mp.Peso = m.Peso;
                    mp.VolumeTotal = m.VolumeTotal;
                    mp.PesoTotal = m.PesoTotal;
                    mDal.Insert(mp);
                    mDal.Save();
                }

            }

            mDal.CalcularMateriais(IdDestino);

            //Copia os itnes de qualidade
            var qualidade = (from q in db.PlanoProducaoControleQualidade
                             where q.IdPlanoProducao == IdOrigem
                             select q).ToList();
            foreach(var q in qualidade)
            {
                PlanoProducaoControleQualidade cq = new PlanoProducaoControleQualidade();
                cq.IdPlanoProducao = IdDestino;
                cq.Descricao = q.Descricao;
                cq.Valor = q.Valor;
                cq.ToleranciaAmais = q.ToleranciaAmais;
                cq.ToleranciaAMenos = q.ToleranciaAMenos;
                cq.Aspecto = q.Aspecto;
                qDal.Insert(cq);
                qDal.Save();
            }



        }
    }
}
