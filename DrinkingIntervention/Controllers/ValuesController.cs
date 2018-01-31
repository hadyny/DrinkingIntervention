using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DrinkingIntervention.Models;

namespace DrinkingIntervention
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<dynamic> Get()
        {
            using (var db = new DbModel())
            {
                var returnList = new List<dynamic>();

                foreach (var phone in db.PhoneNumbers)
                {
                    returnList.Add(new { phoneNum = phone.PhoneNumber, group = phone.Group });
                }

                return returnList;
            }
        }
        
        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post(Answer answer)
        {
            try
            {
                using (var db = new DbModel())
                {
                    db.Answers.Add(answer);
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        /*
        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post(List<Answer> answers)
        {
            try
            {
                using (var db = new DbModel())
                {
                    foreach (var answer in answers)
                    {
                        db.Answers.Add(answer);
                    }
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }*/
    }
}