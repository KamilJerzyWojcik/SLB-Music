using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLB_REST.Models
{
	public class AlbumModel
	{
		public string Title { get; set; }
		public ICollection<ArtistModel> Artists { get; set; }
		public ICollection<string> Genres { get; set; }
		public ICollection<VideoModel> Videos { get; set; }
		public ICollection<TrackModel> Tracks { get; set; }
		public ICollection<ExtraArtistModel> Extraartists { get; set; }
		public ICollection<ImagesModel> Images { get; set; }
	}
}
