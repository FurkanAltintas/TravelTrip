using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelTrip.Models.EntityFramework;

namespace TravelTrip.Models
{
    public class BlogAboutUs
    {
        public IEnumerable<Blogs> Blog { get; set; }
        public IEnumerable<AboutUs> AboutUs { get; set; }
    }
}