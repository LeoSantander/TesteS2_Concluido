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
    public class JogosController : Controller
    {
        private TesteS2ITEntities db = new TesteS2ITEntities();

        // GET: Jogos
        public ActionResult Index()
        {
            return View(db.jogos.ToList());
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jogos jogos = db.jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JogoID,Nome_Jogo,UserID,SN_Emprestado,NM_Amigo")] jogos jogos)
        {
            if (ModelState.IsValid)
            {
                db.jogos.Add(jogos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jogos);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jogos jogos = db.jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JogoID,Nome_Jogo,UserID,SN_Emprestado,NM_Amigo")] jogos jogos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jogos);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jogos jogos = db.jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            jogos jogos = db.jogos.Find(id);
            db.jogos.Remove(jogos);
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
