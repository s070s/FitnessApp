using System;
using System.Collections.Generic;

namespace FitnessApp.API.Models;

public partial class TrainerCustomerRelationship
{
    public int RelationshipId { get; set; }

    public int TrainerId { get; set; }

    public int CustomerId { get; set; }

    public int RelationshipStartDateYear { get; set; }

    public int RelationshipStartDateMonth { get; set; }

    public int RelationshipStartDateDay { get; set; }

    public int? RelationshipEndDateYear { get; set; }

    public int? RelationshipEndDateMonth { get; set; }

    public int? RelationshipEndDateDay { get; set; }

    public int? IsActive { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Trainer Trainer { get; set; } = null!;

    public virtual TrainingSession? TrainingSession { get; set; }
}
