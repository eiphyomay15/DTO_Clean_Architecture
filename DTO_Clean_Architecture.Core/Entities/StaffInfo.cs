namespace DTO_Clean_Architecture.Core.Entities
{
    public class StaffInfo : IDomainObject
    {
        public string StaffId { get;  set; }
        public string StaffName { get;  set; }
        public string? NrcNumber { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public decimal? Salary { get; set; }

        public DateTime JoinedDate { get; set; }

        public StaffInfo(string staffId,string staffName, string? nrcNumber, string? phoneNumber, string? email, string? address, decimal? salary, DateTime joinedDate)
        {
            StaffId = staffId;
            StaffName = staffName;
            NrcNumber = nrcNumber;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            Salary = salary;
            JoinedDate = joinedDate;
        }
    }
}
