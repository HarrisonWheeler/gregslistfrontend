using System.ComponentModel.DataAnnotations;

namespace gregslist_api.Models
{
    public class DTOFavoriteCar
    {
        public int Id { get; set; }
        [Required]
        public int CarId { get; set; }
        public string UserId { get; set; }
    }
}