using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]//URL
    [ApiController] //AOP
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _productService.GetAll();

           if (result.Success)
           {
               return Ok(result);
           }

           return BadRequest(result) ;

        }

        [HttpGet("getbyid")] //alias (Takma Ad) URL olarak eklenir
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbycategory")] //alias (Takma Ad) URL olarak eklenir
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product) //post
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
