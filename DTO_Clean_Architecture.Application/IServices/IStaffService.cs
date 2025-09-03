using DTO_Clean_Architecture.Application.Dtos.RequestModel;
using DTO_Clean_Architecture.Core.Entities;
using DTO_Clean_Architecture.Core.ServiceResponse;

namespace DTO_Clean_Architecture.Application.IServices
{
    public interface IStaffService
    {
        Task<ServiceResponse<StaffInfo>> CreateNewStaffInfoAsync(StaffDto staffInfo);
        Task<bool> DisableStaffInfoByStaffIdAsync(string staffId);
        Task<ServiceResponse<List<StaffInfo>>> GetAllActiveStaffsAsync();
        Task<ServiceResponse<StaffInfo>> GetStaffInfoByStaffIdAsync(string staffId);
        Task<ServiceResponse<StaffInfo>> UpdateStaffInfoAsync(StaffDto staffInfo);
    }
}
