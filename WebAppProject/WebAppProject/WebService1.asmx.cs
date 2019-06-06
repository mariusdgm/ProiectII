using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

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
        private String connString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ProjectDatabase.mdf;Integrated Security=True;";

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
            daCategories.Fill(dsCategories, "AdaptedData");

            List<string> categoryList = new List<string>();
            foreach (DataRow dr in dsCategories.Tables["AdaptedData"].Rows)
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

            SqlDataAdapter daCategories = new SqlDataAdapter("SELECT DISTINCT c.IdCategorie, c.NumeCategorie FROM [Categorii] as c " +
                                                            "INNER JOIN [Marimi] as m on (c.IdCategorie = m.IdCategorie) " +
                                                            "INNER JOIN [Table] as t on(c.IdCategorie = t.IdCategorie)"
                                                            , myCon);
            daCategories.Fill(dsCategories, "AdaptedData");
            myCon.Close();

            return dsCategories;
        }

        [WebMethod(Description = "Returns a dataset containing products from a category (based on category id)")]
        public DataSet get_products_from_category(int categoryId)
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
                                                            "WHERE c.IdCategorie = " + categoryId.ToString()
                                                            , myCon);
            daCategories.Fill(dsCategories, "AdaptedData");
            myCon.Close();

            return dsCategories;
        }

        [WebMethod(Description = "Returns a dataset containing the details of a product (based on product id)")]
        public DataSet get_product_details(int productId)
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
                                                            "WHERE c.IdCategorie = " + productId.ToString()
                                                            , myCon);
            daCategories.Fill(dsCategories, "AdaptedData");
            myCon.Close();

            return dsCategories;
        }

        [WebMethod(Description = "Adds a product to the database")]
        public DataSet add_product(int categoryId, String name, float v1, float v2, float v3)
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
                                                            "WHERE c.IdCategorie = " + categoryId.ToString()
                                                            , myCon);
            daCategories.Fill(dsCategories, "AdaptedData");
            myCon.Close();

            return dsCategories;
        }

        [WebMethod(Description = "Change product details")]
        public DataSet update_product_details(int categoryId, String name, float v1, float v2, float v3)
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
                                                            "WHERE c.IdCategorie = " + categoryId.ToString()
                                                            , myCon);
            daCategories.Fill(dsCategories, "AdaptedData");
            myCon.Close();

            return dsCategories;
        }

        [WebMethod(Description = "Delete a product from database")]
        public DataSet delete_product(int productId)
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
                                                            "WHERE c.IdCategorie = " + productId.ToString()
                                                            , myCon);
            daCategories.Fill(dsCategories, "AdaptedData");
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