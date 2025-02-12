﻿using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class Form
    {
        //Properties of the form with get and set included for each
        [Required]
        [Key]
        public int ApplicationID { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }
    }
}
