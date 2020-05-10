using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstateWeb.Models.ResponseModels
{
    public class IndexNewsModel
    {
        public int MovieId;

        public string Title { get; set; }
        public string Category { get; set; }
        public int Duration { get; set; }
        public string Premiere { get; set; }
        public string Directors { get; set; }
        public string Cast { get; set; }
        public string Language { get; set; }
        public string Rated { get; set; }
        public string ImgUrl { get; set; }
    }
}

