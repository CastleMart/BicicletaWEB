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
using BicicletaWEB.Models;

namespace BicicletaWEB.Controllers
{
    public class APIVentaDetalles2Controller : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/APIVentaDetalles2
        public IQueryable<VentaDetalles2> GetVentaDetalles2()
        {
            return db.VentaDetalles2;
        }

        // GET: api/APIVentaDetalles2/5
        [ResponseType(typeof(VentaDetalles2))]
        public IHttpActionResult GetVentaDetalles2(int id)
        {
            VentaDetalles2 ventaDetalles2 = db.VentaDetalles2.Find(id);
            if (ventaDetalles2 == null)
            {
                return NotFound();
            }

            return Ok(ventaDetalles2);
        }

        // PUT: api/APIVentaDetalles2/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVentaDetalles2(int id, VentaDetalles2 ventaDetalles2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ventaDetalles2.idVenta)
            {
                return BadRequest();
            }

            db.Entry(ventaDetalles2).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaDetalles2Exists(id))
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

        // POST: api/APIVentaDetalles2
        [ResponseType(typeof(VentaDetalles2))]
        public IHttpActionResult PostVentaDetalles2(VentaDetalles2 ventaDetalles2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VentaDetalles2.Add(ventaDetalles2);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VentaDetalles2Exists(ventaDetalles2.idVenta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ventaDetalles2.idVenta }, ventaDetalles2);
        }

        // DELETE: api/APIVentaDetalles2/5
        [ResponseType(typeof(VentaDetalles2))]
        public IHttpActionResult DeleteVentaDetalles2(int id)
        {
            VentaDetalles2 ventaDetalles2 = db.VentaDetalles2.Find(id);
            if (ventaDetalles2 == null)
            {
                return NotFound();
            }

            db.VentaDetalles2.Remove(ventaDetalles2);
            db.SaveChanges();

            return Ok(ventaDetalles2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VentaDetalles2Exists(int id)
        {
            return db.VentaDetalles2.Count(e => e.idVenta == id) > 0;
        }
    }
}