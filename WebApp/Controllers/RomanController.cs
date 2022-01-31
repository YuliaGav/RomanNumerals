using Microsoft.AspNetCore.Mvc;
using RomanNumerals;
using RomanNumerals.APIModels;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RomanController : ControllerBase
    {
        private readonly IConvNumbers _convertService;
        private readonly ILogger<RomanController> _logger;

        public RomanController(ILogger<RomanController> logger, IConvNumbers convNumber)
        {
            _logger = logger;
            _convertService = convNumber;
        }
        /// <summary>
        /// Converts a number to roman numerals
        /// </summary>
        /// <param name="arabic">Arabic number between 1 to 2000 to convert</param>
        /// <returns>string representing roman numeral, status, error</returns>
        /// 
        [HttpGet("{arabic:int}",Name = "GetRoman")]
        public RomanNumeralGetResult Get(int arabic)
        {
            try
            {
                var res = _convertService.ToRomanNumerals(arabic);
                if (arabic == _convertService.ToArabicNumerals(res))
                    return new RomanNumeralGetResult
                    {
                        Result = res,
                        Checked = true,
                        Error = ""
                    };

                else
                    return new RomanNumeralGetResult
                    {
                        Result = res,
                        Checked = false,
                        Error = ""
                    }; 
            }
            catch (Exception ex) {
                _logger.LogError("Parameter arabic = " + arabic.ToString() + " : " + ex.Message);
                return new RomanNumeralGetResult
                {
                    Result = "arabic parameter should be between 1 and 2000",
                    Checked = false,
                    Error = ex.Message
                };
            }
            
        }
    }
}