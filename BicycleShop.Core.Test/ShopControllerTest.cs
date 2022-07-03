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


        [Fact]
        public void BikeBuyingTest()
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


            Customer c1 = new Customer()
            {
                Name = "Jan",
                LastName = "Kowalski",
                Email = "Jkowalski@gmail.com",
                PhoneNumber = 516663843
            };


            // Kupuje rower który jest w sklepie
            Assert.Equal(b1,shop.BuyBike(c1, 1));
            // Kupuje rower którego nie ma w sklepie
            Assert.Null(shop.BuyBike(c1, 2));

            // Kupuje rower który został sprzedany wcześniej
            Assert.Null(shop.BuyBike(c1, 1));

        }
        [Fact]
        public void ResignFromBuyiong()
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


            Customer c1 = new Customer()
            {
                Name = "Jan",
                LastName = "Kowalski",
                Email = "Jkowalski@gmail.com",
                PhoneNumber = 516663843
            };
            shop.BuyBike(c1, 1);

            // po zwrocie możliwe powinno być ponowne kupno tego samego roweru
            Assert.Equal(shop.BuyBike(c1,1),shop.ReturnBike(b1));
            // po zwrocie powinno możliwe być usunięcie roweru
            Assert.Equal(shop.RemoveBike(1), shop.ReturnBike(b1));
        }
    }

}
