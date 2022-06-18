using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ticket2.Models
{ 
    public class Ticket
    {
        public string Operation_Type { get; set; }
        
        public string Operration_Time { get; set; }
        
        public string Operation_Place { get; set; }
        
        public Passenger Passenger { get; set; }
        
        public Route[] Routes { get; set; }
        
    }
}