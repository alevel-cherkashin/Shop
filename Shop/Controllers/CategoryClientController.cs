using Shop.BusinnesLogic.Convesions;
using Shop.BusinnesLogic.Models;
using Shop.BusinnesLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Controllers
{
    public class CategoryClientController : ApiController
    {
        private ICategoryClientService _categoryClientService;

        public CategoryClientController(ICategoryClientService categoryClientService)
        {
            _categoryClientService = categoryClientService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var categoryLIst = _categoryClientService.Get().Select(c=>c.ToViewModel());

            return Ok(categoryLIst);           
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var category = _categoryClientService.GetDetails(id).ToViewModel();

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] CategoryClientViewModel model)
        {
            if (model == null)
                BadRequest();

            var category = model.ToDto();

            int categoryId = _categoryClientService.Add(category);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] CategoryClientViewModel model)
        {
            if (model == null)
                BadRequest();

            var category = model.ToDto();

            _categoryClientService.Update(category);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _categoryClientService.Delete(id);

            return Ok();
        }
    }
}
