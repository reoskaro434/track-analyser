using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.Utilities.DataInitializer
{
    public class DatabaseInitializer : IDatabaseInitializer<IUnitOfWork>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public DatabaseInitializer(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManeger,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManeger;
            _unitOfWork = unitOfWork;
        }
        private void SetRoleAndAdmin()
        {
            _roleManager.CreateAsync(new IdentityRole(StaticDetails.ROLE_ADMIN)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(StaticDetails.ROLE_USER)).GetAwaiter().GetResult();
            ApplicationUser admin = new ApplicationUser()
            {
                Email = "admin@gmail.com",
                UserName = "Admin"
            };

            _userManager.CreateAsync(admin, "Admin123*").GetAwaiter().GetResult(); 
            _userManager.AddToRoleAsync(admin, StaticDetails.ROLE_ADMIN).GetAwaiter().GetResult(); 

        }
        public void SetDatabase()
        {
            _unitOfWork.Migrate();

            _unitOfWork.Save();
            if (_unitOfWork.Tracks.GetAll().ToList().Count > 0)
                return;

            SetRoleAndAdmin();

            _unitOfWork.Save();

            #region Names of Artists
            _unitOfWork.Artists.AddAsync(new Artist()
            {
                Name = "Savant",
            });
            _unitOfWork.Artists.AddAsync(new Artist()
            {
                Name = "Infected Mushroom",
            });
            _unitOfWork.Artists.AddAsync(new Artist()
            {
                Name = "Iron Maiden",
            });
            _unitOfWork.Artists.AddAsync(new Artist()
            {
                Name = "Blind Guardian",
            });

            _unitOfWork.Save();


            Artist savant = _unitOfWork.Artists.Find(predicate => predicate.Name == "Savant").FirstOrDefault();
            Artist infectedMuschroom = _unitOfWork.Artists.Find(predicate => predicate.Name == "Infected Mushroom").FirstOrDefault();
            Artist ironMaiden = _unitOfWork.Artists.Find(predicate => predicate.Name == "Iron Maiden").FirstOrDefault();
            Artist blindGuardian = _unitOfWork.Artists.Find(predicate => predicate.Name == "Blind Guardian").FirstOrDefault();
            #endregion

            #region Tracks

            _unitOfWork.Tracks.AddAsync(new Track()
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
            _unitOfWork.Tracks.AddAsync(new Track()
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
            _unitOfWork.Tracks.AddAsync(new Track()
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
            _unitOfWork.Tracks.AddAsync(new Track()
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

            _unitOfWork.Tracks.AddAsync(new Track()
            {
                CoverPicturePath = "/pictures/iron_maiden_powerslave.jpg",
                Duration = new DateTime(1, 1, 1, 0, 4, 32),
                Description = "\"Aces High\" is a song by English heavy metal band Iron Maiden, written by the band's bassist Steve Harris. It is Iron Maiden's eleventh single release and the second from their fifth studio album, Powerslave (1984).",
                Title = "Aces High",
                Version = "Remaster Version",
                Artist = ironMaiden
            });
            _unitOfWork.Tracks.AddAsync(new Track()
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

            _unitOfWork.Save();


            Track savantDesEag = _unitOfWork.Tracks.Find(predicate => predicate.Title == "Desert Eagle").FirstOrDefault();
            Track savantApoc = _unitOfWork.Tracks.Find(predicate => predicate.Title == "Apocalypse").FirstOrDefault();
            Track savantBegNear = _unitOfWork.Tracks.Find(predicate => predicate.Title == "The Beginning Is Near").FirstOrDefault();
            Track infectedmuschroomNevMind = _unitOfWork.Tracks.Find(predicate => predicate.Title == "Never Mind").FirstOrDefault();
            Track ironmaidenAcesHigh = _unitOfWork.Tracks.Find(predicate => predicate.Title == "Aces High").FirstOrDefault();
            Track blindguardianNightfall = _unitOfWork.Tracks.Find(predicate => predicate.Title == "Nightfall").FirstOrDefault();

            #endregion

            #region Assigning Tracks to Artists
            savant = _unitOfWork.Artists.Find(predicate => predicate.Name == "Savant").FirstOrDefault();
            infectedMuschroom = _unitOfWork.Artists.Find(predicate => predicate.Name == "Infected Mushroom").FirstOrDefault();
            ironMaiden = _unitOfWork.Artists.Find(predicate => predicate.Name == "Iron Maiden").FirstOrDefault();
            blindGuardian = _unitOfWork.Artists.Find(predicate => predicate.Name == "Blind Guardian").FirstOrDefault();

            savant.Tracks = new List<Track>() { savantDesEag, savantApoc, savantBegNear };
            infectedMuschroom.Tracks = new List<Track>() { infectedmuschroomNevMind };
            ironMaiden.Tracks = new List<Track>() { ironmaidenAcesHigh };
            blindGuardian.Tracks = new List<Track>() { blindguardianNightfall };

            _unitOfWork.Save();

            #endregion

            #region Adding Track to Canals

            _unitOfWork.Canals.AddAsync(new Canal()
            {
                Name = "RadioS",
                Tracks = new List<CanalTrack>() {
                   new CanalTrack() { Track= savantApoc },
                    new CanalTrack() { Track= savantBegNear },
                    new CanalTrack() { Track= ironmaidenAcesHigh },
            }
            });
            _unitOfWork.Canals.AddAsync(new Canal()
            {
                Name = "AntRadio",
                Tracks = new List<CanalTrack>() {
                   new CanalTrack() { Track= savantApoc },
                   new CanalTrack() { Track= ironmaidenAcesHigh },
                   new CanalTrack() { Track= blindguardianNightfall },
            }
            });
            _unitOfWork.Canals.AddAsync(new Canal()
            {
                Name = "XYZMusic",
                Tracks = new List<CanalTrack>() {
                    new CanalTrack() { Track= savantDesEag } ,
                   new CanalTrack() { Track= savantApoc },
                   new CanalTrack() { Track= infectedmuschroomNevMind },
             }
            });

            _unitOfWork.Save();
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
            TrackStatistic radioSIronMaidAcesHigh = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() {
                  new DayStatistic() { Day = new DateTime(2020, 6, 22, 0, 0, 0), PlayedTimes = 241 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 23, 0, 0, 0), PlayedTimes = 661 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 24, 0, 0, 0), PlayedTimes = 115 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 25, 0, 0, 0), PlayedTimes = 99 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 26, 0, 0, 0), PlayedTimes = 72 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 27, 0, 0, 0), PlayedTimes = 46 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 28, 0, 0, 0), PlayedTimes = 36 }
                },
                Track = ironmaidenAcesHigh
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
            TrackStatistic antRadioIronMaidAcesHigh = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() {
                  new DayStatistic() { Day = new DateTime(2020, 6, 22, 0, 0, 0), PlayedTimes = 15 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 23, 0, 0, 0), PlayedTimes = 71 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 24, 0, 0, 0), PlayedTimes = 135 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 25, 0, 0, 0), PlayedTimes = 21},
                  new DayStatistic() { Day = new DateTime(2020, 6, 26, 0, 0, 0), PlayedTimes = 61 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 27, 0, 0, 0), PlayedTimes = 355 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 28, 0, 0, 0), PlayedTimes = 55 }
                },
                Track = ironmaidenAcesHigh
            };
            TrackStatistic antRadioBlGuarNightfall = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() {
                  new DayStatistic() { Day = new DateTime(2020, 6, 22, 0, 0, 0), PlayedTimes = 145 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 23, 0, 0, 0), PlayedTimes = 162 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 24, 0, 0, 0), PlayedTimes = 35 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 25, 0, 0, 0), PlayedTimes = 211},
                  new DayStatistic() { Day = new DateTime(2020, 6, 26, 0, 0, 0), PlayedTimes = 511 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 27, 0, 0, 0), PlayedTimes = 11 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 28, 0, 0, 0), PlayedTimes = 71 }
                },
                Track = blindguardianNightfall
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
            TrackStatistic xyzMusicIMNevMind = new TrackStatistic()
            {
                DayStatistics = new List<DayStatistic>() {
                  new DayStatistic() { Day = new DateTime(2020, 6, 22, 0, 0, 0), PlayedTimes = 11 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 23, 0, 0, 0), PlayedTimes = 45 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 24, 0, 0, 0), PlayedTimes = 52 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 25, 0, 0, 0), PlayedTimes = 88},
                  new DayStatistic() { Day = new DateTime(2020, 6, 26, 0, 0, 0), PlayedTimes = 95 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 27, 0, 0, 0), PlayedTimes = 55 },
                  new DayStatistic() { Day = new DateTime(2020, 6, 28, 0, 0, 0), PlayedTimes = 1 }
                },
                Track = infectedmuschroomNevMind
            };
            #endregion

            #region TrackEmissions

            Canal radioS = _unitOfWork.Canals.Find(predicate => predicate.Name == "RadioS").FirstOrDefault();
            Canal antRadio = _unitOfWork.Canals.Find(predicate => predicate.Name == "AntRadio").FirstOrDefault();
            Canal xyzMusic = _unitOfWork.Canals.Find(predicate => predicate.Name == "XYZMusic").FirstOrDefault();

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

            infectedmuschroomNevMind.Canals = new List<CanalTrack>()
            {
                new CanalTrack() { Canal = xyzMusic } ,
            };

            blindguardianNightfall.Canals = new List<CanalTrack>()
            {
                new CanalTrack() { Canal = antRadio } ,
            };

            ironmaidenAcesHigh.Canals = new List<CanalTrack>()
            {
                new CanalTrack() { Canal = radioS } ,
                new CanalTrack() { Canal = antRadio } ,
            };
            radioS.TrackStatistics = new List<TrackStatistic> { radioSSavApoc, radioSSavBegNear, radioSIronMaidAcesHigh };
            antRadio.TrackStatistics = new List<TrackStatistic> { antRadioSavApoc, antRadioIronMaidAcesHigh, antRadioBlGuarNightfall };
            xyzMusic.TrackStatistics = new List<TrackStatistic> { xyzMusicSavApoc, xyzMusicSavDesEag, xyzMusicIMNevMind };

            _unitOfWork.Canals.Update(radioS);
            _unitOfWork.Canals.Update(antRadio);
            _unitOfWork.Canals.Update(xyzMusic);


            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = savantDesEag,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 1, 22, 13, 4),
                EmissionTime = savantDesEag.Duration
            });
            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = ironmaidenAcesHigh,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 14, 2, 21, 15),
                EmissionTime = ironmaidenAcesHigh.Duration
            });
            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = savantApoc,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 15, 22, 13, 4),
                EmissionTime = savantApoc.Duration
            });
            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = ironmaidenAcesHigh,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 15, 2, 22, 50),
                EmissionTime = ironmaidenAcesHigh.Duration
            });
            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = infectedmuschroomNevMind,
                Canal = xyzMusic,
                BeginDateTime = new DateTime(2020, 7, 17, 2, 13, 15),
                EmissionTime = infectedmuschroomNevMind.Duration
            });
            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = savantBegNear,
                Canal = xyzMusic,
                BeginDateTime = new DateTime(2020, 7, 15, 20, 13, 4),
                EmissionTime = savantBegNear.Duration
            });
            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = infectedmuschroomNevMind,
                Canal = xyzMusic,
                BeginDateTime = new DateTime(2020, 7, 16, 1, 13, 15),
                EmissionTime = infectedmuschroomNevMind.Duration
            });
            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = blindguardianNightfall,
                Canal = antRadio,
                BeginDateTime = new DateTime(2020, 7, 21, 4, 40, 40),
                EmissionTime = blindguardianNightfall.Duration
            });
            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = savantApoc,
                Canal = antRadio,
                BeginDateTime = new DateTime(2020, 7, 15, 22, 13, 4),
                EmissionTime = savantApoc.Duration
            });
            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = blindguardianNightfall,
                Canal = antRadio,
                BeginDateTime = new DateTime(2020, 7, 20, 12, 10, 20),
                EmissionTime = blindguardianNightfall.Duration
            });
            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = savantDesEag,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 2, 22, 13, 4),
                EmissionTime = savantDesEag.Duration
            });

            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = ironmaidenAcesHigh,
                Canal = radioS,
                BeginDateTime = new DateTime(2020, 7, 19, 2, 20, 20),
                EmissionTime = ironmaidenAcesHigh.Duration
            });

            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = ironmaidenAcesHigh,
                Canal = antRadio,
                BeginDateTime = new DateTime(2020, 7, 20, 2, 12, 30),
                EmissionTime = ironmaidenAcesHigh.Duration
            });

            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = blindguardianNightfall,
                Canal = antRadio,
                BeginDateTime = new DateTime(2020, 7, 22, 12, 12, 12),
                EmissionTime = blindguardianNightfall.Duration
            });
            _unitOfWork.TrackEmissions.AddAsync(new TrackEmission()
            {
                Track = ironmaidenAcesHigh,
                Canal = antRadio,
                BeginDateTime = new DateTime(2020, 7, 20, 2, 10, 30),
                EmissionTime = ironmaidenAcesHigh.Duration
            });

            #endregion

            _unitOfWork.Save();
        }
    }
}