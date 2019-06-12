using solo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace solo.Dtos
    {
    public class CustomerDto
        {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }


       //[Min18YearsIfaMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

              
        public byte MembershipTypeId { get; set; }

            public MembershipDto MembershipType { get; set; }
        }
    }