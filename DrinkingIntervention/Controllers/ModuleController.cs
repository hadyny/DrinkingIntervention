using DrinkingIntervention.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrinkingIntervention.Controllers
{
    public class ModuleController : Controller
    {
        public DbModel db = new DbModel();

        // GET: Module
        public ActionResult Module1(int id)
        {
            var answers = db.Surveys.SingleOrDefault(m => m.Pid == id);
            var demographics = db.Demographics.SingleOrDefault(m => m.Id == id);
            if (answers == null)
            {
                return new HttpNotFoundResult();
            }
            return View();
        }

        public ActionResult Module2(int id)
        {
            var answers = db.Surveys.SingleOrDefault(m => m.Pid == id);
            var demographics = db.Demographics.SingleOrDefault(m => m.Id == id);
            if (answers == null)
            {
                return new HttpNotFoundResult();
            }
            int weeklyDrinks = (int)(answers.q2monday ?? 0 + answers.q2tuesday ?? 0 + answers.q2wednesday ?? 0 + answers.q2thursday ?? 0 + answers.q2friday ?? 0 + answers.q2saturday ?? 0 + answers.q2sunday ?? 0);
            ViewBag.aveNumWeeklyDrinks = weeklyDrinks;
            ViewBag.gender = demographics.Gender;
            ViewBag.typicalDrinksPerWeek = demographics.Gender == "male" ? "11.2" : "6.0";

            if (demographics.Gender == "male")
            {
                if (weeklyDrinks == 0)
                {
                    ViewBag.drinkMoreThanPercent = "21.3";
                    ViewBag.drinkMoreThanFirstYearPercent = 24;
                }
                else if (weeklyDrinks > 0 && weeklyDrinks <= 5)
                {
                    ViewBag.drinkMoreThanPercent = "21.3";
                    ViewBag.drinkMoreThanFirstYearPercent = 24;
                }
                else if (weeklyDrinks > 5 && weeklyDrinks <= 10)
                {
                    ViewBag.drinkMoreThanPercent = "40";
                    ViewBag.drinkMoreThanFirstYearPercent = 40;
                }
                else if (weeklyDrinks > 10 && weeklyDrinks <= 15)
                {
                    ViewBag.drinkMoreThanPercent = "60";
                    ViewBag.drinkMoreThanFirstYearPercent = 52;
                }
                else if (weeklyDrinks > 15 && weeklyDrinks <= 20)
                {
                    ViewBag.drinkMoreThanPercent = "68";
                    ViewBag.drinkMoreThanFirstYearPercent = 64;
                }
                else if (weeklyDrinks > 20 && weeklyDrinks <= 25)
                {
                    ViewBag.drinkMoreThanPercent = "79";
                    ViewBag.drinkMoreThanFirstYearPercent = 82;
                }
                else if (weeklyDrinks > 25 && weeklyDrinks <= 30)
                {
                    ViewBag.drinkMoreThanPercent = "86";
                    ViewBag.drinkMoreThanFirstYearPercent = 89;
                }
                else if (weeklyDrinks > 30 && weeklyDrinks <= 35)
                {
                    ViewBag.drinkMoreThanPercent = "92";
                    ViewBag.drinkMoreThanFirstYearPercent = 95;
                }
                else if (weeklyDrinks > 35 && weeklyDrinks <= 40)
                {
                    ViewBag.drinkMoreThanPercent = "94";
                    ViewBag.drinkMoreThanFirstYearPercent = 95;
                }
                else if (weeklyDrinks > 40 && weeklyDrinks <= 45)
                {
                    ViewBag.drinkMoreThanPercent = "97";
                    ViewBag.drinkMoreThanFirstYearPercent = 96;
                }
                else if (weeklyDrinks > 45 && weeklyDrinks <= 50)
                {
                    ViewBag.drinkMoreThanPercent = "99+";
                    ViewBag.drinkMoreThanFirstYearPercent = 98;
                }
                else if (weeklyDrinks > 50)
                {
                    ViewBag.drinkMoreThanPercent = "99+";
                    ViewBag.drinkMoreThanFirstYearPercent = 99;
                }
            }
            else if (demographics.Gender == "female")
            {
                if (weeklyDrinks == 0)
                {
                    ViewBag.drinkMoreThanPercent = "25";
                    ViewBag.drinkMoreThanFirstYearPercent = 25;
                }
                else if (weeklyDrinks > 0 && weeklyDrinks <= 5)
                {
                    ViewBag.drinkMoreThanPercent = "25";
                    ViewBag.drinkMoreThanFirstYearPercent = 25;
                }
                else if (weeklyDrinks > 5 && weeklyDrinks <= 10)
                {
                    ViewBag.drinkMoreThanPercent = "56";
                    ViewBag.drinkMoreThanFirstYearPercent = 56;
                }
                else if (weeklyDrinks > 10 && weeklyDrinks <= 15)
                {
                    ViewBag.drinkMoreThanPercent = "78";
                    ViewBag.drinkMoreThanFirstYearPercent = 78;
                }
                else if (weeklyDrinks > 15 && weeklyDrinks <= 20)
                {
                    ViewBag.drinkMoreThanPercent = "89";
                    ViewBag.drinkMoreThanFirstYearPercent = 89;
                }
                else if (weeklyDrinks > 20 && weeklyDrinks <= 25)
                {
                    ViewBag.drinkMoreThanPercent = "95";
                    ViewBag.drinkMoreThanFirstYearPercent = 95;
                }
                else if (weeklyDrinks > 25 && weeklyDrinks <= 30)
                {
                    ViewBag.drinkMoreThanPercent = "98";
                    ViewBag.drinkMoreThanFirstYearPercent = 98;
                }
                else if (weeklyDrinks > 30)
                {
                    ViewBag.drinkMoreThanPercent = "99+";
                    ViewBag.drinkMoreThanFirstYearPercent = 99;
                }
            }

            if (weeklyDrinks == 0)
            {
                ViewBag.drinkMoreThanPercentMsg = ViewBag.drinkMoreThanPercent + "% of " + demographics.Gender + " students also report not drinking during a typical week!";
            }
            else
            {
                ViewBag.drinkMoreThanPercentMsg = "You drink more than " + ViewBag.drinkMoreThanPercent + "% of " + demographics.Gender + " students at the University of Otago";
            }

            return View();
        }

        public ActionResult Module3(int id)
        {
            var answers = db.Surveys.SingleOrDefault(m => m.Pid == id);
            var demographics = db.Demographics.SingleOrDefault(m => m.Id == id);
            if (answers == null)
            {
                return new HttpNotFoundResult();
            }
            int weeklyDrinks = (int)(answers.q2monday ?? 0 + answers.q2tuesday ?? 0 + answers.q2wednesday ?? 0 + answers.q2thursday ?? 0 + answers.q2friday ?? 0 + answers.q2saturday ?? 0 + answers.q2sunday ?? 0);

            if (demographics.Gender == "male")
            {
                if (weeklyDrinks == 0)
                {
                    ViewBag.drinkMoreThanPercent = "21.3";
                    ViewBag.drinkMoreThanFirstYearPercent = 24;
                }
                else if (weeklyDrinks > 0 && weeklyDrinks <= 5)
                {
                    ViewBag.drinkMoreThanPercent = "21.3";
                    ViewBag.drinkMoreThanFirstYearPercent = 24;
                }
                else if (weeklyDrinks > 5 && weeklyDrinks <= 10)
                {
                    ViewBag.drinkMoreThanPercent = "40";
                    ViewBag.drinkMoreThanFirstYearPercent = 40;
                }
                else if (weeklyDrinks > 10 && weeklyDrinks <= 15)
                {
                    ViewBag.drinkMoreThanPercent = "60";
                    ViewBag.drinkMoreThanFirstYearPercent = 52;
                }
                else if (weeklyDrinks > 15 && weeklyDrinks <= 20)
                {
                    ViewBag.drinkMoreThanPercent = "68";
                    ViewBag.drinkMoreThanFirstYearPercent = 64;
                }
                else if (weeklyDrinks > 20 && weeklyDrinks <= 25)
                {
                    ViewBag.drinkMoreThanPercent = "79";
                    ViewBag.drinkMoreThanFirstYearPercent = 82;
                }
                else if (weeklyDrinks > 25 && weeklyDrinks <= 30)
                {
                    ViewBag.drinkMoreThanPercent = "86";
                    ViewBag.drinkMoreThanFirstYearPercent = 89;
                }
                else if (weeklyDrinks > 30 && weeklyDrinks <= 35)
                {
                    ViewBag.drinkMoreThanPercent = "92";
                    ViewBag.drinkMoreThanFirstYearPercent = 95;
                }
                else if (weeklyDrinks > 35 && weeklyDrinks <= 40)
                {
                    ViewBag.drinkMoreThanPercent = "94";
                    ViewBag.drinkMoreThanFirstYearPercent = 95;
                }
                else if (weeklyDrinks > 40 && weeklyDrinks <= 45)
                {
                    ViewBag.drinkMoreThanPercent = "97";
                    ViewBag.drinkMoreThanFirstYearPercent = 96;
                }
                else if (weeklyDrinks > 45 && weeklyDrinks <= 50)
                {
                    ViewBag.drinkMoreThanPercent = "99+";
                    ViewBag.drinkMoreThanFirstYearPercent = 98;
                }
                else if (weeklyDrinks > 50)
                {
                    ViewBag.drinkMoreThanPercent = "99+";
                    ViewBag.drinkMoreThanFirstYearPercent = 99;
                }
            }
            else if (demographics.Gender == "female")
            {
                if (weeklyDrinks == 0)
                {
                    ViewBag.drinkMoreThanPercent = "25";
                    ViewBag.drinkMoreThanFirstYearPercent = 25;
                }
                else if (weeklyDrinks > 0 && weeklyDrinks <= 5)
                {
                    ViewBag.drinkMoreThanPercent = "25";
                    ViewBag.drinkMoreThanFirstYearPercent = 25;
                }
                else if (weeklyDrinks > 5 && weeklyDrinks <= 10)
                {
                    ViewBag.drinkMoreThanPercent = "56";
                    ViewBag.drinkMoreThanFirstYearPercent = 56;
                }
                else if (weeklyDrinks > 10 && weeklyDrinks <= 15)
                {
                    ViewBag.drinkMoreThanPercent = "78";
                    ViewBag.drinkMoreThanFirstYearPercent = 78;
                }
                else if (weeklyDrinks > 15 && weeklyDrinks <= 20)
                {
                    ViewBag.drinkMoreThanPercent = "89";
                    ViewBag.drinkMoreThanFirstYearPercent = 89;
                }
                else if (weeklyDrinks > 20 && weeklyDrinks <= 25)
                {
                    ViewBag.drinkMoreThanPercent = "95";
                    ViewBag.drinkMoreThanFirstYearPercent = 95;
                }
                else if (weeklyDrinks > 25 && weeklyDrinks <= 30)
                {
                    ViewBag.drinkMoreThanPercent = "98";
                    ViewBag.drinkMoreThanFirstYearPercent = 98;
                }
                else if (weeklyDrinks > 30)
                {
                    ViewBag.drinkMoreThanPercent = "99+";
                    ViewBag.drinkMoreThanFirstYearPercent = 99;
                }
            }

            if (weeklyDrinks == 0)
            {
                ViewBag.drinkMoreThanFirstYearPercentMsg = ViewBag.drinkMoreThanFirstYearPercent + "% of " + demographics.Gender + " first year students also report not drinking during a typical week!";
            }
            else
            {
                ViewBag.drinkMoreThanFirstYearPercentMsg = "You drink more than " + ViewBag.drinkMoreThanFirstYearPercent + "% of " + demographics.Gender + " first year students at the University of Otago";
            }

            int daysDrinking = 0;
            if (answers.q2monday != 0) daysDrinking++;
            if (answers.q2tuesday != 0) daysDrinking++;
            if (answers.q2wednesday != 0) daysDrinking++;
            if (answers.q2thursday != 0) daysDrinking++;
            if (answers.q2friday != 0) daysDrinking++;
            if (answers.q2saturday != 0) daysDrinking++;
            if (answers.q2sunday != 0) daysDrinking++;

            ViewBag.daysDrinkingPercent = Math.Round((double)((100 / 7) * daysDrinking), 0);
            ViewBag.lowSpend = weeklyDrinks * 52 * 2;
            ViewBag.highSpend = weeklyDrinks * 52 * 10;
            ViewBag.numCalories = weeklyDrinks * 170;

            return View();
        }

        public ActionResult Module4(int id)
        {
            var answers = db.Surveys.SingleOrDefault(m => m.Pid == id);
            var demographics = db.Demographics.SingleOrDefault(m => m.Id == id);
            if (answers == null)
            {
                return new HttpNotFoundResult();
            }

            int? audit = (answers.q3 ?? 0) + 
                         (answers.q4 ?? 0) + 
                         (answers.q5 ?? 0) + 
                         (answers.q6 ?? 0) +
                         (answers.q7 ?? 0) + 
                         (answers.q8 ?? 0) + 
                         (answers.q9 ?? 0) + 
                         (answers.q10 ?? 0) + 
                         (answers.q11 ?? 0) + 
                         (answers.q12 ?? 0);
            ViewBag.auditScore = audit.Value;
            
            return View();
        }

        public ActionResult Module5(int id)
        {
            var answers = db.Surveys.SingleOrDefault(m => m.Pid == id);
            var demographics = db.Demographics.SingleOrDefault(m => m.Id == id);
            if (answers == null)
            {
                return new HttpNotFoundResult();
            }

            int? audit = (answers.q3 ?? 0) +
                         (answers.q4 ?? 0) +
                         (answers.q5 ?? 0) +
                         (answers.q6 ?? 0) +
                         (answers.q7 ?? 0) +
                         (answers.q8 ?? 0) +
                         (answers.q9 ?? 0) +
                         (answers.q10 ?? 0) +
                         (answers.q11 ?? 0) +
                         (answers.q12 ?? 0);
            ViewBag.auditScore = audit.Value;
            string genderImage = "";
            if (demographics.Gender == "male")
            {
                genderImage = "<img src=\"" + Url.Content("~/Content/Images/male.png") + "\" alt=\"\" />";
            }
            else if (demographics.Gender == "female")
            {
                genderImage = "<img src=\"" + Url.Content("~/Content/Images/female.png") + "\" alt=\"\" />";
            }

            if (audit == 0)
            {
                ViewBag.auditText = "Your AUDIT score indicates that you have no problem with your drinking.";
                ViewBag.auditDescription = "But, if you were to start drinking more it is still important to notice the effect alcohol is having on you. At the current level, your drinking will make your transition to academic life nice and smooth.";
                ViewBag.veryHigh = "very high";
                ViewBag.high = "high";
                ViewBag.medium = "medium";
                ViewBag.low = "low";
                ViewBag.noProblem = genderImage + "no problem" + genderImage;
                ViewBag.npclass = "selected";
            }
            else if (audit > 0 && audit <= 7)
            {
                ViewBag.auditText = "Your AUDIT score indicates that you are a low risk.";
                ViewBag.auditDescription = "Your drinking is not likely to cause you problems if it remains at this level. At the current level, your drinking will make your transition to academic life nice and smooth. But, if you were to start drinking more it is still important to notice the effect alcohol is having on you.";
                ViewBag.veryHigh = "very high";
                ViewBag.high = "high";
                ViewBag.medium = "medium";
                ViewBag.low = genderImage + "low" + genderImage;
                ViewBag.noProblem = "no problem";
                ViewBag.lclass = "selected";
            }
            else if (audit > 7 && audit <= 15)
            {
                ViewBag.auditText = "Your AUDIT score indicates that you are at a medium risk.";
                ViewBag.auditDescription = "Your drinking is putting you at risk of developing problems. Cutting down how much and how often you drink will reduce your risks and make your academic life a lot smoother.";
                ViewBag.veryHigh = "very high";
                ViewBag.high = "high";
                ViewBag.medium = genderImage + "medium" + genderImage;
                ViewBag.low = "low";
                ViewBag.noProblem = "no problem";
                ViewBag.mclass = "selected";
            }
            else if (audit > 15 && audit <= 19)
            {
                ViewBag.auditText = "Your AUDIT score indicates that you are at a high risk.";
                ViewBag.auditDescription = "Your drinking will cause you or may have already caused you problems. Cutting down how much and how often you drink will reduce your risks and make your academic life a lot smoother.";
                ViewBag.veryHigh = "very high";
                ViewBag.high = genderImage + "high" + genderImage;
                ViewBag.medium = "medium";
                ViewBag.low = "low";
                ViewBag.noProblem = "no problem";
                ViewBag.hclass = "selected";
            }
            else if (audit > 19)
            {
                ViewBag.auditText = "Your AUDIT score indicates that you are at a very high risk.";
                ViewBag.auditDescription = "Your drinking will cause you or may have already caused you problems. Cutting down how much and how often you drink will reduce your risks and make your academic life a lot smoother.";
                ViewBag.veryHigh = genderImage + "very high" + genderImage;
                ViewBag.high = "high";
                ViewBag.medium = "medium";
                ViewBag.low = "low";
                ViewBag.noProblem = "no problem";
                ViewBag.vhclass = "selected";
            }
            return View();
        }

        public ActionResult Module6(int id)
        {
            var answers = db.Surveys.SingleOrDefault(m => m.Pid == id);
            var demographics = db.Demographics.SingleOrDefault(m => m.Id == id);
            if (answers == null)
            {
                return new HttpNotFoundResult();
            }

            ViewBag.numDrinks = answers.q1drinks ?? 0;
            ViewBag.numHours = answers.q1hours ?? 0;

            double SD = answers.q1drinks ?? 0;
            double BW = demographics.Gender == "male" ? 0.58 : 0.49;
            double Wt = demographics.Weight.Value;
            double MR = demographics.Gender == "male" ? 0.017 : 0.015;
            double DP = answers.q1hours ?? 0;


            double peakBAC = Math.Round(((0.806 * SD) / (BW * Wt)) - (MR * DP), 2);
            if (peakBAC <= 0)
            {
                ViewBag.peakBAC = "0.00";
            }
            else
            {
                ViewBag.peakBAC = peakBAC;
            }

            return View();
        }

        public ActionResult Module7(int id)
        {
            var answers = db.Surveys.SingleOrDefault(m => m.Pid == id);
            var demographics = db.Demographics.SingleOrDefault(m => m.Id == id);
            if (answers == null)
            {
                return new HttpNotFoundResult();
            }

            double SD = answers.q1drinks ?? 0;
            double BW = demographics.Gender == "male" ? 0.58 : 0.49;
            double Wt = demographics.Weight.Value;
            double MR = demographics.Gender == "male" ? 0.017 : 0.015;
            double DP = answers.q1hours ?? 0;


            double peakBAC = Math.Round(((0.806 * SD) / (BW * Wt)) - (MR * DP), 2);
       
            if (peakBAC > 0 && peakBAC <= .04)
            {
                ViewBag.selectedCircle = "js-bac04";
            }
            else if (peakBAC > .04 && peakBAC <= .09)
            {
                ViewBag.selectedCircle = "js-bac09";
            }
            else if (peakBAC > .09 && peakBAC <= .14)
            {
                ViewBag.selectedCircle = "js-bac14";
            }
            else if (peakBAC > .14 && peakBAC <= .24)
            {
                ViewBag.selectedCircle = "js-bac24";
            }
            else if (peakBAC > .24 && peakBAC <= .34)
            {
                ViewBag.selectedCircle = "js-bac34";
            }
            else if (peakBAC > .34)
            {
                ViewBag.selectedCircle = "js-bac35";
            }

            ViewBag.maxDrinks = demographics.Gender == "male" ? 5 : 4;

            return View();
        }

        public ActionResult Module8(int id)
        {
            var answers = db.Surveys.SingleOrDefault(m => m.Pid == id);
            var demographics = db.Demographics.SingleOrDefault(m => m.Id == id);
            if (answers == null)
            {
                return new HttpNotFoundResult();
            }
            return View();
        }
        public ActionResult Module9(int id)
        {
            var answers = db.Surveys.SingleOrDefault(m => m.Pid == id);
            var demographics = db.Demographics.SingleOrDefault(m => m.Id == id);
            if (answers == null)
            {
                return new HttpNotFoundResult();
            }

            ViewBag.numHarms =
                answers.q13a ?? 0 + answers.q13b ?? 0 + answers.q13c ?? 0 + answers.q13d ?? 0 + answers.q13e ?? 0 + answers.q13f ?? 0 +
                answers.q13g ?? 0 + answers.q13h ?? 0 + answers.q13i ?? 0 + answers.q13j ?? 0 + answers.q13k ?? 0 + answers.q13l ?? 0 +
                answers.q13m ?? 0 + answers.q13n ?? 0 + answers.q13o ?? 0 + answers.q13p ?? 0 + answers.q13q ?? 0 + answers.q13r ?? 0 +
                answers.q13s ?? 0 + answers.q13t ?? 0 + answers.q13u ?? 0 + answers.q13v ?? 0 + answers.q13w ?? 0 + answers.q13x ?? 0;
            ViewBag.droveIntoxicated = "7";
            ViewBag.passedOut = "22";
            ViewBag.cantRemember = "37";
            ViewBag.embarrassed = "42";
            ViewBag.hurt = "13";
            ViewBag.academicHarm = "10";
            ViewBag.rude = "17";
            return View();
        }
        public ActionResult Module10(int id)
        {
            var answers = db.Surveys.SingleOrDefault(m => m.Pid == id);
            var demographics = db.Demographics.SingleOrDefault(m => m.Id == id);
            if (answers == null)
            {
                return new HttpNotFoundResult();
            }
            return View();
        }
        public ActionResult Module11(int id)
        {
            var answers = db.Surveys.SingleOrDefault(m => m.Pid == id);
            var demographics = db.Demographics.SingleOrDefault(m => m.Id == id);
            if (answers == null)
            {
                return new HttpNotFoundResult();
            }
            return View();
        }
        public ActionResult Module12(int id)
        {
            var answers = db.Surveys.SingleOrDefault(m => m.Pid == id);
            var demographics = db.Demographics.SingleOrDefault(m => m.Id == id);
            if (answers == null)
            {
                return new HttpNotFoundResult();
            }

            db.ReachedTheEnd.Add(new ReachedTheEnd() { UserId = id });
            db.SaveChanges();

            return View();
        }
    }
}