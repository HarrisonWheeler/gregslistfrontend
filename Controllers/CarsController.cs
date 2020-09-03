using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using gregslist_api.Models;
using gregslist_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gregslist_api.Controllers
{
  // NOTE use this if you want to lock the entire controller and all its routes
  // [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    private readonly CarsService _service;

    public CarsController(CarsService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Car>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetById(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // NOTE use this if you want to lock just this route
    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Car>> GetMyCars()
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to make a car, yo.");
        }
        return Ok(_service.Get(user.Value));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to make a car, yo.");
        }
        newCar.User = user.Value;
        return Ok(_service.Create(newCar));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to make a car, yo.");
        }
        return Ok(_service.Delete(user.Value, id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Car> Update(int id, [FromBody] Car updatedCar)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to make a car, yo.");
        }
        updatedCar.User = user.Value;
        updatedCar.Id = id;
        return Ok(_service.Update(updatedCar));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}
