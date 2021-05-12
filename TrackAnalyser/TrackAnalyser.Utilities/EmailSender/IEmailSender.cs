using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.EmailSender
{
    public interface IEmailSender
    {
        public Task<bool> SendEmailAsync(string email, string password);
    }
}
