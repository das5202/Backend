﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartWebApi.Models
{
    public class feedback
    {

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UserId { get; set; }
        //public string Feedback { get; set; }

        //public virtual UserDetails UserDetails { get; set; }
        [Key]
        public string Username { get; set; }
        public string Feedback { get; set; }

       public virtual UserDetails UserDetails { get; set; }
    }
}