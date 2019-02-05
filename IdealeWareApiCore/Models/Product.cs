using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdealeWareWebApiCore.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public int Quantity { get; private set; }
        public string Description { get; set; }
        public decimal Price { get; private set; }
        public int IdCategory { get; set; }
        public Category Category { get; set; }

        public Product(string name, int quantity, decimal price, Category category)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
            this.Category = category;
        }

        public Product()
        {

        }

        public int SetQuantity(int quantity)
        {
            this.Quantity = quantity >= 0 ? quantity : 0;
            return this.Quantity;
        }

        public decimal SetPrice(decimal price)
        {
            this.Price = price >= 0 ? price : 0;
            return this.Price;
        }

    }
}
