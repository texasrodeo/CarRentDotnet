﻿using System;
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
            ViewBag.Count = cars.Count();
            ViewBag.Cars = cars;
             
            return View();
        }

        public ActionResult ShowRequsts()
        {
            ViewBag.Requests = getRequests(autoParkContext.Contracts);
            ViewBag.Count = ViewBag.Requests.Count;
            return View();
        }
        public ActionResult ShowApprovedContracts()
        {
            ViewBag.Requests = getApprovedContracts(autoParkContext.Contracts);
            ViewBag.Count = ViewBag.Requests.Count;
            return View();
        }
        public ActionResult ShowAllContracts()
        {
            ViewBag.Requests = autoParkContext.Contracts;
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
        public ActionResult SendRequest(Contract contract)
        {
            
                
            // добавляем информацию о покупке в базу данных
            autoParkContext.Contracts.Add(contract);
            // сохраняем в бд все изменения
            autoParkContext.SaveChanges();
            return View("Success");
        }


        [HttpGet]
        public ActionResult AddCar()
        {
            return View();
        }


        [HttpPost]
        public RedirectResult AddCar(Car car)
        {
            autoParkContext.Cars.Add(car);
            autoParkContext.SaveChanges();
            return Redirect("/Home/ShowCars");
        }

        [HttpGet]
        public ActionResult AlterCar(int id)
        {
            ViewBag.Car = autoParkContext.GetCarById(id);
            return View();
        } 

        [HttpPost]
        public RedirectResult AlterCar(Car car)
        {
            autoParkContext.AlterCar(car);
            autoParkContext.SaveChanges();
            return Redirect("/Home/ShowCars");
        }


        [HttpGet]
        public RedirectResult DeleteCar(int id)
        {
            autoParkContext.removeCarById(id);
            autoParkContext.SaveChanges();
            return Redirect("/Home/ShowCars");
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
        private IEnumerable<Contract> getApprovedContracts(IEnumerable<Contract> contracts)
        {
            List<Contract> result = new List<Contract>();
            foreach (Contract c in contracts)
            {
                if (c.IsApproved)
                    result.Add(c);
            }
            return result;
        }
       
    }
}