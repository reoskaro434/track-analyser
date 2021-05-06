using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models.ViewModels.UserManagementViewModel
{
    public class NewUserDetailsViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string NewUserEmail { get; set; }
    }
}
