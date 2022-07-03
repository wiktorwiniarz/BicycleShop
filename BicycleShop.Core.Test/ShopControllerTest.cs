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
            Assert.False(shop.AddBike(b1));
        }
        [Fact]
        public void RemoveBikeFromShop()
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

            shop.AddBike(b1);
            // po usunięciu zwracany jest rower który został usunięty
            Assert.Equal(b1, shop.RemoveBike(1));
            // Nie można usunąć dwa razy tego samego roweru
            Assert.Equal(null, shop.RemoveBike(1));
            // nie można usunąć roweru którego nie ma
            Assert.Equal(null, shop.RemoveBike(2));

            // Po usunięciu roweru możliwe jest ponowne jego dodanie
            Assert.True(shop.AddBike(b1));
        }
    }

}
