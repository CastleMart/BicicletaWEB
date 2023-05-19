using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BicicletaWEB.Models;

namespace BicicletaWEB.Controllers
{
    public class VentaDetalles2Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: VentaDetalles2
        public ActionResult Index()
        {
            return View(db.VentaDetalles2.ToList());
        }

        // GET: VentaDetalles2/Details/5
        public ActionResult Details(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaDetalles2 ventaDetalles2 = db.VentaDetalles2.Find(id, id2);
            if (ventaDetalles2 == null)
            {
                return HttpNotFound();
            }
            return View(ventaDetalles2);
        }

        // GET: VentaDetalles2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VentaDetalles2/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVenta,idProducto,Cantidad")] VentaDetalles2 ventaDetalles2)
        {
            var ven = db.Productos.ToList();
            var producto = ven.Where(a => a.idProducto == ventaDetalles2.idProducto);
            bool hayProducto = producto.Any(n => n.Existencia >= ventaDetalles2.Cantidad);
            
            if (ModelState.IsValid && hayProducto)
            {
                producto.Select(a => a.Existencia -= ventaDetalles2.Cantidad).ToList();
                db.VentaDetalles2.Add(ventaDetalles2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ventaDetalles2);
        }

        // GET: VentaDetalles2/Edit/5
        public ActionResult Edit(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaDetalles2 ventaDetalles2 = db.VentaDetalles2.Find(id, id2);
            if (ventaDetalles2 == null)
            {
                return HttpNotFound();
            }
            return View(ventaDetalles2);
        }

        // POST: VentaDetalles2/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVenta,idProducto,Cantidad")] VentaDetalles2 ventaDetalles2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventaDetalles2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ventaDetalles2);
        }

        // GET: VentaDetalles2/Delete/5
        public ActionResult Delete(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaDetalles2 ventaDetalles2 = db.VentaDetalles2.Find(id, id2);
            if (ventaDetalles2 == null)
            {
                return HttpNotFound();
            }
            return View(ventaDetalles2);
        }

        // POST: VentaDetalles2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id, int? id2)
        {
            VentaDetalles2 ventaDetalles2 = db.VentaDetalles2.Find(id, id2);
            db.VentaDetalles2.Remove(ventaDetalles2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
