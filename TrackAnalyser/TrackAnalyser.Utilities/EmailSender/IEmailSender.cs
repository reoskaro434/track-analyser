using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.EmailSender
{
    public interface IEmailSender
    {
        /// <summary>
        /// Sends password to given email.
        /// </summary>
        /// <param name="email">Email where password will be sent.</param>
        /// <param name="password">User's password</param>
        /// <returns></returns>
        public Task<bool> SendEmailAsync(string email, string password);
    }
}
