using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinutoSeguros.Application.Interfaces;
using MinutoSeguros.Application.ViewModel;

namespace MinutoSeguros.WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BlogController : Controller
    {
        public IBlogAppService blogAppService;

        public BlogController(IBlogAppService appService)
        {
            blogAppService = appService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult getMainWords()
        {
            var blogViewModels = blogAppService.getMainWords();
            return Ok(blogViewModels);
        }

    }
}