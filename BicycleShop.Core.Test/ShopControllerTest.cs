using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BicycleShop.Core
{
    public class ShopControllerTest
    {
        [Fact]
        public void AddingBikeToShop()
        {
            Bike b1 = new Bike()
            {
                Id = 1,
                Manufacturer = "Kross",
                Name = "version1",
                Price = 143
            };

            ShopController shop = new ShopController()
            {
                Name = "Sklep1"
            };
            // Jeśli dodanie do skelpu się powiedzie funkcja zwróci true
            Assert.True(shop.AddBike(b1));
        }
    }
}
