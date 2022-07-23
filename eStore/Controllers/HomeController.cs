using DataAccess.Models;
using DataAccess.Repository;
using eStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;

namespace eStore.Controllers
{
    public class HomeController : Controller
    {
        readonly IMemberRepository memberRepository = new MemberRepository();

        private readonly ILogger<HomeController> _logger;

        Member user = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult MemberPage()
        {
            var memberList = memberRepository.GetMembers();
            return View(memberList);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            try
            {
                if (email == null)
                {
                    ViewBag.Message1 = "Please input email";
                }
                else if (password == null)
                {
                    ViewBag.Message2 = "Please input password";
                }
                else
                {
                    bool checkAdminResult = memberRepository.Login(email, password);
                    if (checkAdminResult)
                    {
                        HttpContext.Session.SetInt32("MemberID", 0);
                        return RedirectToAction(nameof(MemberPage), "Member");
                    }
                    else
                    {
                        bool check = memberRepository.Login(email, password);
                        if (check)
                        {
                             HttpContext.Session.SetInt32("MemberID", user.MemberId);
                            return RedirectToAction(nameof(Login), "Member");
                        }
                        else
                        {
                            ViewBag.Message3 = "Wrong email or password";
                            

                        }

                    }
                }
                ViewBag.Email = email;
                ViewBag.Password = password;
                return View(nameof(Login));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(nameof(Error));
            }
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
