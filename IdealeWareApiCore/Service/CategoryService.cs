using Dapper;
using IdealeWareWebApiCore.Interfaces;
using IdealeWareWebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealeWareWebApiCore.Data
{
    public class CategoryService : BaseConnection, ICategoryService
    {
        public async Task<Category> Insert(Category category)
        {
            return (await Connection.QueryAsync<Category>(@"INSERT INTO category(name, description) VALUES (@name, @description);
                                                     SELECT idCategory, name, description
                                                     FROM category 
                                                     where idCategory = (SELECT LAST_INSERT_ID() AS idCategory);", category))
                                                     .Single();
        }

        public async Task<int> Remove(int id)
        {
            await Connection.QueryAsync<int>(@"DELETE FROM category WHERE idCategory = @id", new { id });
            return id;
        }

        public async Task<IEnumerable<Category>> Select()
        {
            var result = await Connection.QueryAsync<Category>(@"SELECT idCategory, name, description FROM category;", null);
            return result.ToList();
        }

        public async Task<Category> SelectById(int id)
        {
           return  (await Connection.QueryAsync<Category>(@"SELECT idCategory, name, description FROM category WHERE idCategory = @id;", new { id }))
                                                            .Single();
            
        }

        public async Task<Category> Update(Category category)
        {
            return (await Connection.QueryAsync<Category>(@"UPDATE category SET name = @name, description = @description WHERE idCategory = @idCategory;
                                                                 SELECT idCategory, name, description FROM category WHERE idCategory = @idCategory;", category))
                                                                 .Single();
        }
    }
}
