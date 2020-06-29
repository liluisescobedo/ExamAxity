using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExamAxity.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        [HttpGet]
        [Route("GetAllProducts")]
        public IEnumerable<Models.Products> GetAllProducts()
        {
            IEnumerable<Models.Products> lst;
            using (Models.ExamAxityEntities db = new Models.ExamAxityEntities())
            {
                lst = db.Products.ToList();
            }

            return lst;
        }
    }
}
