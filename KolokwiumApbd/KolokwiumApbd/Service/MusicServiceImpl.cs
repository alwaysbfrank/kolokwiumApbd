using System;
using System.Linq;
using KolokwiumApbd.Controller;
using KolokwiumApbd.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumApbd.Service
{
    public class MusicServiceImpl : IMusicService
    {
        private readonly Database _db;

        public MusicServiceImpl(Database db)
        {
            _db = db;
        }

        public GetArtistResponse FindArtist(int artistId)
        {
            var result = _db.Artists
                .Include(artist => artist.ArtistEvents)
                .ThenInclude(artistEvent => artistEvent.Event)
                .SingleOrDefault(artist => artist.Id == artistId);

            if (result == null)
            {
                return null;
            }

            var events = result
                .ArtistEvents
                .Select(artistEvent => artistEvent.Event)
                .OrderByDescending(eventObject => eventObject.StartDate.Year)
                .ToList();

            return new GetArtistResponse()
            {
                Id = result.Id,
                Nickname = result.Nickname,
                Events = events
            };
        }

        public bool UpdateScheduledTime(UpdatePerformanceTimeRequest request)
        {
            var artistEvent = _db.ArtistEvents
                .Include(ae => ae.Event)
                .SingleOrDefault(ae => ae.ArtistId == request.ArtistId && ae.EventId == request.EventId);

            if (!ValidateScheduledTimeUpdate(artistEvent, request.PerformanceDate))
            {
                return false;
            }

            artistEvent.PerformanceDate = request.PerformanceDate;
            _db.SaveChanges();
            return true;
        }

        private static bool ValidateScheduledTimeUpdate(ArtistEvent oldEntry, DateTime newTime)
        {
            return oldEntry != null
                   && oldEntry.Event.StartDate < newTime
                   && oldEntry.Event.EndTime > newTime;
        }
    }
}