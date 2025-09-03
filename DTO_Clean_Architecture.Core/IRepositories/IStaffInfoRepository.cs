using DTO_Clean_Architecture.Core.Entities;

namespace DTO_Clean_Architecture.Core.IRepositories
{
    public interface IStaffInfoRepository
    {
        Task<bool> CreateNewStaffInfoAsync(StaffInfo staffInfo);
        Task<StaffInfo> GetStaffInfoByStaffIdAsync(string staffId);
        Task<StaffInfo> UpdateStaffInfoAsync(StaffInfo staffInfo);
        Task<bool> DisableStaffInfoByStaffIdAsync(string staffId);
        Task<List<StaffInfo>> GetAllActiveStaffsAsync();
    }
}
