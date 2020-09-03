using System.ComponentModel.DataAnnotations;

namespace gregslist_api.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Price { get; set; }
        public string Description { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        public string User { get; set; }
    }

    public class ViewModelCar : Car
    {
        // NOTE this is the relationship id
        public int FavoriteCarId { get; set; }
        // public ViewModelCar()
        // {

        // }

        // this is where you could pass the car to "Base" which is your parent class in the inheritance chain. "Car"
        // public ViewModelCar(Car car) : base(car)
        // {
        // CarId = car.Id
        // }

    }
}