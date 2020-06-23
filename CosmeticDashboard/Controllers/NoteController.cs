using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticDashboard.DataContext;
using CosmeticDashboard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CosmeticDashboard.Controllers
{
    public class NoteController : Controller
    {
        private readonly AspnetNoteDbContext _db;

        public NoteController(AspnetNoteDbContext db)
        {
            _db = db;
        }


        /// <summary>
        /// 게시판 리스트
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(int pageNumber=1)
        {
            RequestHeaders header = Request.GetTypedHeaders();

            if (HttpContext.Session.GetString("USER_LOGIN_ID") == null)
            {
                               
                return Redirect(header.Referer.ToString());
                
            }
            return View(await PaginatedList<Note>.CreateAsync(_db.Notes, pageNumber, 5));
           
        }

        /// <summary>
        /// 게시물 추가 페이지 이동
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Add()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Note note)
        {
            if (HttpContext.Session.GetString("USER_LOGIN_ID") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                await _db.Notes.AddAsync(note);

                if(await _db.SaveChangesAsync() > 0)
                {
                    return Redirect("Index");
                }

                ModelState.AddModelError(string.Empty, "게시물을 저장할 수 없습니다. ");
            }

            return View(note);
        }

        /// <summary>
        /// 게시물 보기
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ViewBoard(int id)
        {
            if (HttpContext.Session.GetString("USER_LOGIN_ID") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var CurrentUserID = HttpContext.Session.GetString("USER_LOGIN_ID");
            if (CurrentUserID.Equals(null))
            {
                return PartialView("NoRight");
            }
            Note note = await _db.Notes.FindAsync(id);

            if(note.User.UserId != CurrentUserID)
            {
                note.User.isEditable = false;
                await _db.SaveChangesAsync();
                return PartialView("NoRight");
            }
            note.User.isEditable = true;
            await _db.SaveChangesAsync();
            
            return View(note);
        }

        /// <summary>
        /// 게시물 보기
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewBoard(Note note)
        {
            
            return View(note);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Note note)
        {
            
            if (ModelState.IsValid)
            {
                var NoteFromDB = await _db.Notes.FindAsync(note.NoteNo);
                NoteFromDB.NoteTitle = note.NoteTitle;
                NoteFromDB.NoteContents = note.NoteContents;
                NoteFromDB.NoteDate = DateTime.Now.ToString("yyyy/MMMM/dd:hh:mm tt");

                await _db.SaveChangesAsync();

                return View(note);
            }
           
            return View();
        }

        /// <summary>
        /// 게시물 삭제
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Delete()
        {
            return View();
        }
    }
}
