using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BootcampBlog.Models;

namespace BootcampBlog.Controllers
{
    public class ComentariosController : Controller
    {
        private BlogBootcampEntities1 db = new BlogBootcampEntities1();

        // GET: Comentarios
        //public ActionResult Index()
        //{
        //    var comentarios = db.Comentarios.Include(c => c.Post);
        //    return View(comentarios.ToList());
        //}

        // GET: Comentarios/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comentarios comentarios = db.Comentarios.Find(id);
        //    if (comentarios == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(comentarios);
        //}

        // GET: Comentarios/Create
        public ActionResult Create(int? id)
        {
            ViewData["id"] = id;
            ViewBag.PostId = new SelectList(db.Post, "Id", "Titulo");
            return View();
        }

        // POST: Comentarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Autor,Comentario,Fecha,PostId")] Comentarios comentarios)
        {
            if (ModelState.IsValid)
            {
                db.Comentarios.Add(comentarios);
                db.SaveChanges();
                return RedirectToAction("../Posts");
            }

            ViewBag.PostId = new SelectList(db.Post, "Id", "Titulo", comentarios.PostId);
            return View(comentarios);
        }

        // GET: Comentarios/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comentarios comentarios = db.Comentarios.Find(id);
        //    if (comentarios == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.PostId = new SelectList(db.Post, "Id", "Titulo", comentarios.PostId);
        //    return View(comentarios);
        //}

        // POST: Comentarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Autor,Comentario,Fecha,PostId")] Comentarios comentarios)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(comentarios).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.PostId = new SelectList(db.Post, "Id", "Titulo", comentarios.PostId);
        //    return View(comentarios);
        //}

        // GET: Comentarios/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comentarios comentarios = db.Comentarios.Find(id);
        //    if (comentarios == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(comentarios);
        //}

        // POST: Comentarios/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Comentarios comentarios = db.Comentarios.Find(id);
        //    db.Comentarios.Remove(comentarios);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
