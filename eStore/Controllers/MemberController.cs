using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eStore.Controllers
{
    public class MemberController : Controller
    {
        readonly IMemberRepository memberRepository = null;

        public MemberController() => memberRepository = new MemberRepository();
        // GET: MemberController
        public ActionResult MemberPage()
        {

            var memberID = HttpContext.Session.GetInt32("MemberID");
            if (memberID != 0)
            {
                return RedirectToAction(nameof(DetailsMember));
            }
            var memberList = memberRepository.GetMembers();
            return View(memberList);
        }

        // GET: MemberController/Details/5
        public ActionResult DetailsMember(int? id)
        {
            var memberID = HttpContext.Session.GetInt32("MemberID");
            if (memberID != 0)
            {
                id = memberID;

            }
            if (id == null)
            {
                return NotFound();
            }
            var member = memberRepository.GetMember(id, null, null);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // GET: MemberController/Create
        public ActionResult CreateMember() => View();

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMember(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    memberRepository.InsertMember(member);
                }
                return RedirectToAction(nameof(MemberPage));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(member);
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult EditMember(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var member = memberRepository.GetMember(id, null, null);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMember(int memberId, Member member)
        {
            try
            {
                if (memberId != member.MemberId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    memberRepository.UpdateMember(member);
                }
                return RedirectToAction(nameof(MemberPage));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: MemberController/Delete/5
        public ActionResult DeleteMember(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var member = memberRepository.GetMember(id, null, null);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMember(int memberId)
        {
            try
            {
                memberRepository.DeleteMember(memberId);
                return RedirectToAction(nameof(MemberPage));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
