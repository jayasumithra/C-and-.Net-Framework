using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string con = @"Data Source=.\SQLEXPRESS;
Initial Catalog=College;
Integrated Security=True;
TrustServerCertificate=True";

        SqlDataAdapter da = new SqlDataAdapter(
            "SELECT * FROM Student", con);

        DataSet ds = new DataSet();

        da.Fill(ds, "Student");

        foreach (DataRow row in ds.Tables["Student"].Rows)
        {
            Console.WriteLine(row["Id"] + " " + row["Name"]);
        }
    }
}