using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeekPlanner.Models
{
	public class Day
	{
		public Day()
		{
			this.TimeSlots = new List<TimeSlot>();
		}

		public Guid Id { get; set; }

		[Required]
		public Week Week { get; set; }

		public DateTime Date { get; set; }

		public IList<TimeSlot> TimeSlots { get; set; }
	}
}