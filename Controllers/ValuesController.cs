using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SendMailApi.Services;

namespace SendMailApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //[HttpPost(Name = "SendFormToMail")]
        //public async Task<IActionResult> SendFormToMail([FromBody] SendFormToMailCommand getECollectionByIdQuery)
        //{
        //    return Ok(await _mediator.Send(getECollectionByIdQuery));
        //}
        // GET api/values
        //[HttpGet(Name = "Get")]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
    }
}