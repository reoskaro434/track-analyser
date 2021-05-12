using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Models.DBModels;
using TrackAnalyser.Models.ViewModels;

namespace TrackAnalyser.Utilities.Rank
{
    public class Rank : IRank<RankViewModel, IUnitOfWork>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Rank(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public RankViewModel GetRank(int maxSize)
        {
            IEnumerable<Track> tracks = _unitOfWork.Tracks.GetAll();
            List<RankElementViewModel> rankElements = new List<RankElementViewModel>();

            foreach (var track in tracks)
            {
                IEnumerable<TrackStatistic> trackStatistics = _unitOfWork.TrackStatistics.Find(p => p.TrackId == track.Id);
                Artist artist = _unitOfWork.Artists.Find(p => p.Id == track.ArtistId).FirstOrDefault();
                int trackStatisticsSum = 0;
                foreach (var trackStatistic in trackStatistics)
                {
                    IEnumerable<DayStatistic> dayStatistics = _unitOfWork.DayStatistics.Find(p => p.TrackStatisticId == trackStatistic.Id);
                    int dayStatisticsSum = 0;
                    foreach (var day in dayStatistics)
                    {
                        dayStatisticsSum += day.PlayedTimes;
                    }
                    trackStatisticsSum += dayStatisticsSum;
                }

                rankElements.Add(new RankElementViewModel()
                {
                    TrackArtist = artist.Name,
                    TrackName = track.Title,
                    TotalPlayback = trackStatisticsSum
                });
            }
            return new RankViewModel()
            {
                RankElements = rankElements.
                OrderBy(prop => prop.TotalPlayback).
                Reverse().
                Take(maxSize)
            };
        }
    }
}
