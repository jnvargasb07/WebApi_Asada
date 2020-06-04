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
    public class Factura_ChequeController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Factura_Cheque
        public IQueryable<Factura_Cheque> GetFactura_Cheque()
        {
            return db.Factura_Cheque;
        }

        // GET: api/Factura_Cheque/5
        [ResponseType(typeof(Factura_Cheque))]
        public IHttpActionResult GetFactura_Cheque(int id)
        {
            Factura_Cheque factura_Cheque = db.Factura_Cheque.Find(id);
            if (factura_Cheque == null)
            {
                return NotFound();
            }

            return Ok(factura_Cheque);
        }

        // PUT: api/Factura_Cheque/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFactura_Cheque(int id, Factura_Cheque factura_Cheque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factura_Cheque.ID)
            {
                return BadRequest();
            }

            db.Entry(factura_Cheque).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Factura_ChequeExists(id))
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

        // POST: api/Factura_Cheque
        [ResponseType(typeof(Factura_Cheque))]
        public IHttpActionResult PostFactura_Cheque(Factura_Cheque factura_Cheque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Factura_Cheque.Add(factura_Cheque);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = factura_Cheque.ID }, factura_Cheque);
        }

        // DELETE: api/Factura_Cheque/5
        [ResponseType(typeof(Factura_Cheque))]
        public IHttpActionResult DeleteFactura_Cheque(int id)
        {
            Factura_Cheque factura_Cheque = db.Factura_Cheque.Find(id);
            if (factura_Cheque == null)
            {
                return NotFound();
            }

            db.Factura_Cheque.Remove(factura_Cheque);
            db.SaveChanges();

            return Ok(factura_Cheque);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Factura_ChequeExists(int id)
        {
            return db.Factura_Cheque.Count(e => e.ID == id) > 0;
        }
    }
}