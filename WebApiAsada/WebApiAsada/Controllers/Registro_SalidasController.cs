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
    public class Registro_SalidasController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Registro_Salidas
        public IQueryable<Registro_Salidas> GetRegistro_Salidas()
        {
            return db.Registro_Salidas;
        }

        // GET: api/Registro_Salidas/5
        [ResponseType(typeof(Registro_Salidas))]
        public IHttpActionResult GetRegistro_Salidas(int id)
        {
            Registro_Salidas registro_Salidas = db.Registro_Salidas.Find(id);
            if (registro_Salidas == null)
            {
                return NotFound();
            }

            return Ok(registro_Salidas);
        }

        // PUT: api/Registro_Salidas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegistro_Salidas(int id, Registro_Salidas registro_Salidas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registro_Salidas.ID)
            {
                return BadRequest();
            }

            db.Entry(registro_Salidas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Registro_SalidasExists(id))
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

        // POST: api/Registro_Salidas
        [ResponseType(typeof(Registro_Salidas))]
        public IHttpActionResult PostRegistro_Salidas(Registro_Salidas registro_Salidas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Registro_Salidas.Add(registro_Salidas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = registro_Salidas.ID }, registro_Salidas);
        }

        // DELETE: api/Registro_Salidas/5
        [ResponseType(typeof(Registro_Salidas))]
        public IHttpActionResult DeleteRegistro_Salidas(int id)
        {
            Registro_Salidas registro_Salidas = db.Registro_Salidas.Find(id);
            if (registro_Salidas == null)
            {
                return NotFound();
            }

            db.Registro_Salidas.Remove(registro_Salidas);
            db.SaveChanges();

            return Ok(registro_Salidas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Registro_SalidasExists(int id)
        {
            return db.Registro_Salidas.Count(e => e.ID == id) > 0;
        }
    }
}