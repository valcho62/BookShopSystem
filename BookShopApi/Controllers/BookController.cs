using System.Web.Http;
using BookShopSystem.Service;
using BookShopSytem.Models.BM;

namespace BookShopApi.Controllers
{
    [RoutePrefix("api/books")]
    public class BookController : ApiController
    {
        private BookService service;

        public BookController()
        {
            this.service = new BookService();
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (this.service.Contex.Books.Find(id) == null)
            {
                return this.BadRequest();
            }

            var model = this.service.GetBookById(id);
            return this.Ok(model);
        }

        [HttpGet]
        [Route()]
        public IHttpActionResult Get(string search)
        {
           
            var model = this.service.GetTopBooks(search);
            if (model.Count == 0)
            {
                return this.NotFound();
            }
            return this.Ok(model);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id,[FromBody] EditBookBM model)
        {
            if (this.service.Contex.Books.Find(id) == null || model.Title == null || model.Title==null)
            {
                return this.BadRequest();
            }

            this.service.EditBookById(id,model);
            return this.Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (this.service.Contex.Books.Find(id) == null )
            {
                return this.BadRequest();
            }

            this.service.DeleteBookById(id);
            return this.Ok();
        }

        [HttpPost]
        [Route()]
        public IHttpActionResult Create([FromBody] CreateBookBM model)
        {
            this.service.CreateBook(model);
            return this.Ok();
        }
    }
}
