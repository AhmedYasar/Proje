using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SepetlerController : ControllerBase
    {
        ISepetService _sepetlerService;

        public SepetlerController(ISepetService sepetService)
        {
                _sepetlerService = sepetService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int sepetId)
        {
            var result = _sepetlerService.GetById(sepetId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]

        public IActionResult Add(Sepet sepet)
        {
            var result = _sepetlerService.Add(sepet);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpPost("delete")]

        public IActionResult Delete(Sepet sepet)
        {
            var result = _sepetlerService.Delete(sepet);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpGet("getbyuserid")]
        
        public IActionResult GetByUserId(int userId)
        {
           
            var result = _sepetlerService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]

        public IActionResult Update(Sepet sepet)
        {
            var result = _sepetlerService.Update(sepet);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

    }
}
