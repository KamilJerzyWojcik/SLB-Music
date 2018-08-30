using Newtonsoft.Json.Linq;
using SLB_REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLB_REST.Helpers
{
	public class SourceManagerEF
	{
		private DiscogsClientModel discogsClient;
		private JObject _albumJSON;

		public SourceManagerEF()
		{
			discogsClient = new DiscogsClientModel();
			_albumJSON = null;
		}

		public SourceManagerEF Load(string link)
		{
			string result = discogsClient.SetLink(link).GetJsonByLink();
			_albumJSON = JObject.Parse(result);

			return this;
		}

		public AlbumModel GetAlbum()
		{
			if (_albumJSON == null) return null;

			try
			{
				AlbumModel album = new AlbumModel();
				album.Title = _albumJSON["title"].ToString();

				return album;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<ArtistModel> GetArtist()
		{
			if (_albumJSON == null) return null;

			try
			{
				List<ArtistModel> artists = new List<ArtistModel>();

				foreach (var a in _albumJSON["artists"])
				{
					artists.Add(new ArtistModel() { Name = a["name"].ToString() });
				}

				return artists;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<GenreModel> GetGenres()
		{
			if (_albumJSON == null) return null;

			try
			{
				List<GenreModel> genres = new List<GenreModel>();

				foreach (var g in _albumJSON["genres"])
				{
					GenreModel genre = new GenreModel() { Genre = g.ToString() };
					genres.Add(genre);
				}

				return genres;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<StyleModel> GetStyles()
		{
			if (_albumJSON == null) return null;

			try
			{
				List<StyleModel> styles = new List<StyleModel>();

				foreach (var s in _albumJSON["styles"])
				{
					StyleModel style = new StyleModel() { Style = s.ToString() };
					styles.Add(style);
				}

				return styles;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<VideoModel> GetVideos()
		{
			if (_albumJSON == null) return null;

			try
			{
				List<VideoModel> videos = new List<VideoModel>();
				foreach (var video in _albumJSON["videos"])
				{
					VideoModel videoModel = new VideoModel();
					videoModel.Description = video["description"].ToString();
					videoModel.Uri = video["uri"].ToString();

					videos.Add(videoModel);
				}
				return videos;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<TrackModel> GetTracks()
		{
			if (_albumJSON == null) return null;

			try
			{
				List<TrackModel> tracks = new List<TrackModel>();
				
				foreach (var track in _albumJSON["tracklist"])
				{
					TrackModel trackModel = new TrackModel();

					trackModel.Duration = track["duration"].ToString();
					trackModel.Position = track["position"].ToString();
					trackModel.Title = track["title"].ToString();

					trackModel.ExtraArtists = new List<ExtraArtistModel>();
					foreach (var a in track["extraartists"])
					{
						trackModel.ExtraArtists.Add(new ExtraArtistModel() { Name = a["name"].ToString() });
					}

					tracks.Add(trackModel);
				}

				return tracks;
			}
			catch (Exception)
			{
				return null;
			}
		}

		//public List<ExtraArtistModel> GetExtraArtists()
		//{
		//	if (_albumJSON == null) return null;

		//	try
		//	{
		//		List<ExtraArtistModel> extraArtists = new List<ExtraArtistModel>();
		//		foreach (var track in _albumJSON["tracklist"])
		//		{
		//			ExtraArtistModel extraArtist = new ExtraArtistModel();
		//			foreach (var a in track["extraartists"])
		//			{
		//				extraArtist.Name = a["name"].ToString();
		//				extraArtists.Add(extraArtist);
		//			}
		//		}

		//		return extraArtists;
		//	}
		//	catch (Exception)
		//	{
		//		return null;
		//	}
		//}

		public List<ImageModel> GetImages()
		{
			if (_albumJSON == null) return null;

			try
			{
				List<ImageModel> images = new List<ImageModel>();
				foreach (var image in _albumJSON["images"])
				{
					ImageModel imageModel = new ImageModel();
					imageModel.Uri = image["uri"].ToString();
					images.Add(imageModel);
				}

				return images;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public AlbumThumbModel GetAlbumThumb()
		{
			try
			{

				AlbumThumbModel albumThumb = new AlbumThumbModel();

				albumThumb.Title = GetAlbum().Title;
				albumThumb.Style = GetStyles()[0].Style;
				albumThumb.Genres = GetGenres()[0].Genre;
				albumThumb.ArtistName = GetArtist()[0].Name;
				albumThumb.ImageThumbSrc = GetImages()[0].Uri;
				return albumThumb;
			}
			catch (Exception)
			{
				return null;
			}
		}

	}
}