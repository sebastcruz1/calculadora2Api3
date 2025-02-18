using Microsoft.AspNetCore.Mvc;

namespace CalculadoraAPI.Controllers;

[ApiController]
[Route("[controller]")] // Elimina "template:" para simplificar
public class CalculadoraController : ControllerBase // Usa ControllerBase en lugar de Controller
{
    [HttpGet("sumar")]
    public ActionResult<int> Sumar([FromQuery] int a, [FromQuery] int b)
    {
        var result = new
        {
            a = a,
            b = b,
            operacion = "sumar",
            result = a + b,
        };

        return Ok(result); // Devuelve el objeto anónimo con un código HTTP 200
    }

    [HttpGet("restar")]
    public ActionResult<int> Restar([FromQuery] int a, [FromQuery] int b)
    {
        var result = new
        {
            a = a,
            b = b,
            operacion = "restar",
            result = a - b,
        };

        return Ok(result); // Devuelve el objeto anónimo con un código HTTP 200
    }

    [HttpGet("multiplicar")]
    public ActionResult<int> Multiplicar([FromQuery] int a, [FromQuery] int b)
    {
        return a * b; // Devuelve directamente el resultado como un entero
    }

    [HttpGet("division/{a}/{b}")]
    public ActionResult<int> Division(int a, int b)
    {
        if (b == 0)
        {
            return 0; // Devuelve 0 como un valor entero si se intenta dividir entre cero
        }

        return a / b; // Devuelve el resultado de la división si b no es cero
    }

    [HttpGet("operacion/{a}/{b}")]
    public IActionResult Operacion(string operacion, [FromQuery] int a, [FromQuery] int b)
    {
        var result = 0;
        switch (operacion)
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
            case "division":
                result = a / b;
                break;
            default:
                return BadRequest("Operacion Invalida");
        }

        var response = new
        {
            a,
            b,
            operacion,
            result
        };
        return Ok(response);
    }
}