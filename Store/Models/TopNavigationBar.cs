using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public static class TopNavigationBar
    {
        public static string[] m_ActiveValues { get; set; }

        public static int BuyCounter { get; set; }

        public static Order CurrentOrder { get; set; }
        public static void SetActiveByIndex(int index)
        {
            for (int i = 0; i < m_ActiveValues.Length; i++)
            {
                m_ActiveValues[i] = "nav-item";
            }
            if (index != -1)
            {
                m_ActiveValues[index] = "nav-item active";
            }
        }
    }

}
