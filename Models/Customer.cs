﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace solo.Models
    {
    public class Customer
        {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Bith")]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name="Memebership Type")]
        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
        }
    }