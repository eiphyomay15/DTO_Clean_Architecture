using DTO_Clean_Architecture.Application.Dtos.RequestModel;
using DTO_Clean_Architecture.Core.Entities;

namespace DTO_Clean_Architecture.Application.DtoMapper
{
    public class StaffDtoMapper : IDtoMapper<StaffDto, Core.Entities.StaffInfo>
    {
        public StaffInfo ToDomainObject(StaffDto dto)
        {
           return new StaffInfo(dto.StaffId, dto.StaffName,dto.NrcNumber,dto.PhoneNumber,dto.Email,dto.Address,dto.Salary,dto.JoinedDate);
        }

        public StaffDto ToDto(StaffInfo domainObject)
        {
            return new StaffDto(domainObject.StaffId, domainObject.StaffName, domainObject.NrcNumber, domainObject.PhoneNumber, domainObject.Email, domainObject.Address, domainObject.Salary, domainObject.JoinedDate);
        }
    }
}
