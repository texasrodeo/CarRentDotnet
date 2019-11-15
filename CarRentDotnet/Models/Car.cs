using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentDotnet.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public string Info { get; set; }
        public bool Avaliability { get; set; }

        public Car(int Id)
        {
            this.Id = Id;
        }

        public Car(string Brand, int Price, string Info)
        {
            this.Brand = Brand;
            this.Price = Price;
            this.Info = Info;
        }

        public Car()
        {

        }

        public override bool Equals(object obj)
        {
            var item = obj as Car;

            if (item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}