using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BooksAPI.Controllers
{
    //[Authorize] // all action need to be autenticated
    public class BooksController : ApiController
    {
        public IEnumerable<Books> Get()
        {
            using (var db = new BookShopEntities())
            {
                return db.Books.Where(b => b.IsDeleted == false).ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (var db = new BookShopEntities())
            {
                var book = db.Books.Where(b => b.Id == id).FirstOrDefault();

                if (book == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, book);
            }
        }

        public HttpResponseMessage Post([FromBody]Books book)
        {
            using (var db = new BookShopEntities())
            {
                db.Books.Add(book);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, book);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody]Books book)
        {
            using (var db = new BookShopEntities())
            {
                var mbook = db.Books.Where(b => b.Id == id).FirstOrDefault();

                if (mbook == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "invalid id");
                else
                {
                    mbook.Title = book.Title;
                    mbook.Price = book.Price;

                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, mbook);
                }  
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            using (var db = new BookShopEntities())
            {
                var rbook = db.Books.Where(b => b.Id == id).FirstOrDefault();

                if (rbook == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "invalid id");
                else
                {
                    db.Books.Remove(rbook);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "book with id = " + id + " has been deleted");
                }
            }
        }
    }
}
