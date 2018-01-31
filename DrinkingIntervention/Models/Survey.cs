using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingIntervention.Models
{
    public class Survey
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Pid { get; set; }
        
        public DateTime Timestamp { get; set; }

        public string consumed { get; set; }

        public double? q1drinks { get; set; }
        public double? q1hours { get; set; }
        public double? q2monday { get; set; }
        public double? q2tuesday { get; set; }
        public double? q2wednesday { get; set; }
        public double? q2thursday { get; set; }
        public double? q2friday { get; set; }
        public double? q2saturday { get; set; }
        public double? q2sunday { get; set; }
        
        public int? q3 { get; set; }
        
        public int? q4 { get; set; }
        
        public int? q5 { get; set; }
        
        public int? q6 { get; set; }
        
        public int? q7 { get; set; }
        
        public int? q8 { get; set; }
        
        public int? q9 { get; set; }
        
        public int? q10 { get; set; }
        
        public int? q11 { get; set; }
        
        public int? q12 { get; set; }
        
        public int? q13a { get; set; }
        
        public int? q13b { get; set; }
        
        public int? q13c { get; set; }
        
        public int? q13d { get; set; }
        
        public int? q13e { get; set; }
        
        public int? q13f { get; set; }
        
        public int? q13g { get; set; }
        
        public int? q13h { get; set; }
        
        public int? q13i { get; set; }
        
        public int? q13j { get; set; }
        
        public int? q13k { get; set; }
        
        public int? q13l { get; set; }
        
        public int? q13m { get; set; }
        
        public int? q13n { get; set; }
        
        public int? q13o { get; set; }
        
        public int? q13p { get; set; }
        
        public int? q13q { get; set; }
        
        public int? q13r { get; set; }
        
        public int? q13s { get; set; }
        
        public int? q13t { get; set; }
        
        public int? q13u { get; set; }
        
        public int? q13v { get; set; }
        
        public int? q13w { get; set; }
        
        public int? q13x { get; set; }
        
        public int? q14 { get; set; }
        
        public int? q15a { get; set; }
        
        public int? q15b { get; set; }
        
        public int? q15c { get; set; }
        
        public int? q15d { get; set; }
        
        public int? q15e { get; set; }
    }
}
