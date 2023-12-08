using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCartWeb.Email
{
    public interface ISendGridEmailSender
    {
        Task SendAsync(string from, string to, string subject, string body, string confirmationLink);
    }
}
