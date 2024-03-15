
using System.Data.OleDb;

namespace testAsynch
{
    class clsDBConnector
    {
        OleDbConnection conn = new OleDbConnection();
        string dbProvider;
        string dbSource;

        public void Connect()
        {
            dbProvider = "Provider=Microsoft.ACE.OLEDB.12.0;";
            dbSource = @"Data Source =C:\Users\charl\OneDrive - Brockenhurst College\Visual Studio\dbStudentlates.accdb";
            conn.ConnectionString = dbProvider + dbSource;
           
            conn.Open();
        }

        public void close()
        {
            conn.Close();
        }

        public void DoDML(string dmlString)
        {
            OleDbCommand cmd;
            cmd = new OleDbCommand(dmlString, conn);
            cmd.ExecuteNonQuery();
        }

        public OleDbDataReader DoSQL(string sqlString)
        {
            OleDbCommand cmd;
            cmd = new OleDbCommand(sqlString, conn);
            return cmd.ExecuteReader() ;
        }  
    }
}
