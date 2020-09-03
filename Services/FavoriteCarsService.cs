using System;
using System.Collections;
using System.Collections.Generic;
using gregslist_api.Models;
using gregslist_api.Repositories;

namespace gregslist_api.Services
{
    public class FavoriteCarsService
    {
        private readonly FavoriteCarsRepository _repo;
        private readonly CarsService _carService;

        public FavoriteCarsService(FavoriteCarsRepository repo, CarsService carService)
        {
            _repo = repo;
            _carService = carService;
        }

        internal DTOFavoriteCar Create(DTOFavoriteCar newFavoriteCar)
        {
            // Car car = _carService.GetById(newFavoriteCar.CarId);
            // newFavoriteCar = _repo.Create(newFavoriteCar);
            // ViewModelCar favoriteCar = new ViewModelCar();
            return _repo.Create(newFavoriteCar);
        }

        internal IEnumerable<ViewModelCar> Get(string userId)
        {
            return _repo.Get(userId);
        }
    }
}