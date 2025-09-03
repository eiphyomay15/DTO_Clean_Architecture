using DTO_Clean_Architecture.Application.DtoMapper;
using DTO_Clean_Architecture.Application.Dtos.RequestModel;
using DTO_Clean_Architecture.Application.IServices;
using DTO_Clean_Architecture.Core.Entities;
using DTO_Clean_Architecture.Core.IRepositories;
using DTO_Clean_Architecture.Core.ServiceResponse;

namespace DTO_Clean_Architecture.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffInfoRepository _staffInfoRepository;
        public StaffService(IStaffInfoRepository staffInfoRepository)
        {
            _staffInfoRepository = staffInfoRepository;
        }
        public async Task<ServiceResponse<StaffInfo>> CreateNewStaffInfoAsync(StaffDto staffInfo)
        {
            var newStaffDomain = new StaffDtoMapper().ToDomainObject(staffInfo);
            var isAdded =  await _staffInfoRepository.CreateNewStaffInfoAsync(newStaffDomain);
            
           return !isAdded ? new ServiceResponse<StaffInfo>(false, "Failed to add new staff") :
                new ServiceResponse<StaffInfo>(true, "New staff added successfully", newStaffDomain);
        }

        public Task<bool> DisableStaffInfoByStaffIdAsync(string staffId)
        {
            return _staffInfoRepository.DisableStaffInfoByStaffIdAsync(staffId);
        }

        public async Task<ServiceResponse<List<StaffInfo>>> GetAllActiveStaffsAsync()
        {
            var result = await _staffInfoRepository.GetAllActiveStaffsAsync();
            return result.Count == 0 ? new ServiceResponse<List<StaffInfo>>(false, "No staff found") :
                   new ServiceResponse<List<StaffInfo>>(true, "Active staff retrieved successfully", result);
        }

        public async Task<ServiceResponse<StaffInfo>> GetStaffInfoByStaffIdAsync(string staffId)
        {
            var staff = await _staffInfoRepository.GetStaffInfoByStaffIdAsync(staffId);
            return staff == null ? new ServiceResponse<StaffInfo>(false, "Staff not found") :
                   new ServiceResponse<StaffInfo>(true, "Staff retrieved successfully", staff);
        }

        public async Task<ServiceResponse<StaffInfo>> UpdateStaffInfoAsync(StaffDto staffInfo)
        {
            var updatedStaff = await _staffInfoRepository.UpdateStaffInfoAsync(new StaffDtoMapper().ToDomainObject(staffInfo));
            return updatedStaff == null ? new ServiceResponse<StaffInfo>(false, "Failed to update staff") :
                   new ServiceResponse<StaffInfo>(true, "Staff updated successfully", updatedStaff);
        }
    }
}
