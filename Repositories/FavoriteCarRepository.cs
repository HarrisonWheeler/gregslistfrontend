using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist_api.Models;

namespace gregslist_api.Repositories
{
    public class FavoriteCarsRepository
    {
        private readonly IDbConnection _db;

        public FavoriteCarsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal DTOFavoriteCar Create(DTOFavoriteCar newFavoriteCar)
        {
            string sql = @"INSERT INTO favoriteCars
            (carId, userId)
            VALUES
            (@CarId, @UserId);
            SELECT LAST_INSERT_ID();
            ";
            newFavoriteCar.Id = _db.ExecuteScalar<int>(sql, newFavoriteCar);
            return newFavoriteCar;
        }

        internal IEnumerable<ViewModelCar> Get(string userId)
        {
            string sql = @"
            SELECT
            c.*,
            fc.id as FavoriteCarId
            FROM favoriteCars fc
            INNER JOIN cars c ON c.id = fc.carId
            WHERE userId = @userId;
            ";
            return _db.Query<ViewModelCar>(sql, new { userId });
        }
    }
}