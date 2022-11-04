using System;
using System.Collections.Generic;

namespace NetC_Assessment___Coding_exercise.Models
{
    public partial class Owner
    {
        public int OwnerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastNme { get; set; }
        public bool? DriverLicense { get; set; }
    }
}
