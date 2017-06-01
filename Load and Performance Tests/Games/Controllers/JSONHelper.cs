using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using Games.Models;
using Games.DAL;
using System.Diagnostics;

namespace Games.Controllers
{
    public static class JSONHelper
    {
        public static void addToDatabase(Game Game, GameDBContext db)
        {
            db.Games.Add(Game);
            db.SaveChanges();
        }


        public static void addToStaticClass(string jsonString)
        {
            Game game = new Game();
            Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(jsonString);
            game.Name = jObject["name"].ToString();
      
            LocalDatabase.Games.Add(game);
        }
    }
}