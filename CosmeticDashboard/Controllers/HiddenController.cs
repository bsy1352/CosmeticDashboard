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
    public class HiddenController : Controller
    {
        private readonly AspnetNoteDbContext _db;

        public HiddenController(AspnetNoteDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = 0)]
        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                
                return View("LoginPage");
            }
            else
            {

                return RedirectToAction("Index", "Dashboard");
            }

            
        }

        
        [HttpPost]
        public async Task<IActionResult> LoginPage(LoginViewModel model)
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
                    HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);
                    //HttpContext.Session.SetString("USER_LOGIN_ID", user.UserId);
                    //HttpContext.Session.SetString("USER_LOGIN_NAME", user.UserName);
                    //로그인에 성공했을 때
                    return RedirectToAction("Index", "Dashboard");

                }
                ModelState.Clear();
                TempData["LoginFailure"] = "로그인 정보가 틀립니다. 다시 확인해 주세요.";
            }


            return View();
        }


        [HttpGet]
        public IActionResult Registration()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Regiform()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(LoginViewModel model)
        {

            return View();
        }



        public async Task<IActionResult> Logout()
        {
            //HttpContext.Session.Remove("USER_LOGIN_KEY");
            //HttpContext.Session.Remove("USER_LOGIN_ID");
            //HttpContext.Session.Remove("USER_LOGIN_NAME"); // 해당 키값 세션만 클리어
            HttpContext.Session.Clear(); //서버에 존재하는 모든 세션을 클리어 함

            return RedirectToAction("Index", "Home");
        }

        public IActionResult LoginFailure()
        {

            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> isDuplicated([FromBody]Test user)
        {
            DupResult dr = new DupResult();
            
            var userID = await _db.Users
                   .FirstOrDefaultAsync(u => u.UserId.Equals(user.ID));
            if(userID != null)
            {
                dr.isDup = 1;
                return Json(dr);
            }
            dr.isDup = 0;
            return Json(dr);
        }

       
    }
}
