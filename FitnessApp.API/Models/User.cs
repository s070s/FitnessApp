using System;
using System.Collections.Generic;

namespace FitnessApp.API.Models;

public partial class User
{
    public int Id { get; set; }

    public string LoginUserName { get; set; } = null!;

    public int JoinDateYear { get; set; }

    public int JoinDateMonth { get; set; }

    public int JoinDateDay { get; set; }

    public int LastLoginDateYear { get; set; }

    public int LastLoginDateMonth { get; set; }

    public int LastLoginDateDay { get; set; }

    public int? BirthDateYear { get; set; }

    public int? BirthDateMonth { get; set; }

    public int? BirthDateDay { get; set; }

    public string LoginEmaill { get; set; } = null!;

    public string LoginPasswordHash { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Gender { get; set; }

    public string IsActive { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public double? BodyHeight { get; set; }

    public int? BodyWeight { get; set; }

    public string FitnessLevel { get; set; } = null!;

    public double? Bmr { get; set; }

    public double? BodyFatWeight { get; set; }

    public double? MuscoSkeletalWeight { get; set; }

    public long? CommunicationPhone { get; set; }

    public int? CommunicationPhoneAreaCode { get; set; }

    public string? DietaryPreferences { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
