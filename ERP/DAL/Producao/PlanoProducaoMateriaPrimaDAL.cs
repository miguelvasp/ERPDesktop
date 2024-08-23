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
    public class PlanoProducaoMateriaPrimaDAL : Repository<PlanoProducaoMateriaPrima>
    {
        public List<PlanoProducaoMateriaPrima> getByEtapa(int idEtapa)
        {
            return (from p in db.PlanoProducaoMateriaPrima
                    where p.IdPlanoProducaoEtapa == idEtapa
                    select p).ToList();
        }

        public void apagaMateriais(int IdEtapa)
        {
            var l = (from m in db.PlanoProducaoMateriaPrima
                     where m.IdPlanoProducaoEtapa == IdEtapa
                     select m).ToList();
            foreach(var m in l)
            {
                this.Delete(m.IdPlanoProducaoMateriaPrima);
                this.Save();
            }
        }

        public List<PlanoProducaoMateriaPrima> getByPlanoProducao(int IdPlanoProducao)
        {
            return (from m in db.PlanoProducaoMateriaPrima
                    where m.IdPlanoProducao == IdPlanoProducao
                    orderby m.IdPlanoProducaoMateriaPrima
                    select m).ToList();
        }

        public List<PlanoProducaoMateriaPrima> getByEtapaCalculado(int IdEtapa, int IdPlano)
        {
            var plano = new PlanoProducaoDAL().GetByID(IdPlano);
            var MateriaisPlanoProducao = this.getByPlanoProducao(IdPlano);
            decimal SomaDensidade = Convert.ToDecimal(MateriaisPlanoProducao.Sum(x => x.Densidade));
            decimal SomaVolume = Convert.ToDecimal(MateriaisPlanoProducao.Sum(x => x.Peso / x.Densidade));

            decimal DensidadeSomada = 0;
            var lista = this.getByEtapa(IdEtapa);
            var materiais = lista.Select(x => new PlanoProducaoMateriaPrima
            {
                IdPlanoProducaoMateriaPrima = x.IdPlanoProducaoMateriaPrima, 
                Densidade = x.Densidade,
                Volume = x.Peso / x.Densidade,
                Peso = x.Peso,
                PesoTotal = (plano.VolumeContainer * DensidadeSomada) * (x.Peso / 100),
                VolumeTotal = (plano.VolumeContainer * DensidadeSomada) * (x.Peso / 100) / x.Densidade,
                Produto = x.Produto

            }).ToList();
            return materiais;
        }

        public void CalcularMateriais(int IdPlano)
        {
            try
            {
                var plano = new PlanoProducaoDAL().GetByID(IdPlano);
                var MateriaisPlanoProducao = this.getByPlanoProducao(IdPlano);
                decimal SomaVolume = Convert.ToDecimal(MateriaisPlanoProducao.Sum(x => x.Peso / x.Densidade));
                decimal SomaPeso = Convert.ToDecimal(MateriaisPlanoProducao.Sum(x => x.Peso));
                decimal DensidadeSomada = SomaPeso / SomaVolume;


                foreach (var i in MateriaisPlanoProducao)
                {
                    i.Volume = i.Peso / i.Densidade;
                    i.VolumeTotal = (plano.VolumeContainer * DensidadeSomada) * (i.Peso / 100) / i.Densidade;
                    i.PesoTotal = (plano.VolumeContainer * DensidadeSomada) * (i.Peso / 100);
                    this.Update(i);
                    this.Save();
                }
            }
            catch (Exception ex)
            {
                 
            }
            
        }
    }
}
