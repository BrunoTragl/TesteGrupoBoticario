using AutoMapper;
using BrunoTragl.TesteGrupoBoticario.Domain.Model;
using BrunoTragl.TesteGrupoBoticario.Domain.Services.Interfaces;
using BrunoTragl.TesteGrupoBoticario.Web.WebApi.Enumerable;
using BrunoTragl.TesteGrupoBoticario.Web.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace BrunoTragl.TesteGrupoBoticario.Web.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : MainController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(ILogger<MainController> logger, 
                                 IProductService productService,
                                 IMapper mapper)
            : base(logger)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("{sku:long}")]
        public IActionResult Get(long sku)
        {
            try
            {
                var produto = _productService.Get(sku);
                if (produto == null)
                    return NotFound();

                ProductModel model = _mapper.Map<ProductModel>(produto);

                model.Inventory.CalculateQuantity();
                model.IsMarketableProduct();
                
                return OkResponse(model);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse(ex);
            }
        }

        [HttpPost]
        public IActionResult Create(ProductModel productModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_productService.Any(productModel.Sku))
                        throw new Exception($"The resource already exists.");

                    _productService.Add(_mapper.Map<Product>(productModel));
                    return Created($"{Request.Host}{Request.Path}/{productModel.Sku}", productModel);
                }

                return BadRequestResponse(ModelState.Values.SelectMany(m => m.Errors),
                                          productModel,
                                          Resources.Products.ToString());

            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse(ex);
            }
        }

        [HttpPut("{sku:long}")]
        public IActionResult Update(long sku, ProductModel productModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_productService.Any(sku))
                        return NotFound();

                    _productService.Update(_mapper.Map<Product>(productModel));
                    return NoContent();
                }

                return BadRequestResponse(ModelState.Values.SelectMany(m => m.Errors),
                                          productModel,
                                          Resources.Products.ToString());

            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse(ex);
            }
        }

        [HttpDelete("{sku:long}")]
        public IActionResult Remove(long sku)
        {
            try
            {
                if (!_productService.Any(sku))
                    return NotFound();

                _productService.Remove(sku);
                return NoContent();
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse(ex);
            }
        }
    }
}
