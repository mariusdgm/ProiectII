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

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public DataSet get_dataset()
        {
            DataSet dsCategories;
            dsCategories = new DataSet();

            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=App_Data\Database1.mdf;Integrated Security=True";
            myCon.Open();

            SqlDataAdapter daCategories = new SqlDataAdapter("SELECT * FROM CATEGORIES_TABLE", myCon);
            daCategories.Fill(dsCategories, "Cars");

            List<string> categoryList = new List<string>();
            foreach (DataRow dr in dsCategories.Tables["Cars"].Rows)
            {
                String name = dr.ItemArray.GetValue(1).ToString();
                categoryList.Add(name);
            }
            myCon.Close();

            return dsCategories;
        }
    }
}
