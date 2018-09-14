﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidation.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {        
        public IActionResult Index() => View("MakeBooking", new Appointment { Date = DateTime.Now });

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            //if (string.IsNullOrEmpty(appt.ClientName))
            //{
            //    ModelState.AddModelError(nameof(appt.ClientName), "Please enter your name");
            //}
            //if (ModelState.GetValidationState("Date") == ModelValidationState.Valid && DateTime.Now > appt.Date)
            //{
            //    ModelState.AddModelError(nameof(appt.Date), "Please enter a date in the future");
            //}
            //if (!appt.TermsAccepted)
            //{
            //    ModelState.AddModelError(nameof(appt.TermsAccepted), "You must accept the terms");
            //}
            if (ModelState.GetValidationState(nameof(appt.Date)) == ModelValidationState.Valid
                && ModelState.GetValidationState(nameof(appt.ClientName)) == ModelValidationState.Valid
                && appt.ClientName.Equals("Joe", StringComparison.OrdinalIgnoreCase)
                && appt.Date.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("", "Joe cannot book appointments on Mondays");
            }
                if (ModelState.IsValid)
            {
                return View("Completed", appt);
            }
            else
            {
                return View();
            }
        }
        public JsonResult ValidateDate(string Date)
        {
            DateTime parsedDate;
            if (!DateTime.TryParse(Date, out parsedDate))
            {
                return Json("Please enter a valid date (mm/dd/yyyy)");
            }
            else if (DateTime.Now > parsedDate)
            {
                return Json("Please enter a date in the future");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
