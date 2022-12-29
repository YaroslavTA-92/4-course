using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;
using System.Drawing;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using System.Threading;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        
        
        public HomeController(MobileContext context)
        {
            db = context;
        }
        public IActionResult Index(string part = "", string sortType = "", string producerName = "", 
            string minPrice = "", string maxPrice = "")
        {
            SearchHelper.LastSearchValue = part;
            FilterViewSortType.SelectedName = sortType;
            FilterViewProducer.SelectedName = producerName;
            FilterViewPrice.MinPrice = minPrice;
            FilterViewPrice.MaxPrice = maxPrice;
            TopNavigationBar.SetActiveByIndex(0);

            var resultList = SearchHelper.FindPhones(db.Phones, part);
            resultList = FilterViewSortType.GetOrderlyList(resultList);
            resultList = FilterViewProducer.GetOrderlyList(resultList);
            resultList = FilterViewPrice.GetOrderlyList(resultList);
            return View(resultList);
        }
        public IActionResult Edit()
        {
            TopNavigationBar.SetActiveByIndex(1);
            return View();
        }
        [HttpGet]
        public IActionResult Buy()
        {
            TopNavigationBar.SetActiveByIndex(-1);
            var phones = db.Phones.ToArray();
            List<Phone> toPassPhones = new List<Phone>();
            foreach (int index in TopNavigationBar.CurrentOrder.PhonesInOrder)
            {
                toPassPhones.Add(phones[index - 1]);
            }
            return View(toPassPhones);
        }

        public IActionResult AddPhone(int id)
        {
            TopNavigationBar.CurrentOrder.PhonesInOrder.Add(id);
            TopNavigationBar.BuyCounter++;
            return RedirectToAction("Index", "Home", new
            {
                part = SearchHelper.LastSearchValue,
                sortType = FilterViewSortType.SelectedName,
                producerName = FilterViewProducer.SelectedName,
                minPrice = FilterViewPrice.MinPrice,
                maxPrice = FilterViewPrice.MaxPrice,
            });
        }
        public IActionResult RemoveFromOrder(int id)
        {
            var arr = TopNavigationBar.CurrentOrder.PhonesInOrder.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == id)
                {
                    TopNavigationBar.CurrentOrder.PhonesInOrder.RemoveAt(i);
                    TopNavigationBar.BuyCounter--;
                    break;
                }
            }
            return Redirect("~/Home/Buy");
        }

        [HttpPost]
        public string Buy(Order order)
        {
            
           

            return "Дякуємо, " + order.User + ", за покупку!";
            //return result;
        }

    }
}