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
    public class Inventario_StockController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Inventario_Stock
        public IQueryable<Inventario_Stock> GetInventario_Stock()
        {
            return db.Inventario_Stock;
        }

        // GET: api/Inventario_Stock/5
        [ResponseType(typeof(Inventario_Stock))]
        public IHttpActionResult GetInventario_Stock(int id)
        {
            Inventario_Stock inventario_Stock = db.Inventario_Stock.Find(id);
            if (inventario_Stock == null)
            {
                return NotFound();
            }

            return Ok(inventario_Stock);
        }

        // PUT: api/Inventario_Stock/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventario_Stock(int id, Inventario_Stock inventario_Stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventario_Stock.ID)
            {
                return BadRequest();
            }

            db.Entry(inventario_Stock).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Inventario_StockExists(id))
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

        // POST: api/Inventario_Stock
        [ResponseType(typeof(Inventario_Stock))]
        public IHttpActionResult PostInventario_Stock(Inventario_Stock inventario_Stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inventario_Stock.Add(inventario_Stock);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inventario_Stock.ID }, inventario_Stock);
        }

        // DELETE: api/Inventario_Stock/5
        [ResponseType(typeof(Inventario_Stock))]
        public IHttpActionResult DeleteInventario_Stock(int id)
        {
            Inventario_Stock inventario_Stock = db.Inventario_Stock.Find(id);
            if (inventario_Stock == null)
            {
                return NotFound();
            }

            db.Inventario_Stock.Remove(inventario_Stock);
            db.SaveChanges();

            return Ok(inventario_Stock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Inventario_StockExists(int id)
        {
            return db.Inventario_Stock.Count(e => e.ID == id) > 0;
        }
    }
}