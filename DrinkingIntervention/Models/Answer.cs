using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkingIntervention.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string phone { get; set; }

        public string question { get; set; }

        public string answer { get; set; }

        public string surveyid { get; set; }

        public string timestamp { get; set; }
    }
}