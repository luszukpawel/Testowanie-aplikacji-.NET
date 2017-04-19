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
    public class GameController : Controller
    {
        private IGamesStudiosDBContext db;

        public GameController()
        {
            db = new GamesStudiosDBContext();
        }

        public GameController(IGamesStudiosDBContext context)
        {
            db = context;
        }

        public ActionResult Index()
        {
            var Games = db.Games.Include(p => p.Genre);
            return View(Games.ToList());
        }

        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }
            Game Game = db.FindGameById(id);
            if (Game == null)
            {
                throw new Exception();
            }
            return View("Details", Game);
        }

        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name");
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GenreID,Name")] Game Game)
        {
            if (ModelState.IsValid)
            {
                db.Add<Game>(Game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name", Game.GenreID);
            return View("Create", Game);
        }

        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }
            Game Game = db.FindGameById(id);
            if (Game == null)
            {
                throw new Exception();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name", Game.GenreID);
            return View("Edit", Game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GenreID,Name")] Game Game)
        {
            if (ModelState.IsValid)
            {
                db.ChangeStateToModified<Game>(Game);
                db.SaveChanges();
                return RedirectToAction("Index", "Game");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name", Game.GenreID);
            return View("Edit", Game);
        }

        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }
            Game Game = db.FindGameById(id);
            if (Game == null)
            {
                throw new Exception();
            }
            return View(Game);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game Game = db.FindGameById(id);
            db.Delete<Game>(Game);
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
