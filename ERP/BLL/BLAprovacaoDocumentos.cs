using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using ERP.DAL;
using ERP.Models;

namespace ERP.BLL
{
    public class BLAprovacaoDocumentos
    {
        DB_ERPViewContext dbv = new DB_ERPViewContext();
        DB_ERPContext db = new DB_ERPContext();
        public List<vwAprovacaoDocumentos> GetDocumentos(int pTipoDocumento, int pIdUsuario)
        {
            List<vwAprovacaoDocumentos> Documentos = (from a in dbv.vwAprovacaoDocumentos
                                                      where a.TipoDocumento == pTipoDocumento
                                                      && a.IdUsuario == pIdUsuario
                                                      select a).ToList();
            return Documentos;
        }

        public AprovacaoNivel GetNexNivel(string Sigla, int Sequencia)
        {
            var ProximoNivel = (from a in db.AprovacaoDocumento
                                join n in db.AprovacaoNivel on a.IdAprovacaoDocumento equals n.IdAprovacaoDocumento
                                where a.Sigla == Sigla
                                && n.Sequencia == Sequencia + 1
                                select n).FirstOrDefault();
            return ProximoNivel;
        }


    }
}
