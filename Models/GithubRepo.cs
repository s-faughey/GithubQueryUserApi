using System;

namespace TechnicalAssessmentTask.Models
{
    public class GithubRepo
    {
        public string name { get; set; }
        public string description { get; set; }
        public string html_url { get; set; }
        public string stargazers_url { get; set; }
        public int stargazers_count { get; set; }
    }
}