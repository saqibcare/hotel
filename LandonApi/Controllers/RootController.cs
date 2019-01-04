using Microsoft.AspNetCore.Mvc;  //use this import for the ControllerBase class by which Rootcontroller is inherited
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Controllers
{
    [Route("/")]  //can be access by simple /
    [ApiController] //this will tell the Asp.netcore that i am building the controller meant for API
    public class RootController : ControllerBase
    {
        [HttpGet (Name = nameof(GetRoot))] //this will be called by get method
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null),
                rooms = new
                {
                    href = Url.Link(nameof(RoomController.GetRooms), null)
                }
            };
            return Ok(response);
        }
    }
}
