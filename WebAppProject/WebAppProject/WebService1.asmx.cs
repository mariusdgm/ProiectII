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
        public DataRow get_product_details(int productId)
        {
            DataSet dsCategories;
            dsCategories = new DataSet();

            SqlConnection myCon = new SqlConnection();
            // Change the connection string on other computers
            myCon.ConnectionString = connString;
            myCon.Open();

            SqlDataAdapter daCategories = new SqlDataAdapter("SELECT c.NumeCategorie, m.PropertyName1, m.PropertyName2, m.PropertyName3, " +
                                                             "t.Nume, t.PropertyValue1, t.PropertyValue2, t.PropertyValue3, " +
                                                             "t.Quantity FROM [Categorii] as c " +
                                                            "INNER JOIN [Marimi] as m on (c.IdCategorie = m.IdCategorie) " +
                                                            "INNER JOIN [Table] as t on(c.IdCategorie = t.IdCategorie)" +
                                                            "WHERE t.IdPiesa = " + productId.ToString()
                                                            , myCon);
            daCategories.Fill(dsCategories, "AdaptedData");
            myCon.Close();

            return dsCategories.Tables["AdaptedData"].Rows[0];
        }

        [WebMethod(Description = "Adds a product to the database")]
        public void add_product(int categoryId, String name, float v1, float v2, float v3, int quantity)
        {
            DataSet dsCategories;
            dsCategories = new DataSet();

            SqlConnection myCon = new SqlConnection();
            // Change the connection string on other computers
            myCon.ConnectionString = connString;
            myCon.Open();

            string querry;
            querry = "INSERT INTO Table ([IdCategorie], [Nume], " +
                        "[PropertyValue1], [PropertyValue1], [PropertyValue1], [Quantity]) " +
                        "values(@categoryId, @nume, @propVal1, @propVal2, @propVal3, @quantity)";
            SqlCommand command = new SqlCommand(querry, myCon);

            command.Parameters.AddWithValue("@categoryId", categoryId);
            command.Parameters.AddWithValue("@nume", name);
            command.Parameters.AddWithValue("@propVal1", v1);
            command.Parameters.AddWithValue("@propVal2", v2);
            command.Parameters.AddWithValue("@propVal3", v3);
            command.Parameters.AddWithValue("@quantity", quantity);


            int res = command.ExecuteNonQuery();
            myCon.Close();

            return;
        }

        [WebMethod(Description = "Change product details")]
        public void update_product_details(int productId, int categoryId, String name, float v1, float v2, float v3)
        {
            DataSet dsCategories;
            dsCategories = new DataSet();

            SqlConnection myCon = new SqlConnection();
            // Change the connection string on other computers
            myCon.ConnectionString = connString;
            myCon.Open();

            string querry;
            querry = "UPDATE Table SET IdCategorie = @categoryId, Nume = @name, " +
                "PropertyValue1 = @propVal1, PropertyValue2 = @propVal2, PropertyValue3 = propVal3" +
                " WHERE IdPiesa = @idPiesa";
            SqlCommand command = new SqlCommand(querry, myCon);

            command.Parameters.AddWithValue("@IdCategorie", categoryId);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@propVal1", v1);
            command.Parameters.AddWithValue("@propVal2", v2);
            command.Parameters.AddWithValue("@propVal3", v3);
            command.Parameters.AddWithValue("@idPiesa", productId);

            int res = command.ExecuteNonQuery();

            myCon.Close();

            return;
        }

        [WebMethod(Description = "Change product quantity")]
        public void update_product_quantity(int productId, int changedVal)
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

            return;
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