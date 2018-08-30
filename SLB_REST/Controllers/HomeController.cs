using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SLB_REST.Context;
using SLB_REST.Helpers;
using SLB_REST.Models;

namespace SLB_REST.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private UserManager<UserModel> _userManager { get; }
		private SignInManager<UserModel> _signInManager { get; }
		private RoleManager<IdentityRole<int>> _roleManager { get; }
		private readonly EFContext _context;
		private SourceManagerEF _sourceManagerEF;

		public HomeController(SourceManagerEF sourceManagerEF, EFContext context, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, RoleManager<IdentityRole<int>> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_context = context;
			_sourceManagerEF = sourceManagerEF;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Albums(string queryUser)
		{
			DiscogsClientModel discogsClient = new DiscogsClientModel();

			if (!string.IsNullOrEmpty(queryUser))
			{
				string[] query = queryUser.Split(",");

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

		public async Task<IActionResult> MyAlbums(int page = 0)
		{
			JsonModel json = new JsonModel();

			UserModel userAuth = await _userManager.GetUserAsync(User);

			json.Albums = _context.AlbumsThumb.Include(a => a.User).Include(a=>a.Album).Where(a => a.User.Id == userAuth.Id).Skip(page * 3).Take(3).ToList();
			json.Pages = json.Albums.Count;
			json.Pages = Math.Ceiling(json.Pages / 3.0);

			return Json(json);
		}

		[HttpPost]
		public async Task<IActionResult> GetMyAlbum(string link)
		{

			UserModel user = await _userManager.GetUserAsync(User);
			AlbumModel album = _sourceManagerEF.Load(link).GetAlbum();

			album.User = user;
			album.Tracks = _sourceManagerEF.GetTracks();
			album.Images = _sourceManagerEF.GetImages();
			album.Videos = _sourceManagerEF.GetVideos();
			album.Genres = _sourceManagerEF.GetGenres();
			album.Styles = _sourceManagerEF.GetStyles();
			album.Artists = _sourceManagerEF.GetArtist();
			AlbumThumbModel albumThumb = _sourceManagerEF.GetAlbumThumb();
			albumThumb.User = user;
			album.AlbumThumb = albumThumb;

			_context.Albums.Add(album);

			var result = _context.SaveChanges();

			return Ok();
		}

		public IActionResult GetAlbum(int id)
		{
			AlbumModel album = _context.Albums.Where(a => a.ID == id)
			.Include(a => a.Artists)
			.Include(a => a.Genres)
			.Include(a => a.Images)
			.Include(a => a.Styles)
			.Include(a=>a.Videos)
			.Include(a=>a.Tracks)
			.SingleOrDefault();

			return Json(album);
		}
	}
}
