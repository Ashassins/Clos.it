using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc; // the one that holds controller
using Microsoft.Data.SqlClient;
using Closit.Models;
using System.Net.Http;
// using System.IDisposable;

namespace Closit.Controllers {
    public class ClosetController : Controller {
        // [HttpGet ("/browse")]
        // public async Task<IActionResult> ReadItems() {
        // }
        public void populateBuilder(SqlConnectionStringBuilder builder ) {
            builder.DataSource = "east-blob-8299.7tt.cockroachlabs.cloud"; 
            builder.UserID = "Ashassins";            
            builder.Password = "oyY1nkAuz5-YaJ4GpX6UhQ";     
            builder.InitialCatalog = "defaultdb";
        }

        [HttpPost ("/browse/insert")]
        public void InsertItem (Cloth cloth) {
            // Run SQL Procedure to save.
            try 
            { 
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                populateBuilder(builder);
                using(SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    String tableName = "Closet";
                    String colorString = "";
                    foreach (allEnums.Color color in cloth.colorList)
                    {
                        colorString += color.ToString() + ",";
                    }
                    colorString.Remove(colorString.Length - 1); // What's going on here @Kenyon
                    // building the SQL command // the data set name might change
                    String sql = "INSERT INTO " + tableName + " VALUES(" + "'" + cloth.realID + "', "
                        + "'" + cloth.listingName + "', " 
                        + "'" + cloth.givenName + "', " 
                        + "'" + colorString + "', "  
                        + "'" + cloth.season.ToString() + "', "
                        + "'" + cloth.purchaseDate.ToLongDateString() + "', "
                        + "'" + cloth.gender.ToString() + "', "
                        + "'" + cloth.brand + "', "
                        + "'" + cloth.tags + "' "
                        + "'" + cloth.wears + ");";
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    using(adapter.InsertCommand = new SqlCommand(sql, connection))
                    {
                        adapter.InsertCommand.ExecuteNonQuery();
                    }
                    // return Task.FromResult(cloth);
                    //return ret;
                }
            }
            catch (SqlException e)
            {
                throw e; //Console.WriteLine(e.ToString());
            }
        }

        // [HttpPost ("/browse/{id}/update")]
        // public async Task<IActionResult> UpdateItem(Cloth cloth) {

        // }

        // [HttpPost ("/browse/{id}/delete")]
        // public async Task<IActionResult> DeleteItem(Cloth cloth) {
        //     // int deleteId = cloth.getUUID();
        //     // Run SQL Procedure to delete
        // }
    }
}