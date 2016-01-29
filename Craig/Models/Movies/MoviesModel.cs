using System.Collections.Generic;
using System.Web.Helpers;

namespace Craig.Models.Movies
{
    public class MoviesModel
    {
        public IEnumerable<MovieModel> Movies { get; set; }
        public int Page { get; set; }
        public int NumberOfPages { get; set; }
        public SortDirection SortDirection { get; set; }
        public string SortColumn { get; set; }
    }
}