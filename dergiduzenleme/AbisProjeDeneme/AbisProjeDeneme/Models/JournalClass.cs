using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AbisProjeDeneme.Models
{
    [Table("adana",Schema = "public")]
    public class JournalClass
    {
        [Key]
        public int Id { get; set; }

        [Required]  
        public string Name { get; set; }    
        public string Group { get; set; } 
        public string IsISI { get; set; }   
         
    }
}