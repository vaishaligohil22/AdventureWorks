using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AdventureWorks.Models;
using AdventureWorks.DBModels;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly AdventureWorks2017Context _context;
        private readonly IMapper _mapper;
        public ILogger<ProductController> _logger { get; }

        public ProductController(AdventureWorks2017Context context, IMapper mapper, ILogger<ProductController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }


        /// GET /v1/product
        /// <summary>
        /// Get all products
        /// </summary>
        /// <remarks>
        /// Return all available products in an inventary
        /// </remarks>
        [HttpGet]
        [Route("/v1/product")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetProduct()
        {
            List<Models.Product> product = new List<Models.Product>();

            _logger.LogInformation("Here is info message from the controller.");
            _logger.LogDebug("Here is debug message from the controller.");

            try
            {
                product = (from p in _context.Product
                           from pm in _context.ProductModel.Where(pm => pm.ProductModelId == p.ProductModelId).DefaultIfEmpty()
                           from ps in _context.ProductSubcategory.Where(ps => ps.ProductSubcategoryId == p.ProductSubcategoryId).DefaultIfEmpty()
                           from pc in _context.ProductCategory.Where(pc => pc.ProductCategoryId == ps.ProductCategoryId).DefaultIfEmpty()
                           from ppp in _context.ProductProductPhoto.Where(ppp => ppp.ProductId == p.ProductId).DefaultIfEmpty()
                           from pp in _context.ProductPhoto.Where(pp => pp.ProductPhotoId == ppp.ProductPhotoId).DefaultIfEmpty()
                           orderby p.ProductId
                           select new Models.Product
                           {
                               ProductId = p.ProductId,
                               Name = p.Name,
                               ProductNumber = p.ProductNumber,
                               Color = p.Color,
                               StandardCost = (double)p.StandardCost,
                               ListPrice = (double)p.ListPrice,
                               Size = p.Size,
                               Weight = p.Weight != null ? (decimal)p.Weight : 0,
                               ProductLine = p.ProductLine,
                               Class = p.Class,
                               Style = p.Style,
                               Model = (pm != null) ? _mapper.Map<Models.ProductModel>(pm) : null,
                               SubCategory = (ps != null) ? _mapper.Map<Models.ProductSubCategory>(new Models.ProductSubCategory
                               {
                                   Name = ps.Name,
                                   Category = (pc != null) ? _mapper.Map<Models.ProductCategory>(pc) : null,
                                   ProductSubCategoryID = ps.ProductSubcategoryId
                               }) : null,
                               Photo = (pp != null) ? _mapper.Map<Models.ProductPhoto>(pp) : null,
                               Review = _mapper.Map<List<Models.ProductReview>>(_context.ProductReview.Where(x => x.ProductId == p.ProductId).ToList())
                           }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error at GetProduct() Message() " + ex.Message + " Message() End StackTrace()" + ex.StackTrace + " StackTrace() End ");
            }

            return new ObjectResult(product.Take(5));
        }

        /// GET /v1/product/{productId}
        /// <summary>
        /// Find product by ID
        /// </summary>
        /// <remarks>
        /// Returns a single product based on the productID
        /// </remarks>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/v1/product/{productId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetProduct([FromRoute][Required]int productId)
        {
            Models.Product product = (from p in _context.Product
                                      from pm in _context.ProductModel.Where(pm => pm.ProductModelId == p.ProductModelId).DefaultIfEmpty()
                                      from ps in _context.ProductSubcategory.Where(ps => ps.ProductSubcategoryId == p.ProductSubcategoryId).DefaultIfEmpty()
                                      from pc in _context.ProductCategory.Where(pc => pc.ProductCategoryId == ps.ProductCategoryId).DefaultIfEmpty()
                                      from ppp in _context.ProductProductPhoto.Where(ppp => ppp.ProductId == p.ProductId).DefaultIfEmpty()
                                      from pp in _context.ProductPhoto.Where(pp => pp.ProductPhotoId == ppp.ProductPhotoId).DefaultIfEmpty()
                                      where p.ProductId == productId
                                      select new Models.Product
                                      {
                                          ProductId = p.ProductId,
                                          Name = p.Name,
                                          ProductNumber = p.ProductNumber,
                                          Color = p.Color,
                                          StandardCost = (double)p.StandardCost,
                                          ListPrice = (double)p.ListPrice,
                                          Size = p.Size,
                                          Weight = p.Weight != null ? (decimal)p.Weight : 0,
                                          ProductLine = p.ProductLine,
                                          Class = p.Class,
                                          Style = p.Style,
                                          Model = (pm != null) ? _mapper.Map<Models.ProductModel>(pm) : null,
                                          SubCategory = (ps != null) ? _mapper.Map<Models.ProductSubCategory>(new Models.ProductSubCategory
                                          {
                                              Name = ps.Name,
                                              Category = (pc != null) ? _mapper.Map<Models.ProductCategory>(pc) : null,
                                              ProductSubCategoryID = ps.ProductSubcategoryId
                                          }) : null,
                                          Photo = (pp != null) ? _mapper.Map<Models.ProductPhoto>(pp) : null,
                                          Review = _mapper.Map<List<Models.ProductReview>>(_context.ProductReview.Where(x => x.ProductId == p.ProductId).ToList())
                                      }).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return new ObjectResult(product);
        }

        /// <summary>
        /// Filter products
        /// </summary>
        /// <remarks>
        /// Returns product based on search criteria
        /// </remarks>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="category"></param>
        /// <param name="subCategory"></param>
        /// <param name="model"></param>
        /// <param name="size"></param>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        [HttpGet]
        [Route("/v1/product/search")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult FindProduct([FromQuery]string name, [FromQuery]string color, [FromQuery]string category, [FromQuery]string subCategory, [FromQuery]string model, [FromQuery]int? size, [FromQuery]int? minPrice, [FromQuery][Range(1, 99999)]int? maxPrice)
        {
            var product = (from p in _context.Product
                           from pm in _context.ProductModel.Where(pm => pm.ProductModelId == p.ProductModelId).DefaultIfEmpty()
                           from ps in _context.ProductSubcategory.Where(ps => ps.ProductSubcategoryId == p.ProductSubcategoryId).DefaultIfEmpty()
                           from pc in _context.ProductCategory.Where(pc => pc.ProductCategoryId == ps.ProductCategoryId).DefaultIfEmpty()
                           from ppp in _context.ProductProductPhoto.Where(ppp => ppp.ProductId == p.ProductId).DefaultIfEmpty()
                           from pp in _context.ProductPhoto.Where(pp => pp.ProductPhotoId == ppp.ProductPhotoId).DefaultIfEmpty()
                           orderby p.ProductId
                           select new Models.Product
                           {
                               ProductId = p.ProductId,
                               Name = p.Name,
                               ProductNumber = p.ProductNumber,
                               Color = p.Color,
                               StandardCost = (double)p.StandardCost,
                               ListPrice = (double)p.ListPrice,
                               Size = p.Size,
                               Weight = p.Weight != null ? (decimal)p.Weight : 0,
                               ProductLine = p.ProductLine,
                               Class = p.Class,
                               Style = p.Style,
                               Model = (pm != null) ? _mapper.Map<Models.ProductModel>(pm) : null,
                               SubCategory = (ps != null) ? _mapper.Map<Models.ProductSubCategory>(new Models.ProductSubCategory
                               {
                                   Name = ps.Name,
                                   Category = (pc != null) ? _mapper.Map<Models.ProductCategory>(pc) : null,
                                   ProductSubCategoryID = ps.ProductSubcategoryId
                               }) : null,
                               Photo = (pp != null) ? _mapper.Map<Models.ProductPhoto>(pp) : null,
                               Review = _mapper.Map<List<Models.ProductReview>>(_context.ProductReview.Where(x => x.ProductId == p.ProductId).ToList())
                           }).ToList();

            if (name != null && name != string.Empty && product != null)
                product = product.Where(u => u.Name.Contains(name)).ToList();

            if (color != null && product != null)
                product = product.Where(d => d.Color != null && d.Color == color).ToList();

            if (model != null && product != null)
                product = product.Where(p => p.Model != null && p.Model.Name == model).ToList();

            if (category != null && product != null)
                product = product.Where(p => p.SubCategory.Category != null && p.SubCategory.Category.Name == category).ToList();

            if (subCategory != null && product != null)
                product = product.Where(p => p.SubCategory != null && p.SubCategory.Name == subCategory).ToList();

            if (size > 0 && product != null)
                product = product.Where(u => u.Size != null && u.Size == size.ToString()).ToList();

            if (minPrice != null && product != null)
                product = product.Where(d => (double)d.ListPrice >= minPrice).ToList();

            if (maxPrice != null && product != null)
                product = product.Where(d => (double)d.ListPrice <= maxPrice).ToList();

            return new ObjectResult(product.Take(5));
        }

        /// GET /v1/product/category
        /// <summary>
        /// Get product category
        /// </summary>
        /// <remarks>
        /// Returns product based on search criteria
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("/v1/product/category")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetProductCategory()
        {
            var category = (from p in _context.ProductCategory
                            select new
                            {
                                ProductCategoryID = p.ProductCategoryId,
                                Name = p.Name,
                                SubCategory = _context.ProductSubcategory.Where(x => x.ProductCategoryId == p.ProductCategoryId).Select(q => new { q.ProductSubcategoryId, q.Name }).ToList()
                            }).ToList();

            if (category == null)
            {
                return NotFound();
            }

            return new ObjectResult(category);
        }
    }
}
