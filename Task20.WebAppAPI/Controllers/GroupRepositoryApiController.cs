using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task20.Entities;
using Task20.DataContext.DataBaseContext;
using Task20.Models;
using Task20.ApiModels;

namespace Task20.WebAppAPI.Controllers
{
    public class GroupRepositoryApiController : MyControllerBase
    {
        private readonly UniversityDbContext _context;

        public GroupRepositoryApiController(UniversityDbContext context)
        {
            _context = context;
        }

        #region CRUD
        // GET /GroupRepositoryApi
        [HttpGet]
        public async Task<ActionResult<GroupEntity[]>> GetAllGroupsAsync()
        {
            var groups = await _context.Groups.ToArrayAsync();
            if (groups is null)
            {
                return NotFound();
            }

            return Ok(groups);
        }

        // GET /GroupRepositoryApi/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupEntity>> GetGroupByGroupIdAsync(int id)
        {
            var group = await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
            if (group is null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // POST /GroupRepositoryApi
        [HttpPost]
        public async Task<ActionResult> CreatedGroup(GroupCreator creator)
        {
            var loggedUser = GetLoggedUser();
            if (loggedUser is null)
            {
                return Unauthorized();
            }

            if (!await CheckIsCourseExistsAsync(creator.CourseId))
            {
                return NotFound();
            }

            if (!await CheckIsTeacherAvailabilityAsync(creator.LeaderId.HasValue ? creator.LeaderId.Value : 0))
            {
                creator.LeaderId = null;
            }

            var newGroup = new GroupEntity
            {
                Name = creator.Name,
                Description = creator.Description,
                CourseId = creator.CourseId,
                LeaderId = creator.LeaderId,
                CreationDate = DateTime.Now,
            };

            _context.Add(newGroup);
            await _context.SaveChangesAsync();

            // CreationDate = DateTime.Now можно считать уникальным значением, по которому можно найти группу.
            var addedGroup = await _context.Groups.FirstOrDefaultAsync(g => g.CreationDate == newGroup.CreationDate);
            if (addedGroup is null)
            {
                return NotFound();
            }

            return Ok();
        }

        // PUT /GroupRepositoryApi/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGroup(int id, GroupUpdater updater)
        {
            var loggedUser = GetLoggedUser();
            if (loggedUser is null)
            {
                return Unauthorized();
            }

            if (updater == null || !updater.IsWhetherUpdatesNeedApplied)
            {
                return NoContent();
            }

            var updatedGroup = await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
            if (updatedGroup is null) return NotFound();

            if (!string.IsNullOrEmpty(updater.Name))
            {
                updatedGroup.Name = updater.Name;
            }

            if (!string.IsNullOrEmpty(updater.Description))
            {
                updatedGroup.Description = updater.Description;
            }

            if (updater.CourseId.HasValue)
            {
                if (await CheckIsCourseExistsAsync(updater.CourseId.Value))
                {
                    updatedGroup.CourseId = updater.CourseId.Value;
                }
            }

            if (updater.LeaderId.HasValue)
            {
                if (updater.LeaderId == -1)
                {
                    updatedGroup.LeaderId = null;
                }
                else if (await CheckIsTeacherAvailabilityAsync(updater.LeaderId.Value))
                {
                    updatedGroup.LeaderId = updater.LeaderId.Value;
                }
            }

            _context.Update(updatedGroup);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE /GroupRepositoryApi/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            var loggedUser = GetLoggedUser();
            if (loggedUser == null)
            {
                return Unauthorized();
            }

            var deletedGroup = await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
            if (deletedGroup == null)
            {
                return NotFound();
            }

            if (await CheckThereAreStudentsInGroupAsync(deletedGroup.Id))
            {
                return NoContent();
            }

            _context.Remove(deletedGroup);
            await _context.SaveChangesAsync();

            return Ok();
        }
        #endregion

        #region Verification methods
        private async Task<bool> CheckIsCourseExistsAsync(int courseId)
        {
            return await _context.Courses.AnyAsync(c => c.Id == courseId);
        }

        private async Task<bool> CheckIsTeacherAvailabilityAsync(int teacherId)
        {
            // учитель должен не только существовать, но ещё и должен не быть лидером курса или группы
            if (!await _context.Teachers.AnyAsync(t => t.Id == teacherId) ||
                await _context.Courses.AnyAsync(c => c.LeaderId == teacherId) ||
                await _context.Groups.AnyAsync(g => g.LeaderId == teacherId))
            {
                return false;
            }

            return true;
        }

        private async Task<bool> CheckThereAreStudentsInGroupAsync(int groupId)
        {
            return await _context.Students.AnyAsync(s => s.GroupId == groupId);
        }
        #endregion
    }
}