using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CosmeticDashboard.DataContext;
using CosmeticDashboard.Models;
using CosmeticDashboard.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CosmeticDashboard.Controllers
{
    public class AccountController : Controller
    {
        private readonly AspnetNoteDbContext _db;

        public AccountController(AspnetNoteDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                

                // Linq 사용
                // => 람다식 ; A Go to B
                // == -> 사용자제
                //await _db.Users.FirstOrDefaultAsync(u => u.UserId == model.UserId && u.UserPassword == model.UserPassword);

                var user = await _db.Users
                    .FirstOrDefaultAsync(u => u.UserId.Equals(model.UserId) &&
                                                                   u.UserPassword.Equals(model.UserPassword));

                //회원가입 아이디 중복체크 시에 사용한다
                //악의적인 방법을 막기위해
                //var user = await _db.Users.FirstOrDefaultAsync(u => u.UserId.Equals(model.UserId));

                if (user != null)
                {
                    
                    // key 값과 value값을 필요로 한다
                    HttpContext.Session.SetInt32("USER_LOGIN_KEY",  user.UserNo);
                    HttpContext.Session.SetString("USER_LOGIN_ID", user.UserId);
                    HttpContext.Session.SetString("USER_LOGIN_NAME", user.UserName);
                    //로그인에 성공했을 때
                    return RedirectToAction("Index", "Home");
                    
                }

                TempData["LoginFailure"] = "로그인실패";
                RequestHeaders header = Request.GetTypedHeaders();
                return new PartialViewResult();
                //return View(model);
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            HttpContext.Session.Remove("USER_LOGIN_ID");
            HttpContext.Session.Remove("USER_LOGIN_NAME"); // 해당 키값 세션만 클리어
                                                          // HttpContext.Session.Clear(); //서버에 존재하는 모든 세션을 클리어 함

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 회원 가입 전송
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                await _db.Users.AddAsync(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

     
        public async Task<PartialViewResult> LoginFailure()
        {

            return PartialView();
        }
    }
}
