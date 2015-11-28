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


            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var clientContext = spContext.CreateUserClientContextForSPAppWeb())
            {
                List teamsList = clientContext.Web.Lists.GetByTitle("Teams");

                var itemCreateInfo = new ListItemCreationInformation();

                ListItem newTeam = null;

                //Here we store the results in a sharepoint List
                foreach (var team in resultsFromApi)
                {
                    newTeam = teamsList.AddItem(itemCreateInfo);
                    newTeam["Title"] = team.Name;
                    newTeam["Position"] = team.Position;
                    newTeam["Points"] = team.Points;
                    newTeam["Played"] = team.Played;

                    newTeam.Update();

                }
                clientContext.ExecuteQuery();

                //Here is an example of how to get the information from the list
                List list = clientContext.Web.Lists.GetByTitle("Teams");

                ListItemCollection listItems = list.GetItems(CamlQuery.CreateAllItemsQuery());

                clientContext.Load(listItems);
                clientContext.ExecuteQuery();

                var resultsFromSharepoint = listItems.Select(x => new Team()
                {
                    Name = x["Title"] + string.Empty,
                    Points = Convert.ToInt32(x["Points"]),
                    Played = Convert.ToInt32(x["Played"]),
                    Position = Convert.ToInt32(x["Position"])
                });


                var model = new Results()
                {
                    ResultsFromAPI = resultsFromApi,
                    ResultsFromSharePoint = resultsFromSharepoint
                };

                return View(model);
            }
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
