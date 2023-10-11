using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SendMailApi.Services;

namespace SendMailApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [HttpPost("SendFormToMail")]
        public async Task<IActionResult> SendFormToMail([FromForm] MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}