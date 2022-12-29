using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using MobileStore.Models;

namespace MobileStore
{
    public static class SearchHelper
    {
        public static string LastSearchValue = "";
        public static bool IsNameContains(string name, string part)
        {
            return name.Contains(part);
        }
        public static List<Phone> FindPhones(DbSet<Phone> db, string part)
        {
            if (part != null && part != "")
            {
                List<Phone> result = new List<Phone>();
                var phonesArr = db.ToArray();
                foreach (Phone phone in phonesArr)
                {
                    
                    if (phone.Name.ToLower().Contains(part.ToLower()))
                    {
                        result.Add(phonesArr[phone.Id - 1]);
                    }
                }
                return result;
            }
            else
            {
                return db.ToList(); 
            }
        }
    }
}
