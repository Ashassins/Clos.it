using Microsoft.Data.SqlClient;
using Closit.Models;

public class WebController {
    public void insert(Cloth cloth, String databaseName) {
        try 
        { 
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "<your_server.database.windows.net>"; 
            builder.UserID = "<your_username>";            
            builder.Password = "<your_password>";     
            //builder.InitialCatalog = "<your_database>";
            using(SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                String colorString = "";
                foreach (allEnums.Color color in cloth.colorList)
                {
                    colorString += color.ToString() + ",";
                }
                colorString.Remove(colorString.Length - 1);

                // building the SQL command // the data set name might change
                String sql = "INSERT INTO " + databaseName + " VALUES(" + "'" + cloth.realID + "', "
                    + "'" + cloth.listingName + "', " 
                    + "'" + cloth.givenName + "', " 
                    + "'" + colorString + "', "  
                    + "'" + cloth.season.ToString() + "', "
                    + "'" + cloth.purchaseDate.ToLongDateString() + "', "
                    + "'" + cloth.gender.ToString() + "', "
                    + "'" + cloth.brand + "', "
                    + "'" + cloth.tags + "');";
                SqlDataAdapter adapter = new SqlDataAdapter();
                using(adapter.InsertCommand = new SqlCommand(sql, connection))
                {
                    using(adapter.InsertCommand.ExecuteNonQuery()) {
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public String delete(int realID, String databaseName) {
        try 
        { 
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "<your_server.database.windows.net>"; 
            builder.UserID = "<your_username>";            
            builder.Password = "<your_password>";     
            //builder.InitialCatalog = "<your_database>";
            using(SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                // building the SQL command
                
                String sql = "DELETE FROM " + databaseName + "WHERE REALID = '" + realID.ToString() + "'";
                SqlDataAdapter adapter = new SqlDataAdapter();
                using(adapter.InsertCommand = new SqlCommand(sql, connection))
                {
                    using(adapter.InsertCommand.ExecuteNonQuery()) {
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}