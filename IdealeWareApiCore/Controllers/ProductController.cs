using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdealeWareWebApiCore.Interfaces;
using IdealeWareWebApiCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdealeWareApiCore.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.Select());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productService.SelectById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.Insert(product);
                return Ok(result);
            }

            else
            {
                return Unauthorized();
            }
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.Update(product);
                return Ok(product);
            }

            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.SelectById(id);

            if (result == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(await _productService.Remove(id));
            }
        }
    }
}