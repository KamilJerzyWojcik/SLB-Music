using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLB_REST.Models
{
	public class AlbumThumbModel
	{
		public int Id { get; set; }
		public string ImageThumbSrc { get; set; }
		public string Title { get; set; }
		public string ArtistName { get; set; }
		public string Style { get; set; }
		public string Genres { get; set; }

		public AlbumThumbModel(int id, string imageThumbSrc, string title, string artistName, string style, string genres)
		{
			ImageThumbSrc = imageThumbSrc;
			Title = title;
			ArtistName = artistName;
			Style = style;
			Genres = genres;
			Id = id;
		}
	}
}
