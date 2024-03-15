using Application.Common.Dto.Exception;
using Application.Common.Dto.Page;
using Application.Interfaces.Informations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace TradingOrchid.Controllers
{
    [Route("trading-orchid/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer, Staff, Manager, Orchid Owner")]
    public class InformationController : Controller
    {
        private readonly IInformationService informationService;

        public InformationController(IInformationService informationService)
        {
            this.informationService = informationService;
        }

        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll(PageDto page)
        {
            var list = await informationService.GetAll(page);

            if (list == null)
            {
                throw new MyException("Không tìm thấy.", 404);
            }

            return Ok(list);
        }

        [HttpPost("get-by-user-id")]
        public async Task<IActionResult> GetByUserId(PageDto page)
        {
            string encodedToken = HttpContext.Items["Token"]!.ToString()!;

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(encodedToken);

            int userId = Int32.Parse(token.Claims
                .FirstOrDefault(c => c.Type == "userId")!.Value);

            var list = await informationService.GetByUserId(page, userId);

            if (list == null)
            {
                throw new MyException("Không tìm thấy.", 404);
            }

            return Ok(list);
        }

        [HttpPost("get-by-register")]
        public async Task<IActionResult> GetByBeingRegiter(PageDto page)
        {
            string encodedToken = HttpContext.Items["Token"]!.ToString()!;

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(encodedToken);

            int userId = Int32.Parse(token.Claims
                .FirstOrDefault(c => c.Type == "userId")!.Value);

            var list = await informationService.GetByBeingRegiter(page, userId);

            if (list == null)
            {
                throw new MyException("Không tìm thấy.", 404);
            }

            return Ok(list);
        }


        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search(string search)
        {
            var list = await informationService.Search(search);
            return Ok(list);
        }


        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var list = await informationService.GetByID(id);
            return Ok(list);
        }
    }
}
