using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Games.Models
{
    public class Game
    {
        public int ID { get; set; }
        [Display(Name = "Game Name")]
        public string Name { get; set; }
 
    }
}