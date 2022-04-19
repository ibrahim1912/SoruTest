using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using SoruTest.Business.Abstract;
using SoruTest.Entities.Concrete;
using WebApplication1.Models;

namespace ExamProjectCore.WebUI.Controllers
{
    public class ExamController : Controller
    {
        private IExamService _examService;
        private IQuestionService _questionService;
        private IOptionService _optionService;
        private ICorrectAnswerService _correctAnswer;
        public ExamController(IExamService examService, IQuestionService questionService, IOptionService optionsService, ICorrectAnswerService correctAnswer)
        {
            _examService = examService;
            _questionService = questionService;
            _optionService = optionsService;
            _correctAnswer = correctAnswer;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateExam()
        {
            //if (Session["admin"] == null)
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            //else
            //{
            int counter = 0;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string link = "http://wired.com/most-popular/";
            Uri url = new Uri(link);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            //*[@id="app-root"]/div/div[3]/div
            //*[@id="app-root"]/div/div[3]/div/div/div/ul
            var secilenhtml = @"//*[@id='app-root']/div/div[3]/div/div/div/ul";  

            List <String> basliklar = new List<string>();  
            List<String> linkler = new List<string>();  
            List<String> metinler = new List<string>();  

            var secilenHtmlList = document.DocumentNode.SelectNodes(secilenhtml);  

            foreach (var items in secilenHtmlList)
            {
                foreach (var innerItem in items.SelectNodes("li")) 
                {
                   
                        metinler.Add(innerItem.SelectNodes("a")[0].Attributes["href"].Value);
                        counter++;
                    
                   

                    basliklar.Add(innerItem.SelectNodes("div//a//h2")[0].InnerHtml);
                    if (counter >= 5)
                        break;
                }
            }

            ViewBag.Basliklar = basliklar; 
            ViewBag.Metinler = metinler;
            return View();
            //}
        }

        public string getData(string eklink)
        {
            string link =  eklink;  
            Uri url = new Uri(link); 
            WebClient client = new WebClient(); 
            client.Encoding = Encoding.UTF8; 
            string html = client.DownloadString(url); 
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); 
            document.LoadHtml(html);

            // var secilenhtml = @"//*[@id=""app-root""]/div/div[3]/div/div[3]/div[1]/div[2]/main/article/div[1]"; 
            StringBuilder metin = new StringBuilder();
            HtmlNodeCollection secilenHtmlList = document.DocumentNode.SelectNodes("//*[@id='main-content']/article/div[2]/div[1]/div[1]/div/div[1]"); 
            foreach (var items in secilenHtmlList)
            {
                foreach (var innerItem in items.SelectNodes("p")) 
                {

                    metin.Append(innerItem.InnerHtml);  

                }
            }
            return metin.ToString();
        }

        [HttpPost]
        public JsonResult CreateExam(string[] questiones, string[] choices, string[] correctAnswers, string header, string text)
        {

            if (questiones != null && choices != null && correctAnswers != null && header != null)
            {
                Exam ex = new Exam();
                ex.Title = header;
                ex.Content = text;
                _examService.Add(ex);
                var exID = ex.Id; //sınav id
                int a = 0;
                int b = 6;
                int k = 0;

                foreach (var item in questiones)
                {
                    Question q = new Question();
                    q.Content = item;
                    q.Number = 1;
                    q.ExamId = exID; //soruya sınavId atılıyor
                    _questionService.Add(q);
                    var questionID = q.Id; //soruId bir değişkende tutuluyor
                    for (int i = a; i <= b; i += 2)
                    {
                        Option op = new Option();
                        op.Content = choices[i];
                        op.Name = choices[i + 1];
                        op.CorrectOption = true;
                        op.QuestionId = questionID; //cevaba soruId atılıyor
                        _optionService.Add(op);
                        var opId = op.Id;


                        if (op.Name == correctAnswers[k])
                        {
                            CorrectAnswer correct = new CorrectAnswer();
                            correct.Correct = correctAnswers[k];
                            correct.OptionId = opId;
                            _correctAnswer.Add(correct);
                        }
                    }
                    k++;
                    a += 8;
                    b += 8;

                }
                return Json(new { result = 1, message = "Succes." });

            }

            else
            {

                return Json(new { result = 0, message = "Failed." });
            }


        }

        //Sınav Listeleme 
        public IActionResult ExamList()
        {

            var exList = _examService.GetAll().ToList();
            return View(exList);
        }

        //Sınav Silme
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public JsonResult DeleteExam(int id)
        {
            if (id != 0)
            {
                var findExam = _examService.GetById(id);
                _examService.Delete(findExam);
                var findQuestionList = _questionService.GetAll().Where(x => x.ExamId == id).ToList();
                foreach (var question in findQuestionList)
                {
                    int QuestionId = question.Id;
                    _questionService.Delete(question);
                    var findOptionList = _optionService.GetAll().Where(x => x.QuestionId == QuestionId).ToList();
                    foreach (var op in findOptionList)
                    {
                        int opId = op.Id;
                        _optionService.Delete(op);
                        var findCorrectList = _correctAnswer.GetAll().Where(x => x.OptionId == opId).ToList();
                        foreach (var correct in findCorrectList)
                        {
                            _correctAnswer.Delete(correct);
                        }
                    }

                }
                return Json(true);

            }
            else
            {
                return Json(false);
            }
        }



        //------------------------------Sınava girme ve sınavı tamamlama alanları--------------------------------------------
        //Sınava girme get action'ı
        public ActionResult EnterExam(int id)
        {
            if (id != 0)
            {
                EnterExamClass modal = new EnterExamClass();
                var findExam = _examService.GetById(id);
                modal.exam = findExam;
                var findQuestionList = _questionService.GetAll().Where(x => x.ExamId == id).ToList();
                modal.questions = findQuestionList;
                List<Option> opList = new List<Option>();


                foreach (var question in findQuestionList)
                {
                    int QuestionId = question.Id;
                    var findOptionList = _optionService.GetAll().Where(x => x.QuestionId == QuestionId).ToList();
                    foreach (var option in findOptionList)
                    {
                        opList.Add(option);
                    }
                }
                modal.options = opList;

                return View(modal);
            }
            else
            {
                var exList = _examService.GetAll();
                return RedirectToAction("ExamList", exList);
            }

        }

        //Sınavı tamamlama post action'ı
        [HttpPost]
        public JsonResult EnterExam(int examId, string[] correctAnswers)
        {
            if (examId != 0 && correctAnswers != null)
            {
                var findExam = _examService.GetById(examId);
                var findQuestionList = _questionService.GetAll().Where(x => x.ExamId == examId).ToList();
                int c = 0;
                List<string> bgList = new List<string>();

                foreach (var question in findQuestionList)
                {
                    var findOptionList = _optionService.GetAll().Where(x => x.QuestionId == question.Id).ToList();
                    foreach (var option in findOptionList)
                    {
                        var correct = _correctAnswer.GetAll().Where(x => x.OptionId == option.Id).FirstOrDefault();
                        if (correct != null)
                        {
                            if (correct.Correct == correctAnswers[c])
                            {
                                bgList.Add("green");
                                //Gönderilen cevapla veri tabanındaki cevap dogru(karsılaştırma)

                            }
                            else
                            {
                                bgList.Add("red");
                                //yanlissa

                            }
                        }

                    }
                    c++;
                }

                return Json(new { success = bgList });
            }
            else
            {
                return Json(new { });
            }
        }

    }
}