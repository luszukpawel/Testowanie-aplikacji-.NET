using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace GamesStudios.Models
{
    public class Genre
    {
        public int ID { get; set; }
        [Display(Name = "Genre Name")]
        [RegularExpression("[,.żźćńółęąśŻŹĆĄŚĘŁÓŃA-Za-z ]+", ErrorMessage = "Name must contains only letters")]
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}