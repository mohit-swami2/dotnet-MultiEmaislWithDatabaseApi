using EmailWithDatabaseApi.Dto;
using EmailWithDatabaseApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Identity.Client;

namespace EmailWithDatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailServices _services;

        public EmailsController(IEmailServices services)
        {
            _services = services;
        }

        [HttpGet("GetAll")]
        public List<string> GetallEmails()
        {
           return(_services.GetAll()); 
            
        }

        [HttpPost("SendMail")]
        public async Task<ActionResult> Post(EmailDto request)
        {
            string a =  _services.GetObject(request);
            return Ok(a); 
        }


        [HttpPost("NewMail")]
        public IActionResult Post(PostEmailDto newemail)
        {
            _services.Post(newemail);
            return Ok("Adding Email Successfull");
        }
    }
}
