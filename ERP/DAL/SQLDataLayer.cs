using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ERP.DAL
{
    public class SQLDataLayer
    {
        DB_ERPContext db = new DB_ERPContext();
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB_ERPContext"].ConnectionString;


        #region FluxoDeCaixa

        public void AddFluxo(DateTime De, DateTime Ate, int Periodo, string Tipo, int IdUsuario)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("STP_CALCULA_FLUXO", cn);
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DE", De));
                cmd.Parameters.Add(new SqlParameter("@ATE", Ate));
                cmd.Parameters.Add(new SqlParameter("@Periodo", Periodo));
                cmd.Parameters.Add(new SqlParameter("@TIPO", Tipo));
                cmd.Parameters.Add(new SqlParameter("@IdUsuario", IdUsuario));
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                cn.Close();
            } 
        }

        public DataTable CalculaTotais(decimal ValorInicial, int IdUsuario)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("STP_TOTALIZA_FLUXO", cn);
            try
            {
                DataTable dt = new DataTable();
                cmd.CommandType = System.Data.CommandType.StoredProcedure; 
                cmd.Parameters.Add(new SqlParameter("@IdUsuario", IdUsuario));
                cmd.Parameters.Add(new SqlParameter("@ValorInicial", ValorInicial));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cn.Open();
                da.Fill(dt);
                //DataTable dt = cmd.BeginExecuteReader();
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
            finally
            {
                cn.Close();
            }
        }

        #endregion


        public List<string> getFiltroCombo(string nomeView, string Campo)
        {
            List<string> valores = new List<string>();
            valores.Add("");
            SqlConnection cn = new SqlConnection(ConnectionString);
            string str = $"SELECT DISTINCT {Campo} FROM {nomeView} ORDER BY {Campo}";
            SqlCommand cmd = new SqlCommand(str, cn);
            DataTable dt = new DataTable();
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cn.Open();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                valores.Add(dr[Campo].ToString());
            }
            return valores;
        }

        public DataTable getReportData(string SQL)
        {
            SqlConnection cn = new SqlConnection(ConnectionString); 
            SqlCommand cmd = new SqlCommand(SQL, cn);
            DataTable dt = new DataTable();
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cn.Open();
            da.Fill(dt);
            return dt;
        }

        public void corrigeDepositoEstoque()
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            try
            {
                
                SqlCommand cmd = new SqlCommand("UPDATE INVENTARIO SET IDDEPOSITO = 1", cn);
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }
           
        }

        public void corrigeUnidadeEstoque()
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            try
            {

                SqlCommand cmd = new SqlCommand("UPDATE INVENTARIO SET IDUNIDADE = 4", cn);
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            } 
        }

        public void UnificaEstoque(string Codigo)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            try
            {

                SqlCommand cmd = new SqlCommand($"EXEC STP_UNIFICAESTOQUE '{Codigo}'", cn);
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                cn.Close();
            }
        }

        public List<string> getProdutoDuplicado()
        {
            string sql = "SELECT  Codigo, COUNT(CODIGO) FROM PRODUTO WHERE VendaProdDescontinuado = 0 GROUP BY Codigo HAVING COUNT(CODIGO) > 1";
            SqlConnection cn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, cn);
            DataTable dt = new DataTable();
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cn.Open();
            da.Fill(dt);

            List<string> codigos = new List<string>();
            foreach(DataRow dr in dt.Rows)
            {
                codigos.Add(dr["Codigo"].ToString());

            }
            return codigos;
        }
    }
}
