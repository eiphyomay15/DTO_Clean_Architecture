using DTO_Clean_Architecture.Core.Entities;
using DTO_Clean_Architecture.Infrastructure.Database;

namespace DTO_Clean_Architecture.Infrastructure.DbMapper
{
    public class StaffInfoMapper : IDbMapper<StaffInfo, Staff>
    {
        public Staff ToDbObject(StaffInfo domainObject)
        {
            return new Staff()
            {
                Id  = Guid.NewGuid().ToString(),
                StaffId = domainObject.StaffId,
                StaffName = domainObject.StaffName,
                NrcNumber = domainObject.NrcNumber,
                PhoneNumber = domainObject.PhoneNumber,
                Email = domainObject.Email,
                Address = domainObject.Address,
                Salary = domainObject.Salary,
                JoinedDate = domainObject.JoinedDate,
                Active = true,
                CreatedDate = DateTime.Now,
                CreatedUser = "admin",
                UpdatedDate = null,
                UpdatedUser = null
            };
        }

        public StaffInfo ToDomainObject(Staff dbObject)
        {
            return new StaffInfo(
                dbObject.StaffId,
                dbObject.StaffName ?? string.Empty,
                dbObject.NrcNumber,
                dbObject.PhoneNumber,
                dbObject.Email,
                dbObject.Address,
                dbObject.Salary,
                dbObject.JoinedDate
            );
        }
    }
}
