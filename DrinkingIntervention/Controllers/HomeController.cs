using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrinkingIntervention.Models;

namespace DrinkingIntervention.Controllers
{
    public class HomeController : Controller
    {
        private DbModel db = new DbModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consent()
        {
            return View();
        }

        public ActionResult Demographics()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Demographics(Demographics model)
        {
            model.Timestamp = DateTime.Now;

            if (model.Email != null && db.Demographics.Count(m => m.Email == model.Email) != 0)
            {
                ViewBag.emailError = 1;
                ViewBag.email = model.Email;
                ModelState.AddModelError("email", "Email already exists");
            }

            if (ModelState.IsValid)
            {
                db.Demographics.Add(model);
                db.SaveChanges();
                return RedirectToAction("survey", new { id = model.Id });
            }

            return View(model);
        }

        public ActionResult Survey(int id)
        {
            if (db.Demographics.Count(m => m.Id == id) == 0)
            {
                Response.Redirect("~/");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Survey(Survey model, int id)
        { 

            model.Timestamp = DateTime.Now;
            if (ModelState.IsValid)
            {
                model.Pid = id;

                var existing = db.Surveys.SingleOrDefault(m => m.Pid == id);
                if (existing != null)
                {
                    db.Surveys.Remove(existing);
                }

                db.Surveys.Add(model);
                db.SaveChanges();
                return RedirectToAction("additional", new { id = id });

            }
            return View(model);
        }

        public ActionResult Additional(int id)
        {
            if (db.Demographics.Count(m => m.Id == id) == 0)
            {
                Response.Redirect("~/");
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Additional(Additional model, int id)
        {
            model.Timestamp = DateTime.Now;
            if (ModelState.IsValid)
            {
                model.Pid = id;

                var existing = db.Additionals.SingleOrDefault(m => m.Pid == id);
                if (existing != null)
                {
                    db.Additionals.Remove(existing);
                }

                db.Additionals.Add(model);
                db.SaveChanges();
                return RedirectToAction("phone", new { id = id });

            }
            return View(model);
        }

        public ActionResult Phone(int id)
        {
            if (db.Demographics.Count(m => m.Id == id) == 0)
            {
                Response.Redirect("~/");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Phone(Phone model, int id)
        {
            if (!string.IsNullOrEmpty(model.PhoneNumber) && db.PhoneNumbers.Count(m => m.PhoneNumber == model.PhoneNumber) != 0)
            {
                ViewBag.phoneError = 1;
                ViewBag.phone = model.PhoneNumber;
                ModelState.AddModelError("phoneNumber", "Phone number already exists");
            }

            var gender = db.Demographics.Single(m => m.Id == id).Gender;

            if (gender == "male")
            {
                int group1 = db.PhoneNumbers.Count(m => m.Group == 1);
                int group2 = db.PhoneNumbers.Count(m => m.Group == 2);
                int group3 = db.PhoneNumbers.Count(m => m.Group == 3);

                if (group1 > group2)
                {
                    model.Group = 2;
                }
                else if (group2 > group3)
                {
                    model.Group = 3;
                }
                else
                {
                    model.Group = 1;
                }

            }
            else if (gender == "female")
            {
                int group4 = db.PhoneNumbers.Count(m => m.Group == 4);
                int group5 = db.PhoneNumbers.Count(m => m.Group == 5);
                int group6 = db.PhoneNumbers.Count(m => m.Group == 6);

                if (group4 > group5)
                {
                    model.Group = 5;
                }
                else if (group5 > group6)
                {
                    model.Group = 6;
                }
                else
                {
                    model.Group = 4;
                }
            }
                    

            model.Timestamp = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.PhoneNumber))
                {
                    model.Pid = id;

                    var existing = db.PhoneNumbers.SingleOrDefault(m => m.Pid == id);
                    if (existing != null)
                    {
                        db.PhoneNumbers.Remove(existing);
                    }

                    db.PhoneNumbers.Add(model);
                    db.SaveChanges();
                }

                if (model.Group == 3 || model.Group == 6)
                {
                    return RedirectToAction("Complete");
                }

                return RedirectToAction("Module1", "Module", new { id = id });
            }

            return View();
        }

        public ActionResult Complete()
        {
            return View();
        }
    }
}