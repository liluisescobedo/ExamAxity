using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExamAxity.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("Login/{user}/{psw}")]
        public IEnumerable<Models.Users> Login(string user, string psw)
        {
            IEnumerable<Models.Users> lst;
            using (Models.ExamAxityEntities db = new Models.ExamAxityEntities())
            {
                lst = db.Users.ToList().Where(x => x.Nombre == user && x.Password == psw).ToList();
            }

            return lst;
        }
    }
}
