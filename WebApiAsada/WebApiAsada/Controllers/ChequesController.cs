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
    public class ChequesController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Cheques
        public IQueryable<Cheques> GetCheques()
        {
            return db.Cheques;
        }

        // GET: api/Cheques/5
        [ResponseType(typeof(Cheques))]
        public IHttpActionResult GetCheques(int id)
        {
            Cheques cheques = db.Cheques.Find(id);
            if (cheques == null)
            {
                return NotFound();
            }

            return Ok(cheques);
        }

        // PUT: api/Cheques/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCheques(int id, Cheques cheques)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cheques.ID)
            {
                return BadRequest();
            }

            db.Entry(cheques).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequesExists(id))
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

        // POST: api/Cheques
        [ResponseType(typeof(Cheques))]
        public IHttpActionResult PostCheques(Cheques cheques)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cheques.Add(cheques);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cheques.ID }, cheques);
        }

        // DELETE: api/Cheques/5
        [ResponseType(typeof(Cheques))]
        public IHttpActionResult DeleteCheques(int id)
        {
            Cheques cheques = db.Cheques.Find(id);
            if (cheques == null)
            {
                return NotFound();
            }

            db.Cheques.Remove(cheques);
            db.SaveChanges();

            return Ok(cheques);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChequesExists(int id)
        {
            return db.Cheques.Count(e => e.ID == id) > 0;
        }
    }
}