// using Closit.Models;
// public class CloestRepository 
// {
//     public void populateBuilder(SqlConnectionStringBuilder builder ) {
//             builder.DataSource = "east-blob-8299.7tt.cockroachlabs.cloud"; 
//             builder.UserID = "Ashassins";            
//             builder.Password = "oyY1nkAuz5-YaJ4GpX6UhQ";     
//             builder.InitialCatalog = "defaultdb";
//     }
//     public void extractOneCloth(int realID) {
//         try
//         {   
//             SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
//             populateBuilder(builder);
//             using(SqlConnection connection = new SqlConnection(builder.ConnectionString)) {
//                 connection.Open();
//                 String catalogName = "Catalog";
//                 String sql = "SELECT * FROM " + catalogName 
//                                 + " WHERE real_id = " + realID.ToString();
//                 SqlCommand command = new SqlCommand(sql, connection);
//                 Cloth[] tempInput = {};
//                 using (var reader = command.ExecuteReader()) {
//                     reader.Read();
//                     reader.GetValues(tempInput);
//                     reader.Close();
//                 }
//                 // reading from catalog ends here //

//                 Cloth selected_temp = tempInput[0];
//                 String outPutTable = "closet";
//                 String colorString = "";
//                 String givenName = "";
//                 int wears = 0;
//                     foreach (allEnums.Color color in selected_temp.colorList)
//                     {
//                         colorString += color.ToString() + ",";
//                     }
//                     colorString.Remove(colorString.Length - 1);
//                 String newCommand = "INSERT INTO " + outPutTable + " VALUES(" + "'" + selected_temp.realID + "', "
//                         + "'" + selected_temp.listingName + "', " 
//                         + "'" + givenName + "', " 
//                         + "'" + colorString + "', "  
//                         + "'" + selected_temp.season.ToString() + "', "
//                         + "'" + DateTime.Now.ToString("yyyy-MM-dd") + "', "
//                         + "'" + selected_temp.gender.ToString() + "', "
//                         + "'" + selected_temp.brand + "', "
//                         + "'" + selected_temp.tags + "' "
//                         + "'" + wears.ToString() + ");";
//                  SqlDataAdapter adapter = new SqlDataAdapter();
//                     using(adapter.InsertCommand = new SqlCommand(sql, connection))
//                     {
//                         adapter.InsertCommand.ExecuteNonQuery();
//                     }
//             }
//         }
//         catch (SqlException e) {
//             throw e;
//         }
//     }

//     public Cloth selectFromCatalog(int real_id) {
//         try
//         {   
//             SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
//             populateBuilder(builder);
//             using(SqlConnection connection = new SqlConnection(builder.ConnectionString)) {
//                 connection.Open();
//                 String catalogName = "Catalog";
//                 String sql = "SELECT * FROM " + catalogName 
//                                 + " WHERE real_id = " + realID.ToString();
//                 SqlCommand command = new SqlCommand(sql, connection);
//                 Cloth[] tempInput = {};
//                 using (var reader = command.ExecuteReader()) {
//                     reader.Read();
//                     reader.GetValues(tempInput);
//                     reader.Close();
//                 }
//                 return tempInput[0];
//             }
//         }
//         catch (SqlException e) {
//             throw e;
//         }    
//     }


//     /*
//     public void SendToFront(Cloth cloth) {
//         System.Web.Serialization.JavaScriptSerializer oSerializer = 
//             new System.Web.Script.Serialization.JavaScriptSerializer();
//         String sJson = oSerializer.Serialize(cloth);
//     }
//     */

// }