//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelTrip.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Admins
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public System.DateTime Date { get; set; }
        public bool Status { get; set; }
        public string Profile { get; set; }
    }
}
