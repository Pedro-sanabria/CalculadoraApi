using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculadoraController : ControllerBase
{

    [HttpGet(template: "sumar")]
    public int Sumar([FromQuery] int a, [FromQuery] int b)
    {
        return a + b;
    }
    
    [HttpGet(template: "sumar2")]
    public ActionResult<int> Sumar2([FromQuery] int a, [FromQuery] int b)
    {
        var result = new
        {
            a,
            b,
            operacion = "sumar",
            result = a + b,
        };
        return Ok(result);
    }

    [HttpGet(template: "restar")]
    public int Restar([FromQuery] int a, [FromQuery] int b)
    {
        return a - b;
    }

    [HttpGet(template: "multiplicar")]
    public int Multiplicar([FromQuery] int a, [FromQuery] int b)
    {
        return a * b;
    }

    [HttpGet(template: "dividir/{a}/{b}")]
    public ActionResult<float> Dividir( int a, int b)
    {
        if (b == 0)
        {
            return BadRequest(error:"sin definir");
        }
        else
        {
            return a / b;
        }
    }

    [HttpGet(template: "CALC/{operation}")]
    public ActionResult Sumar(string operation, [FromQuery] int a, [FromQuery] int b)
    {
        var result = 0;
        switch (operation)
        {
            case "sumar":
                result = a + b;
                break;
            case "restar":
                result = a - b;
                break;
            case "multiplicar":
                result = a * b;
                break;
            case "dividir":
                result = a / b;
                break;
            default:
                return BadRequest(error:"sin definir");
        }

        var resultado = new
        {
            a,
            b,
            operation,
            result
        };
        return Ok(resultado);

    }
}
