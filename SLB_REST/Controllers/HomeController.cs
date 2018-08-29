using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SLB_REST.Models;


namespace SLB_REST.Controllers
{
    [Authorize]
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

		public IActionResult MyAlbums(int page = 0)
		{
			JsonModel json = new JsonModel();
			var albums = new List<AlbumThumbModel>() { 
				new AlbumThumbModel(
				1,
				"https://img.discogs.com/XGltkSWapnuUT3Ksk2USD0DwKzw=/fit-in/150x150/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-226430-1332181744.jpeg.jpg",
				"2Pac - All Eyez On Me",
				"2Pac",
				"Gangsta",
				"Hip Hop"
				),
				new AlbumThumbModel(
				2,
				"https://img.discogs.com/XGltkSWapnuUT3Ksk2USD0DwKzw=/fit-in/150x150/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-226430-1332181744.jpeg.jpg",
				"2Pac - All Eyez On Me2",
				"2Pac",
				"Gangsta",
				"Hip Hop"
				),
				new AlbumThumbModel(
				3,
				"https://img.discogs.com/XGltkSWapnuUT3Ksk2USD0DwKzw=/fit-in/150x150/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-226430-1332181744.jpeg.jpg",
				"2Pac - All Eyez On Me3",
				"2Pac",
				"Gangsta",
				"Hip Hop"
				),
				new AlbumThumbModel(
				4,
				"https://img.discogs.com/XGltkSWapnuUT3Ksk2USD0DwKzw=/fit-in/150x150/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-226430-1332181744.jpeg.jpg",
				"2Pac - All Eyez On Me4",
				"2Pac",
				"Gangsta",
				"Hip Hop"
				),
				new AlbumThumbModel(
				5,
				"https://img.discogs.com/XGltkSWapnuUT3Ksk2USD0DwKzw=/fit-in/150x150/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-226430-1332181744.jpeg.jpg",
				"2Pac - All Eyez On Me5",
				"2Pac",
				"Gangsta",
				"Hip Hop"
				),
				new AlbumThumbModel(
				6,
				"https://img.discogs.com/XGltkSWapnuUT3Ksk2USD0DwKzw=/fit-in/150x150/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-226430-1332181744.jpeg.jpg",
				"2Pac - All Eyez On Me6",
				"2Pac",
				"Gangsta",
				"Hip Hop"
				),
				new AlbumThumbModel(
				7,
				"https://img.discogs.com/XGltkSWapnuUT3Ksk2USD0DwKzw=/fit-in/150x150/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-226430-1332181744.jpeg.jpg",
				"2Pac - All Eyez On Me7",
				"2Pac",
				"Gangsta",
				"Hip Hop"
				),
				new AlbumThumbModel(
				8,
				"https://img.discogs.com/XGltkSWapnuUT3Ksk2USD0DwKzw=/fit-in/150x150/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-226430-1332181744.jpeg.jpg",
				"2Pac - All Eyez On Me",
				"2Pac",
				"Gangsta",
				"Hip Hop"
				),
				new AlbumThumbModel(
				9,
				"https://img.discogs.com/XGltkSWapnuUT3Ksk2USD0DwKzw=/fit-in/150x150/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-226430-1332181744.jpeg.jpg",
				"2Pac - All Eyez On Me8",
				"2Pac",
				"Gangsta",
				"Hip Hop"
				)
			};

			json.Pages = albums.Count;
			json.Pages = Math.Ceiling(json.Pages / 3.0);

			json.Albums = albums.Skip(page * 3).Take(3).ToList();

			return Json(json);
		}

		public IActionResult GetMyAlbum(int id)
		{
			return Content(id.ToString());
		}
	}
}
