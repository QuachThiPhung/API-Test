using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newtest.Model;

namespace newtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hanghoa = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hanghoa);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID (string id)
        {
            try 
            {
                var HangHoa = hanghoa.SingleOrDefault(hh => hh.Code == Guid.Parse(id));
                if (HangHoa == null)
                {
                    return NotFound();
                }
                return Ok(HangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoanew = new HangHoa
            {
                Code = Guid.NewGuid(),
                HangHoaName = hangHoaVM.HangHoaName,
                Price = hangHoaVM.Price
            };
            hanghoa.Add(hanghoanew);
            return Ok(new
            {
                Success = true, Data = hanghoanew
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hanghoaEdit)
        {
            try
            {
                var hangHoa = hanghoa.SingleOrDefault(hh => hh.Code == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                if (id != hangHoa.Code.ToString())
                {
                    return BadRequest();
                }
                hangHoa.HangHoaName = hanghoaEdit.HangHoaName;
                hangHoa.Price = hanghoaEdit.Price;

                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove (String id)
        {
            try
            {
                var hangHoa = hanghoa.SingleOrDefault(hh => hh.Code == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                hanghoa.Remove(hangHoa);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
