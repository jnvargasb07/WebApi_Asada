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
    public class Salidas_InventarioController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Salidas_Inventario
        public IQueryable<Salidas_Inventario> GetSalidas_Inventario()
        {
            return db.Salidas_Inventario;
        }

        // GET: api/Salidas_Inventario/5
        [ResponseType(typeof(Salidas_Inventario))]
        public IHttpActionResult GetSalidas_Inventario(int id)
        {
            Salidas_Inventario salidas_Inventario = db.Salidas_Inventario.Find(id);
            if (salidas_Inventario == null)
            {
                return NotFound();
            }

            return Ok(salidas_Inventario);
        }

        // PUT: api/Salidas_Inventario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalidas_Inventario(int id, Salidas_Inventario salidas_Inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salidas_Inventario.ID)
            {
                return BadRequest();
            }

            db.Entry(salidas_Inventario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Salidas_InventarioExists(id))
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

        // POST: api/Salidas_Inventario
        [ResponseType(typeof(Salidas_Inventario))]
        public IHttpActionResult PostSalidas_Inventario(Salidas_Inventario salidas_Inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Salidas_Inventario.Add(salidas_Inventario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = salidas_Inventario.ID }, salidas_Inventario);
        }

        // DELETE: api/Salidas_Inventario/5
        [ResponseType(typeof(Salidas_Inventario))]
        public IHttpActionResult DeleteSalidas_Inventario(int id)
        {
            Salidas_Inventario salidas_Inventario = db.Salidas_Inventario.Find(id);
            if (salidas_Inventario == null)
            {
                return NotFound();
            }

            db.Salidas_Inventario.Remove(salidas_Inventario);
            db.SaveChanges();

            return Ok(salidas_Inventario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Salidas_InventarioExists(int id)
        {
            return db.Salidas_Inventario.Count(e => e.ID == id) > 0;
        }
    }
}