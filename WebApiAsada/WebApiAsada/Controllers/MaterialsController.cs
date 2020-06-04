﻿using System;
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
    public class MaterialsController : ApiController
    {
        private asadaEntities db = new asadaEntities();

        // GET: api/Materials
        public IQueryable<Material> GetMaterial()
        {
            return db.Material;
        }

        // GET: api/Materials/5
        [ResponseType(typeof(Material))]
        public IHttpActionResult GetMaterial(int id)
        {
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            return Ok(material);
        }

        // PUT: api/Materials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterial(int id, Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != material.ID)
            {
                return BadRequest();
            }

            db.Entry(material).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Materials
        [ResponseType(typeof(Material))]
        public IHttpActionResult PostMaterial(Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Material.Add(material);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = material.ID }, material);
        }

        // DELETE: api/Materials/5
        [ResponseType(typeof(Material))]
        public IHttpActionResult DeleteMaterial(int id)
        {
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            db.Material.Remove(material);
            db.SaveChanges();

            return Ok(material);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialExists(int id)
        {
            return db.Material.Count(e => e.ID == id) > 0;
        }
    }
}