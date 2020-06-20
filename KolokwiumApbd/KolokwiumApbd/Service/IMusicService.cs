using System;
using KolokwiumApbd.Controller;
using KolokwiumApbd.Models;

namespace KolokwiumApbd.Service
{
    public interface IMusicService
    {
        public GetArtistResponse FindArtist(int artistId);

        public bool UpdateScheduledTime(UpdatePerformanceTimeRequest request);
    }
}