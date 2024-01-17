using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorilerController : ControllerBase
    {
        IKategoriService _kategoriService;
        public KategorilerController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
                
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(500);
            var result = _kategoriService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
