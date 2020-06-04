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
    public class Registro_CompraController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Registro_Compra
        public IQueryable<Registro_Compra> GetRegistro_Compra()
        {
            return db.Registro_Compra;
        }

        // GET: api/Registro_Compra/5
        [ResponseType(typeof(Registro_Compra))]
        public IHttpActionResult GetRegistro_Compra(int id)
        {
            Registro_Compra registro_Compra = db.Registro_Compra.Find(id);
            if (registro_Compra == null)
            {
                return NotFound();
            }

            return Ok(registro_Compra);
        }

        // PUT: api/Registro_Compra/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegistro_Compra(int id, Registro_Compra registro_Compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registro_Compra.ID)
            {
                return BadRequest();
            }

            db.Entry(registro_Compra).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Registro_CompraExists(id))
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

        // POST: api/Registro_Compra
        [ResponseType(typeof(Registro_Compra))]
        public IHttpActionResult PostRegistro_Compra(Registro_Compra registro_Compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Registro_Compra.Add(registro_Compra);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = registro_Compra.ID }, registro_Compra);
        }

        // DELETE: api/Registro_Compra/5
        [ResponseType(typeof(Registro_Compra))]
        public IHttpActionResult DeleteRegistro_Compra(int id)
        {
            Registro_Compra registro_Compra = db.Registro_Compra.Find(id);
            if (registro_Compra == null)
            {
                return NotFound();
            }

            db.Registro_Compra.Remove(registro_Compra);
            db.SaveChanges();

            return Ok(registro_Compra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Registro_CompraExists(int id)
        {
            return db.Registro_Compra.Count(e => e.ID == id) > 0;
        }
    }
}