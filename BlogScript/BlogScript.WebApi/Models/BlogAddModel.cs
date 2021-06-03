using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogScript.WebApi.Models
{
    public class BlogAddModel
    {
        /// <summary>
        /// IFormFile interface netcore a ozgu oldugu icin BlogAddDTO olarak degil BlogAddModel olarak olusturduk.
        /// </summary>
        /// 
        public int AppUserId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
