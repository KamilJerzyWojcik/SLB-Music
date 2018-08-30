﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SLB_REST.Models
{
	public class AlbumThumbModel
	{
		public int ID { get; set; }

		[ForeignKey("UserID")]
		public UserModel User { get; set; }

		[ForeignKey("AlbumID")]
		public AlbumModel Album { get; set; }

		public string ImageThumbSrc { get; set; }
		public string Title { get; set; }
		public string ArtistName { get; set; }
		public string Style { get; set; }
		public string Genres { get; set; }
	}
}
