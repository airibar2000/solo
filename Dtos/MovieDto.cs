using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using solo.Models;

namespace solo.Dtos
    {
    public class MovieDto
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name too Long")]
        public string Name { get; set; }

        [Required]
        //[ValidationMovie]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Field Number in Stock must be between 1 and 20")]
        public short NumberInStock { get; set; }

        public Genres Genres { get; set; }

        [Display(Name = "Genre Type")]
        public byte GenreId { get; set; }
        }
    }