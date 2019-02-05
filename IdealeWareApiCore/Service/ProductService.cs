using Dapper;
using IdealeWareWebApiCore.Interfaces;
using IdealeWareWebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealeWareWebApiCore.Data
{
    public class ProductService : BaseConnection, IProductService
    {
        public async Task<Product> Insert(Product product)
        {
            var result = await Connection.QueryAsync<Product, Category, Product>
                (@"INSERT INTO product(idCategory ,name, description, quantity, price)
                VALUES (@idCategory ,@name, @description, @quantity, @price);
                SELECT p.idProduct, p.name, p.description, p.quantity, p.price, c.idCategory, c.name, c.description FROM product p
                INNER JOIN category c ON p.idCategory = c.idCategory WHERE p.idProduct = (SELECT LAST_INSERT_ID() AS idProduct);", (prod, category) =>
            {
                prod.Category = category;
                return prod;
            }, product, splitOn: "idCategory");
            return result.SingleOrDefault();
        }

        public async Task<int> Remove(int id)
        {
            await Connection.QueryAsync<Product>(@"DELETE FROM product WHERE idProduct = @id", new { id });
            return id;
        }

        public async Task<IEnumerable<Product>> Select()
        {
            var result = await Connection.QueryAsync<Product, Category, Product>
                (@"SELECT p.idProduct, p.name, p.description, p.quantity, p.price, c.idCategory, c.name, c.description FROM product p
                INNER JOIN category c ON p.idCategory = c.idCategory;", (prod, category) =>
            {
                prod.Category = category;
                return prod;
            }, null, splitOn: "idCategory");
            return result.ToList();
        }

        public async Task<IEnumerable<Product>> SelectByCategoriaId(int id)
        {
            var result = await Connection.QueryAsync<Product, Category, Product>
                (@"select p.idProduto, p.name, p.description, p.quantity, p.price, 
                c.idCategoria,  c.name, c.description from product p
                inner join category c on p.idCategoria = c.idCategoria where c.idCategoria = @id;"
                , (prod, category) =>
                {
                    prod.Category = category;
                    return prod;
                }, new { id }, splitOn: "idCategory");
            return result.ToList();
        }

        public async Task<Product> SelectById(int id)
        {
            var result = await Connection.QueryAsync<Product, Category, Product>
                (@"SELECT p.idProduct, p.name, p.description, p.quantity, p.price, c.idCategory, c.name, c.description FROM product p
                INNER JOIN category c ON p.idCategory = c.idCategory;", (prod, category) =>
                {
                    prod.Category = category;
                    return prod;
                }, new { id }, splitOn: "idCategory");
            return result.SingleOrDefault();
        }

        public async Task<Product> Update(Product product)
        {
            var result = await Connection.QueryAsync<Product, Category, Product>
                (@"UPDATE product SET idCategory = @idCategory, name = @name, description = @description, quantity = @quantity, price = @price WHERE idProduct = @idProduct;
                SELECT p.idProduct, p.name, p.description, p.quantity, p.price, c.idCategory, c.name, c.description FROM product p
                INNER JOIN category c ON p.idCategory = c.idCategory where p.idProduct = @idProduct;", (prod, category) =>
            {
                prod.Category = category;
                return prod;
            }, product, splitOn: "idCategory");
            return result.SingleOrDefault();
        }
    }
}
