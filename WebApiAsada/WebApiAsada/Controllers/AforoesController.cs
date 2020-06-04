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
    public class AforoesController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Aforoes
        public IQueryable<Aforo> GetAforo()
        {
            return db.Aforo;
        }

        // GET: api/Aforoes/5
        [ResponseType(typeof(Aforo))]
        public IHttpActionResult GetAforo(int id)
        {
            Aforo aforo = db.Aforo.Find(id);
            if (aforo == null)
            {
                return NotFound();
            }

            return Ok(aforo);
        }

        // PUT: api/Aforoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAforo(int id, Aforo aforo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aforo.ID)
            {
                return BadRequest();
            }

            db.Entry(aforo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AforoExists(id))
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

        // POST: api/Aforoes
        [ResponseType(typeof(Aforo))]
        public IHttpActionResult PostAforo(Aforo aforo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Aforo.Add(aforo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aforo.ID }, aforo);
        }

        // DELETE: api/Aforoes/5
        [ResponseType(typeof(Aforo))]
        public IHttpActionResult DeleteAforo(int id)
        {
            Aforo aforo = db.Aforo.Find(id);
            if (aforo == null)
            {
                return NotFound();
            }

            db.Aforo.Remove(aforo);
            db.SaveChanges();

            return Ok(aforo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AforoExists(int id)
        {
            return db.Aforo.Count(e => e.ID == id) > 0;
        }
    }
}