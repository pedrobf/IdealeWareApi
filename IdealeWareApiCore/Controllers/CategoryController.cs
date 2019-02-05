using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdealeWareWebApiCore.Interfaces;
using IdealeWareWebApiCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdealeWareWebApiCore.Controllers
{
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.Select());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.SelectById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Insert(category);
                return Ok(result);
            }

            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Update(category);
                return Ok(category);
            }
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var products = await _productService.SelectByCategoriaId(id);

                if (products.Count() > 0)
                    return Ok();
                    return Ok(await _categoryService.Remove(id));
            }

            else
                return BadRequest();
        }
    }
}