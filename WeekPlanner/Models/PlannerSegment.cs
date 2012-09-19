using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeekPlanner.Models
{
	public class PlannerSegment
	{
		public PlannerSegment()
		{
			this.Restrictions = new List<Restriction>();
		}

		public Guid Id { get; set; }

		public DateTime Start { get; set; }

		public IList<Restriction> Restrictions { get; private set; }
	}
}