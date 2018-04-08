﻿using Newtonsoft.Json;
using RadarrSharp.Helpers;
using System;
using System.Threading.Tasks;

namespace RadarrSharp.Endpoints.Calendar
{
    /// <summary>
    /// Calendar endpoint client
    /// </summary>
    public class Calendar : ICalendar
    {
        private RadarrClient _radarrClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Calendar" /> class.
        /// </summary>
        /// <param name="radarrClient">The radarr client.</param>
        public Calendar(RadarrClient radarrClient)
        {
            _radarrClient = radarrClient;
        }

        /// <summary>
        /// Gets upcoming movies, if start/end are not supplied movies airing today and tomorrow will be returned
        /// </summary>
        /// <returns>
        /// Models.Calendar[]
        /// </returns>
        public async Task<Models.Calendar[]> GetCalendar()
        {
            var json = await _radarrClient.GetJson($"/calendar");
            return JsonConvert.DeserializeObject<Models.Calendar[]>(json, Converter.Settings);
        }

        /// <summary>
        /// Gets upcoming movies, between the given time
        /// </summary>
        /// <param name="start">From date</param>
        /// <param name="end">To date</param>
        /// <returns>
        /// Models.Calendar[]
        /// </returns>
        public async Task<Models.Calendar[]> GetCalendar(DateTime start, DateTime end)
        {
            var json = await _radarrClient.GetJson($"/calendar?start={start.ToString("yyyy-MM-dd")}&end={end.ToString("yyyy-MM-dd")}");
            return JsonConvert.DeserializeObject<Models.Calendar[]>(json, Converter.Settings);
        }
    }
}