using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Models;

namespace TrackAnalyser.Utilities
{
    public class DataInitializer
    {
        static public void SetDatabase(IUnitOfWork unitOfWork)
        {
            unitOfWork.Artists.Add(new Artist()
            {
                Name = "Savant",
               // Tracks = new List<Track>() { }
            });
            unitOfWork.Artists.Add(new Artist()
            {
                Name = "Infected Mushroom",
                //Tracks = new List<Track>() {  }
            });
            unitOfWork.Artists.Add(new Artist()
            {
                Name = "Iron Maiden",
               // Tracks = new List<Track>() {  }
            });
            unitOfWork.Artists.Add(new Artist()
            {
                Name = "Blind Guardian",
               // Tracks = new List<Track>() { }
            });

            unitOfWork.Save();

            Artist savant = unitOfWork.Artists.Find(predicate => predicate.Name == "Savant").FirstOrDefault();
            Artist infectedMuschroom = unitOfWork.Artists.Find(predicate => predicate.Name == "Infected Mushroom").FirstOrDefault();
            Artist ironMaiden = unitOfWork.Artists.Find(predicate => predicate.Name == "Iron Maiden").FirstOrDefault();
            Artist blindGuardian = unitOfWork.Artists.Find(predicate => predicate.Name == "Blind Guardian").FirstOrDefault();

            unitOfWork.Tracks.Add(new Track()
            {
                CoverPicturePath = "/pictures/savant_zion.jpg",
                Duration = new DateTime(1, 1, 1, 0, 3, 34),
                Description = "To celebrate his 10th album release," +
                " Savant is taking you to Zion. Experience Mideastern " +
                "diddies and flurishes over urban and futuristic beats " +
                "crafted by the mad scientist of the electronic music world.",
                Title = "Desert Eagle",
                Version = "Radio Version",
                Artist = savant
            });
            unitOfWork.Tracks.Add(new Track()
            {
                CoverPicturePath = "/pictures/savant_zion.jpg",
                Duration = new DateTime(1, 1, 1, 0, 7, 12),
                Description = "To celebrate his 10th album release," +
               " Savant is taking you to Zion. Experience Mideastern " +
               "diddies and flurishes over urban and futuristic beats " +
               "crafted by the mad scientist of the electronic music world.",
                Title = "Apocalypse",
                Version = "Radio Version",
                Artist = savant
            });
            unitOfWork.Tracks.Add(new Track()
            {
                CoverPicturePath = "/pictures/savant_alchemist.jpg",
                Duration = new DateTime(1, 1, 1, 0, 4, 16),
                Description = "Alchemist is the seventh album by Norwegian electronic dance music" +
                " producer Aleksander Vinter, and his fifth under the alias \"Savant\".It was released " +
                "on 12 December 2012. It is his longest album in total track length to date.",
                Title = "The Beginning Is Near",
                Version = "Original Mix",
                Artist = savant
            });
            unitOfWork.Tracks.Add(new Track()
            {
                CoverPicturePath = "/pictures/infected_mushroom_army_of_mushrooms.jpg",
                Duration = new DateTime(1, 1, 1, 0, 6, 6),
                Description = "Similar to the release of Vicious Delicious, Army of Mushrooms differs greatly from" +
                " their previous styles, with experimentation in dubstep, electro house, and drum and bass. " +
                "Some versions of the album contain a remixed version of \"Bust A Move\" from Classical Mushroom titled \"Bust" +
                " A Move(Infected Remix)\"",
                Title = "Never Mind",
                Version = "Explicit Version",
                Artist = infectedMuschroom
            });

            unitOfWork.Tracks.Add(new Track()
            {
                CoverPicturePath = "/pictures/iron_maiden_powerslave.jpg",
                Duration = new DateTime(1, 1, 1, 0, 4, 32),
                Description = "\"Aces High\" is a song by English heavy metal band Iron Maiden, written by the band's bassist Steve Harris. It is Iron Maiden's eleventh single release and the second from their fifth studio album, Powerslave (1984).",
                Title = "Aces High",
                Version = "Remaster Version",
                Artist = ironMaiden
            });
            unitOfWork.Tracks.Add(new Track()
            {
                CoverPicturePath = "/pictures/blind_guardian_nightfall_in_middle-earth.jpg",
                Duration = new DateTime(1, 1, 1, 0, 5, 34),
                Description = "The album has been described as \"grandiose\" and influenced " +
                "by progressive rock, and has been compared to Queen's operatic approach with \"dense " +
                "choir - like vocal harmonies set against swirling multi - part guitar lines.\"",
                Title = "Nightfall",
                Version = "Radio Version",
                Artist = blindGuardian
            });

            unitOfWork.Save();
       

            Track savant1 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Desert Eagle").FirstOrDefault();
            Track savant2 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Apocalypse").FirstOrDefault();
            Track savant3 = unitOfWork.Tracks.Find(predicate => predicate.Title == "The Beginning Is Near").FirstOrDefault();
            Track ironmaiden1 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Aces High").FirstOrDefault();
            Track infectedmuschroom1 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Never Mind").FirstOrDefault();
            Track blindguardian1 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Nightfall").FirstOrDefault();

            savant = unitOfWork.Artists.Find(predicate => predicate.Name == "Savant").FirstOrDefault();
            infectedMuschroom = unitOfWork.Artists.Find(predicate => predicate.Name == "Infected Mushroom").FirstOrDefault();
            ironMaiden = unitOfWork.Artists.Find(predicate => predicate.Name == "Iron Maiden").FirstOrDefault();
            blindGuardian = unitOfWork.Artists.Find(predicate => predicate.Name == "Blind Guardian").FirstOrDefault();

            savant.Tracks = new List<Track>() { savant1 , savant2 , savant3 };
            infectedMuschroom.Tracks = new List<Track>() { infectedmuschroom1 };
            ironMaiden.Tracks = new List<Track>() { ironmaiden1 };
            blindGuardian.Tracks = new List<Track>() { blindguardian1 };

            unitOfWork.Save();

            #region Canals

            unitOfWork.Canals.Add(new Canal()
            {
                Name = "RadioS",
            });
            unitOfWork.Canals.Add(new Canal()
            {
                Name = "AntRadio",
            });
            unitOfWork.Canals.Add(new Canal()
            {
                Name = "XYZMusic",
            });

            unitOfWork.Save();
            #endregion

            #region TracksStatstics


            DayStatistic dayStatistic1 = new DayStatistic() { Day = new DateTime(2020, 6, 10, 0, 0, 0), PlayedTimes = 432 };
            DayStatistic dayStatistic2 = new DayStatistic() { Day = new DateTime(2020, 6, 10, 0, 0, 0), PlayedTimes = 32 };
            DayStatistic dayStatistic3 = new DayStatistic() { Day = new DateTime(2020, 6, 10, 0, 0, 0), PlayedTimes = 212 };
            DayStatistic dayStatistic4 = new DayStatistic() { Day = new DateTime(2020, 6, 11, 0, 0, 0), PlayedTimes = 152 };
            DayStatistic dayStatistic5 = new DayStatistic() { Day = new DateTime(2020, 6, 11, 0, 0, 0), PlayedTimes = 713 };
            DayStatistic dayStatistic6 = new DayStatistic() { Day = new DateTime(2020, 6, 11, 0, 0, 0), PlayedTimes = 512 };
            DayStatistic dayStatistic7 = new DayStatistic() { Day = new DateTime(2020, 6, 12, 0, 0, 0), PlayedTimes = 96 };
            DayStatistic dayStatistic8 = new DayStatistic() { Day = new DateTime(2020, 6, 12, 0, 0, 0), PlayedTimes = 993 };
            DayStatistic dayStatistic9 = new DayStatistic() { Day = new DateTime(2020, 6, 12, 0, 0, 0), PlayedTimes = 34 };
            DayStatistic dayStatistic10 = new DayStatistic() { Day = new DateTime(2020, 6, 12, 0, 0, 0), PlayedTimes = 122 };
            DayStatistic dayStatistic11 = new DayStatistic() { Day = new DateTime(2020, 6, 13, 0, 0, 0), PlayedTimes = 531 };
            DayStatistic dayStatistic12 = new DayStatistic() { Day = new DateTime(2020, 6, 13, 0, 0, 0), PlayedTimes = 442 };
            DayStatistic dayStatistic13 = new DayStatistic() { Day = new DateTime(2020, 6, 13, 0, 0, 0), PlayedTimes = 13 };
            DayStatistic dayStatistic14 = new DayStatistic() { Day = new DateTime(2020, 6, 13, 0, 0, 0), PlayedTimes = 52 };
            DayStatistic dayStatistic15 = new DayStatistic() { Day = new DateTime(2020, 6, 15, 0, 0, 0), PlayedTimes = 82 };
            DayStatistic dayStatistic16 = new DayStatistic() { Day = new DateTime(2020, 6, 15, 0, 0, 0), PlayedTimes = 82 };
            DayStatistic dayStatistic17 = new DayStatistic() { Day = new DateTime(2020, 6, 15, 0, 0, 0), PlayedTimes = 82 };
            DayStatistic dayStatistic18 = new DayStatistic() { Day = new DateTime(2020, 6, 15, 0, 0, 0), PlayedTimes = 82 };
            DayStatistic dayStatistic19 = new DayStatistic() { Day = new DateTime(2020, 6, 15, 0, 0, 0), PlayedTimes = 82 };
            DayStatistic dayStatistic20 = new DayStatistic() { Day = new DateTime(2020, 6, 15, 0, 0, 0), PlayedTimes = 82 };

            TrackStatistic trackStatistic1 = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() { dayStatistic1, dayStatistic2, dayStatistic3, dayStatistic4, dayStatistic5 },
                Track = savant1
            };
            TrackStatistic trackStatistic2 = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() { dayStatistic6, dayStatistic7, dayStatistic8 },
                Track = savant2
            };
            TrackStatistic trackStatistic3 = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() { dayStatistic9, dayStatistic10, dayStatistic11 },
                Track = savant3
            };
            TrackStatistic trackStatistic4 = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() { dayStatistic12, dayStatistic13, dayStatistic14 },
                Track = infectedmuschroom1
            };
            TrackStatistic trackStatistic5 = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() { dayStatistic15, dayStatistic16, dayStatistic17 },
                Track = ironmaiden1
            };
            TrackStatistic trackStatistic6 = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() { dayStatistic18, dayStatistic19, dayStatistic20 },
                Track = blindguardian1
            };
            #endregion

            #region TrackEmission

            Canal canal1 = unitOfWork.Canals.Find(predicate => predicate.Name == "RadioS").FirstOrDefault();
            Canal canal2 = unitOfWork.Canals.Find(predicate => predicate.Name == "AntRadio").FirstOrDefault();
            Canal canal3 = unitOfWork.Canals.Find(predicate => predicate.Name == "XYZMusic").FirstOrDefault();
            canal1.TrackStatistics = new List<TrackStatistic> { trackStatistic1, trackStatistic2 };
            canal2.TrackStatistics = new List<TrackStatistic> { trackStatistic3, trackStatistic4 };
            canal3.TrackStatistics = new List<TrackStatistic> { trackStatistic5, trackStatistic6 };

            unitOfWork.Canals.Update(canal1);
            unitOfWork.Canals.Update(canal2);
            unitOfWork.Canals.Update(canal3);

            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = savant1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 13, 22, 13, 4),
                EmissionTime = savant1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = savant1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 14, 22, 13, 4),
                EmissionTime = savant1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = savant2,
                Canal = canal2,
                BeginDateTime = new DateTime(2020, 7, 15, 22, 13, 4),
                EmissionTime = savant2.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = savant2,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 15, 22, 13, 4),
                EmissionTime = savant2.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = savant3,
                Canal = canal3,
                BeginDateTime = new DateTime(2020, 7, 15, 20, 13, 4),
                EmissionTime = savant3.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = ironmaiden1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 18, 16, 0, 0),
                EmissionTime = ironmaiden1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = ironmaiden1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 18, 18, 0, 0),
                EmissionTime = ironmaiden1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = ironmaiden1,
                Canal = canal2,
                BeginDateTime = new DateTime(2020, 7, 17, 17, 0, 0),
                EmissionTime = ironmaiden1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = ironmaiden1,
                Canal = canal2,
                BeginDateTime = new DateTime(2020, 7, 17, 19, 0, 0),
                EmissionTime = ironmaiden1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = infectedmuschroom1,
                Canal = canal3,
                BeginDateTime = new DateTime(2020, 7, 15, 15, 11, 0),
                EmissionTime = infectedmuschroom1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = infectedmuschroom1,
                Canal = canal3,
                BeginDateTime = new DateTime(2020, 7, 15, 13, 41, 0),
                EmissionTime = infectedmuschroom1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = infectedmuschroom1,
                Canal = canal3,
                BeginDateTime = new DateTime(2020, 7, 15, 12, 33, 0),
                EmissionTime = infectedmuschroom1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = blindguardian1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 16, 14, 43, 0),
                EmissionTime = blindguardian1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = blindguardian1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 16, 13, 43, 0),
                EmissionTime = blindguardian1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = blindguardian1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 16, 12, 11, 0),
                EmissionTime = blindguardian1.Duration
            }); unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = blindguardian1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 16, 11, 31, 0),
                EmissionTime = blindguardian1.Duration
            });

            #endregion

            unitOfWork.Save();
        }
    }
}

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Models;

namespace TrackAnalyser.Utilities
{
    public class DataInitializer
    {   
        static public void SetDatabase(IUnitOfWork unitOfWork)
        {
            #region Tracks
        
            unitOfWork.Tracks.Add(new Track() 
            {
                CoverPicturePath = "/pictures/savant_zion.jpg",
                Duration = new DateTime(1, 1, 1, 0, 3, 34),
                Description = "To celebrate his 10th album release," +
                " Savant is taking you to Zion. Experience Mideastern " +
                "diddies and flurishes over urban and futuristic beats " +
                "crafted by the mad scientist of the electronic music world.",
                Title = "Desert Eagle",
                Version = "Radio Version"
            });
            unitOfWork.Tracks.Add(new Track()
            {
                CoverPicturePath = "/pictures/savant_zion.jpg",
                Duration = new DateTime(1, 1, 1, 0, 7, 12),
                Description = "To celebrate his 10th album release," +
               " Savant is taking you to Zion. Experience Mideastern " +
               "diddies and flurishes over urban and futuristic beats " +
               "crafted by the mad scientist of the electronic music world.",
                Title = "Apocalypse",
                Version = "Radio Version"
            });
            unitOfWork.Tracks.Add(new Track()
            {
                CoverPicturePath = "/pictures/savant_alchemist.jpg",
                Duration = new DateTime(1, 1, 1, 0, 4, 16),
                Description = "Alchemist is the seventh album by Norwegian electronic dance music" +
                " producer Aleksander Vinter, and his fifth under the alias \"Savant\".It was released " +
                "on 12 December 2012. It is his longest album in total track length to date.",
                Title = "The Beginning Is Near",
                Version = "Original Mix"
            });
            unitOfWork.Tracks.Add(new Track()
            {
                CoverPicturePath = "/pictures/infected_mushroom_army_of_mushrooms.jpg",
                Duration = new DateTime(1, 1, 1, 0, 6, 6),
                Description = "Similar to the release of Vicious Delicious, Army of Mushrooms differs greatly from" +
                " their previous styles, with experimentation in dubstep, electro house, and drum and bass. " +
                "Some versions of the album contain a remixed version of \"Bust A Move\" from Classical Mushroom titled \"Bust" +
                " A Move(Infected Remix)\"",
                Title = "Never Mind",
                Version = "Explicit Version"
            });

            unitOfWork.Tracks.Add(new Track()
            {
                CoverPicturePath = "/pictures/iron_maiden_powerslave.jpg",
                Duration = new DateTime(1, 1, 1, 0, 4, 32),
                Description = "\"Aces High\" is a song by English heavy metal band Iron Maiden, written by the band's bassist Steve Harris. It is Iron Maiden's eleventh single release and the second from their fifth studio album, Powerslave (1984).",
                Title = "Aces High",
                Version = "Remaster Version"
            });
            unitOfWork.Tracks.Add(new Track()
            {
                CoverPicturePath = "/pictures/blind_guardian_nightfall_in_middle-earth.jpg",
                Duration = new DateTime(1, 1, 1, 0, 5, 34),
                Description = "The album has been described as \"grandiose\" and influenced " +
                "by progressive rock, and has been compared to Queen's operatic approach with \"dense " +
                "choir - like vocal harmonies set against swirling multi - part guitar lines.\"",
                Title = "Nightfall",
                Version = "Radio Version"
            });

            unitOfWork.Save();
            #endregion

            #region Artists
            Track savant1 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Desert Eagle").FirstOrDefault();
            Track savant2 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Apocalypse").FirstOrDefault();
            Track savant3 = unitOfWork.Tracks.Find(predicate => predicate.Title == "The Beginning Is Near").FirstOrDefault();
            Track ironmaiden1 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Aces High").FirstOrDefault();
            Track infectedmuschroom1 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Never Mind").FirstOrDefault();
            Track blindguardian1 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Nightfall").FirstOrDefault();

            unitOfWork.Artists.Add(new Artist()
            {
                Name = "Savant",
                Tracks = new List<Track>() { savant1, savant2,savant3 }
            });
            unitOfWork.Artists.Add(new Artist()
            {
                Name = "Infected Mushroom",
                Tracks = new List<Track>() { infectedmuschroom1 }
            });
            unitOfWork.Artists.Add(new Artist()
            {
                Name = "Iron Maiden",
                Tracks = new List<Track>() { ironmaiden1 }
            });
            unitOfWork.Artists.Add(new Artist()
            {
                Name = "Blind Guardian",
                Tracks = new List<Track>() { blindguardian1 }
            });

            unitOfWork.Save();
            #endregion

            #region UpdateTracksWithArtists
            Artist savant = unitOfWork.Artists.Find(predicate => predicate.Name == "Savant").FirstOrDefault();
            Artist infectedMuschroom = unitOfWork.Artists.Find(predicate => predicate.Name == "Infected Mushroom").FirstOrDefault();
            Artist ironMaiden = unitOfWork.Artists.Find(predicate => predicate.Name == "Iron Maiden").FirstOrDefault();
            Artist blindGuardian = unitOfWork.Artists.Find(predicate => predicate.Name == "Blind Guardian").FirstOrDefault();
            savant1.Artist = savant;
            savant2.Artist = savant;
            savant3.Artist = savant;
            infectedmuschroom1.Artist = infectedMuschroom;
            ironmaiden1.Artist = ironMaiden;
            blindguardian1.Artist = blindGuardian;
            
            unitOfWork.Tracks.Update(savant1);
            unitOfWork.Tracks.Update(savant2);
            unitOfWork.Tracks.Update(savant3);
            unitOfWork.Tracks.Update(infectedmuschroom1);
            unitOfWork.Tracks.Update(ironmaiden1);
            unitOfWork.Tracks.Update(blindguardian1);
            unitOfWork.Save();
            #endregion

            #region Canals

            unitOfWork.Canals.Add(new Canal()
            {
                Name = "RadioS",
            });
            unitOfWork.Canals.Add(new Canal()
            {
                Name = "AntRadio",
            });
            unitOfWork.Canals.Add(new Canal()
            {
                Name = "XYZMusic",
            });

            unitOfWork.Save();
            #endregion

            #region TracksStatstics

      
            DayStatistic dayStatistic1 = new DayStatistic() { Day = new DateTime(2020, 6, 10, 0, 0, 0),PlayedTimes = 432 };
            DayStatistic dayStatistic2 = new DayStatistic() { Day = new DateTime(2020, 6, 10, 0, 0, 0),PlayedTimes = 32 };
            DayStatistic dayStatistic3 = new DayStatistic() { Day = new DateTime(2020, 6, 10, 0, 0, 0),PlayedTimes = 212 };
            DayStatistic dayStatistic4 = new DayStatistic() { Day = new DateTime(2020, 6, 11, 0, 0, 0),PlayedTimes = 152 };
            DayStatistic dayStatistic5 = new DayStatistic() { Day = new DateTime(2020, 6, 11, 0, 0, 0),PlayedTimes = 713 };
            DayStatistic dayStatistic6 = new DayStatistic() { Day = new DateTime(2020, 6, 11, 0, 0, 0),PlayedTimes = 512 };
            DayStatistic dayStatistic7 = new DayStatistic() { Day = new DateTime(2020, 6, 12, 0, 0, 0),PlayedTimes = 96 };
            DayStatistic dayStatistic8 = new DayStatistic() { Day = new DateTime(2020, 6, 12, 0, 0, 0),PlayedTimes = 993 };
            DayStatistic dayStatistic9 = new DayStatistic() { Day = new DateTime(2020, 6, 12, 0, 0, 0),PlayedTimes = 34 };
            DayStatistic dayStatistic10 = new DayStatistic() { Day = new DateTime(2020, 6, 12, 0, 0, 0),PlayedTimes = 122 };
            DayStatistic dayStatistic11 = new DayStatistic() { Day = new DateTime(2020, 6, 13, 0, 0, 0),PlayedTimes = 531 };
            DayStatistic dayStatistic12 = new DayStatistic() { Day = new DateTime(2020, 6, 13, 0, 0, 0),PlayedTimes = 442 };
            DayStatistic dayStatistic13 = new DayStatistic() { Day = new DateTime(2020, 6, 13, 0, 0, 0),PlayedTimes = 13 };
            DayStatistic dayStatistic14 = new DayStatistic() { Day = new DateTime(2020, 6, 13, 0, 0, 0),PlayedTimes = 52 };
            DayStatistic dayStatistic15 = new DayStatistic() { Day = new DateTime(2020, 6, 15, 0, 0, 0),PlayedTimes = 82 };
            DayStatistic dayStatistic16 = new DayStatistic() { Day = new DateTime(2020, 6, 15, 0, 0, 0),PlayedTimes = 82 };
            DayStatistic dayStatistic17 = new DayStatistic() { Day = new DateTime(2020, 6, 15, 0, 0, 0),PlayedTimes = 82 };
            DayStatistic dayStatistic18 = new DayStatistic() { Day = new DateTime(2020, 6, 15, 0, 0, 0),PlayedTimes = 82 };
            DayStatistic dayStatistic19 = new DayStatistic() { Day = new DateTime(2020, 6, 15, 0, 0, 0),PlayedTimes = 82 };
            DayStatistic dayStatistic20= new DayStatistic() { Day = new DateTime(2020, 6, 15, 0, 0, 0),PlayedTimes = 82 };

            TrackStatistic trackStatistic1 = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() { dayStatistic1, dayStatistic2, dayStatistic3, dayStatistic4, dayStatistic5 },
                Track = savant1
            };
            TrackStatistic trackStatistic2 = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() { dayStatistic6, dayStatistic7, dayStatistic8 },
                Track = savant2
            };
            TrackStatistic trackStatistic3 = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() { dayStatistic9, dayStatistic10, dayStatistic11 },
                Track = savant3
            };
            TrackStatistic trackStatistic4 = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() { dayStatistic12, dayStatistic13, dayStatistic14 },
                Track = infectedmuschroom1
            };
            TrackStatistic trackStatistic5 = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() { dayStatistic15, dayStatistic16, dayStatistic17 },
                Track = ironmaiden1
            };
            TrackStatistic trackStatistic6 = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() { dayStatistic18, dayStatistic19, dayStatistic20 },
                Track = blindguardian1
            };
            #endregion

            #region TrackEmission

           Canal canal1 = unitOfWork.Canals.Find(predicate => predicate.Name == "RadioS").FirstOrDefault();
           Canal canal2 = unitOfWork.Canals.Find(predicate => predicate.Name == "AntRadio").FirstOrDefault();
           Canal canal3 = unitOfWork.Canals.Find(predicate => predicate.Name == "XYZMusic").FirstOrDefault();
            canal1.TrackStatistics = new List<TrackStatistic> { trackStatistic1, trackStatistic2 };
            canal2.TrackStatistics = new List<TrackStatistic> { trackStatistic3, trackStatistic4 };
            canal3.TrackStatistics = new List<TrackStatistic> { trackStatistic5, trackStatistic6 };

            unitOfWork.Canals.Update(canal1);
            unitOfWork.Canals.Update(canal2);
            unitOfWork.Canals.Update(canal3);

            unitOfWork.TrackEmissions.Add(new TrackEmission() {
                Track = savant1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 13, 22, 13, 4),
                EmissionTime = savant1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = savant1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 14, 22, 13, 4),
                EmissionTime = savant1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = savant2,
                Canal = canal2,
                BeginDateTime = new DateTime(2020, 7, 15, 22, 13, 4),
                EmissionTime = savant2.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = savant2,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 15, 22, 13, 4),
                EmissionTime = savant2.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = savant3,
                Canal = canal3,
                BeginDateTime = new DateTime(2020, 7, 15, 20, 13, 4),
                EmissionTime = savant3.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = ironmaiden1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 18, 16, 0, 0),
                EmissionTime = ironmaiden1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = ironmaiden1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 18, 18, 0, 0),
                EmissionTime = ironmaiden1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = ironmaiden1,
                Canal = canal2,
                BeginDateTime = new DateTime(2020, 7, 17,17, 0, 0),
                EmissionTime = ironmaiden1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = ironmaiden1,
                Canal = canal2,
                BeginDateTime = new DateTime(2020, 7, 17, 19, 0, 0),
                EmissionTime = ironmaiden1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = infectedmuschroom1,
                Canal = canal3,
                BeginDateTime = new DateTime(2020, 7, 15, 15, 11, 0),
                EmissionTime = infectedmuschroom1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = infectedmuschroom1,
                Canal = canal3,
                BeginDateTime = new DateTime(2020, 7, 15, 13, 41, 0),
                EmissionTime = infectedmuschroom1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = infectedmuschroom1,
                Canal = canal3,
                BeginDateTime = new DateTime(2020, 7, 15, 12, 33, 0),
                EmissionTime = infectedmuschroom1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = blindguardian1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 16, 14, 43, 0),
                EmissionTime = blindguardian1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = blindguardian1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 16, 13,43, 0),
                EmissionTime = blindguardian1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = blindguardian1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 16, 12,11, 0),
                EmissionTime = blindguardian1.Duration
            }); unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = blindguardian1,
                Canal = canal1,
                BeginDateTime = new DateTime(2020, 7, 16, 11, 31, 0),
                EmissionTime = blindguardian1.Duration
            });

            #endregion

            unitOfWork.Save();
        }
    }
}
*/