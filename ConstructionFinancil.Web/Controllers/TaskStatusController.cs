using ConstructionFinancial.DataEntity.Context;
using ConstructionFinancial.DataEntity.TaskModel;
using ConstructionFinancial.Domain.TaskModel;
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
    public class TaskStatusController : ApiController
    {
        private  readonly ITaskStatusRepository context;

        public TaskStatusController(ITaskStatusRepository context) {
            this.context = context;
        }

        // GET: api/TaskStatus
        public IEnumerable<TaskStatus> Get()
        {
            return context.GetAll();
        }

        // GET: api/TaskStatus/5
        public HttpResponseMessage Get(int id)
        {
            TaskStatus taskStatus = context.GetById(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, taskStatus);
            return response;
        }

        // POST: api/TaskStatus
         [ResponseType(typeof(TaskStatus))]
        public IHttpActionResult Post([FromBody]TaskStatus taskStatus)
        {
            context.Insert(taskStatus);

            return CreatedAtRoute("DefaultApi", new { id = taskStatus.Id }, taskStatus);
        }

        // PUT: api/TaskStatus/5
        public IHttpActionResult Put(int id, [FromBody]TaskStatus taskStatus)
        {
            TaskStatus taskExist = context.GetById(id);

            try
            {
                context.Update(taskExist);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (taskExist != null)
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

        // DELETE: api/TaskStatus/5
        [ResponseType(typeof(TaskStatus))]
        public IHttpActionResult Delete(int id)
        {
            TaskStatus taskStatus = context.GetById(id);
            if (taskStatus == null)
            {
                return NotFound();
            }
            context.Delete(taskStatus);

            return Ok(taskStatus);
        }

    }
}
