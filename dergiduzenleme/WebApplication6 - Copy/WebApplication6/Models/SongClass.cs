using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    [Table("songs", Schema = "public")]
    public class SongClass
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "İsim")]
        public string name { get; set; }

        public string singer { get; set; }
        public string album { get; set; }

    }
}