using Microsoft.AspNetCore.Mvc.Rendering;
using Movie.Application.Data.Entities;

namespace Movie.Web.Models
{
    public class MovieViewModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public Movie.Application.Data.Entities.Movie Movie { get; set; }
    }
}
