using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace solo.Models
    {
    public class MembershipType
        {
        public byte Id { get; set; }
        public short SignUpFee  { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }

        [Display(Name="Membership Type")]
        public string Name { get; set; }
      
        // Declaring Constants

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

        }
    }