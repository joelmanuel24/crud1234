using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Data.Entities
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
    }
}
