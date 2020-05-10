

using System.Linq;
using HtmlAgilityPack;
using System;
using System.Text;
using System.Web;
using EstateWeb.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Crawler
{
    class Program
    {
        private static EstateWebDbContext _context;
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EstateWebDbContext>();
            optionsBuilder.UseSqlServer("Server=NGOCHAHA; Database= EstateDb; Integrated Security=true;");
            _context = new EstateWebDbContext(optionsBuilder.Options);
            GetDataProvince();
            //GetDataDistrict();
            //GetMultiData();


        }

        static void GetDataProvince()
        {
            string link = "https://alonhadat.com.vn/dang-tin-nha-dat.html";
            HtmlWeb htmlWeb = new HtmlWeb();
            {
            };

            HtmlDocument document = htmlWeb.Load(link);
            var selectboxProvince = document.GetElementbyId("ctl00_content_tinh").ChildNodes;

            List<Province> lstProvince = new List<Province>();
            foreach (var item in selectboxProvince)
            {
                if (item.Name == "option" && item.Attributes["value"].Value != "0")
                {
                    lstProvince.Add(new Province
                    {
                        Id = int.Parse(item.Attributes["value"].Value),
                        Name = HttpUtility.HtmlDecode(item.InnerText)
                    });

                    Console.WriteLine(item.Attributes["value"].Value);
                    Console.WriteLine(HttpUtility.HtmlDecode(item.InnerText));
                }
            }


            var optionsBuilder = new DbContextOptionsBuilder<EstateWebDbContext>();
            optionsBuilder.UseSqlServer("Server=NGOCHAHA; Database= Movie; Integrated Security=true;");
            var _context = new EstateWebDbContext(optionsBuilder.Options);

            _context.Provinces.AddRange(lstProvince);
            _context.SaveChanges();
            GetDataDistrict();
            Console.ReadKey();
        }

        static void GetDataDistrict()
        {
            string link = "https://alonhadat.com.vn/handler/Handler.ashx?command=2&matinh=";
            List<District> lstDistrict = new List<District>();
            var lstProvince = _context.Provinces.ToList();


            HtmlWeb htmlWeb = new HtmlWeb();
            {
            };

            foreach (var pro in lstProvince)
            {
                Console.WriteLine("Crawling: " + pro.Name);
                HtmlDocument document = htmlWeb.Load(link + pro.Id);

                foreach (var item in document.DocumentNode.ChildNodes)
                {
                    if (item.Name == "option" && item.Attributes["value"].Value != "0")
                    {
                        lstDistrict.Add(new District
                        {
                            Id = int.Parse(item.Attributes["value"].Value),
                            Name = HttpUtility.HtmlDecode(item.InnerText),
                            ProvinceId = pro.Id
                        });

                    }
                }
            }


            Console.WriteLine("Insert data to db");

            _context.Districts.AddRange(lstDistrict);
            _context.SaveChanges();

            GetMultiData();
            Console.ReadKey();
        }

        static void GetMultiData()
        {
            var lstDistrict = _context.Districts.ToList();

            List<Ward> lstWard = new List<Ward>();
            List<Street> lstStreet = new List<Street>();

            foreach (var dis in lstDistrict)
            {
                GetDataWard(dis, lstWard);
                GetDataStreet(dis, lstStreet);

            }
            _context.Wards.AddRange(lstWard.Distinct());
            _context.Streets.AddRange(lstStreet);
            _context.SaveChanges();
        }

        static void GetDataWard(District dis, List<Ward> lst)
        {
            string link = "https://alonhadat.com.vn/handler/Handler.ashx?command=3&mahuyen=";
            HtmlWeb htmlWeb = new HtmlWeb();
            {
            };

            Console.WriteLine("Crawling Ward of : " + dis.Name);
            HtmlDocument document = htmlWeb.Load(link + dis.Id);

            foreach (var item in document.DocumentNode.ChildNodes)
            {
                if (item.Name == "option" && item.Attributes["value"].Value != "" && item.Attributes["value"].Value != "0")
                {
                    lst.Add(new Ward
                    {
                        Id = int.Parse(item.Attributes["value"].Value),
                        Name = HttpUtility.HtmlDecode(item.InnerText),
                        DistrictId = dis.Id,
                        District = null
                    });

                }
            }
        }

        static void GetDataStreet(District dis, List<Street> lst)
        {
            string link = "https://alonhadat.com.vn/handler/Handler.ashx?command=4&mahuyen=";
            HtmlWeb htmlWeb = new HtmlWeb();
            {
            };

            Console.WriteLine("Crawling Street of : " + dis.Name);
            HtmlDocument document = htmlWeb.Load(link + dis.Id);

            foreach (var item in document.DocumentNode.ChildNodes)
            {
                if (item.Name == "option" && item.Attributes["value"].Value != "" && item.Attributes["value"].Value != "0")
                {
                    lst.Add(new Street
                    {
                        Id = int.Parse(item.Attributes["value"].Value),
                        Name = HttpUtility.HtmlDecode(item.InnerText),
                        DistrictId = dis.Id
                    });

                }
            }
        }


      
    }
}
