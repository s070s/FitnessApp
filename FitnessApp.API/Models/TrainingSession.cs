using System;
using System.Collections.Generic;

namespace FitnessApp.API.Models;

public partial class TrainingSession
{
    public int TrainingSessionId { get; set; }

    public int TrainerCustomerRelationshipId { get; set; }

    public int SessionDateYear { get; set; }

    public int SessionDateMonth { get; set; }

    public int SessionDateDay { get; set; }

    public int SessionDurationMinutes { get; set; }

    public string SessionFocus { get; set; } = null!;

    public string? Notes { get; set; }

    public int? CustomerRating { get; set; }

    public virtual TrainerCustomerRelationship TrainerCustomerRelationship { get; set; } = null!;
}
