using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeekPlanner.Models;

namespace WeekPlanner.Data
{
	public class WeekPlannerContext : DbContext
	{
		public DbSet<Week> Weeks { get; set; }
		public DbSet<Day> Days { get; set; }
		public DbSet<TimeSlot> TimeSlots { get; set; }
		public DbSet<Activity> Activities { get; set; }
		public DbSet<Restriction> Restrictions { get; set; }
	}
}