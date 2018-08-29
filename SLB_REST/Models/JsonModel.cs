using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLB_REST.Models
{
	public class JsonModel
	{
		public JsonModel(string[] name)
		{
			Name = name;
		}

		public string[] Name { get; private set; }


    }
}
