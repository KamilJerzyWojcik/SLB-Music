using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SLB_REST.Models;


namespace SLB_REST.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Albums(string queryUser)
		{
			DiscogsClientModel discogsClient = new DiscogsClientModel();

			if (!string.IsNullOrEmpty(queryUser))
			{
				string[] query = queryUser.Split(","); //{ "All eyez on me" };

				string json = discogsClient.SetQuery(query).SearchJsonByQuery();

				return Content(json);
			}

			return Content("");
		}

		public IActionResult Links(string link)
		{
			DiscogsClientModel discogsClient = new DiscogsClientModel();
			string json = discogsClient.SetLink(link).GetJsonByLink();

			return Content(json);
		}
	}
}
