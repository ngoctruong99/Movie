using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstateWeb.Entities;
using EstateWeb.Models.RequestModels;
using EstateWeb.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EstateWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly EstateWebDbContext _movie;
        private int IdMovie;
        public MovieController(EstateWebDbContext movie)
        {
            _movie = movie;
        }



        public IActionResult Index()
        {
            var lst = _movie.Movies.Select(n => new IndexNewsModel
            {
                MovieId = n.MovieId,
                Title = n.Title,
                Category = n.Category,
                Premiere = n.Premiere,
                Duration = n.Duration,
                ImgUrl = n.ImgUrl,
            }).ToList();

            return View(lst);
        }
        public IActionResult Input()
        {
            return View();
        }
     
        public IActionResult Detail(int Id)
        {
            
            //    News objNew = _estaweb.News.Find(Id);
            //    return View("Detail", objNew);
            var obj = new IndexNewsModel();
            Movie objMovie = _movie.Movies.Find(Id);
            try
            {
                obj.MovieId = objMovie.MovieId;
                obj.Title = objMovie.Title;
                obj.Category = objMovie.Category;
                obj.Duration = objMovie.Duration;
                obj.Premiere = objMovie.Premiere;
                obj.Directors = objMovie.Directors;
                obj.Cast = objMovie.Cast;
                obj.Language = objMovie.Language;
                obj.Rated = objMovie.Rated;
                obj.ImgUrl = objMovie.ImgUrl;
            }
            catch { }
            return View("Detail", obj);
        }
        public IActionResult Book(int Id)
        {
            return View("Book");
        }

        //public JsonResult GetRoom(int CalendarMovieId)
        //{
        //    var lstSeat = _movie.Rooms.Where(objSeat => objSeat.CalendarMovieId == CalendarMovieId)
        //        .ToList();

        //    return Json(new SelectList(lstSeat, "RoomId", "RoomName"));
        //}
        public JsonResult GetStreet(int streetId)
        {
            var lstStreet = _movie.Streets.Where(x => x.DistrictId == streetId).ToList();

            return Json(new SelectList(lstStreet, "Id", "Name"));
        }

        public JsonResult GetWard(int wardId)
        {
            var lstWard = _movie.Wards.Where(a => a.DistrictId == wardId).ToList();

            return Json(new SelectList(lstWard, "Id", "Name"));
        }
        public JsonResult GetDistrict(int provinceId)
        {
            var lstDisctrict = _movie.Districts.Where(objDis => objDis.ProvinceId == provinceId).ToList();

            return Json(new SelectList(lstDisctrict, "Id", "Name"));
        }
        public JsonResult GetSeat(string RoomId)
        {
            var lstSeat = _movie.Seats.Where(objSeat => objSeat.RoomId == RoomId)
                .Where(objSeat => objSeat.Status == false).ToList();

            return Json(new SelectList(lstSeat, "SeatId", "SeatName"));
        }
        public JsonResult InputNews(InputNewsRequestModel objReq)
        {
            try
            {
                var obj = new Movie();
                obj.Title = objReq.Title;
                obj.Category = objReq.Category;
                obj.Duration = objReq.Duration; 
                obj.Premiere = objReq.Premiere;
                obj.Directors = objReq.Directors;
                obj.Cast = objReq.Cast;
                obj.Language = objReq.Language;
                obj.Rated = objReq.Rated;
                obj.ImgUrl = objReq.ImgUrl;
                
                _movie.Movies.Add(obj);

                _movie.SaveChanges();

           
                return Json(new { success = true, responseText = "Đăng tin thành công" });

            }
            catch (Exception e)
            {
                return Json(new { success = false, responseText = "Errô" });
            }
        }

        public JsonResult InputRoom(InputRoomRequetsModel objReq)
        {
                var obj = new Room();
                obj.RoomId = objReq.RoomId;
                obj.RoomType = objReq.RoomType;
                obj.TotalSeat = objReq.TotalSeat;
                _movie.Rooms.Add(obj);

                _movie.SaveChanges();
                _movie.Rooms.Find(obj.RoomId);


            for (int i = 1; i <= obj.TotalSeat; i++)
            {
                 var item = new Seat("a",false, objReq.RoomId);
                _movie.Seats.Add(item);
            }
            
            
            _movie.SaveChanges();


                return Json(new { success = true, responseText = "Đăng tin thành công" });

          
        }
    }
}