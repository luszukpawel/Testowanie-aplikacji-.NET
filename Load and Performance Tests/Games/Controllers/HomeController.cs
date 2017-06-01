using Games.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Games.Models;

namespace Games.Controllers
{

    public class HomeController : Controller
    {
        private GameDBContext db = new GameDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calculate()
        {
            foreach (Game game in LocalDatabase.Games)
            {
                game.Name = BubbleSort.Sort(game.Name);

            }
            return View();
        }



    }
}