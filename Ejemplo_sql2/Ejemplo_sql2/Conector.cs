using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace Ejemplo_sql2.CLASE
{
    internal class Conector
    {
        string cadena = "workstation id=Empresa_JDMC.mssql.somee.com;packet size=4096;user id=jdmc525_SQLLogin_1;pwd=gx4toj8c7g;data source=Empresa_JDMC.mssql.somee.com;persist security info=False;initial catalog=Empresa_JDMC;TrustServerCertificate=True";

        SqlTransaction myTxn;
        SqlConnection myconn;
        SqlCommandBuilder cust;
        SqlCommand myCommand;
        SqlDataAdapter da;

        public void Abrir()
        {
            myconn = new SqlConnection(cadena);
            myconn.Open();

            myCommand = myconn.CreateCommand();
            myTxn = myconn.BeginTransaction(System.Data.IsolationLevel.Serializable);
            myCommand.Connection = myconn;
            myCommand.Transaction = myTxn;

        }

        public DataSet select(string query)
        {

            DataSet ds = new DataSet();
            da = new SqlDataAdapter(query, myconn);
            da.SelectCommand.Transaction = myTxn;
            cust = new SqlCommandBuilder(da);
            da.Fill(ds);
            return ds;
        }

        public void insert(string query)
        {
            myCommand.CommandText = query;
            myCommand.ExecuteNonQuery();
        }

        public void cerrar()
        {
            myTxn.Commit();
            myconn.Close();
        }
    }


}
