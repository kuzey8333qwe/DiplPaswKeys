using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DiplPaswKeys.CLS
{
    public class SQLConnectionClass
    {
        private static string SQLConnectionString = @"Server = DESKTOP-NARD8PQ\SQLEXPRESS; Database = Dipp_pass_keys; Trusted_Connection = True;";
        private static SqlConnection con = new SqlConnection();
        private static SqlDataAdapter da = new SqlDataAdapter();
        private static SqlCommand com = new SqlCommand();
        
        public static void Baglanti()
        {
            con = new SqlConnection(SQLConnectionString);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public static object Command(string query)
        {
            object obj = null;
            Baglanti(); // Bağlantıyı aç
            try
            {
                com.Connection = con;
                com.CommandText = query;

                // Eğer sorgu bir veri çekme işlemi değilse ExecuteNonQuery kullanın
                if (query.TrimStart().StartsWith("INSERT") || query.TrimStart().StartsWith("UPDATE") || query.TrimStart().StartsWith("DELETE"))
                {
                    obj = com.ExecuteNonQuery(); // Bu komut, etkilenen satır sayısını döndürür
                }
                else
                {
                    obj = com.ExecuteScalar(); // Tek bir değer döndürmesi beklenen sorgular için
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Hatası: " + ex.Message); // Hata varsa konsola yazdır
            }
            return obj;
        }

        public static DataTable Table(string query)
        {
            DataTable dt = new DataTable();
            com.Connection = con; // SqlCommand
            com.CommandText = query; // SqlCommand
            da.SelectCommand = com; // // SqlCommand'ın bir select sorgusu olduğunu belirtiyoruz.
            da.Fill(dt);
            return dt;
        }
    }
}