using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CarRentDotnet.Models
{
    public class DBInizializer: DropCreateDatabaseAlways<AutoParkContext>
    {
        protected override void Seed(AutoParkContext db)
        {
            db.Cars.Add(new Car { Brand = "Volvo", Info = "Надежная машина 150 л.с", Price = 2200, Avaliability = true });
            db.Cars.Add(new Car { Brand = "Lada", Info = "Бюджетная машина 90 л.с", Price = 1000, Avaliability = true });
            db.Cars.Add(new Car { Brand = "Maybach", Info = "Машина класса люкс 600 л.с", Price = 10000, Avaliability = false });

            base.Seed(db);
        }
    }
}