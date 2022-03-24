using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWihtASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {

            _logger = logger;
        }

        [HttpGet("{operacao}/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string operacao,  string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal sum;
                switch (operacao)
                {
                    case "sum":
                        sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                        break;
                    case "sub":
                        sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                        break;
                    case "multi":
                        sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                        break;
                    default:
                        sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                        break;
                }
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        private bool IsNumeric(string strNumber)
        {
            double Number;
            bool isNumber = double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out Number);
            return isNumber;
            //throw new NotImplementedException();
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

    }
}
