using SharePointProviderHostedWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharePointProviderHostedWeb.ViewModels
{
    public class Results
    {
        public IEnumerable<Team> ResultsFromAPI { get; set; }
        public IEnumerable<Team> ResultsFromSharePoint { get; set; }

        public Results(){
            ResultsFromAPI = new List<Team>();
            ResultsFromSharePoint = new List<Team>();
        }
    }
}