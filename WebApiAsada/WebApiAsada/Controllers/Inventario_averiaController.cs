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
    public class Inventario_averiaController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Inventario_averia
        public IQueryable<Inventario_averia> GetInventario_averia()
        {
            return db.Inventario_averia;
        }

        // GET: api/Inventario_averia/5
        [ResponseType(typeof(Inventario_averia))]
        public IHttpActionResult GetInventario_averia(int id)
        {
            Inventario_averia inventario_averia = db.Inventario_averia.Find(id);
            if (inventario_averia == null)
            {
                return NotFound();
            }

            return Ok(inventario_averia);
        }

        // PUT: api/Inventario_averia/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventario_averia(int id, Inventario_averia inventario_averia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventario_averia.ID)
            {
                return BadRequest();
            }

            db.Entry(inventario_averia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Inventario_averiaExists(id))
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

        // POST: api/Inventario_averia
        [ResponseType(typeof(Inventario_averia))]
        public IHttpActionResult PostInventario_averia(Inventario_averia inventario_averia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inventario_averia.Add(inventario_averia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inventario_averia.ID }, inventario_averia);
        }

        // DELETE: api/Inventario_averia/5
        [ResponseType(typeof(Inventario_averia))]
        public IHttpActionResult DeleteInventario_averia(int id)
        {
            Inventario_averia inventario_averia = db.Inventario_averia.Find(id);
            if (inventario_averia == null)
            {
                return NotFound();
            }

            db.Inventario_averia.Remove(inventario_averia);
            db.SaveChanges();

            return Ok(inventario_averia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Inventario_averiaExists(int id)
        {
            return db.Inventario_averia.Count(e => e.ID == id) > 0;
        }
    }
}