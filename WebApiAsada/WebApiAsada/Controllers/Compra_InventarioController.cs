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
    public class Compra_InventarioController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Compra_Inventario
        public IQueryable<Compra_Inventario> GetCompra_Inventario()
        {
            return db.Compra_Inventario;
        }

        // GET: api/Compra_Inventario/5
        [ResponseType(typeof(Compra_Inventario))]
        public IHttpActionResult GetCompra_Inventario(int id)
        {
            Compra_Inventario compra_Inventario = db.Compra_Inventario.Find(id);
            if (compra_Inventario == null)
            {
                return NotFound();
            }

            return Ok(compra_Inventario);
        }

        // PUT: api/Compra_Inventario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompra_Inventario(int id, Compra_Inventario compra_Inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compra_Inventario.ID)
            {
                return BadRequest();
            }

            db.Entry(compra_Inventario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Compra_InventarioExists(id))
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

        // POST: api/Compra_Inventario
        [ResponseType(typeof(Compra_Inventario))]
        public IHttpActionResult PostCompra_Inventario(Compra_Inventario compra_Inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Compra_Inventario.Add(compra_Inventario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = compra_Inventario.ID }, compra_Inventario);
        }

        // DELETE: api/Compra_Inventario/5
        [ResponseType(typeof(Compra_Inventario))]
        public IHttpActionResult DeleteCompra_Inventario(int id)
        {
            Compra_Inventario compra_Inventario = db.Compra_Inventario.Find(id);
            if (compra_Inventario == null)
            {
                return NotFound();
            }

            db.Compra_Inventario.Remove(compra_Inventario);
            db.SaveChanges();

            return Ok(compra_Inventario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Compra_InventarioExists(int id)
        {
            return db.Compra_Inventario.Count(e => e.ID == id) > 0;
        }
    }
}