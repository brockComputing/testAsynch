using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;


namespace testAsynch
{
    class Program
    {
        static Task<string> TaskGetStudents()
        {

            return Task.Run<string>(() =>
           {
               clsDBConnector connector = new clsDBConnector();
               OleDbDataReader dr;
               connector.Connect();
               string sqlStr = "select * from tblStudent";
               dr = connector.DoSQL(sqlStr);
               while (dr.Read())
               {
                   Console.WriteLine($"{dr[0].ToString()}   {dr[1].ToString()}   {dr[2].ToString()} ");
               }
               return "Y";
           });
        }

        static async void TestMethodAsync()
        {
            string result = await TaskGetStudents();
        }
        static void Main(string[] args)
        {

            Console.WriteLine("A");
            TestMethodAsync();
            Console.WriteLine("B");
            Console.ReadLine();
        }
    }
}
