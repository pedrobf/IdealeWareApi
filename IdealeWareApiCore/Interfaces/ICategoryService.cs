using IdealeWareWebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealeWareWebApiCore.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> Select();
        Task<Category> SelectById(int id);
        Task<Category> Insert(Category category);
        Task<Category> Update(Category category);
        Task<int> Remove(int id);
    }
}
