﻿using Microsoft.AspNetCore.Mvc;
using SendEmailTest.Models;
using System.Diagnostics;

namespace SendEmailTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Email _email;

        public HomeController(ILogger<HomeController> logger,Email email)
        {
            _logger = logger;
            _email = email;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Send()
        {
            EmailData emailData = new EmailData()
            {
                Sender = "rustemsh11@yandex.ru",
                Recipient = "Gafurovaguzel2001@mail.ru",
                Text = "I love you so",
                CompanyName = "rustemsh11@yandex.ru",
                Attachment = @"C:\Users\агроном\Desktop\test.docx"
            };
            
            _email.CreateEmail(emailData);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}