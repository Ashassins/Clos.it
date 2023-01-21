using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc; // the one that holds controller
using Microsoft.Data.SqlClient;
using Closit.Models;
using System.Net.Http;

namespace Closit.Controllers {
    public class ClosetController : Controller { 
        String tableName = "CLOSET";
        public void populateBuilder(SqlConnectionStringBuilder builder ) {
            builder.DataSource = "east-blob-8299.7tt.cockroachlabs.cloud"; 
            builder.UserID = "Ashassins";            
            builder.Password = "oyY1nkAuz5-YaJ4GpX6UhQ";     
            builder.InitialCatalog = "defaultdb";
        }

        [HttpGet ("/browse")]
        public Cloth[] ReadItems() {
            try {
                Cloth[] clothes = {};
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                populateBuilder(builder);
                using(SqlConnection connection = new SqlConnection(builder.ConnectionString)) {
                    connection.Open();
                    String sql = "SELECT * FROM " + tableName + " WHERE " + " TRUE;";
                    SqlCommand command = new SqlCommand(sql, connection);
                    using(var reader = command.ExecuteReader()) {
                        while (reader.Read()){ 
                            reader.GetValues(clothes);
                        }
                        reader.Close();
                    }
                    return clothes;
                }
            } catch (SqlException e) {
                throw e; 
            }
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
                }
            }
            catch (SqlException e)
            {
                throw e; //Console.WriteLine(e.ToString());
            }
        }

        [HttpPost ("/browse/{id}/update")]
        public void UpdateItem(int changeRealID, Cloth cloth) {
            try { 
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                populateBuilder(builder);
                using(SqlConnection connection = new SqlConnection(builder.ConnectionString)){
                    connection.Open();
                    String colorString = "";
                    foreach (allEnums.Color color in cloth.colorList)
                    {
                        colorString += color.ToString() + ",";
                    }
                    colorString.Remove(colorString.Length - 1); // What's going on here @Kenyon
                    // building the SQL command // the data set name might change
                    String sql = "UPDATE " + tableName + "@{REAL_ID=" + "'" + changeRealID + "} SET VALUES(" + 
                        changeRealID +", "
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
                    using(adapter.InsertCommand = new SqlCommand(sql, connection)) {
                        adapter.InsertCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e) {
                throw e; //Console.WriteLine(e.ToString());
            }
        }

        [HttpPost ("/browse/{id}/delete")]
        public void deleteItem(int realID) {
            try 
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                populateBuilder(builder);
                using(SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    String sql = "DELETE FROM " + tableName + "WHERE REALID = '" + realID.ToString() + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    using(adapter.InsertCommand = new SqlCommand(sql, connection))
                    {
                        adapter.InsertCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e) 
            {
                throw e;
            }
        }
    }
}