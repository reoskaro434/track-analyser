﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models.ViewModels.UserManagementViewModel
{
    public class UserManagementViewModel
    {
        public IEnumerable<string> UserEmails { get; set; }

        public NewUserDetailsViewModel NewUser { get; set; }
    }
}
