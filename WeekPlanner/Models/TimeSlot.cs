using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeekPlanner.Models
{
	public class TimeSlot
	{
		public TimeSlot()
		{
			this.Restrictions = new List<Restriction>();
			this.Activities = new List<Activity>();
		}

		public Guid Id { get; set; }

		public DateTime StartTime { get; set; }

		public TimeSpan Duration { get; set; }

		public IList<Restriction> Restrictions { get; private set; }

		public IList<Activity> Activities { get; private set; }

		[Required]
		public Day Day { get; set; }

		
	}
}