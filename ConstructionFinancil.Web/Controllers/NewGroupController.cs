using ConstructionFinancial.Domain.Account;
using ConstructionFinancial.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConstructionFinancil.Web.Controllers
{
    public class NewGroupController : ApiController
    {
        private readonly IAccountService service;

        public NewGroupController(IAccountService service)
        {
            this.service = service;
        }
        // GET: api/NewAccount
        public IEnumerable<Account> Get()
        {
            return service.GetAllAccount();
        }

        // GET: api/NewAccount/5
        public HttpResponseMessage Get(int id)
        {
            Account account = service.GetAccount(id);
            if (account == null)
            {
                var message = string.Format("Account with id = {0} not found", id);
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, account);
            }
        }

        // POST: api/NewAccount
        public void Post([FromBody]Account value)
        {
            if (ModelState.IsValid)
            {
                service.InsertAccount(value);
            }
        }

        // PUT: api/NewAccount/5
        public void Put(int id, [FromBody]Account value)
        {
            service.UpdateAccount(value);
        }

        // DELETE: api/NewAccount/5
        public void Delete(int id)
        {
            service.DeleteAccount(id);
        }
    }
}
