using System;
using System.Collections.Generic;

namespace FitnessApp.API.Models;

public partial class Trainer
{
    public int TrainerId { get; set; }

    public string? Specialization { get; set; }

    public string Education { get; set; } = null!;

    public string EducationTitle { get; set; } = null!;

    public int YearsOfExperience { get; set; }

    public double HourlyRate { get; set; }

    public string Bio { get; set; } = null!;

    public int NoOfRating { get; set; }

    public double AverageRating { get; set; }

    public int TotalSessionsConducted { get; set; }

    public int CurrentCustomers { get; set; }

    public virtual ICollection<TrainerCustomerRelationship> TrainerCustomerRelationships { get; set; } = new List<TrainerCustomerRelationship>();

    public virtual User TrainerNavigation { get; set; } = null!;
}
