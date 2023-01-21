using System;


namespace Closit.Models {
    
    public class Outfit
    {
        String UUID;
        String name;
        //Color color;
        allEnums.Color color;
        allEnums.Season season;
        //long createdTime; // YearMonthDay
        String time;
        Cloth[] cloth_list;
    } 
}