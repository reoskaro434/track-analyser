﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.Charts.BarChart
{
    public interface IBarChart<TUnitOfWork> where TUnitOfWork : class
    {
        /// <summary>
        /// Returns JSON string which contains statistics of each day
        /// about total plays of the song.
        /// </summary>
        /// <param name="id">Track id.</param>
        /// <param name="amoun">Amount of returning days.</param>
        /// <param name="dateFormat">Determines date format.</param>
        /// <returns></returns>
        public string GetTrackData(int id, int amoun, string dateFormat);
    }
}
