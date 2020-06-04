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
    public class CloracionsController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Cloracions
        public IQueryable<Cloracion> GetCloracion()
        {
            return db.Cloracion;
        }

        // GET: api/Cloracions/5
        [ResponseType(typeof(Cloracion))]
        public IHttpActionResult GetCloracion(int id)
        {
            Cloracion cloracion = db.Cloracion.Find(id);
            if (cloracion == null)
            {
                return NotFound();
            }

            return Ok(cloracion);
        }

        // PUT: api/Cloracions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCloracion(int id, Cloracion cloracion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cloracion.ID)
            {
                return BadRequest();
            }

            db.Entry(cloracion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CloracionExists(id))
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

        // POST: api/Cloracions
        [ResponseType(typeof(Cloracion))]
        public IHttpActionResult PostCloracion(Cloracion cloracion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cloracion.Add(cloracion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cloracion.ID }, cloracion);
        }

        // DELETE: api/Cloracions/5
        [ResponseType(typeof(Cloracion))]
        public IHttpActionResult DeleteCloracion(int id)
        {
            Cloracion cloracion = db.Cloracion.Find(id);
            if (cloracion == null)
            {
                return NotFound();
            }

            db.Cloracion.Remove(cloracion);
            db.SaveChanges();

            return Ok(cloracion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CloracionExists(int id)
        {
            return db.Cloracion.Count(e => e.ID == id) > 0;
        }
    }
}