using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using solo.Models;

namespace solo.ViewModels
    {
    public class CustomerExtras
        {
        public CustomerExtras()
            {
            Id = 0;
            }
        public CustomerExtras(Customer customer)
            {
            Name = customer.Name;
            Birthdate = customer.Birthdate;
            IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            MembershipType = customer.MembershipType;
            MembershipTypeId = customer.MembershipTypeId;
            }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Display(Name = "Date of Birth")]
        //[Min18YearsIfaMember] comment while using DTO
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }


        [Display(Name = "Memebership Type")]
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        }
    }