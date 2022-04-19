using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoruTest.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private IExamService _examService;
        private IQuestionService _questionService;
        private IOptionService _optionService;
        private ICorrectAnswerService _correctAnswer;
        public HomeController(IExamService examService, IQuestionService questionService, IOptionService optionsService, ICorrectAnswerService correctAnswer)
        {
            _examService = examService;
            _questionService = questionService;
            _optionService = optionsService;
            _correctAnswer = correctAnswer;

        }
        public IActionResult Index()
        {
            //var html = @"https://www.wired.com/most-recent/";

            //HtmlWeb web = new HtmlWeb();

            //var htmlDoc = web.Load(html);

            //var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");
            //HtmlNodeCollection box = htmlDoc.DocumentNode.SelectNodes("//div/[@class='SummaryItemContent-gYA-Dbp bHOHql summary-item__content']");

            //Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);

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
    }
}
