using System;
using System.Collections.Generic;

namespace BicycleShop.Core
{
    public class ShopController
    {
        public ShopController()
        {
           BikeList = new List<Bike>();
        }

        public string Name { get; set; }
        private List<Bike> BikeList;

        public bool AddBike(Bike b1)
        {
            var result = true;
            foreach (Bike b in BikeList)
            {
                if(b.Id == b1.Id)
                {
                    result = false;
                }
            }
            if (result)
            {
                BikeList.Add(b1);
            }
            return result;
        }

        public Bike RemoveBike(int bikeid)
        {
            foreach (Bike b in BikeList)
            {
                if (b.Id == bikeid)
                {
                    BikeList.Remove(b);
                    return b;
                }
            }
            return null;
        }

        public Bike BuyBike(Customer c1, int v)
        {
            throw new NotImplementedException();
        }
    }
}