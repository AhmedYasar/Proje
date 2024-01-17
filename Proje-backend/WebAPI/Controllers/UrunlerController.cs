using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        IUrunService _urunService;
        public UrunlerController(IUrunService urunService)
        {
            _urunService = urunService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);
            var result = _urunService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int urunid)
        {
            var result = _urunService.GetById(urunid);
            if (result.Success) { return Ok(result); }
            return BadRequest(result.Message);

        }
        [HttpGet("getbykategori")]
        public IActionResult GetByKategori(int kategoriid)
        {
            var result = _urunService.GetAllByCategoryId(kategoriid);
            if (result.Success) { return Ok(result); }
            return BadRequest(result.Message);

        }

        [HttpPost("add")]

        public IActionResult Add(Urun urun) 
        {
            var result = _urunService.Add(urun);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        
        }

        [HttpPost("update")]

        public IActionResult Update(Urun urun)
        {
            var result = _urunService.Update(urun);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }





    }
}
