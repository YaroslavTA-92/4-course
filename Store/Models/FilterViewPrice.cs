using System;
using System.Collections.Generic;

namespace MobileStore.Models
{
    public static class FilterViewPrice
    {
        public static string MinPrice { get; set; }
        public static string MaxPrice { get; set; }
        public static List<Phone> GetOrderlyList(List<Phone> phones)
        {
            if (MinPrice == null && MaxPrice == null)
            {
                return phones;
            }
            int minPrice = 0;
            int maxPrice = 0;
            try
            {
                minPrice = Convert.ToInt32(MinPrice);
                maxPrice = Convert.ToInt32(MaxPrice);
            }
            catch
            {
                return phones;
            }
            List<Phone> result = new List<Phone>();
            foreach (var item in phones)
            {
                if (MinPrice == null && maxPrice >= item.Price)
                {
                    result.Add(item);
                }
                else if (MaxPrice == null && minPrice <= item.Price)
                {
                    result.Add(item);
                }
                else if (minPrice <= item.Price && maxPrice >= item.Price)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
