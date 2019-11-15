using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CarRentDotnet.Models
{
    public class AutoParkContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Contract> Contracts { get; set; }
       // public DbSet<Contract> Requests { get; set; }

        public void removeCarById(int id)
        {
            Car c = Cars
                .Where(o => o.Id == id)
                   .FirstOrDefault();
            Cars.Remove(c);
        }

        public void AlterCar(Car car)
        {
            Car c = Cars
                .Where(o => o.Id == car.Id)
                   .FirstOrDefault();
            c.Info = car.Info;
            c.Price = car.Price;
            c.Brand = car.Brand;
        }

        public Car GetCarById(int id)
        {
            return  Cars
                .Where(o => o.Id == id)
                   .FirstOrDefault();
        }
    }
}