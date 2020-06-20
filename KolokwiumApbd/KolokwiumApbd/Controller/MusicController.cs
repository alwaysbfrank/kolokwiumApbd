using KolokwiumApbd.Service;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumApbd.Controller
{
    [ApiController]
    [Route("api/")]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet]
        [Route("artists/{id}")]
        public IActionResult GetArtist(int id)
        {
            GetArtistResponse getArtistResponse;
            try
            {
                getArtistResponse = _musicService.FindArtist(id);
            }
            catch
            {
                return Problem();
            }

            if (getArtistResponse == null)
            {
                return NotFound();
            }

            return Ok(getArtistResponse);
        }

        [HttpPut]
        [Route("artists/{idArtist}/events/{idEvent}")]
        public IActionResult UpdatePerformanceTime(int idArtist, int idEvent, UpdatePerformanceTimeRequest request)
        {
            if (!request.CheckIfIdsMatch(idArtist, idEvent)
            || !_musicService.UpdateScheduledTime(request))
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}