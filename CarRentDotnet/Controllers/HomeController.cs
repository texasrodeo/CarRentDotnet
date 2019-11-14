using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRentDotnet.Models;

namespace CarRentDotnet.Controllers
{
    public class HomeController : Controller
    {
        AutoParkContext autoParkContext = new AutoParkContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowCars()
        {

            IEnumerable<Car> cars = autoParkContext.Cars;
            ViewBag.Cars = cars;
            ViewBag.Count = ViewBag.Cars.Count;
            return View();
        }

        public ActionResult ShowRequsts()
        {
            ViewBag.Requests = getRequests(autoParkContext.Contracts);
            ViewBag.Count = ViewBag.Requests.Count;
            return View();
        }

        [HttpGet]
        public ActionResult SendRequest(int id)
        {
            ViewBag.CarId = id;
            return View();
        }
        [HttpPost]
        public string SendRequest(Contract contract)
        {
            
                
            // добавляем информацию о покупке в базу данных
            autoParkContext.Contracts.Add(contract);
            // сохраняем в бд все изменения
            autoParkContext.SaveChanges();
            return "Запрос на аренду отправлен";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private IEnumerable<Contract> getRequests(IEnumerable<Contract> contracts)
        {
            List<Contract> result = new List<Contract>();
            foreach(Contract c in contracts)
            {
                if (!c.IsApproved)
                    result.Add(c);
            }
            return result;
        }
    }
}