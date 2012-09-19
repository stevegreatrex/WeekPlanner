using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeekPlanner.Models
{
	public class Week
	{
		public Week()
		{
			this.Days = new List<Day>();
		}

		public Guid Id { get; set; }

		public DateTime StartDate { get; set; }

		public IList<Day> Days { get; set; }
	}
}