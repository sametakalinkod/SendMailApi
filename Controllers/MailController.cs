using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SendMailApi.Services;
using SendMailApi.Settings;

namespace SendMailApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MailController : ControllerBase
    {
        //public readonly IMediator _mediator;
        private readonly ILogger<MailController> _logger;
        private readonly IMailService _mailService;

        public MailController(ILogger<MailController> logger, IMailService mailService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }

        //[HttpPost(Name = "SendFormToMail")]
        //public async Task<IActionResult> SendFormToMail([FromBody] SendFormToMailCommand getECollectionByIdQuery)
        //{
        //    return Ok(await _mediator.Send(getECollectionByIdQuery));
        //}
        [EnableCors("AllowCors")]
        [HttpPost("SendFormToMail")]
        public async Task<IActionResult> SendFormToMail([FromBody] MailRequest jsonData)
        {
            try
            {
                await _mailService.SendEmailAsync(jsonData);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}