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
    public class Agua_No_ContabilizadaController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Agua_No_Contabilizada
        public IQueryable<Agua_No_Contabilizada> GetAgua_No_Contabilizada()
        {
            return db.Agua_No_Contabilizada;
        }

        // GET: api/Agua_No_Contabilizada/5
        [ResponseType(typeof(Agua_No_Contabilizada))]
        public IHttpActionResult GetAgua_No_Contabilizada(int id)
        {
            Agua_No_Contabilizada agua_No_Contabilizada = db.Agua_No_Contabilizada.Find(id);
            if (agua_No_Contabilizada == null)
            {
                return NotFound();
            }

            return Ok(agua_No_Contabilizada);
        }

        // PUT: api/Agua_No_Contabilizada/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgua_No_Contabilizada(int id, Agua_No_Contabilizada agua_No_Contabilizada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agua_No_Contabilizada.ID)
            {
                return BadRequest();
            }

            db.Entry(agua_No_Contabilizada).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Agua_No_ContabilizadaExists(id))
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

        // POST: api/Agua_No_Contabilizada
        [ResponseType(typeof(Agua_No_Contabilizada))]
        public IHttpActionResult PostAgua_No_Contabilizada(Agua_No_Contabilizada agua_No_Contabilizada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Agua_No_Contabilizada.Add(agua_No_Contabilizada);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agua_No_Contabilizada.ID }, agua_No_Contabilizada);
        }

        // DELETE: api/Agua_No_Contabilizada/5
        [ResponseType(typeof(Agua_No_Contabilizada))]
        public IHttpActionResult DeleteAgua_No_Contabilizada(int id)
        {
            Agua_No_Contabilizada agua_No_Contabilizada = db.Agua_No_Contabilizada.Find(id);
            if (agua_No_Contabilizada == null)
            {
                return NotFound();
            }

            db.Agua_No_Contabilizada.Remove(agua_No_Contabilizada);
            db.SaveChanges();

            return Ok(agua_No_Contabilizada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Agua_No_ContabilizadaExists(int id)
        {
            return db.Agua_No_Contabilizada.Count(e => e.ID == id) > 0;
        }
    }
}