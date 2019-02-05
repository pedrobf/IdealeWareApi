using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdealeWareWebApiCore.Models
{
    public class Category
    {
        public int IdCategory { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public Category()
        {
        }

        public Category(string name)
        {
            this.Name = name;
        }

    }
}
