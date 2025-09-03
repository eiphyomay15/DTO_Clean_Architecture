using System;
using System.Collections.Generic;

namespace DTO_Clean_Architecture.Infrastructure.Database;

public partial class Staff
{
    public string Id { get; set; } = null!;

    public string StaffId { get; set; } = null!;

    public string StaffName { get; set; } = null!;

    public string? NrcNumber { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public decimal? Salary { get; set; }

    public DateTime JoinedDate { get; set; }

    public bool Active { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedUser { get; set; } = null!;

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedUser { get; set; }
}
