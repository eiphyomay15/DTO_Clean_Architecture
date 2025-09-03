using DTO_Clean_Architecture.Core.Entities;
using DTO_Clean_Architecture.Core.IRepositories;
using DTO_Clean_Architecture.Infrastructure.Database;
using DTO_Clean_Architecture.Infrastructure.DbMapper;
using Microsoft.EntityFrameworkCore;

namespace DTO_Clean_Architecture.Infrastructure.Repositories
{
    public class StaffInfoRepository : IStaffInfoRepository
    {
        private readonly ApplicationDbContext _context;
        public StaffInfoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateNewStaffInfoAsync(StaffInfo staffInfo)
        {
            try
            {
                using (var db = _context)
                {
                    var newStaff = new StaffInfoMapper().ToDbObject(staffInfo);
                    db.Staff.Add(newStaff);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
                
            }
        }

        public async Task<bool> DisableStaffInfoByStaffIdAsync(string staffId)
        {
            try
            {
                using (var db = _context)
                {
                    var staff = await db.Staff.FirstOrDefaultAsync(s => s.StaffId == staffId && s.Active);
                    if (staff != null)
                    {
                        staff.Active = false;
                        staff.UpdatedDate = DateTime.UtcNow;
                        // Assuming you have a way to get the current user
                        staff.UpdatedUser = "system"; // Replace with actual user
                       
                        await db.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<StaffInfo>> GetAllActiveStaffsAsync()
        {
            try
            {
                using (var db = _context)
                {
                    var activeStaffs = await  db.Staff.Where(s => s.Active).ToListAsync();
                    if (activeStaffs != null)
                    {
                        var staffInfos = activeStaffs.Select(s => new StaffInfoMapper().ToDomainObject(s)).ToList();
                        return staffInfos;
                    }
                    return new List<StaffInfo>();
                }
            }
            catch (Exception ex)
            {
                return new List<StaffInfo>();
            }
        }
        public async Task<StaffInfo> GetStaffInfoByStaffIdAsync(string staffId)
        {
            try
            {
                using (var db = _context)
                {
                   var stataff = await db.Staff.FirstOrDefaultAsync(x=>x.StaffId == staffId && x.Active);
                    if (stataff != null)
                    {
                        var staffInfo = new StaffInfoMapper().ToDomainObject(stataff);
                        return staffInfo;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<StaffInfo> UpdateStaffInfoAsync(StaffInfo staffInfo)
        {
            try
            {
                using(var db = _context)
                {
                    var existingStaff = await db.Staff.FirstOrDefaultAsync(s => s.StaffId == staffInfo.StaffId && s.Active);
                    if (existingStaff != null)
                    {
                        existingStaff.StaffName = staffInfo.StaffName;
                        existingStaff.NrcNumber = staffInfo.NrcNumber;
                        existingStaff.PhoneNumber = staffInfo.PhoneNumber;
                        existingStaff.Email = staffInfo.Email;
                        existingStaff.Address = staffInfo.Address;
                        existingStaff.Salary = staffInfo.Salary;
                        existingStaff.JoinedDate = staffInfo.JoinedDate;
                        existingStaff.UpdatedDate = DateTime.UtcNow;
                        // Assuming you have a way to get the current user
                        existingStaff.UpdatedUser = "system"; // Replace with actual user
                        await db.SaveChangesAsync();
                        return staffInfo;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;    
            }
        }
    }
}
