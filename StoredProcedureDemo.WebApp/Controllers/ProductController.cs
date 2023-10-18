using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoredProcedureDemo.WebApp.Data;

namespace StoredProcedureDemo.WebApp.Controllers
{
    
    public class ProductController : Controller
    {
        
        private readonly ProductContext _productContext;

        public ProductController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public IActionResult List()
        {
            // Call GetAllProducts SP
            var products = _productContext.Products
                .FromSqlRaw($"EXEC GetAllProducts")
                .ToList();
            return View(products);
        }


        public IActionResult GetProductByPrice(decimal price)
        {
            //  Call GetProductsByPrice SP
            var productByPrice = _productContext.Products
                 .FromSqlRaw($"EXEC GetProductsByPrice @Price", new SqlParameter("@Price", price)) // Here, price means actual price of product
                 .ToList();
            return View(productByPrice);
        }

    }
}
