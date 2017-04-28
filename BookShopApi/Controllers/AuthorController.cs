using System.Web.Http;
using BookShopSystem.Service;
using BookShopSytem.Models.BM;

namespace BookShopApi.Controllers
{
    [RoutePrefix("api/author")]
    public class AuthorController : ApiController
    {
        private AuthorService service;

        public AuthorController()
        {
            this.service = new AuthorService();
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var model = this.service.GetAuthorById(id);
            return this.Ok(model);
        }

        [Route()]
        [HttpPost]
        public IHttpActionResult Post([FromBody] AddAuthorBM model)
        {
            if (ModelState.IsValid)
            {
                this.service.AddAuthor(model);
                return this.Ok();
            }

            return this.BadRequest();
        }

        [Route("{id}/books")]
        public IHttpActionResult GetBooks(int id)
        {
            if (this.service.Contex.Authors.Find(id) == null)
            {
                return this.BadRequest();
            }
            var model = this.service.GetAuthorsBooks(id);
            return this.Ok(model);
        }


    }
}
