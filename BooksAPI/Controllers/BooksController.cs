using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BooksAPI.Controllers
{
    [Authorize] // all action need to be autenticated
    public class BooksController : ApiController
    {
        public IEnumerable<Books> Get()
        {
            using (BookShopEntities db = new BookShopEntities())
            {
                return db.Books.Where(b => b.IsDeleted == false).ToList();
            }
        }
    }
}
