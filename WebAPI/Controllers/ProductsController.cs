using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // HttpPost Attribute

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpPost("productwithimageadd")]
        //public IActionResult ProductWithImageAdd([FromBody] Product product, [FromForm(Name = ("Image"))] IFormFile file, [FromForm] ProductImage? productImage)
        //{
        //    var result = _productService.ProductWithImageAdd(product, file,productImage);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        // HttpGet Attribute

        //Gereksiz start
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //Gereksiz end

        [HttpGet("getallproductdetail")]
        public IActionResult GetAllProductDetail()
        {
            var result = _productService.GetAllProductDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getproductdetail")]
        public IActionResult GetProductDetail(int productId)
        {
            var result = _productService.GetProductDetail(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getproductbycategory")]
        public IActionResult GetProductByCategory(int categoryId,int languageId)
        {
            var result = _productService.GetProductByCategory(categoryId,languageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getproductbyLanguage")]
        public IActionResult GetProductByLanguage(int LanguageId)
        {
            var result = _productService.GetProductByLanguage(LanguageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpGet("getproductdetailbybrand")]
        //public IActionResult GetProductDetailByBrand(int brandId)
        //{
        //    var result = _productService.GetProductDetailByBrand(brandId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpGet("getproductdetailbycolor")]
        //public IActionResult GetProductDetailByColor(int colorId)
        //{
        //    var result = _productService.GetProductDetailByColor(colorId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}
