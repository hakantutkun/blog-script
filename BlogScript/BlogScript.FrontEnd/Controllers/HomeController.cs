using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogScript.FrontEnd.ApiServices.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogScript.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogApiService _blogApiService;

        public HomeController(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _blogApiService.GetAllAsync());
        }

        public IActionResult BlogDetail(int id)
        {
            return View();
        }
    }
}