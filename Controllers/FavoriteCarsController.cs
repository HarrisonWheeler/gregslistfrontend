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

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteCarsController : ControllerBase
    {
        private readonly FavoriteCarsService _service;

        public FavoriteCarsController(FavoriteCarsService service)
        {
            _service = service;
        }


        [HttpPost]
        public ActionResult<DTOFavoriteCar> Create([FromBody] DTOFavoriteCar newFavoriteCar)
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("You must be logged in to favorite a car, yo.");
                }
                newFavoriteCar.UserId = user.Value;
                return Ok(_service.Create(newFavoriteCar));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ViewModelCar>> Get()
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("You must be logged in to get yo favorite cars, yo.");
                }
                return Ok(_service.Get(user.Value));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}
