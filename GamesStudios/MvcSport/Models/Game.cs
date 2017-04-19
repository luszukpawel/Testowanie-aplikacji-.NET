using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesStudios.Models
{
    public class Game
    {
        public int ID { get; set; }
        [Display(Name = "Genre Name")]
        public int GenreID { get; set; }
        [Display(Name = "Title")]
   
        public string Name { get; set; }

        public virtual Genre Genre { get; set; }
    }
}