using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial6.DTOs;
using Tutorial6.Models;

namespace Tutorial6.Controllers
{
    // api/rooms
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        public static List<Room> rooms = new List<Room>()
        {

        };
        
        // GET api/rooms
        [HttpGet]
        public IActionResult Get()
        {
            // 200 Ok
            return Ok(rooms);
        }

        // GET api/rooms/{id}
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetById([FromRoute] int id)
        {
            var room = rooms.FirstOrDefault(x => x.Id == id);
            if (room == null) return NotFound();
            return Ok(room);
        }

        public IActionResult GetFromBuilding([FromRoute] string building)
        {
            var room = rooms.Where(x => x.BuildingCode == building).ToList();
            if (room.Count() == 0) return NotFound();
            return Ok(room);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateRoomDto dto)
        {
            var room = new Room()
            {
                Id = rooms.Count + 1,
                Name = dto.Name,
                BuildingCode = dto.BuildingCode,
                Floor = dto.Floor,
                Capacity = dto.Capacity,
                HasProjector = dto.HasProjector,
                IsActive = dto.IsActive
            };
            
            rooms.Add(room);
            
            return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
        }
    }
}
