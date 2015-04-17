using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoBanco.Models;

namespace ProyectoBanco.Controllers
{
    [Authorize(Users="Administrador")]
    public class TipoCuentasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /TipoCuentas/
        public ActionResult Index()
        {
            return View(db.TipoCuentas.ToList());
        }

        // GET: /TipoCuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCuenta tipocuenta = db.TipoCuentas.Find(id);
            if (tipocuenta == null)
            {
                return HttpNotFound();
            }
            return View(tipocuenta);
        }

        // GET: /TipoCuentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoCuentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdTipo,Tipo")] TipoCuenta tipocuenta)
        {
            if (ModelState.IsValid)
            {
                db.TipoCuentas.Add(tipocuenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipocuenta);
        }

        // GET: /TipoCuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCuenta tipocuenta = db.TipoCuentas.Find(id);
            if (tipocuenta == null)
            {
                return HttpNotFound();
            }
            return View(tipocuenta);
        }

        // POST: /TipoCuentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdTipo,Tipo")] TipoCuenta tipocuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipocuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipocuenta);
        }

        // GET: /TipoCuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCuenta tipocuenta = db.TipoCuentas.Find(id);
            if (tipocuenta == null)
            {
                return HttpNotFound();
            }
            return View(tipocuenta);
        }

        // POST: /TipoCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCuenta tipocuenta = db.TipoCuentas.Find(id);
            db.TipoCuentas.Remove(tipocuenta);
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
