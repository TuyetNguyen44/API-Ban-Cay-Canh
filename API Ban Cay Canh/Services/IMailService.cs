using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API_Ban_Cay_Canh.Models;

namespace API_Ban_Cay_Canh.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}


