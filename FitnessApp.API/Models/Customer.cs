using System;
using System.Collections.Generic;

namespace FitnessApp.API.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string SubscriptionType { get; set; } = null!;

    public int SubDateStartYear { get; set; }

    public int SubDateStartMonth { get; set; }

    public int SubDateStartDay { get; set; }

    public int SubDateEndYear { get; set; }

    public int SubDateEndMonth { get; set; }

    public int SubDateEndDay { get; set; }

    public string? BillingAddressStreet { get; set; }

    public int? BillingAddressNo { get; set; }

    public int? BillingAddressFloor { get; set; }

    public string? BillingAddressFull { get; set; }

    public virtual User CustomerNavigation { get; set; } = null!;

    public virtual ICollection<TrainerCustomerRelationship> TrainerCustomerRelationships { get; set; } = new List<TrainerCustomerRelationship>();
}
