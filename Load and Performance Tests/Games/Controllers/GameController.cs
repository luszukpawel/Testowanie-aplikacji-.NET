using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Games.Controllers;
using Games.DAL;
using Games.Models;

namespace MvcGame.Controllers
{
    public class GameController : Controller
    {
        private GameDBContext db = new GameDBContext();
        private HttpClient client = new HttpClient();

        public async Task<ActionResult> Index(string populate = "")
        {
            if (populate != "")
            {
                if (populate == "read")
                {
                    await read();
                }

                if (populate == "write")
                {
                    write();
                }

            }

            var Games = from m in db.Games
                orderby m.Name
                select m;
            return View(Games);
        }


        async Task<bool> read()
        {
            LocalDatabase.Games.Clear();

            for (int i = 1; i < 20; i++)
            {
                HttpResponseMessage response = await client.GetAsync(new Uri("http://pokeapi.co/api/v2/pokemon/" + i));

                var json = await response.Content.ReadAsStringAsync();
                JSONHelper.addToStaticClass(json);
            }
            return true;
        }

        void write()
        {
            foreach (Game Game in db.Games)
            {
                db.Games.Remove(Game);
            }

            foreach (Game Game in LocalDatabase.Games)
            {
                JSONHelper.addToDatabase(Game, db);
            }
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game Game = db.Games.Find(id);
            if (Game == null)
            {
                return HttpNotFound();
            }
            return View(Game);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Alias,doc")] Game Game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(Game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Game);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game Game = db.Games.Find(id);
            if (Game == null)
            {
                return HttpNotFound();
            }
            return View(Game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Game Game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Game);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game Game = db.Games.Find(id);
            if (Game == null)
            {
                return HttpNotFound();
            }
            return View(Game);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game Game = db.Games.Find(id);
            db.Games.Remove(Game);
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