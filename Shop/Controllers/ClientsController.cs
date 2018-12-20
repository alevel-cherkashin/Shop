using Shop.BusinnesLogic.Convesions;
using Shop.BusinnesLogic.Models;
using Shop.BusinnesLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shop.Atrributes;
using Shop.Attributes;

namespace Shop.Controllers
{
    [RoutePrefix ("api/clients")]
    [ZeroHendler]
    public class ClientsController : ApiController
    {

        private readonly IClientService _clientServise;

        public ClientsController(IClientService clientService)
        {
            _clientServise = clientService;
        }

        [Route("get-all")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            
            var clientList = _clientServise.Get().Select(c => c.ToViewModel());
            return Ok(clientList);
        }

        [Route("get-deteils/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var client = _clientServise.GetDetails(id).ToViewModel();
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] ClientViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_clientServise.Validate(model.Name))
            {
                return BadRequest("Duplicate");
            }

            var client = model.ToDto();

            int clientId = _clientServise.Add(client);

            return Ok(clientId);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] ClientViewModel model)
        {
            var client = model.ToDto();

            _clientServise.Update(client);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _clientServise.Delete(id);

            return Ok();
        }

        [Route("get-limited/{number}")]
        [HttpGet]
        [HendlerArgumentException]
        public IHttpActionResult GetLimited(int? number)
        {
           
            var clients = _clientServise.GetLimited(number.Value);

            return Ok(clients);
        }
    }
}
