using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GamesStudios.DAL;
using GamesStudios.Models;

namespace GamesStudios.Controllers
{
    public class GenreController : Controller
    {
        private IGamesStudiosDBContext db;

        public GenreController()
        {
            db = new GamesStudiosDBContext();
        }

        public GenreController(IGamesStudiosDBContext context)
        {
            db = context;
        }

        public ActionResult Index(){
            var Genres = from m in db.Genres orderby m.ID select m;
            return View("Index", Genres);
        }

        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre Genre = db.FindGenreById(id);
            if (Genre == null)
            {
                throw new Exception();
            }
            return View("Details", Genre);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Genre Genre)
        {
            if (ModelState.IsValid)
            {
                db.Add<Genre>(Genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", Genre);
        }

        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }
            Genre Genre = db.FindGenreById(id);
            if (Genre == null)
            {
                throw new Exception();
            }
            return View("Edit", Genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,doc")] Genre Genre)
        {
            if (ModelState.IsValid)
            {
                db.ChangeStateToModified<Genre>(Genre);
                db.SaveChanges();
                return RedirectToAction("Index", "Genre");
            }
            return View("Edit", Genre);
        }

        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }
            Genre Genre = db.FindGenreById(id);
            if (Genre == null)
            {
                throw new Exception();
            }
            return View(Genre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre Genre = db.FindGenreById(id);
            db.Delete<Genre>(Genre);
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
