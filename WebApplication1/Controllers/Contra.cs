using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
using WebApplication1.SQRS;
using WebApplication1.SQRS.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Contra : ControllerBase
    {
        [HttpGet("SpisokStudent")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> ListGroups(bool onlyNormal)
        {
            // 1. экземпляр команды 
            var command = new GetListStudentByGroupCommand { IdStudent = Id };
            // 2. отправили команду на обработку в медиатор
            // 3. медиатор нашел обработчик, передал туда команду, получил результат
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }

    }
}
