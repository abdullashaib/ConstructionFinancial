using ConstructionFinancial.Domain.Account;
using ConstructionFinancial.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ConstructionFinancil.Web.Controllers
{
    public class AccountGroupController : ApiController
    {
        private readonly IAccountGroupRepository service;

        public AccountGroupController(IAccountGroupRepository service)
        {
            this.service = service;
        }

        // GET: api/AccountGroup
        public IEnumerable<AccountGroup> Get()
        {
            return service.GetAll();
        }

        // GET: api/AccountGroup/5
        public HttpResponseMessage Get(int id)
        {
            AccountGroup accountGroup = service.GetById(id);
            if (accountGroup == null)
            {
                var message = string.Format("Account group with id = {0} not found", id);
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, accountGroup);
            }
        }

        // POST: api/AccountGroup
        [ResponseType(typeof(AccountGroup))]
        public IHttpActionResult Post([FromBody]AccountGroup value)
        {
            try
            {
                service.Insert(value);
            }
            catch (Exception ex)
            {
               
            }
            return CreatedAtRoute("DefaultApi", new { id = value.Id }, value); 
        }

        // PUT: api/AccountGroup/5
        public IHttpActionResult Put(int id, [FromBody]AccountGroup value)
        {
            AccountGroup accountToUpdate = service.GetById(value.Id);
            try
            {
                service.Update(accountToUpdate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (accountToUpdate != null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/AccountGroup/5
        public void Delete(int id)
        {
            AccountGroup accountToDelete = service.GetById(id);
            service.Delete(accountToDelete);
        }
    }
}
