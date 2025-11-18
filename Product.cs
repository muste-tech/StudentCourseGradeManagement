using System;

namespace Mustakim
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }
        public Product(string name, int price, int stockquantity, string category)
        {
            try
            {
                Name = name;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Name cannot be null or empty : {ex.Message}");
                throw;
            }
            try
            {
                Price = price;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Price cannot be null or empty : {ex.Message}");
                throw;
            }
            try
            {
                StockQuantity = stockquantity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Stock quantity cannot be null or empty : {ex.Message}");
                throw;
            }
            try
            {
                Category = category;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Category cannot be null or empty : {ex.Message}");
                throw;
            }
            Id = Generateid();
            
        }
         public  string Generateid()
        {
            try
            {
                string id = $"{new Random().Next(2000, 9999)}";
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Id cannot be null or empty : {ex.Message}");
                throw;
            }

        }

    }

}