using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Ban_Cay_Canh.Models;
using API_Ban_Cay_Canh.Services;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace API_Ban_Cay_Canh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IMailService _mailService;
        public EmailController(IMailService mailService)
        {
            _mailService = mailService;
        }
        [HttpPost("Send")]
        public async Task<IActionResult>Send([FromForm]MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                return StatusCode(StatusCodes.Status200OK, "Mail has successfully been sent.");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
