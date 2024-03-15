using Application.Common.Dto.Exception;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TradingOrchid.Controllers.Errors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : Controller
    {
        [Route("/error")]
        public IActionResult Error()
        {
            switch (HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error!)
            {
                case MyException:
                    var exception = (MyException)HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error!;
                    return Problem(title: exception.Message, statusCode: exception.StatusCode);
                default:
                    return Problem(title: "Internal Server Error", statusCode: 500);
            }
        }
    }
}
