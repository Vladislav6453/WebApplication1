using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
using WebApplication1.SQRS;
using WebApplication1.SQRS.CountStudent;
using WebApplication1.SQRS.DTO;
using WebApplication1.SQRS.Students;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Mediator mediator;
        public StudentsController(MyMediator.Types.Mediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("SpisokStudentByGroupId")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> ListGroups(int ID)
        {
            var command = new GetListStudentByGroupCommand { GroupId = ID };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }

        [HttpGet("SpisokStudentByGroupIdToGenders")]
        public async Task<ActionResult<IEnumerable<int>>> ListGender(int ID)
        {
            var command = new GetCountGendersStudentCommand { GroupId = ID };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }


    }
}
