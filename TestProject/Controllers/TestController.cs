using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.Interfaces;

namespace TestProject.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository testRepository;

        public TestController(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }

        /// <summary>
        /// Aracın giriş ve çıkış saati string türünde gönderilmelidir. Örnek 07:15 - 11:20
        /// 24 saatten fazla girilmek istenirse başına tarih eklenebilir. Engelleyebilirdim fakat ekstra özellik olarak kalmasını tercih ettim.
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="exit"></param>
        /// <returns></returns>
        [HttpGet, Route("GetParkingFee")]
        public IActionResult GetParkingFee(string entry = "07:15", string exit = "11:20")
        {
            return Ok(testRepository.GetParkingFee(entry, exit));
        }
    }
}
