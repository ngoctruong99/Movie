using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EstateWeb.Models;
using EstateWeb.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EstateWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly EstateWebDbContext _estaweb;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(EstateWebDbContext estaweb)
        {
            _estaweb = estaweb;
        }


        public IActionResult Index()
        {
            //ViewBag.OptionProvince = new SelectList(_estaweb.Provinces.ToList(),"Id","Name");
            return View();
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

        //public JsonResult GetDistrict(int provinceId)
        //{
        //    var lstDisctrict = _estaweb.Districts.Where(objDis => objDis.ProvinceId == provinceId).ToList();

        //    return Json(new SelectList(lstDisctrict, "Id", "Name"));
        //}

        //public JsonResult GetStreet(int streetId)
        //{
        //    var lstStreet = _estaweb.Streets.Where(x => x.DistrictId == streetId).ToList();

        //    return Json(new SelectList(lstStreet, "Id", "Name"));
        //}

        //public JsonResult GetWard(int wardId)
        //{
        //    var lstWard = _estaweb.Wards.Where(a => a.DistrictId == wardId).ToList();

        //    return Json(new SelectList(lstWard, "Id", "Name"));
        //}

        //public JsonResult GetProject(int projectID)
        //{
        //    var lstProject = _estaweb.Projects.Where(a => a.DistrictId == projectID).ToList();

        //    return Json(new SelectList(lstProject, "Id", "Name"));
        //}

        //public IActionResult InputNews(Info objNews)
        //{
        //    //string mes = "";

        //    //var optionsBuilder = new DbContextOptionsBuilder<EstateWebDbContext>();

        //    //_estaweb.News.Add(objNews);
        //    //_estaweb.SaveChanges();

        //    //return Content(mes);
        //}
    }
}
