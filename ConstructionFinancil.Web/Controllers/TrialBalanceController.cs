using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConstructionFinancil.Web.Controllers
{
    public class TrialBalanceController : ApiController
    {

        // GET: api/TrialBalance
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TrialBalance/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TrialBalance
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TrialBalance/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TrialBalance/5
        public void Delete(int id)
        {
        }
    }
}
