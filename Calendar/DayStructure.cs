using System;
namespace Calendar
{
	public class DayStructure
	{
		public DateTime Day { get; set; }
		public bool isSelected { get; set; }
		public bool isSelectedMonth { get; set; }
		public bool isWeekend { get; set; }
		public bool isWorkDay
		{
			get
			{
				if (isSelectedMonth && !isWeekend)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
	}
}
