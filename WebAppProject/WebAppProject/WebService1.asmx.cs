using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace WebAppProject
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Description = "Webservice pentru proiect II", Name = "WebSrv", Namespace = "WebSrvApp")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        String connString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ProjectDatabase.mdf;Integrated Security=True;";


        [WebMethod(Description = "Returns a dataset containing all database data")]
        public DataSet get_all_db()
        {
            DataSet dsCategories;
            dsCategories = new DataSet();

            SqlConnection myCon = new SqlConnection();
            // Change the connection string on other computers
            myCon.ConnectionString = connString;
            myCon.Open();

            SqlDataAdapter daCategories = new SqlDataAdapter("SELECT * FROM [Categorii] as c " +
                                                            "INNER JOIN [Marimi] as m on (c.IdCategorie = m.IdCategorie) " +
                                                            "INNER JOIN [Table] as t on(c.IdCategorie = t.IdCategorie) "
                                                            , myCon);
            daCategories.Fill(dsCategories, "Adapted Data");

            List<string> categoryList = new List<string>();
            foreach (DataRow dr in dsCategories.Tables["Adapted Data"].Rows)
            {
                String name = dr.ItemArray.GetValue(1).ToString();
                categoryList.Add(name);
            }
            myCon.Close();

            return dsCategories;
        }

        [WebMethod(Description = "Returns a dataset containing category id and name")]
        public DataSet get_category_list()
        {
            DataSet dsCategories;
            dsCategories = new DataSet();

            SqlConnection myCon = new SqlConnection();
            // Change the connection string on other computers
            myCon.ConnectionString = connString;
            myCon.Open();

            SqlDataAdapter daCategories = new SqlDataAdapter("SELECT c.IdCategorie, c.NumeCategorie FROM [Categorii] as c " +
                                                            "INNER JOIN [Marimi] as m on (c.IdCategorie = m.IdCategorie) " +
                                                            "INNER JOIN [Table] as t on(c.IdCategorie = t.IdCategorie)"
                                                            , myCon);
            daCategories.Fill(dsCategories, "Adapted Data");

            myCon.Close();

            return dsCategories;
        }

        [WebMethod(Description = "Returns a dataset products from a category(based on category id)")]
        public DataSet get_products_from_category(int categId)
        {
            DataSet dsCategories;
            dsCategories = new DataSet();

            SqlConnection myCon = new SqlConnection();
            // Change the connection string on other computers
            myCon.ConnectionString = connString;
            myCon.Open();

            SqlDataAdapter daCategories = new SqlDataAdapter("SELECT t.IdPiesa, t.Nume FROM [Categorii] as c " +
                                                            "INNER JOIN [Marimi] as m on (c.IdCategorie = m.IdCategorie) " +
                                                            "INNER JOIN [Table] as t on(c.IdCategorie = t.IdCategorie)" +
                                                            "WHERE c.IdCategorie = " + categId.ToString()
                                                            , myCon);
            daCategories.Fill(dsCategories, "Adapted Data");

            myCon.Close();

            return dsCategories;
        }

        [WebMethod(Description = "Returns a Hello World string")]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
