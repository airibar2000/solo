using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using solo.Models;

namespace solo.ViewModels
    {
    public class ViewDetail
        {
        public List<Customer> ListCustomer { get; set; }
        public int ID { get; set; }
        public string NAME {get; set;}
        
        }
    }