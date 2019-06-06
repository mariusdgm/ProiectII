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
                                                            "INNER JOIN [Parts] as t on(c.IdCategorie = t.IdCategorie) "
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
                                                            "INNER JOIN [Parts] as t on(c.IdCategorie = t.IdCategorie)"
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
                                                            "INNER JOIN [Parts] as t on(c.IdCategorie = t.IdCategorie)" +
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

            SqlDataAdapter daCategories = new SqlDataAdapter("SELECT c.NumeCategorie, m.PropertyName1, m.PropertyName2, m.PropertyName3, " +
                                                             "t.Nume, t.PropertyValue1, t.PropertyValue2, t.PropertyValue3, " +
                                                             "t.Quantity FROM [Categorii] as c " +
                                                            "INNER JOIN [Marimi] as m on (c.IdCategorie = m.IdCategorie) " +
                                                            "INNER JOIN [Parts] as t on(c.IdCategorie = t.IdCategorie)" +
                                                            "WHERE t.IdPiesa = " + productId.ToString()
                                                            , myCon);
            daCategories.Fill(dsCategories, "AdaptedData");
            myCon.Close();

            return dsCategories;
        }

        [WebMethod(Description = "Adds a product to the database")]
        public void add_product(int categoryId, String name, string v1, string v2, string v3, int quantity)
        {
            DataSet dsCategories;
            dsCategories = new DataSet();

            SqlConnection myCon = new SqlConnection();
            // Change the connection string on other computers
            myCon.ConnectionString = connString;
            myCon.Open();

            string querry;
            querry = "INSERT INTO Parts ([IdCategorie], [Nume], " +
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
        public void update_product_details(int productId, int categoryId, String name, string v1, string v2, string v3)
        {
            DataSet dsCategories;
            dsCategories = new DataSet();

            SqlConnection myCon = new SqlConnection();
            // Change the connection string on other computers
            myCon.ConnectionString = connString;
            myCon.Open();

            string querry;
            querry = "UPDATE Parts SET IdCategorie = @categoryId, Nume = @name, " +
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

            int newQuantity = 0;
            int oldQuantity = 0;

            SqlConnection myCon = new SqlConnection();
            // Change the connection string on other computers
            myCon.ConnectionString = connString;
            myCon.Open();

            SqlDataAdapter daCategories = new SqlDataAdapter("SELECT c.NumeCategorie, m.PropertyName1, m.PropertyName2, m.PropertyName3, " +
                                                            "t.Nume, t.PropertyValue1, t.PropertyValue2, t.PropertyValue3, " +
                                                            "t.Quantity FROM [Categorii] as c " +
                                                           "INNER JOIN [Marimi] as m on (c.IdCategorie = m.IdCategorie) " +
                                                           "INNER JOIN [Parts] as t on(c.IdCategorie = t.IdCategorie)" +
                                                           "WHERE t.IdPiesa = " + productId.ToString()
                                                           , myCon);
            daCategories.Fill(dsCategories, "AdaptedData");

            oldQuantity = Convert.ToInt32(dsCategories.Tables["AdaptedData"].Rows[0]["Quantity"]);
            newQuantity = oldQuantity + changedVal;

            string querry;
            querry = "UPDATE Parts SET Quantity = @newQuantity WHERE IdPiesa = @idPiesa";
            SqlCommand command = new SqlCommand(querry, myCon);

            command.Parameters.AddWithValue("@newQuantity", newQuantity);
            command.Parameters.AddWithValue("@idPiesa", productId);

            int res = command.ExecuteNonQuery();
            myCon.Close();

            return;
        }

        [WebMethod(Description = "Delete a product from database")]
        public void delete_product(int productId)
        {
            DataSet dsCategories;
            dsCategories = new DataSet();

            SqlConnection myCon = new SqlConnection();
            // Change the connection string on other computers
            myCon.ConnectionString = connString;
            myCon.Open();

            string querry;
            querry = "DELETE FROM Parts WHERE IdPiesa = @productId";
            SqlCommand command = new SqlCommand(querry, myCon);

            command.Parameters.AddWithValue("@productId", productId);

            int res = command.ExecuteNonQuery();

            myCon.Close();

            return;
        }

        [WebMethod(Description = "Returns 0 if connection is unsuccessfl, 1 if normal konnection is succesful, 2 if succesful and has admin rights")]
        public int check_login(string userName, string passVal)
        {
            DataSet dsData;
            dsData = new DataSet();

            SqlConnection myCon = new SqlConnection();
            // Change the connection string on other computers
            myCon.ConnectionString = connString;
            myCon.Open();

            SqlDataAdapter daData = new SqlDataAdapter("SELECT * FROM [LoginCreds]", myCon);
            daData.Fill(dsData, "AdaptedData");
            myCon.Close();

            foreach (DataRow dr in dsData.Tables["AdaptedData"].Rows)
            {
                if (userName.Trim() == dr["UserName"].ToString().Trim())
                {
                    if (passVal.Trim() == dr["Password"].ToString().Trim())
                    {
                        // Check if user has admin rights
                        if(Convert.ToBoolean(dr["AdminRights"]) == true)
                        {
                            return 2;
                        }
                        else
                        {
                            return 1;
                        }
                    };
                };
            }

            return 0;
        }

        //[WebMethod(Description = "Returns a Hello World string")]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}
    }
}