using Microsoft.AspNetCore.Mvc;
using NumberToWordsAPI.Model;
using NumberToWordsAPI.Services;

namespace NumberToWordsAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NumberToWordsController : ControllerBase
    {
        private readonly INumberToWordsService _numberToWordsService;
        private readonly ILogger<NumberToWordsController> _logger;

        public NumberToWordsController(
            INumberToWordsService numberToWordsService,
            ILogger<NumberToWordsController> logger
            )
        {
            _numberToWordsService = numberToWordsService;
            _logger = logger;
        }


        [HttpPost]
        public ActionResult<NumberToWordsResultModel> Post(NumberToWordsModel numberToWordsModel)
        {
            var result = _numberToWordsService.Convert(numberToWordsModel.Number);
            return Ok(result);
        }
    }
}
