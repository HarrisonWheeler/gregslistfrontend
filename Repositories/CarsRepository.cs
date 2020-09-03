using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist_api.Models;

namespace gregslist_api.Repositories
{
  public class CarsRepository
  {
    private readonly IDbConnection _db;

    public CarsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Car> Get()
    {
      string sql = "SELECT * FROM cars";
      return _db.Query<Car>(sql);
    }
    public IEnumerable<Car> Get(string userId)
    {
      string sql = "SELECT * FROM cars WHERE user = @User;";
      return _db.Query<Car>(sql, new { userId });
    }

    internal Car GetById(int id)
    {
      string sql = "SELECT * FROM cars WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Car>(sql, new { id });
    }

    public Car Create(Car newCar)
    {
      string sql = @"INSERT INTO cars
            (make, model, year, price, imgUrl, description)
            VALUES
            (@make, @model, @year, @price, @imgUrl, @description, @user);
            SELECT LAST_INSERT_ID();";
      newCar.Id = _db.ExecuteScalar<int>(sql, newCar);
      return newCar;
    }
    public bool Delete(string userId, int id)
    {
      string sql = "DELETE FROM cars WHERE id = @Id AND user = @User LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { userId, id });
      return rowsAffected == 1;
    }

    public bool Update(Car updatedCar)
    {
      string sql = @"UPDATE cars
            SET 
            make = @make,
            price = @price,
            description = @description,
            imgUrl = @imgUrl,
            year = @year
            WHERE id = @id AND user = @user LIMIT 1;";
      int rowsAffected = _db.Execute(sql, updatedCar);
      return rowsAffected == 1;
    }
  }
}