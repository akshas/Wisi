using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace WiSi
{
    class DBConnection
    {
        static SqlConnection conn;
        static SqlDataAdapter adapter;
        public static DataTable Ressourcen = new DataTable();

        static SqlCommand scomm;
        string QueryString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MY_FILES\CSProjects\Apps\Wisi\Wisi.mdf;Integrated Security=True";
         public DBConnection()
        {
            conn = new SqlConnection(QueryString);
            SelectRes();
        }
        public static DataTable SelectRes()
        {
           string QueryString = "Select * From Ressourcen";
           adapter = new SqlDataAdapter(QueryString, conn);
           int rueck =  adapter.Fill(Ressourcen);

           return Ressourcen;
        }
        public static DataTable updateResElement()
        {

            DataRow zeile = Ressourcen.Select("Id = 1")[0];
            int lagerAnzahl = (int)zeile["Lageranzahl"];
            //lagerAnzahl--;
            string QueryString = "Update Ressourcen Set Lageranzahl = " + lagerAnzahl-- + "Where id = 1";
            scomm = new SqlCommand(QueryString, conn);
            conn.Open();
            scomm.ExecuteNonQuery();
            conn.Close();

            return Ressourcen;
        }
    }
}
