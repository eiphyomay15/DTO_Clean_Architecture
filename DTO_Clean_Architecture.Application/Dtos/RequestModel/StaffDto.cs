namespace DTO_Clean_Architecture.Application.Dtos.RequestModel
{
    public class StaffDto : IDto
    {
        public string StaffId { get; }
        public string StaffName { get;  }
        public string? NrcNumber { get; }

        public string? PhoneNumber { get;  }

        public string? Email { get; }

        public string? Address { get; }

        public decimal? Salary { get; }

        public DateTime JoinedDate { get; }
        public StaffDto(string staffId, string staffName, string? nrcNumber, string? phoneNumber, string? email, string? address, decimal? salary, DateTime joinedDate)
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
