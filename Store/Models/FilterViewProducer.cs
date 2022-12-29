

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MobileStore.Models
{
    public static class FilterViewProducer
    {
        public static SelectList Producers { get; set; }

        public static string SelectedName { get; set; }
        public static void MakeList(List<Phone> phones)
        {
            List<string> result = new List<string>();
            result.Add("Всі");
            SelectedName = "Всі";
            bool is_present = false;
            foreach (var item in phones)
            {
                foreach (var prod in result)
                {
                    if (prod == item.Company)
                    {
                        is_present = true;
                        break;
                    }
                }
                if (!is_present)
                { 
                    result.Add(item.Company);
                }
            }
            Producers = new SelectList(result);
        }

        public static List<Phone> GetOrderlyList(List<Phone> phones)
        {
            if (SelectedName == null || SelectedName == "Всі" || SelectedName == "")
            {
                return phones;
            }
            else
            {
                List<Phone> result = new List<Phone>();
                foreach (var item in phones)
                {
                    if (item.Company == SelectedName)
                    {
                        result.Add(item);
                    }
                }
                return result;
            }
        }
    }
}
