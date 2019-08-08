using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AspNewsApi.Models;
using System.Web.Http;
using System.Web.Http.Cors;
using AspNewsApi.Models.Map;

namespace AspNewsApi.Controllers.Admin
{
//    [EnableCors("*", "*", "*")]
    [RoutePrefix("admin/matter")]
    public class MatterController : ApiController
    {
        [Route("index")]
        [HttpGet]
        public IHttpActionResult index()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    return Ok(context.Matters.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("show/{id}")]
        [HttpGet]
        public IHttpActionResult show(int id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Configuration.ProxyCreationEnabled = false;

                    //var matterItem = context.Matters.Find(id);
                    var matterItem = context.Matters.FirstOrDefault(dbMatterItem => dbMatterItem.Id == id);

                    if (matterItem == null) return NotFound();
                    return Ok(matterItem);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("store")]
        [HttpPost]
        public IHttpActionResult store([FromBody] Matter request)
        {
            try
            {
                //if (!ModelState.IsValid) return BadRequest(ModelState);

                using (AppDbContext context = new AppDbContext())
                {
                    request.SlideShow = false;
                    request.Type = "Matter";
                    request.UserId = 1;
                    request.CreatedAt = DateTime.Now;
                    request.UpdatedAt = DateTime.Now;

                    Matter matterItem = context.Matters.Add(request);

                    //File fileItem = new File() { Name = "file2", Uri = "/",Mime = "jpg" , Size = 500, Type = "jpg", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, MatterId = matterItem.Id, UserId = 1};
                    //matterItem.Files.Add(fileItem);

                    //Category categoryItem = context.Categories.FirstOrDefault(dbCategoryItem => dbCategoryItem.Id == 1);
                    //matterItem.Categories.Add(categoryItem);

                    //Tag tagItem = context.Tags.FirstOrDefault(dbTagItem => dbTagItem.Id == 1);
                    //matterItem.Tags.Add(tagItem);

                    context.SaveChanges();
                    return Ok("خبر با موفقیت ثبت شد.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("update/{id}")]
        [HttpPut]
        public IHttpActionResult update(int id, [FromBody] Matter request)
        {
            try
            {
                //if (!ModelState.IsValid) return BadRequest(ModelState);
                if (request.Id != id) return BadRequest();

                using (var context = new AppDbContext())
                {
                    var matterItem = context.Matters.FirstOrDefault(dbItem => dbItem.Id == id); // Find Matter
                    if (matterItem == null) return NotFound();

                    matterItem.TopTitle = request.TopTitle;
                    matterItem.Title = request.Title;
                    matterItem.Lead = request.Lead;
                    matterItem.Body = request.Body;
                    matterItem.UpdatedAt = DateTime.Now;

                    context.SaveChanges();
                    return Ok("بروز رسانی خبر با موفقیت انجام شد.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IHttpActionResult delete(int id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    //var matterItem = context.Matters.Find(id);
                    var matterItem = context.Matters.FirstOrDefault(dbMatterItem => dbMatterItem.Id == id);
                    if (matterItem == null) return NotFound();
                    context.Matters.Remove(matterItem);
                    context.SaveChanges();
                    return Ok("حذف خبر با موفقیت انجام شد.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}