using System;

namespace Mustakim
{
    public class ProductOrderManagement
    {
        public List<Product> product;
        public List<Order> order;
        public ProductOrderManagement()
        {
            try
            {
                product = new List<Product>();
                order = new List<Order>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing ");
            }
          

        }
    }
}