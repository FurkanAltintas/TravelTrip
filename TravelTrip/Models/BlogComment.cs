using System;
using System.Collections.Generic;
using System.Linq;
using TravelTrip.Models.EntityFramework;

namespace TravelTrip.Models
{
    public class BlogComment
    {
        public IEnumerable<Blogs> Blog { get; set; }
        public IEnumerable<Comments> Comment { get; set; }
    }
}