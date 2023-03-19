using Microsoft.AspNetCore.Mvc.Rendering;
using MovieMVC.Models.DTO;

namespace MovieMVC.Models.ViewModels
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        public List<MovieDTO> mList { get; set; }
        public List<SelectListItem> DropDownForCategory { get; set; }
    }
}
