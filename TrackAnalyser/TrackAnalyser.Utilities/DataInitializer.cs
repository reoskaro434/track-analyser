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
            if (unitOfWork.Tracks.GetAll().ToList().Count > 0)
                return;

            #region Names of Artists
            unitOfWork.Artists.AddAsync(new Artist()
            {
                Name = "Savant",
            });
          /*  unitOfWork.Artists.Add(new Artist()
            {
                Name = "Infected Mushroom",
            });
            unitOfWork.Artists.Add(new Artist()
            {
                Name = "Iron Maiden",
            });
            unitOfWork.Artists.Add(new Artist()
            {
                Name = "Blind Guardian",
            });
*/
            unitOfWork.Save();
           

            Artist savant = unitOfWork.Artists.Find(predicate => predicate.Name == "Savant").FirstOrDefault();
       /*   Artist infectedMuschroom = unitOfWork.Artists.Find(predicate => predicate.Name == "Infected Mushroom").FirstOrDefault();
            Artist ironMaiden = unitOfWork.Artists.Find(predicate => predicate.Name == "Iron Maiden").FirstOrDefault();
            Artist blindGuardian = unitOfWork.Artists.Find(predicate => predicate.Name == "Blind Guardian").FirstOrDefault();*/
            #endregion

            #region Tracks

            unitOfWork.Tracks.AddAsync(new Track()
            {
                CoverPicturePath = "/pictures/savant_zion.png",
                Duration = new DateTime(1, 1, 1, 0, 3, 34),
                Description = "To celebrate his 10th album release," +
                " Savant is taking you to Zion. Experience Mideastern " +
                "diddies and flurishes over urban and futuristic beats " +
                "crafted by the mad scientist of the electronic music world.",
                Title = "Desert Eagle",
                Version = "Radio Version",
                Artist = savant
            });
            unitOfWork.Tracks.AddAsync(new Track()
            {
                CoverPicturePath = "/pictures/savant_zion.png",
                Duration = new DateTime(1, 1, 1, 0, 7, 12),
                Description = "To celebrate his 10th album release," +
               " Savant is taking you to Zion. Experience Mideastern " +
               "diddies and flurishes over urban and futuristic beats " +
               "crafted by the mad scientist of the electronic music world.",
                Title = "Apocalypse",
                Version = "Radio Version",
                Artist = savant
            });
            unitOfWork.Tracks.AddAsync(new Track()
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
        /*    unitOfWork.Tracks.Add(new Track()
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
            });*/

            unitOfWork.Save();
       

            Track savantDesEag = unitOfWork.Tracks.Find(predicate => predicate.Title == "Desert Eagle").FirstOrDefault();
            Track savantApoc = unitOfWork.Tracks.Find(predicate => predicate.Title == "Apocalypse").FirstOrDefault();
            Track savantBegNear = unitOfWork.Tracks.Find(predicate => predicate.Title == "The Beginning Is Near").FirstOrDefault();
       /*     Track ironmaiden1 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Aces High").FirstOrDefault();
            Track infectedmuschroom1 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Never Mind").FirstOrDefault();
            Track blindguardian1 = unitOfWork.Tracks.Find(predicate => predicate.Title == "Nightfall").FirstOrDefault();*/

            #endregion

            #region Assigning Tracks to Artists
            savant = unitOfWork.Artists.Find(predicate => predicate.Name == "Savant").FirstOrDefault();
    /*        infectedMuschroom = unitOfWork.Artists.Find(predicate => predicate.Name == "Infected Mushroom").FirstOrDefault();
            ironMaiden = unitOfWork.Artists.Find(predicate => predicate.Name == "Iron Maiden").FirstOrDefault();
            blindGuardian = unitOfWork.Artists.Find(predicate => predicate.Name == "Blind Guardian").FirstOrDefault();*/

            savant.Tracks = new List<Track>() { savantDesEag , savantApoc , savantBegNear };
       /*     infectedMuschroom.Tracks = new List<Track>() { infectedmuschroom1 };
            ironMaiden.Tracks = new List<Track>() { ironmaiden1 };
            blindGuardian.Tracks = new List<Track>() { blindguardian1 };*/

            unitOfWork.Save();

            #endregion

            #region Adding Track to Canals

            unitOfWork.Canals.AddAsync(new Canal()
            {
                Name = "RadioS",
                Tracks = new List<CanalTrack>() {
                   new CanalTrack() { Track= savantApoc },
                    new CanalTrack() { Track= savantBegNear },
            }
            });
            unitOfWork.Canals.AddAsync(new Canal()
            {
                Name = "AntRadio",
                Tracks = new List<CanalTrack>() {
                   new CanalTrack() { Track= savantApoc },
            }
            });
            unitOfWork.Canals.AddAsync(new Canal()
            {
                Name = "XYZMusic",
                Tracks = new List<CanalTrack>() {
                    new CanalTrack() { Track= savantDesEag } ,
                   new CanalTrack() { Track= savantApoc },
             }
            });

            unitOfWork.Save();
            #endregion

            #region TracksStatstics and DayStatistics

            TrackStatistic radioSSavBegNear = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() {
                  new DayStatistic() { Day = new DateTime(2020, 6, 22, 0, 0, 0), PlayedTimes = 22 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 23, 0, 0, 0), PlayedTimes = 12 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 24, 0, 0, 0), PlayedTimes = 42 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 25, 0, 0, 0), PlayedTimes = 52 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 26, 0, 0, 0), PlayedTimes = 72 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 27, 0, 0, 0), PlayedTimes = 47 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 28, 0, 0, 0), PlayedTimes = 13 }
                },
                Track = savantBegNear
            };
            TrackStatistic radioSSavApoc = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() {
                  new DayStatistic() { Day = new DateTime(2020, 6, 22, 0, 0, 0), PlayedTimes = 12 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 23, 0, 0, 0), PlayedTimes = 122 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 24, 0, 0, 0), PlayedTimes = 12 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 25, 0, 0, 0), PlayedTimes = 512 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 26, 0, 0, 0), PlayedTimes = 12 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 27, 0, 0, 0), PlayedTimes = 45 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 28, 0, 0, 0), PlayedTimes = 66 }
                },
                Track = savantApoc
            };
            TrackStatistic antRadioSavApoc = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() {
                  new DayStatistic() { Day = new DateTime(2020, 6, 22, 0, 0, 0), PlayedTimes = 51 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 23, 0, 0, 0), PlayedTimes = 65 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 24, 0, 0, 0), PlayedTimes = 13 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 25, 0, 0, 0), PlayedTimes = 21},
                  new DayStatistic() { Day = new DateTime(2020, 6, 26, 0, 0, 0), PlayedTimes = 44 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 27, 0, 0, 0), PlayedTimes = 61 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 28, 0, 0, 0), PlayedTimes = 9 }
                },
                Track = savantApoc
            };
            TrackStatistic xyzMusicSavApoc = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() {
                  new DayStatistic() { Day = new DateTime(2020, 6, 22, 0, 0, 0), PlayedTimes = 11 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 23, 0, 0, 0), PlayedTimes = 52 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 24, 0, 0, 0), PlayedTimes = 11 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 25, 0, 0, 0), PlayedTimes = 51},
                  new DayStatistic() { Day = new DateTime(2020, 6, 26, 0, 0, 0), PlayedTimes = 42 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 27, 0, 0, 0), PlayedTimes = 81 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 28, 0, 0, 0), PlayedTimes = 82 }
                },
                Track = savantApoc
            };
            TrackStatistic xyzMusicSavDesEag = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() {
                  new DayStatistic() { Day = new DateTime(2020, 6, 22, 0, 0, 0), PlayedTimes = 11 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 23, 0, 0, 0), PlayedTimes = 115 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 24, 0, 0, 0), PlayedTimes = 6 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 25, 0, 0, 0), PlayedTimes = 61},
                  new DayStatistic() { Day = new DateTime(2020, 6, 26, 0, 0, 0), PlayedTimes = 92 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 27, 0, 0, 0), PlayedTimes = 2 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 28, 0, 0, 0), PlayedTimes = 11 }
                },
                Track = savantDesEag
            };
 
            #endregion

            #region TrackEmissions

            Canal radioS = unitOfWork.Canals.Find(predicate => predicate.Name == "RadioS").FirstOrDefault();
            Canal antRadio = unitOfWork.Canals.Find(predicate => predicate.Name == "AntRadio").FirstOrDefault();
            Canal xyzMusic = unitOfWork.Canals.Find(predicate => predicate.Name == "XYZMusic").FirstOrDefault();

            savantDesEag.Canals = new List<CanalTrack>() {
                    new CanalTrack() { Canal = xyzMusic } ,
            };
          
            savantApoc.Canals = new List<CanalTrack>() {
                    new CanalTrack() { Canal = antRadio} ,
                    new CanalTrack() { Canal = radioS} ,
                    new CanalTrack() { Canal = xyzMusic} ,
             };

            savantBegNear.Canals = new List<CanalTrack>() {
                    new CanalTrack() { Canal = radioS } ,
             
            };

            radioS.TrackStatistics = new List<TrackStatistic> { radioSSavApoc, radioSSavBegNear };
            antRadio.TrackStatistics = new List<TrackStatistic> { antRadioSavApoc };
            xyzMusic.TrackStatistics = new List<TrackStatistic> { xyzMusicSavApoc,xyzMusicSavDesEag};

            unitOfWork.Canals.Update(radioS);
            unitOfWork.Canals.Update(antRadio);
            unitOfWork.Canals.Update(xyzMusic);


            unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = savantDesEag,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7,1, 22, 13, 4),
                EmissionTime = savantDesEag.Duration
            });
            unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = savantDesEag,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 2, 22, 13, 4),
                EmissionTime = savantDesEag.Duration
            });
            unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = savantApoc,
                Canal = antRadio,
                BeginDateTime = new DateTime(2020, 7, 15, 22, 13, 4),
                EmissionTime = savantApoc.Duration
            });
            unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = savantApoc,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 15, 22, 13, 4),
                EmissionTime = savantApoc.Duration
            });
            unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = savantBegNear,
                Canal = xyzMusic,
                BeginDateTime = new DateTime(2020, 7, 15, 20, 13, 4),
                EmissionTime = savantBegNear.Duration
            });
          /*  unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = ironmaiden1,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 18, 16, 0, 0),
                EmissionTime = ironmaiden1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = ironmaiden1,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 18, 18, 0, 0),
                EmissionTime = ironmaiden1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = ironmaiden1,
                Canal = antRadio,
                BeginDateTime = new DateTime(2020, 7, 17, 17, 0, 0),
                EmissionTime = ironmaiden1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = ironmaiden1,
                Canal = antRadio,
                BeginDateTime = new DateTime(2020, 7, 17, 19, 0, 0),
                EmissionTime = ironmaiden1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = infectedmuschroom1,
                Canal = xyzMusic,
                BeginDateTime = new DateTime(2020, 7, 15, 15, 11, 0),
                EmissionTime = infectedmuschroom1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = infectedmuschroom1,
                Canal = xyzMusic,
                BeginDateTime = new DateTime(2020, 7, 15, 13, 41, 0),
                EmissionTime = infectedmuschroom1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = infectedmuschroom1,
                Canal = xyzMusic,
                BeginDateTime = new DateTime(2020, 7, 15, 12, 33, 0),
                EmissionTime = infectedmuschroom1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = blindguardian1,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 16, 14, 43, 0),
                EmissionTime = blindguardian1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = blindguardian1,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 16, 13, 43, 0),
                EmissionTime = blindguardian1.Duration
            });
            unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = blindguardian1,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 16, 12, 11, 0),
                EmissionTime = blindguardian1.Duration
            }); unitOfWork.TrackEmissions.Add(new TrackEmission()
            {
                Track = blindguardian1,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 16, 11, 31, 0),
                EmissionTime = blindguardian1.Duration
            });
*/
            #endregion

            unitOfWork.Save();
        }
    }
}