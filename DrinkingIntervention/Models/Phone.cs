using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingIntervention.Models
{
    public class Phone
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Pid { get; set; }
        
        public DateTime Timestamp { get; set; }

        public string PhoneNumber { get; set; }

        public int Group { get; set; }
    }

}
