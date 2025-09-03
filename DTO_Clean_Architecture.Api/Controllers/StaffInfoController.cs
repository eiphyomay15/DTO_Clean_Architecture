using DTO_Clean_Architecture.Application.DtoMapper;
using DTO_Clean_Architecture.Application.Dtos.RequestModel;
using DTO_Clean_Architecture.Application.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DTO_Clean_Architecture.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffInfoController : ControllerBase
    {
        private readonly IStaffService _staffService;
        public StaffInfoController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        [HttpGet]
        [Route("getAllActiveStaffLists")]
        public async Task<IActionResult> GetAllStaffs()
        {
            var results = await _staffService.GetAllActiveStaffsAsync();
            if (!results.Status)
            {
                return BadRequest(results.Message);
            }
            var staffDtos = results.Data.Select(s => new StaffDtoMapper().ToDto(s)).ToList();
            return Ok(staffDtos); 
        }

        [HttpPost]
        [Route("createNewStaffInfo")]
        public async Task<IActionResult> CreateNewStaffInfo(StaffDto staffInfo)
        {
            var result = await _staffService.CreateNewStaffInfoAsync(staffInfo);
            if (!result.Status)
            {
                return BadRequest(result.Message);
            }
            var newStaffDto = new StaffDtoMapper().ToDto(result.Data);
            return Ok(newStaffDto);
        }
        [HttpPost]
        [Route("updateStaffInfo")]
        public async Task<IActionResult> UpdateStaffInfo(StaffDto staffInfo)
        {
            var result = await _staffService.UpdateStaffInfoAsync(staffInfo);
            if (!result.Status)
            {
                return BadRequest(result.Message);
            }
            var updatedStaffDto = new StaffDtoMapper().ToDto(result.Data);
            return Ok(result.Data);
        }

        [HttpPost]
        [Route("disableStaffInfoByStaffId/{staffId}")]
        public async Task<IActionResult> DisableStaffInfoByStaffId(string staffId)
        {
            var isDisabled = await _staffService.DisableStaffInfoByStaffIdAsync(staffId);
            if (!isDisabled)
            {
                return BadRequest("Failed to disable staff or staff not found");
            }
            return Ok("Staff disabled successfully");
        }

    }
}
