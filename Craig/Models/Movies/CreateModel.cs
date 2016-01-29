using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Craig.Validation;

namespace Craig.Models.Movies
{
    public class CreateModel
    {
        [StringLength(128)]
        [Required]
        public string Title { get; set; }

        [Required]
        public Classification Classification { get; set; }

        // In a real world example I would use the following package to automatically generate display labels:
        // (https://github.com/MehdiK/Humanizer#mix-this-into-your-framework-to-simplify-your-life)
        [DisplayName("Release Date")]
        [Range(1, 9999)]
        public int ReleaseDate { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [MinLength(1)]
        [CastValidation]
        public string[] Cast { get; set; }
    }

    /// <summary>
    /// If I had more time I would create an overload for @Html.EnumDropDownListFor()
    /// which would read the Description attribute off of the supplied Enum.
    /// I can't make M15 display M15+ on the form as it is.
    /// </summary>
    public enum Classification
    {
        G,
        PG,
        M,
        [Description("M15+")]
        M15,
        R
    }
}