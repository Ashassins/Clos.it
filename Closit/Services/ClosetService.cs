// using Closit.Models;
// using Closit.Controllers;

// namespace Closit.Services {
//     public static class ClosetService {
//         static List<Cloth> Closet { get; }
//         static int nextId = 9;
//         static ClosetService() {
//             Closet = new List<CatalogService> { 
//                 new Cloth {realID = 1, listingName ="ULTRA HIGH-RISE BLACK SUPER SKINNY JEANS", givenName = NULL, colorList = {allEnums.Color.Black}, season = allEnums.Season.Fall, purchaseDate = DateTime.Today, gender = allEnums.Gender.Female, brand = "Hollister", tags = NULL, clothingType = allEnums.ClothingType.Pants, itemType = allEnums.ItemType.Clothing, wears = 8},
//             };
//         }
//         // public static List<Cloth> GetAll() => Closet;
//         // public static Cloth? GetCloth() {}

//         public static void Add(Cloth cloth) {
//             cloth.realID = nextId++;
//             Closet.Add(cloth);
//         }

//         // public static void Update(Cloth cloth) {
            
//         // }
//         // public static void Delete(Cloth cloth) {
            
//         // }
//     }
// }