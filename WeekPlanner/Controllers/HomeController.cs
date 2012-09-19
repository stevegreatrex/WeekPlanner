using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeekPlanner.Data;
using WeekPlanner.Models;

namespace WeekPlanner.Controllers
{
    public class HomeController : Controller
    {
		private WeekPlannerContext _context = new WeekPlannerContext();

        //
        // GET: /Home/

        public ActionResult Index(DateTime? date = null)
        {
			date = date ?? DateTime.Today;
			var endOfWeek = StartOfWeek(date.Value).AddDays(7);
			var week = _context.Weeks.Include("Days.TimeSlots").Where(w => date > w.StartDate && w.StartDate < endOfWeek).FirstOrDefault();
			if (week == null)
			{
				week = CreateBlankWeek(date);
				_context.Weeks.Add(week);

				foreach (var day in week.Days)
				{
					_context.Days.Add(day);
					foreach (var timeslot in day.TimeSlots)
					{
						_context.TimeSlots.Add(timeslot);
					}
				}

				_context.SaveChanges();
			}
            return View(week);
        }

		private static Week CreateBlankWeek(DateTime? date)
		{
			var start = StartOfWeek(date.Value);
			var week = new Week
			{
				Id = Guid.NewGuid(),
				StartDate = start
			};

			for (int i = 0; i < 7; i++)
			{
				var day = start.AddDays(i).Date;

				week.Days.Add(new Day
				{
					Week = week,
					Id = Guid.NewGuid(),
					Date = day,
					TimeSlots =
					{
						new TimeSlot { Id = Guid.NewGuid(), StartTime = day.AddHours(6), Duration = TimeSpan.FromHours(3) },
						new TimeSlot { Id = Guid.NewGuid(), StartTime = day.AddHours(9), Duration = TimeSpan.FromHours(3) },
						new TimeSlot { Id = Guid.NewGuid(), StartTime = day.AddHours(12), Duration = TimeSpan.FromHours(3) },
						new TimeSlot { Id = Guid.NewGuid(), StartTime = day.AddHours(18), Duration = TimeSpan.FromHours(3) }
					}
				});
			}
			return week;
		}

		private static DateTime StartOfWeek(DateTime date)
		{
			while (date.Date.DayOfWeek != DayOfWeek.Monday)
				return date = date.Date.AddDays(-1);

			return date.Date;
		}
    }
}
