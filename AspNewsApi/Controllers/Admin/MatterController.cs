using System;
using AspNewsApi.Models;
using System.Web.Http;

namespace AspNewsApi.Controllers.Admin
{
    [RoutePrefix("admin/matter")]
    public class MatterController : ApiController
    {
        [Route("index")]
        [HttpGet]
        public IHttpActionResult index()
        {
            return Ok("index");
        }

        public IHttpActionResult show()
        {
            return Ok("show");
        }

        [Route("store")]
        [HttpPost]
        public IHttpActionResult store([FromBody] Matter request)
        {
            request.Type = "Matter";
            request.UserId = 1;
            request.CreatedAt = DateTime.Now;
            request.UpdatedAt = DateTime.Now;
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    context.Matters.Add(request);
                    context.SaveChanges();
                    return Ok("خبر با موفقیت ثبت شد.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult update(int id, [FromBody] Matter request)
        {
            return Ok("update");
        }

        public IHttpActionResult delete(int id)
        {
            return Ok("delete");
        }
    }
}