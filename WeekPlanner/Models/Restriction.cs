using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeekPlanner.Models
{
	public class Restriction
	{
		public Guid Id { get; set; }
		
		public string Name { get; set; }

		public string Color { get; set; }
	}
}