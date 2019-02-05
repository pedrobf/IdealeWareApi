using IdealeWareWebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealeWareWebApiCore.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Select();
        Task<Product> SelectById(int id);
        Task<IEnumerable<Product>> SelectByCategoriaId(int id);
        Task<Product> Insert(Product product);
        Task<Product> Update(Product product);
        Task<int> Remove(int id);
    }
}
