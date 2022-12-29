using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MobileStore.Models
{
    public class FilterViewSortType
    {
        public static SelectList SortTypes { get; set; }

        public static string SelectedName { get; set; }
        public static void MakeList(List<string> sortTypes)
        {
            List<string> result = new List<string>();
            SelectedName = sortTypes.First();
            foreach (var item in sortTypes)
            {
                result.Add(item);
            }
            SortTypes = new SelectList(result);
        }
        public static List<Phone> GetOrderlyList(List<Phone> phones)
        {
            List<Phone> result = phones;
            if (SelectedName == "За зр. алфавіту")
            {
                result.Sort((left, right) => string.Compare(left.Name.ToLower(), right.Name.ToLower()));
            }
            else if (SelectedName == "За сп. алфавіту")
            {
                result.Sort((left, right) => string.Compare(left.Name.ToLower(), right.Name.ToLower()));
                result.Reverse();
            }
            else if (SelectedName == "За зр. ціни")
            {
                result.Sort((left, right) => left.Price.CompareTo(right.Price));
            }
            else if (SelectedName == "За сп. ціни")
            {
                result.Sort((left, right) => left.Price.CompareTo(right.Price));
                result.Reverse();
            }
            return result;
        }
    }
}
