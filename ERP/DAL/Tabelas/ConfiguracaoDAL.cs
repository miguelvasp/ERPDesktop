using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ERP.DAL
{
    public class ConfiguracaoDAL : Repository<Configuracao>
    {
        public Configuracao GetByEmpresa(int Id)
        {
            Configuracao conf = (from c in db.Configuracao
                                 where c.IdEmpresa == Id
                                 select c).FirstOrDefault();
            return conf;
        }

        public void AtualizaVersao(decimal? NovaVersao)
        {
            List<Configuracao> lista = (from c in db.Configuracao select c).ToList();

            if (lista.Count == 0)
            {
                Configuracao c = new Configuracao();
                c.VersaoSistema = NovaVersao;
                int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                c.IdEmpresa = idEmpresa;
                this.Insert(c);
                this.Save();
            }
            else
            {
                foreach (Configuracao c in lista)
                {
                    c.VersaoSistema = NovaVersao;
                    this.Update(c);
                    Save();
                }
            }
        }

        public decimal? ConsultaVersao()
        {
            var versao = (from c in db.Configuracao
                          select c.VersaoSistema).FirstOrDefault();

            if(versao == null)
            {
                versao = 0;
            }

            return versao;
        }

        public ConfiguracaoEMailModelView GetConfEMailByEmpresa(int Id)
        {
            ConfiguracaoEMailModelView conf = (from c in db.Configuracao
                                               where c.IdEmpresa == Id
                                               select new ConfiguracaoEMailModelView
                                               {
                                                   EMailUserName = c.EMailUserName,
                                                   EMailPassword = c.EMailPassword,
                                                   EMailSMTP = c.EMailSMTP,
                                                   EMailPort = c.EMailPort,
                                                   EMailSSL = c.EMailSSL
                                               }).FirstOrDefault();
            return conf;
        }
    }
}
