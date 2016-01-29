namespace Craig.Models.Movies
{
    public class MovieDetailModel
    {
        public string Rating { get; set; }
        public string ReleaseDate { get; set; }
        public string Title { get; set; }
        public string Classification { get; set; }
        public string Genre { get; set; }
        public string[] Cast { get; set; }
    }
}