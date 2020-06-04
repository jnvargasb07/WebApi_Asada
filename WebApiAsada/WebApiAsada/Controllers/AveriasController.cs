using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiAsada.Models;

namespace WebApiAsada.Controllers
{
    public class AveriasController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Averias
        public IQueryable<Averias> GetAverias()
        {
            return db.Averias;
        }

        // GET: api/Averias/5
        [ResponseType(typeof(Averias))]
        public IHttpActionResult GetAverias(int id)
        {
            Averias averias = db.Averias.Find(id);
            if (averias == null)
            {
                return NotFound();
            }

            return Ok(averias);
        }

        // PUT: api/Averias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAverias(int id, Averias averias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != averias.ID)
            {
                return BadRequest();
            }

            db.Entry(averias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AveriasExists(id))
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

        // POST: api/Averias
        [ResponseType(typeof(Averias))]
        public IHttpActionResult PostAverias(Averias averias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Averias.Add(averias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = averias.ID }, averias);
        }

        // DELETE: api/Averias/5
        [ResponseType(typeof(Averias))]
        public IHttpActionResult DeleteAverias(int id)
        {
            Averias averias = db.Averias.Find(id);
            if (averias == null)
            {
                return NotFound();
            }

            db.Averias.Remove(averias);
            db.SaveChanges();

            return Ok(averias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AveriasExists(int id)
        {
            return db.Averias.Count(e => e.ID == id) > 0;
        }
    }
}