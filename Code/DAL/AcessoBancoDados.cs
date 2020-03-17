using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Locadora_1._2.Code.DAL
{
    class AcessoBancoDados
    {
        private SqlConnection conn;
        private DataTable data;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private SqlCommandBuilder cb;

        private String server;
        private String user;
        private String password;
        private String database;

        public void Conectar()
        {
            if (conn != null)
                conn.Close();

            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Greg\Desktop\PROJETO\1.2\Locadora 1.2\Locadora 1.2\DB\Dbvideo.mdf;Integrated Security=True";

            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void ExecutarComandoSQL(string comandoSql)
        {
            SqlCommand comando = new SqlCommand(comandoSql, conn);
            comando.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable RetDataTable(string sql)
        {
            data = new DataTable();
            da = new SqlDataAdapter(sql, conn);
            cb = new SqlCommandBuilder(da);
            da.Fill(data);

            return data;
        }

        public SqlDataReader RetDataReadReader(string sql)
        {
            SqlCommand comando = new SqlCommand(sql, conn);
            SqlDataReader dr = comando.ExecuteReader();
            dr.Read();

            return dr;
        }
    } 
            
}
            
            
        