﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLB_REST.Models
{
	public class JsonModel
	{
		public List<AlbumThumbModel> Albums { get; set; }
		public double Pages { get; set; } = 0;

    }
}
