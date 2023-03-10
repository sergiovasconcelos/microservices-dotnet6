using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{    
    private readonly ILogger<PersonController> _logger;
    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult Sub(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("mult/{firstNumber}/{secondNumber}")]
    public IActionResult Mult(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult Div(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("med/{firstNumber}/{secondNumber}")]
    public IActionResult Med(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("squ/{firstNumber}")]
    public IActionResult Squ(string firstNumber)
    {
        if(IsNumeric(firstNumber))
        {
            var squ = Math.Sqrt((double)ConvertToDecimal(firstNumber));
            return Ok(squ.ToString());
        }
        return BadRequest("Invalid Input");
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

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(
            strNumber, System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, 
            out number);
        return isNumber;
    }
}
