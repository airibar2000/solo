﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace solo.Models
    {
    public class Genres
        {
        [Key]
        public byte GenreId { get; set; }
        public string GenreName { get; set; }
        }
    }