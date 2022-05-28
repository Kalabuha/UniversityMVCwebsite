using Task20.Repositories;
using Task20.Services.Converters;
using Task20.Services.Resources;
using Task20.Models;

namespace Task20.Services
{
    public class GroupService
    {
        private readonly GroupRepository _groupRepository;

        public GroupService(GroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public List<GroupModel> GetAllGroupModels()
        {
            return _groupRepository.GetAllGroups().Select(g => g.EntityToModel()).ToList();
        }

        public GroupData? GetStudentNumberAsGroupDataById(int groupId)
        {
            var groupEntity = _groupRepository.GetEntity(groupId);
            if (groupEntity == null)
            {
                return null;
            }

            var statistics = _groupRepository.GetGroupStatisticsByGroupId(groupId);
            if (statistics == null)
            {
                return null;
            }

            return new GroupData
            {
                StudentsAmount = statistics.Value
            };
        }
    }
}
