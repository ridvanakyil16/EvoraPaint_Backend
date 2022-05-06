using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {

        IMailService _mailService;

        public MailsController(IMailService mailService)
        {
            _mailService = mailService;
        }

        // HttpPost Attribute

        [HttpPost("add")]
        public IActionResult Add(Mail mail)
        {
            var result = _mailService.Add(mail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Mail mail)
        {
            var result = _mailService.Update(mail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Mail mail)
        {
            var result = _mailService.Delete(mail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        // HttpGet Attribute

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _mailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _mailService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
