using System;
using System.Collections.Generic;

namespace NetC_Assessment___Coding_exercise.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Claims = new HashSet<Claim>();
            InverseOwner = new HashSet<Vehicle>();
        }

        public decimal VehiclesId { get; set; }
        public string? Brand { get; set; }
        public string? Vin { get; set; }
        public string? Color { get; set; }
        public string? Year { get; set; }
        public decimal? OwnerId { get; set; }

        public virtual Vehicle? Owner { get; set; }
        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<Vehicle> InverseOwner { get; set; }
    }
}
