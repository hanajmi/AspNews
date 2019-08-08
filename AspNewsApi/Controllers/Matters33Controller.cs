﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AspNewsApi.Models;

namespace AspNewsApi.Controllers
{
    public class Matters33Controller : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/Matters33
        public IQueryable<Matter> GetMatters()
        {
            return db.Matters;
        }

        // GET: api/Matters33/5
        [ResponseType(typeof(Matter))]
        public IHttpActionResult GetMatter(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Matter matter = db.Matters.Find(id);
            if (matter == null)
            {
                return NotFound();
            }

            return Ok(matter);
        }

        // PUT: api/Matters33/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMatter(int id, Matter matter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != matter.Id)
            {
                return BadRequest();
            }

            db.Entry(matter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatterExists(id))
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

        // POST: api/Matters33
        [ResponseType(typeof(Matter))]
        public IHttpActionResult PostMatter(Matter matter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Matters.Add(matter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = matter.Id }, matter);
        }

        // DELETE: api/Matters33/5
        [ResponseType(typeof(Matter))]
        public IHttpActionResult DeleteMatter(int id)
        {
            Matter matter = db.Matters.Find(id);
            if (matter == null)
            {
                return NotFound();
            }

            db.Matters.Remove(matter);
            db.SaveChanges();

            return Ok(matter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatterExists(int id)
        {
            return db.Matters.Count(e => e.Id == id) > 0;
        }
    }
}