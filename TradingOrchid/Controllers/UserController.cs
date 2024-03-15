using Application.Common.Dto.Authen;
using Application.Common.Dto.Exception;
using Application.Common.Dto.Page;
using Application.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TradingOrchid.Controllers
{
    [Route("trading-orchid/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController
            (IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll(PageDto page)
        {
            var list = await userService.GetAll(page);

            if (list == null)
            {
                throw new MyException("Không tìm thấy.", 404);
            }

            return Ok(list);
        }


        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search(string search)
        {
            var list = await userService.Search(search);
            return Ok(list);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(RegisterDto registerDto)
        {
            await userService.Register(registerDto);
            throw new MyException("Thành công.", 200);
        }


        [HttpPut("update-status/{id}")]
        public async Task<IActionResult> EditUser(int id)
        {
            await userService.Edit(id);
            throw new MyException("Thành công.", 200);
        }

        /*[HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await userService.Delete(id);
            throw new MyException("Thành công.", 200);
        }*/
    }
}
