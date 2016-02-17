﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fintechmonitor.Domain;
using Fintechmonitor.Services;
using Fintechmonitor.Web.Models;

namespace Fintechmonitor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyService _companyService;

        public HomeController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(int companyId)
        {
            var company = _companyService.Company(companyId);

            return View(ToCompanyViewModel(company));
        }

        private CompanyViewModel ToCompanyViewModel(Company company)
        {
            return new CompanyViewModel
            {
                Id = company.Id,
                Name = company.Name,
                AboutUs = company.AboutUs
            };
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}