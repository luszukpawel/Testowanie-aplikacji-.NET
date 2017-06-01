using Games.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Games.DAL
{
    public class Gameinitializer : System.Data.Entity.DropCreateDatabaseAlways<GameDBContext>
    {
        protected override void Seed(Games.DAL.GameDBContext context)
        {
            context.Games.AddOrUpdate(i => i.Name,
            new Game
            {
                Name = "The Wish 2"
         
            },

           new Game
           {
               Name = "The Wish",
   
           });
            context.SaveChanges();
        }
    }
}