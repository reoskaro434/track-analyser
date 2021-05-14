using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrackAnalyser.Models.ViewModels.UserManagementViewModel
{
    public class UserManagementViewModel
    {
        public IEnumerable<string> UserEmails { get; set; }
       
        [Required]
        [EmailAddress]
        [DisplayName("New Email")]
        public string NewEmail { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("New User's Email")]
        public string NewUserEmail { get; set; }
    }
}
