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
    public class Cuentas_BancariasController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Cuentas_Bancarias
        public IQueryable<Cuentas_Bancarias> GetCuentas_Bancarias()
        {
            return db.Cuentas_Bancarias;
        }

        // GET: api/Cuentas_Bancarias/5
        [ResponseType(typeof(Cuentas_Bancarias))]
        public IHttpActionResult GetCuentas_Bancarias(int id)
        {
            Cuentas_Bancarias cuentas_Bancarias = db.Cuentas_Bancarias.Find(id);
            if (cuentas_Bancarias == null)
            {
                return NotFound();
            }

            return Ok(cuentas_Bancarias);
        }

        // PUT: api/Cuentas_Bancarias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuentas_Bancarias(int id, Cuentas_Bancarias cuentas_Bancarias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuentas_Bancarias.ID)
            {
                return BadRequest();
            }

            db.Entry(cuentas_Bancarias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cuentas_BancariasExists(id))
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

        // POST: api/Cuentas_Bancarias
        [ResponseType(typeof(Cuentas_Bancarias))]
        public IHttpActionResult PostCuentas_Bancarias(Cuentas_Bancarias cuentas_Bancarias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cuentas_Bancarias.Add(cuentas_Bancarias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cuentas_Bancarias.ID }, cuentas_Bancarias);
        }

        // DELETE: api/Cuentas_Bancarias/5
        [ResponseType(typeof(Cuentas_Bancarias))]
        public IHttpActionResult DeleteCuentas_Bancarias(int id)
        {
            Cuentas_Bancarias cuentas_Bancarias = db.Cuentas_Bancarias.Find(id);
            if (cuentas_Bancarias == null)
            {
                return NotFound();
            }

            db.Cuentas_Bancarias.Remove(cuentas_Bancarias);
            db.SaveChanges();

            return Ok(cuentas_Bancarias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Cuentas_BancariasExists(int id)
        {
            return db.Cuentas_Bancarias.Count(e => e.ID == id) > 0;
        }
    }
}