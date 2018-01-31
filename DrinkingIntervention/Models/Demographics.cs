using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingIntervention.Models
{
    public class Demographics
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string Gender { get; set; }

        public string College { get; set; }

        public string CollegeOther { get; set; }

        public string TertiaryInstitution { get; set; }

        public string FirstToAttend { get; set; }

        public string FirstToAttendWider { get; set; }

        public string Ethnicity { get; set; }

        public string EthnicityOther { get; set; }

        public int Age { get; set; }

        public double? Weight { get; set; }

        public string Email { get; set; }
    }
}
