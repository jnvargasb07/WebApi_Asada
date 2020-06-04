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
    public class ReciclajesController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Reciclajes
        public IQueryable<Reciclaje> GetReciclaje()
        {
            return db.Reciclaje;
        }

        // GET: api/Reciclajes/5
        [ResponseType(typeof(Reciclaje))]
        public IHttpActionResult GetReciclaje(int id)
        {
            Reciclaje reciclaje = db.Reciclaje.Find(id);
            if (reciclaje == null)
            {
                return NotFound();
            }

            return Ok(reciclaje);
        }

        // PUT: api/Reciclajes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReciclaje(int id, Reciclaje reciclaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reciclaje.ID)
            {
                return BadRequest();
            }

            db.Entry(reciclaje).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReciclajeExists(id))
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

        // POST: api/Reciclajes
        [ResponseType(typeof(Reciclaje))]
        public IHttpActionResult PostReciclaje(Reciclaje reciclaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reciclaje.Add(reciclaje);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reciclaje.ID }, reciclaje);
        }

        // DELETE: api/Reciclajes/5
        [ResponseType(typeof(Reciclaje))]
        public IHttpActionResult DeleteReciclaje(int id)
        {
            Reciclaje reciclaje = db.Reciclaje.Find(id);
            if (reciclaje == null)
            {
                return NotFound();
            }

            db.Reciclaje.Remove(reciclaje);
            db.SaveChanges();

            return Ok(reciclaje);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReciclajeExists(int id)
        {
            return db.Reciclaje.Count(e => e.ID == id) > 0;
        }
    }
}