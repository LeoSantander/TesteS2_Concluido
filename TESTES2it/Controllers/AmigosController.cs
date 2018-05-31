using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TESTEs2it.Models;

namespace TESTEs2it.Controllers
{
    public class AmigosController : Controller
    {
        private TesteS2ITEntities db = new TesteS2ITEntities();

        // GET: Amigos
        public ActionResult Index()
        {
            return View(db.amigos.ToList());
        }

        // GET: Amigos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            amigos amigos = db.amigos.Find(id);
            if (amigos == null)
            {
                return HttpNotFound();
            }
            return View(amigos);
        }

        // GET: Amigos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amigos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NM_Amigo,Telefone,Email,UserID")] amigos amigos)
        {
            if (ModelState.IsValid)
            {
                db.amigos.Add(amigos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amigos);
        }

        // GET: Amigos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            amigos amigos = db.amigos.Find(id);
            if (amigos == null)
            {
                return HttpNotFound();
            }
            return View(amigos);
        }

        // POST: Amigos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AmigoID,NM_Amigo,Telefone,Email,UserID")] amigos amigos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amigos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amigos);
        }

        // GET: Amigos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            amigos amigos = db.amigos.Find(id);
            if (amigos == null)
            {
                return HttpNotFound();
            }
            return View(amigos);
        }

        // POST: Amigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            amigos amigos = db.amigos.Find(id);
            db.amigos.Remove(amigos);
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
