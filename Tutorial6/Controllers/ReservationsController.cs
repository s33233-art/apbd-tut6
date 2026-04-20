using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial6.DTOs;
using Tutorial6.Models;

namespace Tutorial6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        public static List<Reservation> reservations = new List<Reservation>()
        {

        };

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(reservations);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        { 
            var reservation = reservations.FirstOrDefault(x => x.Id == id);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        //INSERT GET FROMQUERY HERE

        [HttpPost]
        public IActionResult Post([FromBody] CreateReservationDto dto)
        {
            var reservation = new Reservation()
            {
                Id = reservations.Count + 1,
                RoomId = dto.RoomId,
                OrganizerName = dto.OrganizerName,
                Topic = dto.Topic,
                Date = dto.Date,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Status = dto.Status
            };

            reservations.Add(reservation);
            
            return CreatedAtAction(nameof(GetById), new {id = reservation.Id}, reservation);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] CreateReservationDto dto)
        {
            var reservation = reservations.Where(x => x.Id == id).FirstOrDefault();
            if (reservation == null) return NotFound();
            reservation.RoomId = dto.RoomId;
            reservation.OrganizerName = dto.OrganizerName;
            reservation.Topic = dto.Topic;
            reservation.Date = dto.Date;
            reservation.StartTime = dto.StartTime;
            reservation.EndTime = dto.EndTime;
            reservation.Status = dto.Status;
            return Ok(reservation);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id) 
        {
            var reservation = reservations.First(x => x.Id == id);
            if (reservation == null) return NotFound();
            reservations.Remove(reservation);
            return NoContent();
        }

    }
}
