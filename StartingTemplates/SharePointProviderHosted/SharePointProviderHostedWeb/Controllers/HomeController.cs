using Microsoft.SharePoint.Client;
using SharePointProviderHostedWeb.Helpers;
using SharePointProviderHostedWeb.Models;
using SharePointProviderHostedWeb.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SharePointProviderHostedWeb.Controllers
{
    public class HomeController : Controller
    {
        [SharePointContextFilter]
        public ActionResult Index()
        {
            var requestClient = new HttpRequestClient();

            var resultsFromApi = requestClient.GetFixtureTable();

            //Write your sharepoint code here

            var model = new Results()
            {
                ResultsFromAPI = resultsFromApi,
            };

            return View(model);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
