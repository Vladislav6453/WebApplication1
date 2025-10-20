using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
using WebApplication1.SQRS;
using WebApplication1.SQRS.CountStudent;
using WebApplication1.SQRS.DTO;
using WebApplication1.SQRS.Groups;
using WebApplication1.SQRS.GroupsWithStudents;
using WebApplication1.SQRS.Students;
using WebApplication1.SQRS.StudentsOutGroups;

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

        [HttpGet("SpisokStudentByGroupId/{ID}")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> ListStudents(int ID)
        {
            var command = new GetListStudentByGroupCommand { GroupId = ID };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }

        [HttpGet("SpisokStudentByGroupIdToGenders/{ID}")]
        public async Task<ActionResult<GendersCountDTO>> ListGender(int ID)
        {
            var command = new GetCountGendersStudentCommand { GroupId = ID };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }

        [HttpGet("GetListStudentsOutGroups")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> ListStudent()
        {
            var command = new GetListStudentsOutGroupsCommand { };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }

        [HttpGet("GetListGroupsOutStudents")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetListGroupsOutStudents()
        {
            var command = new GetGroupsOutOfStudentsCommand { };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }

        [HttpGet("GetListGroupsWithStudents")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetListGroupsWithStudents()
        {
            var command = new GetCountGroupAndCountStudentCommand { };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }

        [HttpGet("GetListGroupsWithStudentsWithIndex/{spec}")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetListGroupsWithStudentsWithIndex(int spec)
        {
            var command = new GetGroupsWithStudentsWithIndexCommand { GroupSpecial = spec};
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }

        [HttpGet("GetNewGroupWithSpec/{spec}/{title}")]
        public async Task<ActionResult> GetNewGroupWithSpec(string title,int spec)
        {
            var command = new GetCreateNewGroupWithSpecComamnd { NewGroupTitle = title, NewGroupSpecial = spec };
            await mediator.SendAsync(command);
            return Ok();
        }


        [HttpGet("GetStudentToAnyGroup/{idgroup}/{idstudent}")]
        public async Task<ActionResult> GetStudentToAnyGroup(int idgroup, int idstudent)
        {
            var command = new GetStudentPeveodToAnyGroupComamnd { GroupId = idgroup, StudentId = idstudent };
            await mediator.SendAsync(command);
            return Ok();
        }
    }
}
