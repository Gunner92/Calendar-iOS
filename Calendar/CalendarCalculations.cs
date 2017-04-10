using System;
using System.Collections.Generic;

namespace Calendar
{
	public class CalendarCalculations
	{
		public CalendarCalculations()
		{
		}

		public static List<DayStructure>  CalculateMonthDays(DateTime selectedDate, bool isForDateRange = false)
		{
			List<DayStructure> daysofMonth = new List<DayStructure>();
			int month = selectedDate.Month;
			int year = selectedDate.Year;
			var startofMonth = new DateTime(year, month, 1);
			var difrenceValue = DayOfWeek.Monday - startofMonth.DayOfWeek;
			startofMonth = startofMonth.AddDays(difrenceValue);
			DateTime tempDateTime = startofMonth;
			for (int i = 0; i < 42; i++)
			{
				var dayofMonth = new DayStructure();
				dayofMonth.Day = tempDateTime;
				if (!isForDateRange)
				{
					if (dayofMonth.Day.Day == selectedDate.Day && dayofMonth.Day.Month == selectedDate.Month)
					{
						dayofMonth.isSelected = true;
					}
					else
					{
						dayofMonth.isSelected = false;
					}
				}


				if (dayofMonth.Day.Month == selectedDate.Month)
				{
					dayofMonth.isSelectedMonth = true;
				}
				else
				{
					dayofMonth.isSelectedMonth = false;
				}

				if (dayofMonth.Day.DayOfWeek == DayOfWeek.Saturday || dayofMonth.Day.DayOfWeek == DayOfWeek.Sunday)
				{
					dayofMonth.isWeekend = true;
				}
				else
				{
					dayofMonth.isWeekend = false;
				}


				daysofMonth.Add(dayofMonth);
				tempDateTime = tempDateTime.AddDays(1);
			}

			return daysofMonth;
		}
	}
}
