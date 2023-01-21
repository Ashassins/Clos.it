using System;

namespace Closit.Models
{
    public class Cloth {
        public String UUID;
<<<<<<< HEAD
        public int realID {get;}
        public String listingName {get; set; }
        public String givenName {get; set; }
        public allEnums.Color[] colorList {get; set; }
        public allEnums.Season season {get; set; }
        public DateTime purchaseDate {get; set; }
        public allEnums.Gender gender {get; set; }
        public String brand {get; set; }
        public String tags {get; set; }
        
        // if the color is light then score is high, otherwise high

=======
        public String listingName { get; set; }
        public String givenName { get; set; }
        public allEnums.Color[] colorList { get; set; }
        public allEnums.Season season { get; set; }
        public DateTime purchaseDate { get; set; }
        public allEnums.Gender gender { get; set; }
        public String brand { get; set; }
        public allEnums.Size size { get; set; }
        public String[] tags { get; set; }
        public int wears { get; set;}
>>>>>>> c3d46c4e2fd6f8acfc999172cee0fc01ff52ec10
    }
}