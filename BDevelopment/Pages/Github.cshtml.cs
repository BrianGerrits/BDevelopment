using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GithubConverter;
using Newtonsoft.Json;
using System.Reflection;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RazorWebPagesApplication.Pages
{
    public class GithubModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task OnGet() { 
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Repository Reporter");

            var stringTask = client.GetStringAsync("https://api.github.com/users/BrianGerrits/repos");

            var msg = await stringTask;
            var data = GithubData.FromJson(msg);
            ViewData["data"] = data;

        }
    } //end class
}