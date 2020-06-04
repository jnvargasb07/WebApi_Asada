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
    public class Prestamos_InventarioController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Prestamos_Inventario
        public IQueryable<Prestamos_Inventario> GetPrestamos_Inventario()
        {
            return db.Prestamos_Inventario;
        }

        // GET: api/Prestamos_Inventario/5
        [ResponseType(typeof(Prestamos_Inventario))]
        public IHttpActionResult GetPrestamos_Inventario(int id)
        {
            Prestamos_Inventario prestamos_Inventario = db.Prestamos_Inventario.Find(id);
            if (prestamos_Inventario == null)
            {
                return NotFound();
            }

            return Ok(prestamos_Inventario);
        }

        // PUT: api/Prestamos_Inventario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrestamos_Inventario(int id, Prestamos_Inventario prestamos_Inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestamos_Inventario.ID)
            {
                return BadRequest();
            }

            db.Entry(prestamos_Inventario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Prestamos_InventarioExists(id))
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

        // POST: api/Prestamos_Inventario
        [ResponseType(typeof(Prestamos_Inventario))]
        public IHttpActionResult PostPrestamos_Inventario(Prestamos_Inventario prestamos_Inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prestamos_Inventario.Add(prestamos_Inventario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prestamos_Inventario.ID }, prestamos_Inventario);
        }

        // DELETE: api/Prestamos_Inventario/5
        [ResponseType(typeof(Prestamos_Inventario))]
        public IHttpActionResult DeletePrestamos_Inventario(int id)
        {
            Prestamos_Inventario prestamos_Inventario = db.Prestamos_Inventario.Find(id);
            if (prestamos_Inventario == null)
            {
                return NotFound();
            }

            db.Prestamos_Inventario.Remove(prestamos_Inventario);
            db.SaveChanges();

            return Ok(prestamos_Inventario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Prestamos_InventarioExists(int id)
        {
            return db.Prestamos_Inventario.Count(e => e.ID == id) > 0;
        }
    }
}