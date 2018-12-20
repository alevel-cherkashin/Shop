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
    public class TransactionController : ApiController
    {
        private readonly ITransactionService _transactionServise;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionServise = transactionService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var transactiontList = _transactionServise.Get().Select(c => c.ToViewModel());
            return Ok(transactiontList);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var client = _transactionServise.GetDetails(id).ToViewModel();

            return Ok(client);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] TransactionViewModel model)
        {
            var transaction = model.ToDto();

            int transactionId = _transactionServise.Add(transaction);

            return Ok(transactionId);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] TransactionViewModel model)
        {
            var transaction = model.ToDto();

            _transactionServise.Update(transaction);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _transactionServise.Delete(id);

            return Ok();
        }
    }
}
