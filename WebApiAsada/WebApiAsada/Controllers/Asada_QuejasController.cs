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
    public class Asada_QuejasController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Asada_Quejas
        public IQueryable<Asada_Quejas> GetAsada_Quejas()
        {
            return db.Asada_Quejas;
        }

        // GET: api/Asada_Quejas/5
        [ResponseType(typeof(Asada_Quejas))]
        public IHttpActionResult GetAsada_Quejas(int id)
        {
            Asada_Quejas asada_Quejas = db.Asada_Quejas.Find(id);
            if (asada_Quejas == null)
            {
                return NotFound();
            }

            return Ok(asada_Quejas);
        }

        // PUT: api/Asada_Quejas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsada_Quejas(int id, Asada_Quejas asada_Quejas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asada_Quejas.ID)
            {
                return BadRequest();
            }

            db.Entry(asada_Quejas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Asada_QuejasExists(id))
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

        // POST: api/Asada_Quejas
        [ResponseType(typeof(Asada_Quejas))]
        public IHttpActionResult PostAsada_Quejas(Asada_Quejas asada_Quejas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Asada_Quejas.Add(asada_Quejas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = asada_Quejas.ID }, asada_Quejas);
        }

        // DELETE: api/Asada_Quejas/5
        [ResponseType(typeof(Asada_Quejas))]
        public IHttpActionResult DeleteAsada_Quejas(int id)
        {
            Asada_Quejas asada_Quejas = db.Asada_Quejas.Find(id);
            if (asada_Quejas == null)
            {
                return NotFound();
            }

            db.Asada_Quejas.Remove(asada_Quejas);
            db.SaveChanges();

            return Ok(asada_Quejas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Asada_QuejasExists(int id)
        {
            return db.Asada_Quejas.Count(e => e.ID == id) > 0;
        }
    }
}