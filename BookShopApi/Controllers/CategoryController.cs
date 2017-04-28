using System.Web.Http;
using BookShopSystem.Service;
using BookShopSytem.Models.BM;

namespace BookShopApi.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        private CategoryService service;

        public CategoryController()
        {
            this.service = new CategoryService();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var model =this.service.GetAllCatgories();
            return this.Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCatById(int id)
        {
            var model = this.service.GetCatById(id);
            if (model == null)
            {
                return this.BadRequest();
            }
            return this.Ok(model);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult EditCat(int id,[FromBody] EditCatBM name)
        {
            var model = this.service.EditCatById(id,name);
            if (model == null)
            {
                return this.BadRequest();
            }
            return this.Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCat(int id)
        {
            var model = this.service.DeleteCat(id);
            if (model == null)
            {
                return this.BadRequest();
            }
            return this.Ok("The cat was deleted ");
        }

        [HttpPost]
        [Route()]
        public IHttpActionResult Post([FromBody] EditCatBM model)
        {

            var result = this.service.CreateCat(model);
            if ( result== null)
            {
                return this.BadRequest();
            }
            return this.Ok(result);
        }
    }
}
