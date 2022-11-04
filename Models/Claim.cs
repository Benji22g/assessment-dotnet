using System;
using System.Collections.Generic;

namespace NetC_Assessment___Coding_exercise.Models
{
    public partial class Claim
    {
        public decimal ClaimId { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? Date { get; set; }
        public decimal? VehicleId { get; set; }

        public virtual Vehicle? Vehicle { get; set; }
    }
}
