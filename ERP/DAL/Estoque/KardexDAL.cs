using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ERP.DAL
{
    public class KardexDAL : Repository<Kardex>
    {
        public List<Kardex> getByUsuario()
        {
            int idUsuario = Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"));
            return (from k in db.Kardex
                    where k.IdUsuario == idUsuario
                    select k).OrderByDescending(x => x.Data).ToList();
        }

        public void ConsultaKardex(int IdProduto, int IdCor, int IdEstilo, int IdTamanho, int IdConfig, DateTime De, DateTime Ate)
        {
            int idUsuario = Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"));
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));

            ObjDAL dalsql = new ObjDAL();
            dalsql.AddParameter(new SqlParameter("@ID_USUARIO", idUsuario));
            dalsql.AddParameter(new SqlParameter("@ID_PRODUTO", IdProduto));
            dalsql.AddParameter(new SqlParameter("@ID_COR", IdCor));
            dalsql.AddParameter(new SqlParameter("@ID_ESTILO", IdEstilo));
            dalsql.AddParameter(new SqlParameter("@ID_TAMANHO", IdTamanho));
            dalsql.AddParameter(new SqlParameter("@ID_CONFIG", IdConfig));
            dalsql.AddParameter(new SqlParameter("@ID_EMPRESA", idEmpresa));
            dalsql.AddParameter(new SqlParameter("@DI", De));
            dalsql.AddParameter(new SqlParameter("@DF", Ate));
            dalsql.ExecProcNonQuery("STP_KARDEX");
        }
    }

    
}